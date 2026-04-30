namespace MauiAppCalmaMente.Views;
public partial class Login : ContentPage
{
    public Login(){
        InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
            }

private async void OnEntrar(object sender, EventArgs e)
    {
        string usuario = entryUsuario.Text;
        string senha = entrySenha.Text;

        if (string.IsNullOrWhiteSpace(usuario) || string.IsNullOrWhiteSpace(senha))
        {
            await DisplayAlert("Atenção", "Preencha todos os campos!", "OK");
            return;
        }

        // Por enquanto valida usuário fixo — depois pode conectar ao banco!
        if (usuario == "admin" && senha == "1234")
        {
            await Navigation.PushAsync(new InicioPage());
        }
        else
        {
            await DisplayAlert("Erro", "Usuário ou senha incorretos!", "OK");
        }
    }
    private async void OnCadastrar(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new CadastroPage());
    }

}
