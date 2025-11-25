
Console.WriteLine(NumFriendRequests([16, 17, 18]));

int NumFriendRequests(int[] ages)
{
    HashSet<int> senders = [];
    HashSet<(int, int)> requests = [];

    int count = 1;
    for (int i = 0; i < ages.Length; i++)
    {
        if (!senders.Add(i))
            continue;

        for (int j = i + 1; j < ages.Length; j++)
        {
            int ageA = ages[i];
            int ageB = ages[j];

            if (!CanSendRequest(ageA, ageB) || !requests.Add((ageA, ageB)))
                continue;

            count++;
        }
    }

    return count;
}

bool CanSendRequest(int ageA, int ageB)
{
    if (ageB <= 0.5 * ageA + 7)
        return false;

    if (ageB > ageA)
        return false;

    if (ageB > 100 && ageA < 100)
        return false;

    return true;
}