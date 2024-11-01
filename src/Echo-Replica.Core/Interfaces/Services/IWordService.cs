using Echo_Replica.Core.Entities;

namespace Echo_Replica.Core.Interfaces.Services;

public interface IWordService
{
    public Task<Word?> GetWord(string word);
    
    public Task<IReadOnlyCollection<Word>> GetAllWords();
    
    public Task AddWords(IReadOnlyCollection<Word> words);
}