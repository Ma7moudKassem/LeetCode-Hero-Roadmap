int SubarraysDivByK(int[] nums, int k)
{
    int n = nums.Length;

    int count = 0;  
    int prefix = 0;

    Dictionary<int, int> map = new() { { 0, -1 } };

    for (int i = 0; i < n; i++)
    {
        prefix += nums[i];

        int remainder = k == 0 ? prefix : prefix % k;
        if (remainder < 0)
            remainder += k;

        if (map.ContainsKey(remainder))
        {
            count += map[remainder];
            map[remainder]++;
        }
        else map[remainder] = 1;
    }

    return count;
}