

bool IsAnagram(string s, string t)
{
    if (s.Length != t.Length)
        return false;

    int[] seen = new int[26];

    for (int i = 0; i < s.Length; i++)
    {
        seen[s[i] - 'a']++;
        seen[t[i] - 'a']--;
    }

    for (int i = 0; i < 26; i++)
    {
        if (seen[i] != 0)
            return false;
    }

    return true;
}