// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Blank.Views.Cell
{
    [Register ("CityViewCell")]
    partial class CityViewCell
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView CityImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel CityName { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (CityImageView != null) {
                CityImageView.Dispose ();
                CityImageView = null;
            }

            if (CityName != null) {
                CityName.Dispose ();
                CityName = null;
            }
        }
    }
}