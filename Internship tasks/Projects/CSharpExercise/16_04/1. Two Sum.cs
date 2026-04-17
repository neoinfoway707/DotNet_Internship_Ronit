public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        Dictionary<int, int> map = new Dictionary<int, int>();

for (int i = 0; i < nums.Length; i++)
{
            //target - nums[i] is the complement of nums[i] in the array, which we need to find
            int complement = target - nums[i];

    if (map.ContainsKey(complement))
    {
        return new int[] { map[complement], i };
    }

    map[nums[i]] = i;
}

return new int[] { };
    }
}