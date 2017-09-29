﻿using System;
using System.Collections.Generic;
using System.Linq;
using AsNum.XFControls.iOS;
using Foundation;
using UIKit;

namespace FirebaseXamarinForms.iOS
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
        {
            AsNumAssemblyHelper.HoldAssembly();
            global::Xamarin.Forms.Forms.Init ();

			LoadApplication (new App ());

			return base.FinishedLaunching (app, options);
		}
	}
}