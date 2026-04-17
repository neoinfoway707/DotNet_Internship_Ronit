public class Solution {
    public bool IsMatch(string s, string p) {
        bool[,] mat = new bool[s.Length + 1, p.Length + 1];

        mat[0, 0] = true;

        for (int i = 1; i < mat.GetLength(1); i++) {
            if (p[i - 1] == '*') {
                mat[0, i] = mat[0, i - 2];
            }
        }

        for (int i = 1; i < mat.GetLength(0); i++) {
            for (int j = 1; j < mat.GetLength(1); j++) {
                if (p[j - 1] == '.' || p[j - 1] == s[i - 1]) {
                    mat[i, j] = mat[i - 1, j - 1];
                } else if (p[j - 1] == '*') {
                    mat[i, j] = mat[i, j - 2];
                    if (p[j - 2] == '.' || p[j - 2] == s[i - 1]) {
                        mat[i, j] = mat[i, j] || mat[i - 1, j];
                    }
                } else {
                    mat[i, j] = false;
                }
            }
        }

        return mat[s.Length, p.Length];
    }
}