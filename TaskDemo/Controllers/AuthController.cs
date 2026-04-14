using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System.Data;
using TaskDemo.Models;

namespace TaskDemo.Controllers
{
    public class AuthController : Controller
    {
        private readonly string _connectionString;

        public AuthController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // GET: Register page
        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.EducationList = GetEducationList();
            return View();
        }

        // POST: Register user
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(User_Master model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.EducationList = GetEducationList();
                return View(model);
            }

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("PR_USERREGISTER", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
                cmd.Parameters.AddWithValue("@LastName", model.LastName);
                cmd.Parameters.AddWithValue("@Email", model.Email);
                cmd.Parameters.AddWithValue("@GenderId", model.GenderId ?? "");
                cmd.Parameters.AddWithValue("@EducationId", model.EducationId);
                cmd.Parameters.AddWithValue("@Password", model.Password);
                cmd.Parameters.AddWithValue("@IsDeleted", false);

                cmd.ExecuteNonQuery();
            }

            TempData["Success"] = "Registration successful! Please login.";
            return RedirectToAction("Login");
        }

        // GET: Login page
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Login user
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string email, string password)
        {
            User_Master user = null;

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("PR_USERLOGIN", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    user = new User_Master
                    {
                        Id = (int)reader["Id"],
                        FirstName = reader["FirstName"].ToString(),
                        Email = reader["Email"].ToString()
                    };
                }
            }

            if (user == null)
            {
                ViewBag.Error = "Invalid email or password";
                return View();
            }

            // Set session
            HttpContext.Session.SetInt32("UserId", user.Id);
            HttpContext.Session.SetString("UserName", user.FirstName);

            return RedirectToAction("UserList", "User");
        }

        // Logout user
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        // Helper: Get Education list for dropdown
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
    }
}