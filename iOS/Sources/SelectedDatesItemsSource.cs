using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace Calendar.iOS
{
	public class SelectedDatesItemsSource : UITableViewSource
	{
		private const string reuseIdentifier = "datesIdentifier";
		private List<DayStructure> dateItems;
		public SelectedDatesItemsSource(List<DayStructure> items)
		{
			dateItems = items;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var cell = tableView.DequeueReusableCell(reuseIdentifier,indexPath) as DatesTableViewCell;
			cell.SetDate(dateItems[(int)indexPath.Item].Day.ToString("dd MMMMM yyyy dddd"));
			return cell;
		}

		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return dateItems.Count;
		}
	}
}
