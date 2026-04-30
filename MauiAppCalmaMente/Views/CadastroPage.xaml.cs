using MauiAppCalmaMente.Models;
namespace MauiAppCalmaMente.Views;
public partial class CadastroPage : ContentPage
{
    public CadastroPage()
    {
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
    }

    private async void OnCadastrar(object sender, EventArgs e)
    {
        string usuario = entryUsuario.Text;
        string senha = entrySenha.Text;
        string confirmar = entryConfirmarSenha.Text;

        if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(senha) || string.IsNullOrWhiteSpace(confirmar))
        {
            await DisplayAlert("Atenção", "Preencha todos os campos!", "OK");
            return;
        }

        if (senha != confirmar)
        {
            await DisplayAlert("Erro", "As senhas não coincidem!", "OK");
            return;
        }

        var existe = await App.Database.UsuarioExiste(usuario);
        if (existe != null)
        {
            await DisplayAlert("Erro", "Esse usuário já existe!", "OK");
            return;
        }

        await App.Database.CriarUsuario(new Usuario { Nome = usuario, Senha = senha });
        await DisplayAlert("Sucesso", "Conta criada com sucesso!", "OK");
        await Navigation.PopAsync();
    }

    private async void OnVoltarLogin(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}