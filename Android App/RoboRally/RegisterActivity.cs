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

using RoboRally;

namespace RoboRally
{
	[Activity (Label = "RegisterActivity", Theme = "@android:style/Theme.DeviceDefault.NoActionBar.Fullscreen", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]	
	public class RegisterActivity : Activity
	{

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "login" layout resource
			SetContentView(Resource.Layout.Register);
			this.Window.AddFlags(WindowManagerFlags.Fullscreen);

			// Set our main logo for the app
			ImageView logo = FindViewById<ImageView> (Resource.Id.mainLogo);
			logo.SetImageResource (Resource.Drawable.rr_logo);

			// Get our button from the layout resource,
			// and attach an event to it
			Button registerButton = FindViewById<Button> (Resource.Id.registerButton);
			Button accountButton = FindViewById<Button> (Resource.Id.accountButton);
			EditText firstName = FindViewById<EditText> (Resource.Id.firstName);
			EditText lastName = FindViewById<EditText> (Resource.Id.lastName);
			EditText userName = FindViewById<EditText> (Resource.Id.userName);
			EditText userPass = FindViewById<EditText> (Resource.Id.userPass);
			EditText userPassVerify = FindViewById<EditText> (Resource.Id.userPassVerify);
			TextView errorHandler = FindViewById<TextView> (Resource.Id.errorHandler);

			// Handle the register button, when it gets clicked
			registerButton.Click += delegate
			{
				// Check if the user entered all the fields correctly
				if (firstName.Text.Length < 2  || firstName.Text.Length > 24)
				{
					errorHandler.Text = "Oops! U heeft geen geldige voornaam ingevoerd."; // Show a quick error message
				}
				else if (lastName.Text.Length < 3 || lastName.Text.Length > 24)
				{
					errorHandler.Text = "Oops! U heeft geen geldige achternaam ingevoerd."; // Show a quick error message
				}
				else if (userName.Text.Length < 2 || userName.Text.Length > 14)
				{
					errorHandler.Text = "Oops! De gekozen gebruiksnaam is niet toegestaan."; // Show a quick error message
				}
				else if (userPass.Text.Length < 6)
				{
					errorHandler.Text = "Oops! Uw wachtwoord moet uit minimaal 6 karakters bestaan."; // Show a quick error message
				}
				else if (userPassVerify.Text != userPass.Text)
				{
					errorHandler.Text = "Oops! De wachtwoorden zijn niet gelijk aan elkaar."; // Show a quick error message
				}
				else if ((firstName.Text.Length > 1 || firstName.Text.Length < 25) || (lastName.Text.Length > 2 || lastName.Text.Length < 25) || (userName.Text.Length > 1 || userName.Text.Length < 15) || (userPass.Text.Length > 5) || (userPassVerify.Text == userPass.Text))
				{
					errorHandler.Text = ""; // Clear the errorHandler

					// Pass user data onto MenuActivity
					var usersNameData = new Intent (this, typeof(MenuActivity)); // Create an intent for MenuActivity, giving it the name usersNameData
					usersNameData.PutExtra ("UsernameData", userName.Text); // Adding a name and a value to the Intent

					// Start the MenuActivity based on the "Intent"
					StartActivity(usersNameData);
				}
				else
				{
					errorHandler.Text = "Er is een onverwachte fout onstaan."; // Unexpected error
				}
			};

			// Handle the account button, when it gets clicked
			accountButton.Click += delegate
			{
				// Start the LoginActivity, so the user can login to their account
				StartActivity(typeof(LoginActivity));
			};
		}
	}
}

