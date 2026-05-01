using MauiAppCalmaMente.Models;

namespace MauiAppCalmaMente.Views;

public partial class InicioPage : ContentPage
{
    // Armazena o nome do usuário logado para exibir na saudação
    private string _nomeUsuario;

    public InicioPage(string nomeUsuario)
    {
        InitializeComponent();

        // Remove a barra de navegação superior padrão do MAUI
        NavigationPage.SetHasNavigationBar(this, false);

        // Recebe e exibe o nome do usuário logado no label de saudação
        _nomeUsuario = nomeUsuario;
        lblSaudacao.Text = $"Olá, {_nomeUsuario}!";

        // Carrega os registros de humor salvos no banco de dados
        CarregarHumores();
    }

    // Busca os humores no banco e insere a lista na tela
    private async void CarregarHumores()
    {
        var humores = await App.Database.GetHumores();

        // Ordena do mais recente para o mais antigo,
        // pega os 10 últimos e transforma para exibição na lista
        var lista = humores
            .OrderByDescending(h => h.Data)
            .Take(10)
            .Select(h => new Humor
            {
                Id = h.Id,
                Data = h.Data,
                Rotulo = ObterRotulo(h.Data), // "Hoje", "Ontem" ou a data formatada
                Emoji = ObterEmoji(h.Estado), // Emoji correspondente ao estado
                Estado = h.Estado
            }).ToList();

        listaHumor.ItemsSource = lista;
    }

    // Apaga um registro de humor específico pelo Id
    private async void OnApagarHumor(object sender, EventArgs e)
    {
        var btn = sender as Button;
        int id = (int)btn.CommandParameter;

        // Pede confirmação antes de apagar
        bool confirmar = await DisplayAlert(
            "Apagar",
            "Deseja apagar este registro de humor?",
            "Sim", "Não"
        );

        if (!confirmar) return;

        await App.Database.DeletarHumor(id);
        CarregarHumores();
    }

    // Retorna um rótulo legível para a data:
    // "Hoje", "Ontem" ou a data no formato dd/MM/yyyy
    private string ObterRotulo(DateTime data)
    {
        var hoje = DateTime.Today;
        if (data.Date == hoje) return "Hoje";
        if (data.Date == hoje.AddDays(-1)) return "Ontem";
        return data.ToString("dd/MM/yyyy");
    }

    // Retorna o emoji  de acordo com o estado emocional registrado
    private string ObterEmoji(string estado) => estado switch
    {
        "Muito bem" => "😄",
        "Bem" => "🙂",
        "Neutro" => "😐",
        "Mal" => "😟",
        "Muito mal" => "😣",
        _ => "😐" // Padrão caso o estado não seja reconhecido
    };

    // Registra um novo humor no banco ao clicar em um dos emojis
    private async void OnHumorClicked(object sender, EventArgs e)
    {
        var btn = sender as Button;
        string estado = btn.CommandParameter.ToString();

        // Cria e salva o registro com o estado(emoção) e a data/hora atual
        var humor = new Humor { Data = DateTime.Now, Estado = estado };
        await App.Database.SalvarHumor(humor);

        await DisplayAlert("Registrado!", $"Humor '{estado}' salvo com sucesso", "OK");
        CarregarHumores();
    }

    // Evento gerado ao clicar no botão, redireciona para a tela do Diário
    private async void OnDiarioClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new DiarioPage());
    }

    // Evento gerado ao clicar no botão, redireciona para a tela de Respiração
    private async void OnRespiraClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RespirePage());
    }

    // Evento gerado ao clicar no botão, redireciona para a tela Sobre Nós
    private async void OnSobreNosClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SobreNosPage());
    }

    // Apaga todos os registros de humor do banco de dados
    private async void OnLimparTudo(object sender, EventArgs e)
    {
        // Pede confirmação antes de limpar tudo
        bool confirmar = await DisplayAlert(
            "Limpar Tudo",
            "Deseja apagar todos os registros de humor?",
            "Sim", "Não"
        );

        if (!confirmar) return;

        await App.Database.LimparHumores();
        CarregarHumores();
    }
}
