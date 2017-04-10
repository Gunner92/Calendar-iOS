using System;
using System.Collections.Generic;
using UIKit;
using System.Linq;
namespace Calendar.iOS
{
	public class MonthCollectionViewSource : UICollectionViewSource
	{
		private string reuseIdentifier = "dayViewIdentifier";
		private List<DayStructure> monthViewItems = new List<DayStructure>();
		public bool DisableDeSelect;
		public event EventHandler DayItemSelected;
		private RangeModel ranges = new RangeModel();
		public List<DayStructure> selectedDays;
		public MonthCollectionViewSource(List<DayStructure> items, RangeModel ranges = null)
		{
			if (ranges != null)
			{
				this.ranges = ranges;
			}
			this.monthViewItems = items;
		}
		public override UICollectionViewCell GetCell(UICollectionView collectionView, Foundation.NSIndexPath indexPath)
		{
			var cell = (DayCollectionViewCell)collectionView.DequeueReusableCell(reuseIdentifier, indexPath);
			cell.Create(monthViewItems[(int)indexPath.Item], indexPath, collectionView);
			return cell;
		}
		public override nint NumberOfSections(UICollectionView collectionView)
		{
			return 1;
		}
		public override nint GetItemsCount(UICollectionView collectionView, nint section)
		{
			return 42;
		}

		public override bool ShouldSelectItem(UICollectionView collectionView, Foundation.NSIndexPath indexPath)
		{
			return true;
		}

		public override bool ShouldDeselectItem(UICollectionView collectionView, Foundation.NSIndexPath indexPath)
		{
			return true;
		}

		public override void ItemSelected(UICollectionView collectionView, Foundation.NSIndexPath indexPath)
		{
			if (DisableDeSelect)
			{

				if (ranges.startDate <= monthViewItems[(int)indexPath.Item].Day && monthViewItems[(int)indexPath.Item].Day <= ranges.endDate)
				{
					var cell = (DayCollectionViewCell)collectionView.CellForItem(indexPath);
					DayItemSelectedFunction(monthViewItems[(int)indexPath.Item]);
					if (selectedDays.Contains(monthViewItems[(int)indexPath.Item]))
					{
						cell.DeSelectCell();
						selectedDays.Remove(monthViewItems[(int)indexPath.Item]);
					}
					else
					{
						cell.SelectCell();
						selectedDays.Add(monthViewItems[(int)indexPath.Item]);
					}

				}

			}
			else
			{
				var cell = (DayCollectionViewCell)collectionView.CellForItem(indexPath);
				DayItemSelectedFunction(monthViewItems[(int)indexPath.Item]);
				cell.SelectCell();
			}

		}
		public override void ItemDeselected(UICollectionView collectionView, Foundation.NSIndexPath indexPath)
		{
			if (DisableDeSelect)
			{

			}
			else
			{
				var cell = (DayCollectionViewCell)collectionView.CellForItem(indexPath);
				cell.DeSelectCell();
			}
		}
		public void DayItemSelectedFunction(DayStructure selectedItem)
		{
			if (null != DayItemSelected) DayItemSelected(this, new DaySelectedEventArgs(selectedItem));
		}
	}
}