using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Android.Content.PM; // Used to prevent rotation
using Android.Media; // Used to access the media player

using RoboRally;

namespace RoboRally
{
	[Activity (Label = "SettingActivity", Theme = "@android:style/Theme.DeviceDefault.NoActionBar.Fullscreen", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]			
	public class SettingActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			string usersNameData = Intent.GetStringExtra ("UsernameData" ?? "Data not available"); // Retrieving data using the Intent's data name "UsernameData"

			// Set our view from the "settings" layout resource
			SetContentView(Resource.Layout.Setting);
			this.Window.AddFlags(WindowManagerFlags.Fullscreen);

			// Set our page header icon
			ImageView icon = FindViewById<ImageView> (Resource.Id.settingsIcon);
			icon.SetImageResource (Resource.Drawable.settings_icon);

			// Set our main logo for the app
			ImageView logo = FindViewById<ImageView> (Resource.Id.mainLogo);
			logo.SetImageResource (Resource.Drawable.rr_logo);

			// Get our views from the layout resource,
			// and attach an event to it
			ImageView settingsIcon = FindViewById<ImageView> (Resource.Id.settingsIcon);
			Button musicToggleButton = FindViewById<Button> (Resource.Id.toggleMusicButton);
			Button backButton = FindViewById<Button> (Resource.Id.backButton);

			// Handle the music toggle button, when it gets clicked
			/*musicToggleButton.Click += delegate
			{
				// Turn music on or off with this toggle
				if (musicToggleButton.Text == "Muziek uitzetten")
				{
					_mediaPlayerIntent.Stop(); // Stop the music player
					musicToggleButton.Text = "Muziek aanzetten";
				}
				else if (musicToggleButton.Text == "Muziek aan zetten")
				{
					_mediaPlayerIntent.Start(); // Start the music player
					musicToggleButton.Text = "Muziek uit zetten";
				}
			};*/

			// Handle the back button, when it gets clicked
			backButton.Click += delegate
			{
				// Pass user data onto MenuActivity
				var intentBackup = new Intent (this, typeof(MenuActivity)); // Create an intent for MenuActivity, giving it the name usersNameData
				intentBackup.PutExtra ("UsernameData", usersNameData); // Adding a name and a value to the Intent

				// Start the MenuActivity based on the "Intent"
				StartActivity(intentBackup);
			};
		}
	}
}
