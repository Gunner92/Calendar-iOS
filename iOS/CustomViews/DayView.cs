using System;
using UIKit;

namespace Calendar.iOS
{
	public class DayView : UIView
	{
		private int day;
		public DayView(DayStructure dayOfMonth, CoreGraphics.CGRect rect)
		{
			this.Frame = rect;
			this.day = dayOfMonth.Day.Day;

			var dayLabel = getDayLabel(30);
			dayLabel.Layer.CornerRadius = 15;
			dayLabel.Layer.MasksToBounds = true;
			if (dayOfMonth.isSelected)
			{
                dayLabel.BackgroundColor = UIColor.Red;
				dayLabel.TextColor = UIColor.White;
				BackgroundColor = UIColor.White;
			}
			else
			{
				if (dayOfMonth.isWeekend)
				{
					this.BackgroundColor = UIColor.FromRGB(245,245,245);
					dayLabel.BackgroundColor = UIColor.FromRGB(245,245,245);
					dayLabel.TextColor = UIColor.FromRGB(135,135,135);
				}
				else
				{
					if (dayOfMonth.isWorkDay)
					{
						BackgroundColor = UIColor.White;
	                    dayLabel.BackgroundColor = UIColor.White;
						dayLabel.TextColor = UIColor.Red;
					}
					else
					{
						BackgroundColor = UIColor.White;
	                    dayLabel.BackgroundColor = UIColor.White;
						dayLabel.TextColor = UIColor.FromRGB(195,195,195);
					}
				}
			}
			this.AddSubview(dayLabel);
		}

		private UILabel getDayLabel(float dayLabelHeight)
		{
			UILabel dayLabel = new UILabel(new CoreGraphics.CGRect(((Frame.Height-dayLabelHeight)/2),((Frame.Height-dayLabelHeight)/2),dayLabelHeight,dayLabelHeight));
			dayLabel.Text = day.ToString();
			dayLabel.TextAlignment = UITextAlignment.Center;
			return dayLabel;
		}
	}
}
