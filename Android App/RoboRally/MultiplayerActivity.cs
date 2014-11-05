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
	[Activity (Label = "MultiplayerActivity", Theme = "@android:style/Theme.DeviceDefault.NoActionBar.Fullscreen", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]			
	public class MultiplayerActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			string usersNameData = Intent.GetStringExtra ("UsernameData" ?? "Data not available"); // Retrieving data using the Intent's data name "UsernameData"

			// Set our view from the "Multiplayer Lobby" layout resource
			SetContentView(Resource.Layout.OnlineLobby);
			this.Window.AddFlags(WindowManagerFlags.Fullscreen);

			// Set our page header icon
			ImageView icon = FindViewById<ImageView> (Resource.Id.lobbyIcon);
			icon.SetImageResource (Resource.Drawable.game_icon);

			// Get our views from the layout resource,
			// and attach an event to it
			Button startGameButton = FindViewById<Button> (Resource.Id.startGameButton);
			Button leaveButton = FindViewById<Button> (Resource.Id.leaveButton);

			TextView playerName1 = FindViewById<TextView> (Resource.Id.playerName1); // Create resource for the usersname

			// All playerIcons in the lobby
			ImageView playerIcon1 = FindViewById<ImageView> (Resource.Id.playerIcon1);
			ImageView playerIcon2 = FindViewById<ImageView> (Resource.Id.playerIcon2);
			ImageView playerIcon3 = FindViewById<ImageView> (Resource.Id.playerIcon3);
			ImageView playerIcon4 = FindViewById<ImageView> (Resource.Id.playerIcon4);
			ImageView playerIcon5 = FindViewById<ImageView> (Resource.Id.playerIcon5);
			ImageView playerIcon6 = FindViewById<ImageView> (Resource.Id.playerIcon6);

			// Setup the right username to a player
			playerName1.Text = usersNameData;

			// Setup the correct playericons for each player
			playerIcon1.SetImageResource (Resource.Drawable.user_icon);
			playerIcon2.SetImageResource (Resource.Drawable.user_icon);
			playerIcon3.SetImageResource (Resource.Drawable.user_icon);
			playerIcon4.SetImageResource (Resource.Drawable.user_icon);
			playerIcon5.SetImageResource (Resource.Drawable.user_icon);
			playerIcon6.SetImageResource (Resource.Drawable.user_icon);

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
