using MauiAppCalmaMente.Models;

namespace MauiAppCalmaMente.Views;

public partial class ConteudosPage : ContentPage
{
    public List<Video> Videos { get; set; }

    public ConteudosPage()
    {
        InitializeComponent();

        Videos = new List<Video>
        {
            new Video
            {
                Titulo = "Respiração Profunda Guiada",
                Duracao = "2:06",
                Descricao = "Exercício guiado para reduzir ansiedade.",
                Imagem = "praia.jpg",
                Url = "respiracaoguiada.mp4"
            },

            new Video
            {
                Titulo = "Sons da Natureza",
                Duracao = "5:25",
                Descricao = "Sons relaxantes da natureza.",
                Imagem = "natureza.jpg",
                Url = "natureza.mp4"
            },

            new Video
            {
                Titulo = "Meditação do Sono",
                Duracao = "3:22",
                Descricao = "Ajuda a dormir melhor.",
                Imagem = "meditacao.jpg",
                Url = "meditacaosono.mp4"
            },

            new Video
            {
                Titulo = "Relaxamento para dormir bem",
                Duracao = "18:19",
                Descricao = "Caminhando por uma floresta e refletindo.",
                Imagem = "plantas.jpg",
                Url = "dormirbem.mp4"
            },

            new Video
            {
                Titulo = "Passeio reflexivo",
                Duracao = "10:57",
                Descricao = "Veja como a natureza é bela.",
                Imagem = "cidade.jpg",
                Url = "passeiofloresta.mp4"
            },

            new Video
            {
                Titulo = "Sons da noitada",
                Duracao = "15:43",
                Descricao = "Sons da noite.",
                Imagem = "noite.jpg",
                Url = "sonsnoite.mp4"
            },
        };

        BindingContext = this;
    }

    // Navega para a tela inicial
    private async void OnInicioClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new InicioPage("")); // <- InicioPage agora exige o nome
    }

    // Navega para a tela do Diário
    private async void OnDiarioClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    // Navega de volta para a tela Respira
    private async void OnRespiraClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RespirePage());
    }
    // Clique para acessar os vídeos
    private async void VideoTapped(object sender, TappedEventArgs e)
    {
        var video = e.Parameter as Video;

        if (video != null)
        {
            await Navigation.PushAsync(new VideoPlayerPage(video.Url));
        }
    }
}