using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Gcm.Client;
using AsNum.XFControls.Droid;
namespace FirebaseXamarinForms.Droid
{
	[Activity (Label = "FB Xamarin", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            AsNumAssemblyHelper.HoldAssembly();
            global::Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new App());
            GcmClient.CheckDevice(this);
            GcmClient.CheckManifest(this);



            //Call to register
            GcmClient.Register(this, GcmBroadcastReceiver.SENDER_IDS);
        }
}
}
