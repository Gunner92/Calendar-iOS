using Foundation;
using System;
using UIKit;
using System.Collections.Generic;

namespace Calendar.iOS
{
	public partial class DatesListViewController : UIViewController
	{
		public List<DayStructure> selectedDates = new List<DayStructure>();

		public DatesListViewController(IntPtr handle) : base(handle)
		{
		}
		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			SelectedDatesTableView.Source = new SelectedDatesItemsSource(selectedDates);

		}
	}
}