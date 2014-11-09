using System;
using System.Diagnostics;

namespace TP2.Model
{
    [DebuggerDisplay("{DepartTime}-{Origin} : {ArrivalTime}-{Destination}")]
    public class Route
    {
        [DebuggerDisplay("{Hour}:{Minute}")]
        public DateTime DepartTime { get; set; }

        [DebuggerDisplay("{Hour}:{Minute}")]
        public DateTime ArrivalTime { get; set; }

        public City Origin { get; set; }

        public City Destination { get; set; }

        public TimeSpan Duration
        {
            get { return ArrivalTime.Subtract(DepartTime); }
        }

        public override bool Equals(object obj)
        {
            var otherRoute = obj as Route;
            if (otherRoute != null)
            {
                return this.Origin.Equals(otherRoute.Origin)
                       && this.Destination.Equals(otherRoute.Destination)
                       && this.DepartTime.Equals(otherRoute.DepartTime)
                       && this.ArrivalTime.Equals(otherRoute.ArrivalTime);
            }
            return false;
        }
    }
}
