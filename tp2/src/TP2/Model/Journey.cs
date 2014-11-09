using System.Collections.Generic;

namespace TP2.Model
{
    public class Journey
    {
        private readonly List<Route> Routes = new List<Route>(); 

        public void AddRoute(Route route)
        {
            this.Routes.Add(route);
        }
    }
}
