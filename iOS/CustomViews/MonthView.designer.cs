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
    [Register ("MonthView")]
    partial class MonthView
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UICollectionView MonthCollectionView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel MonthTitle_UILabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton NextMonth_UIButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton PreviousMonth_UIButton { get; set; }

        [Action ("NextMounthTouched:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void NextMounthTouched (UIKit.UIButton sender);

        [Action ("PreviousMonthTouched:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void PreviousMonthTouched (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (MonthCollectionView != null) {
                MonthCollectionView.Dispose ();
                MonthCollectionView = null;
            }

            if (MonthTitle_UILabel != null) {
                MonthTitle_UILabel.Dispose ();
                MonthTitle_UILabel = null;
            }

            if (NextMonth_UIButton != null) {
                NextMonth_UIButton.Dispose ();
                NextMonth_UIButton = null;
            }

            if (PreviousMonth_UIButton != null) {
                PreviousMonth_UIButton.Dispose ();
                PreviousMonth_UIButton = null;
            }
        }
    }
}