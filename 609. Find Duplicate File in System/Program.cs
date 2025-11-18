using System.Linq;

string[] p = ["root/a 1.txt(abcd) 2.txt(efgh)", "root/c 3.txt(abcd)", "root/c/d 4.txt(efgh)", "root 4.txt(efgh)"];

var FindDuplicateResult = FindDuplicate(p);

Console.WriteLine();
IList<IList<string>> FindDuplicate(string[] paths)
{
    var normalizedContentPaths = NormalizeContentPaths(paths);

    List<IList<string>> result = [];

    foreach (var contentWithPath in normalizedContentPaths)
    {
        if (contentWithPath.Value.Count > 1)
            result.Add(contentWithPath.Value);
    }

    return result;
}

Dictionary<string, List<string>> NormalizeContentPaths(string[] paths)
{
    Dictionary<string, List<string>> result = [];
    foreach (string path in paths)
    {
        string[] parts = path.Split(' ');
        string root = parts[0];

        foreach (var fileWithContent in parts.Skip(1))
        {
            int left = fileWithContent.IndexOf('(');

            string file = fileWithContent[..left];
            string content = fileWithContent[left..];

            if (!result.ContainsKey(content))
                result[content] = [];

            result[content].Add($"{root}/{file}");
        }
    }

    return result;
}