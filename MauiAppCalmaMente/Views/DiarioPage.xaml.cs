using MauiAppCalmaMente.ViewModels;

namespace MauiAppCalmaMente.Views;

public partial class DiarioPage : ContentPage
{
    // Instancia o ViewModel responsável pela lógica do diário
    MainViewModel vm = new();

    public DiarioPage()
    {
        InitializeComponent();

        // Remove a barra de navegação superior padrão do MAUI
        NavigationPage.SetHasNavigationBar(this, false);

        // Carrega as entradas do diário salvas no banco de dados
        Carregar();
    }

    // Busca as entradas do diário no banco e popula a lista na tela
    private async void Carregar()
    {
        await vm.Load();
        listaDiario.ItemsSource = vm.Diarios;
    }

    // Salva uma nova entrada no diário ao clicar no botão Salvar
    private async void OnSalvar(object sender, EventArgs e)
    {
        // Valida se o campo de texto não está vazio
        if (string.IsNullOrWhiteSpace(texto.Text))
        {
            await DisplayAlert("Erro", "Diário vazio!", "OK");
            return;
        }

        await vm.AddDiario(texto.Text);

        // Limpa o campo de texto após salvar
        texto.Text = "";
        Carregar();
    }

    // Apaga uma entrada do diário pelo Id ao clicar no botão Apagar
    private async void OnApagar(object sender, EventArgs e)
    {
        var btn = sender as Button;
        int id = (int)btn.CommandParameter;

        await vm.DeleteDiario(id);
        Carregar();
    }

    // Abre um prompt para editar o texto de uma entrada existente
    private async void OnEditar(object sender, EventArgs e)
    {
        var btn = sender as Button;
        int id = (int)btn.CommandParameter;

        // Busca a entrada atual para preencher o campo com o texto existente
        var diarioAtual = vm.Diarios.FirstOrDefault(d => d.Id == id);
        if (diarioAtual == null) return;

        // Exibe o prompt de edição com o texto atual preenchido
        string novoTexto = await DisplayPromptAsync(
            "Editar Diário",
            "Altere o texto:",
            initialValue: diarioAtual.Texto,
            maxLength: 500,
            keyboard: Keyboard.Text
        );

        // Cancela se o usuário não digitou nada
        if (string.IsNullOrWhiteSpace(novoTexto)) return;

        await vm.EditarDiario(id, novoTexto);
        Carregar();
    }

    // Navega para a tela inicial
    private async void OnInicioClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new InicioPage("")); // <- InicioPage exige o nome do usuário
    }

    // Navega para a tela de Respiração
    private async void OnRespiraClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RespirePage());
    }

    // Já está na página — recarrega a lista ao clicar novamente em Diário
    private async void OnDiarioClicked(object sender, EventArgs e)
    {
        Carregar();
    }
}
