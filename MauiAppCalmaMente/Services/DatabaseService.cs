using MauiAppCalmaMente.Models;
using SQLite;

namespace MauiAppCalmaMente.Services;

public class DatabaseService
{
    private readonly SQLiteAsyncConnection _db;

    public DatabaseService(string dbPath)
    {
        _db = new SQLiteAsyncConnection(dbPath);
        _db.CreateTableAsync<Humor>().Wait();
        _db.CreateTableAsync<Diario>().Wait();
        _db.CreateTableAsync<Usuario>().Wait();
    }

    public Task<int> SalvarHumor(Humor humor) => _db.InsertAsync(humor);
    public Task<List<Humor>> GetHumores() => _db.Table<Humor>().ToListAsync();

    public Task<int> SalvarDiario(Diario diario) => _db.InsertAsync(diario);
    public Task<List<Diario>> GetDiarios() => _db.Table<Diario>().ToListAsync();

    public Task<int> DeletarDiario(int id) => _db.DeleteAsync<Diario>(id);

    public Task<int> EditarDiario(Diario diario)
    {
        return _db.UpdateAsync(diario);
    }

    // Adicione esses métodos
    public Task<Usuario?> BuscarUsuario(string nome, string senha)
    {
        return _db.Table<Usuario>()
            .FirstOrDefaultAsync(u => u.Nome == nome && u.Senha == senha);
    }

    public Task<int> CriarUsuario(Usuario usuario)
    {
        return _db.InsertAsync(usuario);
    }

    public Task<Usuario?> UsuarioExiste(string nome)
    {
        return _db.Table<Usuario>()
            .FirstOrDefaultAsync(u => u.Nome == nome);
    }

    public async Task<int> DeletarHumor(int id)
    {
        var humor = await _db.Table<Humor>().FirstOrDefaultAsync(h => h.Id == id);
        if (humor != null)
            return await _db.DeleteAsync(humor);
        return 0;
    }

    public async Task<int> LimparHumores()
    {
        return await _db.DeleteAllAsync<Humor>();
    }
}
