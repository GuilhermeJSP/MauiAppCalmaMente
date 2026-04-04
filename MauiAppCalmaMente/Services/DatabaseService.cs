using SQLite;
using MauiAppCalmaMente.Models;

namespace MauiAppCalmaMente.Services;

public class DatabaseService
{
    private readonly SQLiteAsyncConnection _db;

    public DatabaseService(string dbPath)
    {
        _db = new SQLiteAsyncConnection(dbPath);
        _db.CreateTableAsync<Humor>().Wait();
        _db.CreateTableAsync<Diario>().Wait();
    }

    public Task<int> SalvarHumor(Humor humor) => _db.InsertAsync(humor);
    public Task<List<Humor>> GetHumores() => _db.Table<Humor>().ToListAsync();

    public Task<int> SalvarDiario(Diario diario) => _db.InsertAsync(diario);
    public Task<List<Diario>> GetDiarios() => _db.Table<Diario>().ToListAsync();

    public Task<int> DeletarDiario(int id) => _db.DeleteAsync<Diario>(id);
}