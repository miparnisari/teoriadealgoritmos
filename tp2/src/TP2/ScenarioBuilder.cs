using System.Collections.Generic;
using TP2.Model;

namespace TP2
{
    public class ScenarioBuilder
    {
        public BaseScenarioReader Reader { get; private set; }

        public ScenarioBuilder(BaseScenarioReader scenarioReader)
        {
            this.Reader = scenarioReader;
        }
        public Scenario Build()
        {
            var cities = new List<City>();
            var trains = new List<Train>();
            var request = new Request();
            this.Reader.Read(ref cities, ref trains, ref request);
            return new Scenario {Request = request, Cities = cities, Trains = trains};
        }
    }
}
