namespace MauiAppCalmaMente.Views;

public partial class RespirePage : ContentPage
{
    // Controla se a animação de respiração está em execução
    bool animando = false;

    public RespirePage()
    {
        InitializeComponent();

        // Remove a barra de navegação superior padrão do MAUI
        NavigationPage.SetHasNavigationBar(this, false);
    }

    // Inicia a animação de respiração guiada ao clicar no botão
    private async void OnRespirar(object sender, EventArgs e)
    {
        // Evita iniciar múltiplas animações simultaneamente
        if (animando) return;

        animando = true;

        // Expande e contrai o círculo continuamente simulando a respiração
        while (animando)
        {
            await circulo.ScaleTo(1.5, 4000); // Inspira: expande em 4 segundos
            await circulo.ScaleTo(1, 4000);   // Expira: contrai em 4 segundos
        }
    }

    // Exibe mensagem de apoio ao clicar no botão de emergência
    private async void OnEmergencia(object sender, EventArgs e)
    {
        await DisplayAlert("Respire", "Pare. Respire fundo. Você está seguro.", "OK");
    }

    // Navega para a tela inicial
    private async void OnInicioClicked(object sender, EventArgs e)
    {
        animando = false; // Para a animação antes de navegar
        await Navigation.PushAsync(new InicioPage("")); // <- InicioPage agora exige o nome
    }

    // Navega para a tela do Diário
    private async void OnDiarioClicked(object sender, EventArgs e)
    {
        animando = false; // Para a animação antes de navegar
        await Navigation.PushAsync(new DiarioPage());
    }

    // Já está na página — apenas para a animação ao clicar novamente em Respira
    private async void OnRespiraClicked(object sender, EventArgs e)
    {
        animando = false;
        await circulo.ScaleTo(1, 300); // Retorna o círculo ao tamanho original suavemente
    }

    // Navega para a tela Sobre Nós
    private async void OnSobreNosClicked(object sender, EventArgs e)
    {
        animando = false; // Para a animação antes de navegar
        await Navigation.PushAsync(new SobreNosPage());
    }
}
