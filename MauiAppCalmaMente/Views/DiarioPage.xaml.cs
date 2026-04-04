using Microsoft.Maui.Controls;
using MauiAppCalmaMente.ViewModels;

namespace MauiAppCalmaMente.Views;

public partial class DiarioPage : ContentPage
{
    MainViewModel vm = new();

    public DiarioPage()
    {
        InitializeComponent();
        Carregar();
    }

    private async void Carregar()
    {
        await vm.Load();
        listaDiario.ItemsSource = vm.Diarios;
    }

    private async void OnSalvar(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(texto.Text))
        {
            await DisplayAlert("Erro", "Diário vazio!", "OK");
            return;
        }

        await vm.AddDiario(texto.Text);
        texto.Text = "";
        Carregar();
    }

    private async void OnApagar(object sender, EventArgs e)
    {
        var btn = sender as Button;
        int id = (int)btn.CommandParameter;

        await vm.DeleteDiario(id);
        Carregar();
    }
}