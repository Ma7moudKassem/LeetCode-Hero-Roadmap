Console.WriteLine(CheckSubarraySum([2, 4, 3], 6));

bool CheckSubarraySum(int[] nums, int k)
{
    int n = nums.Length;
    int prefix = 0;

    Dictionary<int, int> map = new() { { 0, -1 } };
    for (int i = 0; i < n; i++)
    {
        prefix += nums[i];

        int remainder = k == 0 ? prefix : prefix % k;

        if (map.ContainsKey(remainder))
        {
            if (i - map[remainder] > 1)
                return true;
        }
        else
            map.Add(remainder, i);
    }

    return false;
}