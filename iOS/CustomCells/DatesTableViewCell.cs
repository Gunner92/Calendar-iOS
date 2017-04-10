using Foundation;
using System;
using UIKit;

namespace Calendar.iOS
{
    public partial class DatesTableViewCell : UITableViewCell
    {
        public DatesTableViewCell (IntPtr handle) : base (handle)
        {
        }
		public void SetDate(string date)
		{
			SelectedDatesLabel.Text = date;
		}
    }
}