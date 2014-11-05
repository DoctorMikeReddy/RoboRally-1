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
using Android.Util;

using RoboRally;

namespace RoboRally
{
	[Activity (Label = "MenuActivity", Theme = "@android:style/Theme.DeviceDefault.NoActionBar.Fullscreen", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]			
	public class MenuActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Retrieve user data from the LoginActivity
			string usersNameData = Intent.GetStringExtra ("UsernameData" ?? "Data not available"); // Retrieving data using the Intent's data name "UsernameData"

			// Retrieve user data from the SettingActivity
			string intentBackUpUsername = Intent.GetStringExtra ("UsernameData" ?? "Data not available"); // Retrieving data using the Intent's data name "UsernameData"

			// Set our view from the "menu" layout resource
			SetContentView(Resource.Layout.Menu);
			this.Window.AddFlags(WindowManagerFlags.Fullscreen);

			// Set our user icon for the user
			ImageView icon = FindViewById<ImageView> (Resource.Id.userIcon);
			icon.SetImageResource (Resource.Drawable.user_icon);

			// Set our main logo for the app
			ImageView logo = FindViewById<ImageView> (Resource.Id.mainLogo);
			logo.SetImageResource (Resource.Drawable.rr_logo);

			// Get our views from the layout resource,
			// and attach an event to it
			ImageView userIcon = FindViewById<ImageView> (Resource.Id.userIcon);
			TextView loggedName = FindViewById<TextView> (Resource.Id.loggedName);
			Button singleButton = FindViewById<Button> (Resource.Id.singleplayerButton);
			Button multiButton = FindViewById<Button> (Resource.Id.multiplayerButton);
			Button settingsButton = FindViewById<Button> (Resource.Id.instellingenButton);

			// Setup the usersname, gathered at login, at the top of the application
			if (usersNameData != "Data not available")
			{
				loggedName.Text = usersNameData;
			}
			else if (intentBackUpUsername != "Data not available")
			{
				loggedName.Text = intentBackUpUsername;
			}

			// Handle the Singeplayer button, when it gets clicked
			singleButton.Click += delegate
			{
				// Pass user data onto SettingsActivity
				var intentBackup = new Intent (this, typeof(SingleplayerActivity)); // Create an intent for SingleplayerActivity, giving it the name usersNameData
				intentBackup.PutExtra ("UsernameData", loggedName.Text); // Adding a name and a value to the Intent

				// Start the MenuActivity based on the "Intent"
				StartActivity(intentBackup);
			};

			// Handle the Multiplayer button, when it gets clicked
			multiButton.Click += delegate
			{
				// Pass user data onto SettingsActivity
				var intentBackup = new Intent (this, typeof(MultiplayerActivity)); // Create an intent for SettingActivity, giving it the name usersNameData
				intentBackup.PutExtra ("UsernameData", loggedName.Text); // Adding a name and a value to the Intent

				// Start the MenuActivity based on the "Intent"
				StartActivity(intentBackup);
			};

			// Handle the settings button, when it gets clicked
			settingsButton.Click += delegate
			{
				// Pass user data onto SettingsActivity
				var intentBackup = new Intent (this, typeof(SettingActivity)); // Create an intent for SettingActivity, giving it the name usersNameData
				intentBackup.PutExtra ("UsernameData", loggedName.Text); // Adding a name and a value to the Intent

				// Start the MenuActivity based on the "Intent"
				StartActivity(intentBackup);
			};
		}
	}
}
