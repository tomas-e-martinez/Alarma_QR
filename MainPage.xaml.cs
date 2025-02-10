#if ANDROID
using Android.App;
using Android.Content;
using Android.Widget;
#endif
using Microsoft.Maui.Controls.PlatformConfiguration;
using System.Threading.Tasks;

namespace AlarmaQR
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void ScanClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ScanPage());
        }

        private void ProgramarAlarma(object sender, EventArgs e)
        {
#if ANDROID
            var context = Android.App.Application.Context;
            var alarmManager = (AlarmManager)context.GetSystemService(Context.AlarmService);

            Intent intent = new Intent(context, typeof(AlarmReceiver));
            PendingIntent pendingIntent = PendingIntent.GetBroadcast(context, 0, intent, PendingIntentFlags.UpdateCurrent);

            long triggerTime = Java.Lang.JavaSystem.CurrentTimeMillis() + 5000; // 5 segundos

            alarmManager.SetExact(AlarmType.RtcWakeup, triggerTime, pendingIntent);

            Toast.MakeText(context, "Alarma programada", ToastLength.Short).Show();
#else
            // Para evitar errores en Windows o iOS, el método existe pero no hace nada
            DisplayAlert("Alarma", "Esta función solo está disponible en Android.", "OK");
#endif
        }

    }

}
