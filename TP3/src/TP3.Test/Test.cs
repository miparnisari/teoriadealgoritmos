namespace TP3.Test
{
    using NUnit.Framework;
    using System.Linq;
    using System.Collections.Generic;
    using TP3.Model;

    [TestFixture()]
    public class PlannerTest
    {
        [Test()]
        public void AllTasksAreScheduledWhenNoDeadline()
        {
            var tasks = new List<Task>
			{
				new Task(1, 1, 100, 10),
				new Task(2, 1, 100, 10),
				new Task(3, 1, 100, 10),
				new Task(4, 1, 100, 10),
				new Task(5, 1, 100, 10)
			};

            var plan = Planner.GetPlan(tasks);
            Assert.AreEqual(1, plan.ElementAt(0).ID);
            Assert.AreEqual(2, plan.ElementAt(1).ID);
            Assert.AreEqual(3, plan.ElementAt(2).ID);
            Assert.AreEqual(4, plan.ElementAt(3).ID);
            Assert.AreEqual(5, plan.ElementAt(4).ID);
        }

        [Test()]
        public void AllTasksAreScheduledWhenIncreasingDeadline()
        {
            var tasks = new List<Task>
			{
				new Task(1, 1, 2, 10),
				new Task(2, 1, 3, 10),
				new Task(3, 1, 4, 10),
				new Task(4, 1, 5, 10),
				new Task(5, 1, 6, 10)
			};

            var plan = Planner.GetPlan(tasks);
            Assert.AreEqual(1, plan.ElementAt(0).ID);
            Assert.AreEqual(2, plan.ElementAt(1).ID);
            Assert.AreEqual(3, plan.ElementAt(2).ID);
            Assert.AreEqual(4, plan.ElementAt(3).ID);
            Assert.AreEqual(5, plan.ElementAt(4).ID);
        }

        [Test()]
        public void AllTasksAreReversedWhenDecreasingDeadline()
        {
            var tasks = new List<Task>
			{
				new Task(1, 1, 5, 10),
				new Task(2, 1, 4, 10),
				new Task(3, 1, 3, 10),
				new Task(4, 1, 2, 10),
				new Task(5, 1, 1, 10)
			};

            var plan = Planner.GetPlan(tasks);
            Assert.AreEqual(5, plan.ElementAt(0).ID);
            Assert.AreEqual(4, plan.ElementAt(1).ID);
            Assert.AreEqual(3, plan.ElementAt(2).ID);
            Assert.AreEqual(2, plan.ElementAt(3).ID);
            Assert.AreEqual(1, plan.ElementAt(4).ID);
        }

        [Test()]
        public void OverlappedTasksWithLowerBenefitAreIgnored()
        {
            var tasks = new List<Task>
			{
				new Task(1, 1, 1, 10),
				new Task(2, 1, 2, 10),
				new Task(3, 1, 3, 10),
				new Task(4, 1, 4, 10),
				new Task(5, 2, 3, 30)
			};

            var plan = Planner.GetPlan(tasks);
            Assert.AreEqual(1, plan.ElementAt(0).ID);
            Assert.AreEqual(5, plan.ElementAt(1).ID);
            Assert.AreEqual(4, plan.ElementAt(2).ID);
        }

        [Test()]
        public void OverlappedTasksWithHigherBenefitsAreScheduled()
        {
            var tasks = new List<Task>
			{
				new Task(1, 1, 1, 10),
				new Task(2, 1, 2, 20),
				new Task(3, 1, 3, 20),
				new Task(4, 1, 4, 10),
				new Task(5, 2, 3, 10)
			};

            var plan = Planner.GetPlan(tasks);
            Assert.AreEqual(1, plan.ElementAt(0).ID);
            Assert.AreEqual(2, plan.ElementAt(1).ID);
            Assert.AreEqual(3, plan.ElementAt(2).ID);
            Assert.AreEqual(4, plan.ElementAt(3).ID);
        }
    }
}