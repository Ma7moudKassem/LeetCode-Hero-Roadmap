Console.WriteLine(MaxScore([96, 90, 41, 82, 39, 74, 64, 50, 30], 8));

int MaxScore(int[] cardPoints, int k)
{
    if (k == 0)
        return 0;

    int n = cardPoints.Length;

    int window = 0;
    for (int i = 0; i < k; i++)
        window += cardPoints[i];

    int result = window;

    //Sliding window
    for (int i = 0; i < k; i++)
    {
        window -= cardPoints[k - i - 1];
        window += cardPoints[n - i - 1];
        
        result = Math.Max(result, window);
    }

    return result;
}