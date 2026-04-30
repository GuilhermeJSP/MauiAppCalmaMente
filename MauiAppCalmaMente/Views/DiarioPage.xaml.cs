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
        NavigationPage.SetHasNavigationBar(this, false);
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

    private async void OnEditar(object sender, EventArgs e)
    {
        var btn = sender as Button;
        int id = (int)btn.CommandParameter;

        // Busca o diário atual para mostrar o texto existente
        var diarioAtual = vm.Diarios.FirstOrDefault(d => d.Id == id);
        if (diarioAtual == null) return;

        // Abre um prompt para o usuário digitar o novo texto
        string novoTexto = await DisplayPromptAsync(
            "Editar Diário",
            "Altere o texto:",
            initialValue: diarioAtual.Texto,
            maxLength: 500,
            keyboard: Keyboard.Text
        );

        if (string.IsNullOrWhiteSpace(novoTexto)) return;

        await vm.EditarDiario(id, novoTexto);
        Carregar();
    }

}
