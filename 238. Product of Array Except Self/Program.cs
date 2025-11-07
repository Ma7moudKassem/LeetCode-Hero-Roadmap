var arr = ProductExceptSelf([1, 2, 3, 4]);

int[] ProductExceptSelf(int[] nums)
{
    int n = nums.Length;

    int[] prefixArray = new int[n];
    int[] suffixArray = new int[n];

    prefixArray[0] = 1;
    for (int i = 1; i < n; i++)
        prefixArray[i] = prefixArray[i - 1] * nums[i - 1];

    int suffix = 1;
    for (int i = n - 1; i >= 0; i--)
    {
        prefixArray[i] *= suffix;
        suffix *= nums[i];
    }

    return prefixArray;
}