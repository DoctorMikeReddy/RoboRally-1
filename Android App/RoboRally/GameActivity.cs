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
	[Activity (Label = "GameActivity", Theme = "@android:style/Theme.DeviceDefault.NoActionBar.Fullscreen", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]			
	public class GameActivity : Activity
	{
		public static Random _random = new Random(); // Randomizer function

		// Result popup message method
		public bool resultMessage(string message)
		{
			string usersNameData = Intent.GetStringExtra ("UsernameData" ?? "Data not available"); // Retrieving data using the Intent's data name "UsernameData"

			bool popupResult = false;

			AlertDialog.Builder builder = new AlertDialog.Builder(this);
			builder.SetTitle("Resultaat!");
			builder.SetIcon(Resource.Drawable.game_icon_small);
			builder.SetMessage(message);
			builder.SetPositiveButton("Afsluiten", delegate {
				// Open the popup window
				popupResult = true;

				// Pass user data onto MenuActivity
				var intentBackup = new Intent (this, typeof(MenuActivity)); // Create an intent for MenuActivity, giving it the name usersNameData
				intentBackup.PutExtra ("UsernameData", usersNameData); // Adding a name and a value to the Intent

				// Start the MenuActivity based on the "Intent"
				StartActivity(intentBackup);
			});

			builder.SetNegativeButton("Opnieuw", (sender, e) =>
			{
				// Pass user data onto SettingsActivity
				var intentBackup = new Intent (this, typeof(MultiplayerActivity)); // Create an intent for SettingActivity, giving it the name usersNameData
				intentBackup.PutExtra ("UsernameData", usersNameData); // Adding a name and a value to the Intent

				// Start the MenuActivity based on the "Intent"
				StartActivity(intentBackup);

				// Close the popup window
				popupResult = false;
			});

			builder.Show();
			return popupResult;
		}

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			string usersNameData = Intent.GetStringExtra ("UsernameData" ?? "Data not available"); // Retrieving data using the Intent's data name "UsernameData"

			// Set our view from the "Game" layout resource
			SetContentView(Resource.Layout.Game);
			this.Window.AddFlags(WindowManagerFlags.Fullscreen);

			// Get our views from the layout resource,
			// and attach an event to it
			ImageView lifeBar = FindViewById<ImageView> (Resource.Id.lifeBar);
			ImageView gameBoard = FindViewById<ImageView> (Resource.Id.gameBoard);
			ImageButton control1 = FindViewById<ImageButton> (Resource.Id.controlButton1);
			ImageButton control2 = FindViewById<ImageButton> (Resource.Id.controlButton2);
			ImageButton control3 = FindViewById<ImageButton> (Resource.Id.controlButton3);
			ImageButton control4 = FindViewById<ImageButton> (Resource.Id.controlButton4);
			ImageButton control5 = FindViewById<ImageButton> (Resource.Id.controlButton5);
			Button forceFinish = FindViewById<Button> (Resource.Id.finishGame);

			// Setup the correct imageViews for each element
			lifeBar.SetImageResource (Resource.Drawable.life_bar);
			gameBoard.SetImageResource (Resource.Drawable.gameboard);

			control1.SetImageResource (Resource.Drawable.Move3_Active);
			control2.SetImageResource (Resource.Drawable.Move3_Inactive);
			control3.SetImageResource (Resource.Drawable.Backup_Inactive);
			control4.SetImageResource (Resource.Drawable.RotateRight_Active);
			control5.SetImageResource (Resource.Drawable.Move3_Active);

			Boolean control1_active = true;
			Boolean control2_active = false;
			Boolean control3_active = false;
			Boolean control4_active = true;
			Boolean control5_active = true;

			// Handle all user controlbuttons for the game
			control1.Click += delegate {
				if (control1_active == true) {
					Toast.MakeText (this, "Robot verplaatst naar voren", ToastLength.Short).Show();
				} else {
					Toast.MakeText (this, "Speelkaart is niet beschikbaar", ToastLength.Short).Show();
				}

				if (_random.Next (0, 8) <= 3) {
					control1_active = false;
					control1.SetImageResource (Resource.Drawable.Move3_Inactive);
				} else {
					control1_active = true;
					control1.SetImageResource (Resource.Drawable.Move3_Active);
				}
			};

			control2.Click += delegate {
				if (control2_active == true) {
					Toast.MakeText (this, "Robot verplaatst naar voren", ToastLength.Short).Show();
				} else {
					Toast.MakeText (this, "Speelkaart is niet beschikbaar", ToastLength.Short).Show();
				}

				if (_random.Next (0, 8) <= 3) {
					control2_active = false;
					control2.SetImageResource (Resource.Drawable.Move3_Inactive);
				} else {
					control2_active = true;
					control2.SetImageResource (Resource.Drawable.Move3_Active);
				}
			};

			control3.Click += delegate {
				if (control3_active == true) {
					Toast.MakeText (this, "Robot verplaatst naar achter", ToastLength.Short).Show();
				} else {
					Toast.MakeText (this, "Speelkaart is niet beschikbaar", ToastLength.Short).Show();
				}

				if (_random.Next (0, 6) <= 4) {
					control3_active = false;
					control1.SetImageResource (Resource.Drawable.Move3_Inactive);
				} else {
					control3_active = true;
					control3.SetImageResource (Resource.Drawable.Move3_Active);
				}
			};

			control4.Click += delegate {
				if (control4_active == true) {
					Toast.MakeText (this, "Robot draait naar rechts", ToastLength.Short).Show();
				} else {
					Toast.MakeText (this, "Speelkaart is niet beschikbaar", ToastLength.Short).Show();
				}

				if (_random.Next (0, 10) <= 4) {
					control4_active = false;
					control4.SetImageResource (Resource.Drawable.RotateRight_Inactive);
				} else {
					control4_active = true;
					control4.SetImageResource (Resource.Drawable.RotateRight_Active);
				}
			};

			control5.Click += delegate {
				if (control5_active == true) {
					Toast.MakeText (this, "Robot verplaatst naar voren", ToastLength.Short).Show();
				} else {
					Toast.MakeText (this, "Speelkaart is niet beschikbaar", ToastLength.Short).Show();
				}

				if (_random.Next (0, 6) <= 2) {
					control5_active = false;
					control5.SetImageResource (Resource.Drawable.Move3_Inactive);
				} else {
					control5_active = true;
					control5.SetImageResource (Resource.Drawable.Move3_Active);
				}
			};

			forceFinish.Click += delegate {
				if (_random.Next (0, 1) == 0)
				{
					resultMessage("U heeft verloren!");
				}
				else if (_random.Next (0, 1) == 1)
				{
					resultMessage("U heeft gewonnen");
				}
			};
		}
	}
}
