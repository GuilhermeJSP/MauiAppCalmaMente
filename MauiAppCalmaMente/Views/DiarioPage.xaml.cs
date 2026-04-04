using MauiAppCalmaMente.ViewModels;

namespace MauiAppCalmaMente.Views;

public partial class DiarioPage : ContentPage
{
    MainViewModel vm = new();

    public DiarioPage()
    {
        InitializeComponent();
    }

    private async void OnSalvar(object sender, EventArgs e)
    {
        await vm.AddDiario(texto.Text);
        texto.Text = "";
    }
}