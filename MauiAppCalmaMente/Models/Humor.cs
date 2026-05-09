using SQLite;

namespace MauiAppCalmaMente.Models;

public class Humor
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public string Rotulo { get; set; }
    public string Emoji { get; set; }
    public string Estado { get; set; }
}
