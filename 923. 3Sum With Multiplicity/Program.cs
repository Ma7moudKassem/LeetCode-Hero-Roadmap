Console.WriteLine(ThreeSumMulti([1, 1, 2, 2, 3, 3, 4, 4, 5, 5], 8));

int ThreeSumMulti(int[] arr, int target)
{
    Array.Sort(arr);
    HashSet<int> set = [];

    long count = 0;
    for (int i = 0; i < arr.Length; i++)
    {
        int diff = target - arr[i];
        for(int j = i + 1; j < arr.Length; j++)
        {
            int complement = diff - arr[j];
            if (!set.Add(complement))
                count++;
        }
    }

    return (int)count % 1_000000_007;
}

(int,int,int) GetKey(int a, int b, int c)
{
    int[] arr = [a, b, c];
    Array.Sort(arr);
    return (arr[0], arr[1], arr[2]);
}