using Android.App;
using Android.OS;

namespace Taxi.Prism.Droid
{
    [Activity(
        Theme = "@style/Theme.Splash",//actividad utiliza tema splash
        MainLauncher = true,//solo una en true xq inicia
        NoHistory = true)]//deshabilita boton atras
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            System.Threading.Thread.Sleep(1800);//dormir app dura 1.8 seg
            StartActivity(typeof(MainActivity));
        }
    }
}