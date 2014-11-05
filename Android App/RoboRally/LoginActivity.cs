using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Android.Content.PM; // Used to prevent rotation
using Android.Media; // Used to access the media player

namespace RoboRally
{
	[Activity(Label = "RoboRally", MainLauncher = false, Icon = "@drawable/icon", Theme = "@android:style/Theme.DeviceDefault.NoActionBar.Fullscreen", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class LoginActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
			base.OnCreate (bundle);

			// Create a mediaplayer for the theme music
			MediaPlayer _themeMusic = MediaPlayer.Create(this, Resource.Raw.Sneak); // Selected music to play in this instance
			_themeMusic.Start(); // Start the music player
			//_themeMusic.Stop(); // Stop the music player

            // Set our view from the "login" layout resource
            SetContentView(Resource.Layout.Login);
            this.Window.AddFlags(WindowManagerFlags.Fullscreen);

            // Set our main logo for the app
            ImageView logo = FindViewById<ImageView> (Resource.Id.mainLogo);
            logo.SetImageResource (Resource.Drawable.rr_logo);

			// Get our views from the layout resource,
            // and attach an event to it
            Button loginButton = FindViewById<Button> (Resource.Id.loginButton);
			Button registerButton = FindViewById<Button> (Resource.Id.registerButton);
			EditText userName = FindViewById<EditText> (Resource.Id.userName);
			EditText userPass = FindViewById<EditText> (Resource.Id.userPass);
			TextView errorHandler = FindViewById<TextView> (Resource.Id.errorHandler);

			// Handle the login button, when it gets clicked
			loginButton.Click += delegate
			{
				// Check if the user is adding valid information
				if ((userName.Text.Length < 2 || userName.Text.Length > 14) || (userPass.Text.Length < 6))
				{
					errorHandler.Text = "Oops! Niet alle login gegevens zijn ingevoerd.";
				}
				else if ((userName.Text.Length > 1 || userName.Text.Length < 15) || (userPass.Text.Length > 5))
				{
					errorHandler.Text = "";

					// Pass user data onto MenuActivity
					var usersNameData = new Intent (this, typeof(MenuActivity)); // Create an intent for MenuActivity, giving it the name usersNameData
					usersNameData.PutExtra ("UsernameData", userName.Text); // Adding a name and a value to the Intent

					// Start the MenuActivity based on the "Intent"
					StartActivity(usersNameData);
				}
			};

			// Handle the register button, when it gets clicked
			registerButton.Click += delegate
			{
				// Start the RegiserActivity, so the user can create an account
				StartActivity(typeof(RegisterActivity));
			};
        }
	}
}

