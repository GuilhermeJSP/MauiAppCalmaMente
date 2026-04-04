using SQLite;

namespace MauiAppCalmaMente.Models;

public class Diario
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public string Texto { get; set; }
}