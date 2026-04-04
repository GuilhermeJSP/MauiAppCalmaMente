using MauiAppCalmaMente.ViewModels;

namespace MauiAppCalmaMente.Views;

public partial class HumorPage : ContentPage
{
    MainViewModel vm = new();

    public HumorPage()
    {
        InitializeComponent();
    }

    private async void OnFeliz(object sender, EventArgs e)
    {
        await vm.AddHumor("Feliz");
    }

    private async void OnTriste(object sender, EventArgs e)
    {
        await vm.AddHumor("Triste");
    }
}
