using CommunityToolkit.Maui.Views;

namespace MauiAppCalmaMente.Views;

public partial class VideoPlayerPage : ContentPage
{
    public VideoPlayerPage(string videoUrl)
    {
        InitializeComponent();
        videoPlayer.Source = MediaSource.FromResource(videoUrl);
    }

    // Para e limpa quando sair da página
    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        videoPlayer.Stop();
        videoPlayer.Source = null;
        videoPlayer.Handler?.DisconnectHandler();
    }
}