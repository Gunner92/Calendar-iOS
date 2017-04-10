using Foundation;
using System;
using UIKit;
using ObjCRuntime;
using System.Collections.Generic;
namespace Calendar.iOS
{
	public partial class MonthView : UIView
	{
		private List<DayStructure> daysofMonth = new List<DayStructure>();
		private DateTime selectedDate;
		private bool rangeEnabled = false;
		private RangeModel dateRangeModel;
		public List<DayStructure> selectedDates = new List<DayStructure>();

		public MonthView(IntPtr handle) : base(handle)
		{
		}
		public static MonthView InitializeCalendar(DateTime selectedDate)
		{
			var arr = NSBundle.MainBundle.LoadNib("MonthView", null, null);
			var v = Runtime.GetNSObject<MonthView>(arr.ValueAt(0));
			v.selectedDate = selectedDate;
			return v;
		}

		public override void AwakeFromNib()
		{
			MonthCollectionView.RegisterClassForCell(typeof( DayCollectionViewCell),"dayViewIdentifier");
		}

		public void CreateCalendar()
		{
			rangeEnabled = false;
			daysofMonth = CalendarCalculations.CalculateMonthDays(selectedDate);
			MonthTitle_UILabel.Text = selectedDate.ToString("dd MMMMM yyyy dddd");
			var source = new MonthCollectionViewSource(daysofMonth);
			source.DayItemSelected += Source_DayItemSelected;
			MonthCollectionView.Source = source;
		}
		public void CreateCalendarForRange(RangeModel rangeModel)
		{
			dateRangeModel = rangeModel;
			rangeEnabled = true;
			daysofMonth = CalendarCalculations.CalculateMonthDays(selectedDate,true);
			MonthTitle_UILabel.Text = selectedDate.ToString("dd MMMMM yyyy dddd");
			var source = new MonthCollectionViewSource(daysofMonth,rangeModel);
			source.selectedDays = selectedDates;
			//source.DayItemSelected += Source_DayItemSelected;
			source.DisableDeSelect = true;
			MonthCollectionView.Source = source;
		}

		void Source_DayItemSelected (object sender, EventArgs e)
		{
			var args = e as DaySelectedEventArgs;
			selectedDate = args.SelectedItem.Day;
			MonthTitle_UILabel.Text = args.SelectedItem.Day.ToString("dd MMMMM yyyy dddd");
			if (!args.SelectedItem.isSelectedMonth)
			{
				selectedDate = args.SelectedItem.Day;
				CreateCalendar();
			}
		}

		partial void PreviousMonthTouched(UIButton sender)
		{
			selectedDate = selectedDate.AddMonths(-1);
			if (!rangeEnabled)
			{
	            CreateCalendar();
			}
			else
			{
				CreateCalendarForRange(dateRangeModel);
			}
		}

		partial void NextMounthTouched(UIButton sender)
		{
			selectedDate = selectedDate.AddMonths(1);
			if (!rangeEnabled)
			{
	            CreateCalendar();
			}
			else
			{
                CreateCalendarForRange(dateRangeModel);
			}
		}

		public void ChangeDate(DateTime newDate)
		{
			selectedDate = newDate;
			CreateCalendar();
		}
		//public void DateRange(DateTime newDate, List<DateTime> range)		{
		//	selectedDate = newDate;
		//	CreateCalendarForRange(range);
		//}
	}
}