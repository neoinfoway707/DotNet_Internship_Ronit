public class Solution {
    public int MaxArea(int[] height) {
        int maxArea = 0;
        int i = 0, j = height.Length - 1;

        while (i < j) {
            int curWidth = j - i;
            int curHeight = Math.Min(height[i], height[j]);
            maxArea = Math.Max(maxArea, curWidth * curHeight);

            if (height[i] <= height[j]) {
                i++;
            } else {
                j--;
            }
        }
        return maxArea;
    }
}