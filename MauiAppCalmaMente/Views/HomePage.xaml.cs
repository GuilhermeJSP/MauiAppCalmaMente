namespace MauiAppCalmaMente.Views;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
    }

    private async void OnRespirar(object sender, EventArgs e)
    {
        await DisplayAlert("Respiração", "Inspire... Segure... Expire...", "OK");
    }
}