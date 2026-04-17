public class Solution {
    public string LongestCommonPrefix(string[] strs) {
        Array.Sort(strs);
        string s = "";
        int i = 0;
        int length = strs.Length;

        while (i < strs[0].Length) {
            if (strs[0][i] == strs[length - 1][i])
                s += strs[0][i];
            else
                break;
            i++;
        }

        return s;
    }
}