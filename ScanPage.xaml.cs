using ZXing;
using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;


namespace AlarmaQR;

public partial class ScanPage : ContentPage
{
	public ScanPage()
	{
		InitializeComponent();
	}

	private async void OnScanResult(object sender, Result result)
    {
        // Detenemos el escaneo una vez que hemos capturado el QR
        cameraView.IsDetecting = false;

        // Muestra un mensaje con el resultado
        await DisplayAlert("QR Escaneado", result.Text, "OK");

        // Aqu� puedes agregar la l�gica para manejar el contenido escaneado, como navegar a otra p�gina, etc.
    }

    private async void OnBackClicked(object sender, EventArgs e)
	{
		await Navigation.PopAsync();
	}
}