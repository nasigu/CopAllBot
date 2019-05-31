using System;

namespace Supreme.Model
{
    public class TaskTime
    {
            public DateTime Date { get; set; }

            public DateTime Time { get; set; }

            public TaskTime()
            {
                Date = new DateTime();
                Time = new DateTime();
            }
    }
}
