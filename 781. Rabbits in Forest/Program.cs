int[] res = [0, 0, 1, 1, 1];

Console.WriteLine(NumRabbits(res));

int NumRabbits(int[] answers)
{
    Dictionary<int, int> map = [];
    foreach (int answer in answers)
    {
        if (!map.ContainsKey(answer))
            map[answer] = 0;

        map[answer]++;
    }

    int result = 0;
    foreach (var item in map)
    {
        int groupSize = item.Key + 1;

        int groups = (item.Value + item.Key) / groupSize;

        result += groups * groupSize;
    }

    return result;
}