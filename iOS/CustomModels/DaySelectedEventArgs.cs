using System;
namespace Calendar.iOS
{
	[System.Serializable]
	public sealed class DaySelectedEventArgs : EventArgs
	{
		public DayStructure SelectedItem;
		public DaySelectedEventArgs(DayStructure _selectedItem)
		{
			SelectedItem = _selectedItem;
		}	
	}
}
