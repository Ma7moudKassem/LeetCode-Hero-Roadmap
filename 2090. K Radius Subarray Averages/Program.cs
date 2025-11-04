var r = GetAverages([7, 4, 3, 9, 1, 8, 5, 2, 6], 3);

int[] GetAverages(int[] nums, int k)
{
    if(k == 0)
        return nums;

    int n = nums.Length;
    int[] result = new int[n];
    Array.Fill(result, -1);

    int windowSize = 2 * k + 1;
    if(n < windowSize)
        return result;

    long[] prefix = new long[nums.Length];
    prefix[0] = nums[0];

    for (int i = 1; i < nums.Length; i++)
        prefix[i] = nums[i] + prefix[i - 1];

    for (int i = k; i < n - k; i++)
    {
        int right = i + k;
        int left = i - k - 1;

        long total = prefix[right];
        if(left >= 0)
            total -= prefix[left];

        result[i] = (int)(total / windowSize);
    }

    return result;
}