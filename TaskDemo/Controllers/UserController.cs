

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using TaskDemo.Models;

namespace TaskDemo.Controllers
{
    public class UserController : Controller
    {
        private readonly string _connectionString;

        public UserController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        [HttpGet]
        public JsonResult SearchUsers(string search)
        {
            List<User_Master> users = new List<User_Master>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(@"
            SELECT U.*, E.EducationName
            FROM User_Master U
            LEFT JOIN Education_Master E ON U.EducationId = E.Id
            WHERE 
                U.FirstName LIKE @search OR 
                U.LastName LIKE @search OR 
                U.Email LIKE @search", connection);

                command.Parameters.AddWithValue("@search", "%" + search + "%");

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    users.Add(new User_Master
                    {
                        Id = (int)reader["Id"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        GenderId = reader["GenderId"].ToString(),
                        EducationName = reader["EducationName"].ToString()
                    });
                }
            }

            return Json(users);
        }
        // GET: User List
        public IActionResult UserList()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Login", "Auth");
            List<User_Master> users = new List<User_Master>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("PR_USERLIST", connection);
                command.CommandType = CommandType.StoredProcedure;

                DataTable dt = new DataTable();
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dt);
                }

                users = dt.AsEnumerable().Select(row => new User_Master
                {
                    Id = row.Field<int>("Id"),
                    FirstName = row.Field<string>("FirstName"),
                    LastName = row.Field<string>("LastName"),
                    Email = row.Field<string>("Email"),
                    GenderId = row.Field<string>("GenderId"),
                    EducationId = row.Field<int>("EducationId"),
                    EducationName = row.Field<string>("EducationName")
                }).ToList();
            }

            return View(users);
        }

        // POST: Delete user
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var currentUserId = HttpContext.Session.GetInt32("UserId");
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("PR_USERDELETE", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            }
            if (id == currentUserId)
            {
                HttpContext.Session.Clear(); // log out the user
                return RedirectToAction("Login", "Auth"); // redirect to login page
            }

            // Otherwise, redirect to user list for normal deletion
            return RedirectToAction("UserList");
        }
        // GET: Edit
        [HttpGet]
        public IActionResult Edit(int id)
        {
            User_Master user = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("PR_USERGETBYID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    user = new User_Master
                    {
                        Id = (int)reader["Id"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        GenderId = reader["GenderId"].ToString(),
                        EducationId = (int)reader["EducationId"],
                        Password = reader["Password"].ToString()
                    };
                }
            }

            if (user == null)
                return NotFound();

            ViewBag.EducationList = GetEducationList();
            return View(user);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(User_Master model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.EducationList = GetEducationList();
                return View(model);
            }

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("PR_USERUPDATE", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", model.Id);
                command.Parameters.AddWithValue("@FirstName", model.FirstName);
                command.Parameters.AddWithValue("@LastName", model.LastName);
                command.Parameters.AddWithValue("@Email", model.Email);
                command.Parameters.AddWithValue("@GenderId", model.GenderId ?? "");
                command.Parameters.AddWithValue("@EducationId", model.EducationId);
                command.Parameters.AddWithValue("@Password", model.Password);

                command.ExecuteNonQuery();
            }

            return RedirectToAction("UserList");
        }

        private List<SelectListItem> GetEducationList()
        {
            var list = new List<SelectListItem>();
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("SELECT Id, EducationName FROM Education_Master", connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new SelectListItem
                    {
                        Value = reader["Id"].ToString(),
                        Text = reader["EducationName"].ToString()
                    });
                }
            }
            return list;
        }

        // GET: Add User
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.EducationList = GetEducationList();
            return View();
        }

        // POST: Add User
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(User_Master model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.EducationList = GetEducationList();
                return View(model);
            }

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("PR_USERINSERT", connection);
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@FirstName", model.FirstName);
                command.Parameters.AddWithValue("@LastName", model.LastName);
                command.Parameters.AddWithValue("@Email", model.Email);
                command.Parameters.AddWithValue("@GenderId", model.GenderId ?? "");
                command.Parameters.AddWithValue("@EducationId", model.EducationId);
                command.Parameters.AddWithValue("@Password", model.Password);

                command.ExecuteNonQuery();
            }

            return RedirectToAction("UserList");
        }

        // GET: User Profile
        public IActionResult Profile()
        {
            var userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
                return RedirectToAction("Login", "Auth");

            User_Master user = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("PR_USERGETBYID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", userId.Value);

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    user = new User_Master
                    {
                        Id = (int)reader["Id"],
                        FirstName = reader["FirstName"].ToString(),
                        LastName = reader["LastName"].ToString(),
                        Email = reader["Email"].ToString(),
                        GenderId = reader["GenderId"].ToString(),
                        EducationId = (int)reader["EducationId"],
                        Password = reader["Password"].ToString()
                    };
                }
            }

            if (user == null)
                return NotFound();

            ViewBag.EducationList = GetEducationList();
            return View(user);
        }


    }
}