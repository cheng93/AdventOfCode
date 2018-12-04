namespace AdventOfCode2018.Day04
{
    using System;
    using System.Globalization;

    public class Day04Record
    {
        public DateTime Date { get; }

        public int? Id { get; }

        public bool IsWakingUp { get; }

        public bool IsFallingAsleep { get; }

        public bool IsBeginningShift { get; }

        public Day04Record(string input)
        {
            var dateFormat = "[yyyy-MM-dd HH:mm]";

            var dateString = input.Substring(0, dateFormat.Length);
            this.Date = DateTime.ParseExact(dateString, dateFormat, CultureInfo.InvariantCulture);

            var message = input.Substring(dateFormat.Length + 1);

            // [1518-11-01 00:05] falls asleep
            if (message == "falls asleep")
            {
                this.IsFallingAsleep = true;
            }
            // [1518-11-01 00:25] wakes up
            else if (message == "wakes up")
            {
                this.IsWakingUp = true;
            }
            // [1518-11-01 00:00] Guard #10 begins shift
            else
            {
                this.IsBeginningShift = true;
                this.Id = int.Parse(message.Split(' ')[1].Substring(1));
            }
        }
    }
}