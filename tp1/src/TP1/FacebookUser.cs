using System.Diagnostics;
using TP1.Graph;

namespace TP1
{
    [DebuggerDisplay("Name: {Name}")]
    public class FacebookUser : IIdentifiable<long>
    {
        public FacebookUser(long Id, string name)
        {
            this.Id = Id;
            this.Name = name;
        }

        public long Id
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            private set;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}