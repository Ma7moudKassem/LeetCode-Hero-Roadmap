using System.Linq;

public class RandomizedSet
{
    private List<int> _store;
    private Dictionary<int, int> _map;
    private Random _random;
    public RandomizedSet()
    {
        _store = [];
        _map = [];
        _random = new Random();
    }

    public bool Insert(int val)
    {
        if (_map.ContainsKey(val))
            return false;

        _map.Add(val, _store.Count);
        _store.Add(val);

        return true;
    }

    public bool Remove(int val)
    {
        if (!_map.ContainsKey(val))
            return false;

        int index = _map[val];
        int last = _store[^1];

        _store[index] = last;
        _store.RemoveAt(_store.Count - 1);
        
        _map[last] = index;
        _map.Remove(val);
        
        return true;
    }

    public int GetRandom()
    {
        if(_store.Count == 0)
            return 0;

        int rondomeIdx = _random.Next(_store.Count - 1);
        return _store[rondomeIdx];
    }
}
