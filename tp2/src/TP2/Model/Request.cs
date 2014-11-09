using System;
using System.Diagnostics;

namespace TP2.Model
{
    [DebuggerDisplay("Start: {StartTime} - {Origin}:{Destination}")]
    public class Request
    {
        public City Origin { get; set; }

        public City Destination { get; set; }

        public DateTime StartTime { get; set; }
    }
}
