namespace MauiAppCalmaMente.Views;
public partial class Login : ContentPage
{
    public Login()
    {
        InitializeComponent();

        //Remove a barra mais escura presente na parte superior do app
        NavigationPage.SetHasNavigationBar(this, false);

    }

    private async void OnEntrar(object sender, EventArgs e)
    {
        //Coleta os dados inseridos nas caixas de senha e usuario
        string usuario = entryUsuario.Text;
        string senha = entrySenha.Text;


        //Verifica se os campos foram preenchidos 
        if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(senha))
        {
            await DisplayAlert("Atenção", "Preencha todos os campos!", "OK");
            return;
        }

        //Consulta o banco de dados para ver se o usuario e a senha existem.
        var usuarioEncontrado = await App.Database.BuscarUsuario(usuario, senha);
        if (usuarioEncontrado != null)
        {

            //se encontrar o usuario ele redireciona para a tela de inicio.
            await Navigation.PushAsync(new InicioPage(usuarioEncontrado.Nome));
        }
        else
        {
            await DisplayAlert("Erro", "Usuário ou senha incorretos!", "OK");
        }
    }

    //Redireciona para a tela de criação de um novo usuario.
    private async void OnCadastrar(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CadastroPage());
    }


}
