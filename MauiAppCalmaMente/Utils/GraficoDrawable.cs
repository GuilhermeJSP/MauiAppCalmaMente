using MauiAppCalmaMente.ViewModels;
using Microsoft.Maui.Graphics;
using System.Linq;

namespace MauiAppCalmaMente.Utils;

public class GraficoDrawable : IDrawable
{
    private readonly MainViewModel vm;

    public GraficoDrawable(MainViewModel vm)
    {
        this.vm = vm;
    }

    public void Draw(ICanvas canvas, RectF dirtyRect)
    {
        var dados = vm.Humores.OrderBy(h => h.Data).ToList();

        if (dados.Count < 2) return;

        float largura = dirtyRect.Width;
        float altura = dirtyRect.Height;
        float passo = largura / (dados.Count - 1);

        canvas.StrokeColor = Colors.Blue;
        canvas.StrokeSize = 3;

        for (int i = 0; i < dados.Count - 1; i++)
        {
            float x1 = i * passo;
            float x2 = (i + 1) * passo;

            float y1 = dados[i].Estado == "Feliz" ? altura * 0.3f : altura * 0.7f;
            float y2 = dados[i + 1].Estado == "Feliz" ? altura * 0.3f : altura * 0.7f;

            canvas.DrawLine(x1, y1, x2, y2);
        }
    }
}