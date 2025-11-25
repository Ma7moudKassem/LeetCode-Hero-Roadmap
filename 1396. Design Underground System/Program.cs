UndergroundSystem undergroundSystem = new();
undergroundSystem.CheckIn(45, "Leyton", 3);
undergroundSystem.CheckIn(32, "Paradise", 8);
undergroundSystem.CheckIn(27, "Leyton", 10);
undergroundSystem.CheckOut(45, "Waterloo", 15);  // Customer 45 "Leyton" -> "Waterloo" in 15-3 = 12
undergroundSystem.CheckOut(27, "Waterloo", 20);  // Customer 27 "Leyton" -> "Waterloo" in 20-10 = 10
undergroundSystem.CheckOut(32, "Cambridge", 22); // Customer 32 "Paradise" -> "Cambridge" in 22-8 = 14
var t3 = undergroundSystem.GetAverageTime("Paradise", "Cambridge"); // return 14.00000. One trip "Paradise" -> "Cambridge", (14) / 1 = 14
var t2 = undergroundSystem.GetAverageTime("Leyton", "Waterloo");    // return 11.00000. Two trips "Leyton" -> "Waterloo", (10 + 12) / 2 = 11
undergroundSystem.CheckIn(10, "Leyton", 24);
var t1 = undergroundSystem.GetAverageTime("Leyton", "Waterloo");    // return 11.00000
undergroundSystem.CheckOut(10, "Waterloo", 38);  // Customer 10 "Leyton" -> "Waterloo" in 38-24 = 14
var t = undergroundSystem.GetAverageTime("Leyton", "Waterloo");    // return 12.00000. Three trips "Leyton" -> "Waterloo", (10 + 12 + 14) / 3 = 12

Console.WriteLine();
public class UndergroundSystem
{
    private Dictionary<int, (string, int)> _checkIn = [];
    private Dictionary<(string, string), (int, int)> _trips = [];
    public UndergroundSystem() { }

    public void CheckIn(int id, string stationName, int t) =>
        _checkIn[id] = (stationName, t);

    public void CheckOut(int id, string stationName, int t)
    {
        if (!_checkIn.ContainsKey(id))
            return;

        var (startStation, startTime) = _checkIn[id];
        
        _checkIn.Remove(id);

        var tripKey = (startStation, stationName);
        if (!_trips.ContainsKey((tripKey)))
            _trips[tripKey] = (0, 0);

        int tripCount = _trips[tripKey].Item1 + 1;
        int totalTime = _trips[tripKey].Item2 + (t - startTime);

        _trips[tripKey] = (tripCount, totalTime);
    }

    public double GetAverageTime(string startStation, string endStation)
    {
        var tripKey = (startStation, endStation);

        if (_trips.TryGetValue(tripKey, out (int, int) value))
        {
            var (tripCount, totalTime) = value;
            return tripCount > 0 ? (double)totalTime / tripCount : 0;
        }

        return 0;
    }
}