using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2018.Day07
{
    public class WorkProcessor
    {
        private int _numberOfWorkers = 0;
        private Dictionary<string, int> _taskQueue = new Dictionary<string, int>();

        public int TimeAdder { get; set; }

        // --------------------------------------------------------------------
        private static Dictionary<string, int> taskDurationMap;
        private static Dictionary<string, int> TaskDurationMap
        {
            get
            {
                if (taskDurationMap == null)
                {
                    taskDurationMap = new Dictionary<string, int>();

                    var cl = Enumerable.Range('A', 'Z' - 'A' + 1)
                        .Select(c => (char)c).ToList();

                    var s = 1;
                    foreach (var c in cl)
                    {
                        taskDurationMap.Add(c.ToString(), s);
                        s++;
                    }
                }

                return taskDurationMap;
            }
        }

        // --------------------------------------------------------------------
        public static int GetTaskDuration(String task)
        {
            var tdm = TaskDurationMap;
            return (tdm.ContainsKey(task)) ? tdm[task] : -1;
        }

        // --------------------------------------------------------------------
        public WorkProcessor(int numberOfWorkers)
        {
            _numberOfWorkers = numberOfWorkers;
        }

        // --------------------------------------------------------------------
        public void LoadWorkQueue(ref List<String> ready)
        {
            if (ready.Count == 0)
                return;

            while (true)
            {
                var task = ready[0];
                var added = AddTask(task);
                if (added)
                    ready.RemoveAt(0);

                if (!added || ready.Count == 0)
                    break;
            }
        }

        // --------------------------------------------------------------------
        // Adds a task to the queue and sets the task duration based on the task name.
        // returns true if the task could be added; false otherwise.
        public bool AddTask(string task)
        {
            if (_taskQueue.ContainsKey(task))
                return true;

            if (_taskQueue.Count < _numberOfWorkers)
            {
                var duration = GetTaskDuration(task) + TimeAdder;
                _taskQueue.Add(task, duration);
                return true;
            }

            return false;
        }

        // --------------------------------------------------------------------
        public bool IsTaskQueueEmpty()
        {
            return _taskQueue.Count == 0;
        }

        // --------------------------------------------------------------------
        // Processes the work queue and returns the names of completed tasks.
        public List<string> ProcessQueue()
        {
            var completed = new List<string>();

            var tasks = new List<string>(_taskQueue.Keys);
            tasks.ForEach(x => _taskQueue[x] -= 1);

            completed = (_taskQueue.Keys.Where(x => _taskQueue[x] == 0).ToList<string>());
            completed.ForEach(x => _taskQueue.Remove(x));
            return completed;
        }
    }
}
