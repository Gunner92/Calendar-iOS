using Foundation;
using System;
using UIKit;

namespace Calendar.iOS
{
    public partial class DayCollectionViewCell : UICollectionViewCell
    {
		public DayStructure day { get; set; }

		private CoreGraphics.CGRect frame { get; set; }
		private DayView dayView;

        public DayCollectionViewCell (IntPtr handle) : base (handle)
        {
			frame = new CoreGraphics.CGRect(0, 0, 50, 50);
        }
		public void Create(DayStructure dayOfMonth ,NSIndexPath indexPath,UICollectionView collectionView)
		{
			this.day = dayOfMonth;

			dayView = new DayView(dayOfMonth,frame);
			if (dayOfMonth.isSelected)
			{
				collectionView.SelectItem(indexPath, true, UICollectionViewScrollPosition.CenteredVertically);
			}
			ContentView.AddSubview(dayView);
		}
		public void SelectCell()
		{
			dayView.RemoveFromSuperview();
			day.isSelected = true;
			dayView = new DayView(day,frame);
			ContentView.AddSubview(dayView);
		}
		public void DeSelectCell()
		{
			dayView.RemoveFromSuperview();
			day.isSelected = false;
			dayView = new DayView(day, frame);
			ContentView.AddSubview(dayView);
		}
    }
}