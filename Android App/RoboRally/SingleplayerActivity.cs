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
	[Activity (Label = "SingleplayerActivity", Theme = "@android:style/Theme.DeviceDefault.NoActionBar.Fullscreen", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]			
	public class SingleplayerActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			string usersNameData = Intent.GetStringExtra ("UsernameData" ?? "Data not available"); // Retrieving data using the Intent's data name "UsernameData"

			// Set our view from the "Multiplayer Lobby" layout resource
			SetContentView(Resource.Layout.OfflineLobby);
			this.Window.AddFlags(WindowManagerFlags.Fullscreen);

			// Set our page header icon
			ImageView icon = FindViewById<ImageView> (Resource.Id.lobbyIcon);
			icon.SetImageResource (Resource.Drawable.game_icon);

			// Get our views from the layout resource,
			// and attach an event to it
			Button startGameButton = FindViewById<Button> (Resource.Id.startGameButton);
			Button leaveButton = FindViewById<Button> (Resource.Id.leaveButton);
			SeekBar seekBar = FindViewById<SeekBar> (Resource.Id.sliderBar);
			TextView seekAmount = FindViewById<TextView> (Resource.Id.amountDisplay);

			seekBar.Progress = 1;
			seekAmount.Text = "1";

			// The seekBar changes
			seekBar.ProgressChanged += (object sender, SeekBar.ProgressChangedEventArgs e) => {
				if (e.FromUser)
				{
					seekAmount.Text = string.Format("{0}", e.Progress);
				}
				if (seekBar.Progress < 1 || seekAmount.Text == "0")
				{
					seekBar.Progress = 1;
					seekAmount.Text = "1";
					seekAmount.Text = string.Format("{0}", e.Progress);
				}
			};

			// Handle the add a player button, when it gets clicked
			startGameButton.Click += delegate
			{
				// Pass user data onto GameActivity
				var intentBackup = new Intent (this, typeof(GameActivity)); // Create an intent for GameActivity, giving it the name usersNameData
				intentBackup.PutExtra ("UsernameData", usersNameData); // Adding a name and a value to the Intent

				// Start the MenuActivity based on the "Intent"
				StartActivity(intentBackup);
			};

			// Handle the back button, when it gets clicked
			leaveButton.Click += delegate
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
