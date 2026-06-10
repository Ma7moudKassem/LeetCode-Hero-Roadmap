

bool ContainsDuplicate(int[] nums)
{
    Dictionary<int, int> seen = [];

    foreach (int num in nums)
    {
        if(!seen.ContainsKey(num))
            seen[num] = 0;

        seen[num]++;

        if (seen[num] > 1)
            return true;
    }

    return false;
}