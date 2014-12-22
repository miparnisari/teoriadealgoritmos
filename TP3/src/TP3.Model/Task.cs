namespace TP3.Model
{
    public class Task
    {
        public Task(int id, int duration, int deadline, int profit)
        {
            this.ID = id;
            this.Duration = duration;
            this.Deadline = deadline;
            this.Profit = profit;
        }

        public int ID
        {
            get; private set;
        }

        public int Duration
        {
            get; private set;
        }

        public int Deadline
        {
            get; private set;
        }

        public int Profit
        {
            get; private set;
        }
    }
}
