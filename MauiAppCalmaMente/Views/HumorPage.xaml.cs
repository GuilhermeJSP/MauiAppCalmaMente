using MauiAppCalmaMente.Utils;
using MauiAppCalmaMente.ViewModels;

namespace MauiAppCalmaMente.Views;

public partial class HumorPage : ContentPage
{
    MainViewModel vm = new();

    public HumorPage()
    {
        InitializeComponent();

        grafico.Drawable = new GraficoDrawable(vm);

        this.Appearing += async (s, e) =>
        {
            await vm.Load();
            grafico.Invalidate();
        };
    }

    private async void OnFeliz(object sender, EventArgs e)
    {
        await vm.AddHumor("Feliz");
        grafico.Invalidate();
    }

    private async void OnTriste(object sender, EventArgs e)
    {
        await vm.AddHumor("Triste");
        grafico.Invalidate();
    }
}