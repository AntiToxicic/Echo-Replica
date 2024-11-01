using Echo_Replica.Core.Entities;
using Echo_Replica.Core.Interfaces.Repositories;
using Echo_Replica.Core.Interfaces.Services;

namespace Echo_Replica.Application.Services;

public class WordService : IWordService
{
    private readonly IWordRepository _wordRepository;

    public WordService(IWordRepository wordRepository)
    {
        _wordRepository = wordRepository;
    }

    public async Task<Word?> GetWord(string word)
    {
        var foundWord = await _wordRepository.GetWord(word);

        return foundWord;
    }
    
    public async Task<IReadOnlyCollection<Word>> GetAllWords()
    {
        return await _wordRepository.GetAllWords();
    }
    
    public async Task AddWords(IReadOnlyCollection<Word> words)
    {
        await _wordRepository.AddWords(words);
    }
}