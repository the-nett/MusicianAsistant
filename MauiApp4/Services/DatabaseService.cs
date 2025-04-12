using SQLite;
using MauiApp4.Models;
using MauiApp4.Constants;

namespace MauiApp4.Services
{
    public class DatabaseService
    {
        SQLiteAsyncConnection database;

        async Task Init()
        {
            if (database is not null)
                return;

            database = new SQLiteAsyncConnection(AppConstants.DatabasePath, AppConstants.Flags);
            var result = await database.CreateTableAsync<Gender>();
        }
        public async Task<List<Gender>> GetGendersAsync()
        {
            await Init();
            return await database.Table<Gender>().ToListAsync();
        }

        public async Task SaveGendersAsync(IEnumerable<Gender> genders)
        {
            await Init();
            await database.DeleteAllAsync<Gender>(); // Clear old data
            await database.ExecuteAsync("DELETE FROM sqlite_sequence WHERE name = ?", nameof(Gender));
            await database.InsertAllAsync(genders);  // Insert new data
        }

    }
}
