using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log_Processing_Component
{
    public class Employee
    {
        string name;
        TimeSpan totalWorkTime = new TimeSpan(0);
        List<Log> allLogs = new List<Log>();
        List<Log> oddDays = new List<Log>();

        public Employee(string name)
        {
            this.name = name;
        }
        #region Manipulation

        public void AddToWorkHour(TimeSpan time)
        {
            totalWorkTime = totalWorkTime.Add(time);
        }

        public void AddLog(Log log)
        {
            allLogs.Add(log);
        }

        public void Process()
        {
            
        }

        public void SortLog()
        {
            allLogs.Sort();
        }

        #endregion

        #region Gets

        public string GetName()
        {
            return name;
        }

        public TimeSpan GetTotalWorkTime()
        {
            return totalWorkTime;
        }

        public List<Log> GetAllLogs()
        {
            return allLogs;
        }

        public List<Log> GetOddDaysLog()
        {
            return oddDays;
        }

        #endregion
    }
}
