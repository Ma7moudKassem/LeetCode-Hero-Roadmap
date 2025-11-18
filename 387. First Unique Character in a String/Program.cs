int FirstUniqChar(string s)
{
    int index = int.MaxValue;
    HashSet<char> set = [];
    for (int i = 0; i < s.Length; i++)
    {
        char c = s[i];
        if (set.Contains(c))
            continue;

        index = Math.Min(index, i);
        set.Add(c);
    }

    return index == int.MaxValue ? -1 : index;
}