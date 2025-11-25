Console.WriteLine(SmallestRepunitDivByK(3));

int SmallestRepunitDivByK(int k)
{
    if (k % 2 == 0 || k % 5 == 0)
        return -1;

    int rem = 0;
    for (int i = 1; i <= k; i++)
    {
        if ((rem * 10 + 1) % k == 0)
            return i;
    }

    return -1;
}