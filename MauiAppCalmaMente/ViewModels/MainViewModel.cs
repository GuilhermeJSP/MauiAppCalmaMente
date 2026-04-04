using MauiAppCalmaMente.Models;
using System.Collections.ObjectModel;

namespace MauiAppCalmaMente.ViewModels;

public class MainViewModel
{
    public ObservableCollection<Humor> Humores { get; set; } = new();
    public ObservableCollection<Diario> Diarios { get; set; } = new();

    public async Task Load()
    {
        var humores = await App.Database.GetHumores();
        Humores.Clear();
        foreach (var h in humores)
            Humores.Add(h);

        var diarios = await App.Database.GetDiarios();
        Diarios.Clear();
        foreach (var d in diarios)
            Diarios.Add(d);
    }

    public async Task AddHumor(string estado)
    {
        var h = new Humor { Data = DateTime.Now, Estado = estado };
        await App.Database.SalvarHumor(h);
        Humores.Add(h);
    }

    public async Task AddDiario(string texto)
    {
        var d = new Diario { Data = DateTime.Now, Texto = texto };
        await App.Database.SalvarDiario(d);
        Diarios.Add(d);
    }
}