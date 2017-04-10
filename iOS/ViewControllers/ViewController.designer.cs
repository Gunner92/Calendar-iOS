// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Calendar.iOS
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        UIKit.UIButton Button { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIView CalendarView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField DatePickerEnd { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField DatePickerStart { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton EnableRangePickers { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton ShowDatesinListView { get; set; }

        [Action ("ShowDatesinListView_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void ShowDatesinListView_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (CalendarView != null) {
                CalendarView.Dispose ();
                CalendarView = null;
            }

            if (DatePickerEnd != null) {
                DatePickerEnd.Dispose ();
                DatePickerEnd = null;
            }

            if (DatePickerStart != null) {
                DatePickerStart.Dispose ();
                DatePickerStart = null;
            }

            if (EnableRangePickers != null) {
                EnableRangePickers.Dispose ();
                EnableRangePickers = null;
            }

            if (ShowDatesinListView != null) {
                ShowDatesinListView.Dispose ();
                ShowDatesinListView = null;
            }
        }
    }
}