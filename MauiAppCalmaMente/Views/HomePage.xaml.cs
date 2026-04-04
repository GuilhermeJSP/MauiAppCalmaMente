using Microsoft.Maui.Controls;

namespace MauiAppCalmaMente.Views;

public partial class HomePage : ContentPage
{
    bool animando = false;

    public HomePage()
    {
        InitializeComponent();
    }

    private async void OnRespirar(object sender, EventArgs e)
    {
        if (animando) return;
        animando = true;

        while (animando)
        {
            await circulo.ScaleTo(1.5, 4000);
            await circulo.ScaleTo(1, 4000);
        }
    }

    private async void OnEmergencia(object sender, EventArgs e)
    {
        await DisplayAlert("Respire", "Pare. Respire fundo. Você está seguro.", "OK");
    }
}