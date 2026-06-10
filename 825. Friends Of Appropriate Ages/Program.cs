
Console.WriteLine(NumFriendRequests([20,30,100,110,120]));

int NumFriendRequests(int[] ages)
{
    int count = 0;

    for (int i = 0; i < ages.Length; i++)
    {
        for (int j = 0; j < ages.Length; j++)
        {
            if (i == j)
                continue;

            if (CanSendRequest(ages[i], ages[j]))
                count++;
        }
    }

    return count;
}


bool CanSendRequest(int ageX, int ageY)
{
    if (ageY <= (0.5 * ageX + 7))
        return false;

    if (ageY > ageX)
        return false;

    if (ageY > 100 && ageX < 100)
        return false;

    return true;
}