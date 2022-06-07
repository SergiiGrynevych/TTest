using System;

namespace Test.Model
{
    public class HistoryExport
    {
        public int id { get; private set; }
        public string name { get; private set; }
        public DateTime dateTime { get; private set; }
        public string userName { get; private set; }
        public string cellName { get; private set; }
        public TimeSpan time { get; set; }
        public HistoryExport(int id, string name, DateTime dateTime, string userName, string cellName)
        {
            this.id = id;
            this.name = name;
            this.dateTime = dateTime;
            this.userName = userName;
            this.cellName = cellName;
            time = dateTime.TimeOfDay;
        }
    }
}
