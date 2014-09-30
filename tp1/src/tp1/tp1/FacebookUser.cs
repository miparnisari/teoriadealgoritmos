using TP1.Graph;

namespace TP1
{
	public class FacebookUser : IIdentifiable<long>
	{
		public FacebookUser(long Id)
		{
			this.Id = Id;
		}

		public long Id
		{
			get;
			private set;
		}

		public string Label
		{
			get;
			set;
		}
	}
}