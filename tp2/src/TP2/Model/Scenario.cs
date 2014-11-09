using System.Collections.Generic;

namespace TP2.Model
{
    public class Scenario
    {
        public List<Train> Trains { get; set; }

        public List<City> Cities { get; set; }

        public Request Request { get; set; }
    }
}
