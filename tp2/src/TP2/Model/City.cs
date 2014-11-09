using System.Diagnostics;

namespace TP2.Model
{
    [DebuggerDisplay("{Name}")]
    public class City
    {
        public City(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            var otherStation = obj as City;
            if (otherStation != null)
            {
                return this.Name.ToLower().Equals(otherStation.Name.ToLower());
            }
            return false;
        }
    }
}
