using System;
using System.Collections.Generic;
using Foundation;
using UIKit;

namespace Calendar.iOS
{
	public partial class ViewController : UIViewController
	{
		private MonthView monthView;
		private DateTime startDate = DateTime.Now;
		private DateTime endDate = DateTime.Now;
		private bool rangesEnabled = false;
		public ViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			ShowDatesinListView.Hidden = true;
			// Perform any additional setup after loading the view, typically from a nib.
			monthView = MonthView.InitializeCalendar(DateTime.Now);
			monthView.CreateCalendar();
			monthView.Frame = new CoreGraphics.CGRect(0, 0, CalendarView.Frame.Width, CalendarView.Frame.Height);
			CalendarView.AddSubview(monthView);
			SetUpFirstDatePicker();
			SetUpEndDatePicker();
			DatePickerStart.Text = DateTime.Now.ToString("dd MMMMM yyyy dddd");
			DatePickerEnd.Text  = DateTime.Now.ToString("dd MMMMM yyyy dddd");
			EnableRangePickers.TouchUpInside += (object sender, EventArgs e) =>
			{
				if (rangesEnabled == false)
				{
					RangeModel range = new RangeModel() { startDate = startDate, endDate = endDate };
					monthView.CreateCalendarForRange(range);
					EnableRangePickers.SetTitle("Disable RangePickers",UIControlState.Normal);
					rangesEnabled = true;
					ShowDatesinListView.Hidden = false;
				}
				else
				{
					monthView.ChangeDate(startDate);
					EnableRangePickers.SetTitle("Enable RangePickers",UIControlState.Normal);
					rangesEnabled = false;
					ShowDatesinListView.Hidden = true;
				}
			};
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.		
		}

		public void SetUpFirstDatePicker()
		{
			UIDatePicker datePicker = new UIDatePicker();
			datePicker.Mode = UIDatePickerMode.Date;

			UIToolbar toolbar = new UIToolbar();
			toolbar.BarStyle = UIBarStyle.Default;
			toolbar.Translucent = true;
			toolbar.SizeToFit();

			UIBarButtonItem doneButton = new UIBarButtonItem("Done", UIBarButtonItemStyle.Done, (s, e) =>
			{
				var selectedDate = NSDateToDateTime(datePicker.Date);
				DatePickerStart.Text = selectedDate.ToString("dd MMMMM yyyy dddd");
				monthView.ChangeDate(selectedDate);
				DatePickerStart.ResignFirstResponder();
				startDate = selectedDate;


			});
			toolbar.SetItems(new UIBarButtonItem[] { new UIBarButtonItem (UIBarButtonSystemItem.FlexibleSpace),doneButton }, true);

			this.DatePickerStart.InputView = datePicker;

            this.DatePickerStart.InputAccessoryView = toolbar;
		}

		public void SetUpEndDatePicker()
		{
			UIDatePicker datePicker = new UIDatePicker();
			datePicker.Mode = UIDatePickerMode.Date;

			UIToolbar toolbar = new UIToolbar();
			toolbar.BarStyle = UIBarStyle.Default;
			toolbar.Translucent = true;
			toolbar.SizeToFit();

			UIBarButtonItem doneButton = new UIBarButtonItem("Done", UIBarButtonItemStyle.Done, (s, e) =>
			{
				if (endDate> startDate)
				{
					var selectedDate = NSDateToDateTime(datePicker.Date);
					DatePickerEnd.Text = selectedDate.ToString("dd MMMMM yyyy dddd");
					DatePickerEnd.ResignFirstResponder();
					endDate = selectedDate;
				}
				else
				{
					UIAlertController alertController = UIAlertController.Create("Error","The end date must be after the start date",UIAlertControllerStyle.Alert);
					PresentViewController(alertController,true,null);
				}
						

			});
			toolbar.SetItems(new UIBarButtonItem[] { new UIBarButtonItem(UIBarButtonSystemItem.FlexibleSpace), doneButton }, true);

			this.DatePickerEnd.InputView = datePicker;

            this.DatePickerEnd.InputAccessoryView = toolbar;
		}

		public static DateTime NSDateToDateTime(NSDate date)
		{
			DateTime reference = TimeZone.CurrentTimeZone.ToLocalTime(
			new DateTime(2001, 1, 1, 0, 0, 0));
			return reference.AddSeconds(date.SecondsSinceReferenceDate);
		}

		partial void ShowDatesinListView_TouchUpInside(UIButton sender)
		{
			var items =  monthView.selectedDates;
			var _settingsStoryboard = UIStoryboard.FromName("Main", null);
			var controller = _settingsStoryboard.InstantiateViewController("DatesListViewController") as DatesListViewController;
			controller.selectedDates = items;
			this.NavigationController.PushViewController(controller, true);
		}
	}
}
