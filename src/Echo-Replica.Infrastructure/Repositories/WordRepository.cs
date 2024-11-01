using Echo_Replica.Core.Entities;
using Echo_Replica.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Echo_Replica.Infrastructure.Repositories;

public class WordRepository : IWordRepository
{
    private readonly SqliteContext _context;

    public WordRepository(SqliteContext context)
    {
        _context = context;
    }

    public Task<Word?> GetWord(string word) =>
        _context.Words.FirstOrDefaultAsync(c => c.Text == word);

    public async Task<IReadOnlyCollection<Word>> GetAllWords() =>
        await _context.Words.ToListAsync();

    public async Task<IReadOnlyCollection<Word>> AddWords(IReadOnlyCollection<Word> words)
    {
        _context.Words.AddRange(words);
        await _context.SaveChangesAsync();

        return words;
    }
}