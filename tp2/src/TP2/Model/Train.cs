using System.Collections.Generic;
using System.Diagnostics;

namespace TP2.Model
{
    [DebuggerDisplay("Id = {Id}")]
    public class Train
    {
        public Train(int id)
        {
            this.Id = id;
            this.Routes = new List<Route>();
        }

        public int Id { get; set; }

        public List<Route> Routes { get; set; }

        public override bool Equals(object obj)
        {
            var otherTrain = obj as Train;
            if (otherTrain != null)
            {
                return this.Id.Equals(otherTrain.Id);
            }
            return false;
        }
    }
}
