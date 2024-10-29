using System.Collections.ObjectModel;
using Echo_Replica.Core.Entities;
using Echo_Replica.Core.Interfaces.Repositories;
using Microsoft.Data.Sqlite;

namespace Echo_Replica.Infrastructure.Repositories;

public class WordRepository : IWordRepository
{
    private readonly SqliteContext _context;

    public WordRepository(SqliteContext context)
    {
        _context = context;
    }

    public Task<Word> GetWord(string word)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyCollection<Word>> GetAllWords()
    {
        throw new NotImplementedException();
    }

    public Task AddWords(Collection<Word> words)
    {
        throw new NotImplementedException();
    }
}