// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Calendar.iOS
{
    [Register ("DatesTableViewCell")]
    partial class DatesTableViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel SelectedDatesLabel { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (SelectedDatesLabel != null) {
                SelectedDatesLabel.Dispose ();
                SelectedDatesLabel = null;
            }
        }
    }
}