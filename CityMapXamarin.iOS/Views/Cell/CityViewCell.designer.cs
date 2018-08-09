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
        UIKit.UIImageView CityImage { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel CityNameText { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (CityImage != null) {
                CityImage.Dispose ();
                CityImage = null;
            }

            if (CityNameText != null) {
                CityNameText.Dispose ();
                CityNameText = null;
            }
        }
    }
}