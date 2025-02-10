using AlarmaQR;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

[BroadcastReceiver(Enabled = true, Exported = false)]
public class AlarmReceiver : BroadcastReceiver
{
    public override void OnReceive(Context context, Intent intent)
    {
        Toast.MakeText(context, "¡Alarma activada! Escanea el código QR.", ToastLength.Long).Show();

        // Abrir la actividad de escaneo de QR al sonar la alarma
        Intent scanIntent = new Intent(context, typeof(MainActivity));
        scanIntent.SetFlags(ActivityFlags.NewTask);
        context.StartActivity(scanIntent);
    }
}
