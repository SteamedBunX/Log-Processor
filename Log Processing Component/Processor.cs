using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log_Processing_Component
{
    public class Processor
    {
        Dictionary<string, Employee> employees = new Dictionary<string, Employee>();
        List<string> employeeNames = new List<string>();
        string[] splitBy = new string[] { " ", "\t" };

        public Processor(ref StreamReader file)
        {
            Process(ref file);
        }

        public void Process(ref StreamReader file)
        {
            while (file.Peek() > -1)
            {
                ProcessLog(ProcessLine(file.ReadLine()));
            }

            foreach (KeyValuePair<string, Employee> pair in employees)
            {
                pair.Value.Process();
            }
        }

        public Log ProcessLine(string line)
        {
            if (line.Length == 58)
            {
                var content = line.Split(splitBy, StringSplitOptions.RemoveEmptyEntries);
                var nameLength = content.Length - 7;
                int logNumber = int.Parse(content[0]);
                DateTime datetime = DateTime.Parse(content[content.Length - 2] + ' ' + content[content.Length - 1]);
                string name = String.Join(" ", content, 3, nameLength);
                Log log = new Log()
                {
                    LogNumber = logNumber,
                    Name = name,
                    LogDateTime = datetime
                };
                return log;
            }
            return null;
        }

        public void ProcessLog(Log log)
        {
            if (log != null)
            {
                if (!HasEmployee(log.Name))
                {
                    AddEmployee(log.Name);
                }
            }

        }

        #region Manipulation

        public void AddEmployee(string name)
        {
            employees[name] = new Employee(name);
            employeeNames.Add(name);
        }

        public void AddLog(Log log)
        {
            employees[log.Name].AddLog(log);
        }

        #endregion

        #region Gets

        public Employee GetEmployee(string name)
        {
            return employees[name];
        }

        public bool HasEmployee(string name)
        {
            return employeeNames.Contains(name);
        }
        #endregion
    }
}
