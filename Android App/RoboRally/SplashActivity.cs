namespace SplashScreen
{
    using System.Threading;

    using Android.App;
    using Android.OS;
    using RoboRally;

    [Activity(Theme = "@style/Theme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Simulate a loading process on app startup.
            Thread.Sleep(750); // 0.75 seconds
            
            // Start the MainActivity (referenced to RoboRally)
			StartActivity(typeof(LoginActivity));
        }
    }
}