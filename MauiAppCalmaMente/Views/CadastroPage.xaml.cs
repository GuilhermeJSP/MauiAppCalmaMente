using MauiAppCalmaMente.Models;
namespace MauiAppCalmaMente.Views;
public partial class CadastroPage : ContentPage
{
    public CadastroPage()
    {
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
        //Remove a quela barra feia do começo.
    }

    private async void OnCadastrar(object sender, EventArgs e)
     //Evento que conultara os valores preenchidos e cadastrará no banco de dados
    {
        string usuario = entryUsuario.Text;
        string senha = entrySenha.Text;
        string confirmar = entryConfirmarSenha.Text;
        //Valores de entrada para realizar o cadastro dos dados no banco.

        //Condições que verificarão os campos vazios e retornarão uma mensagem de acordo com
        // o preenchimento dos campos. 
        
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

        //Este trecho verifica se o usuario já existe no banco 
        var existe = await App.Database.UsuarioExiste(usuario);
        if (existe != null)
        {
            await DisplayAlert("Erro", "Esse usuário já existe!", "OK");
            return;
        }

        //Cria efetivamente o Usuario
        await App.Database.CriarUsuario(new Usuario { Nome = usuario, Senha = senha });
        await DisplayAlert("Sucesso", "Conta criada com sucesso!", "OK");
        await Navigation.PopAsync();
    }

    //Apos a criação do usuario ele retornara a tela de login..
    private async void OnVoltarLogin(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}
