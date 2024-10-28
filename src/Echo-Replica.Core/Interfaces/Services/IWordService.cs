using System.Collections.ObjectModel;
using Echo_Replica.Core.Entities;

namespace Echo_Replica.Core.Interfaces.Services;

public interface IWordService
{
    public Word GetWord(string word);
    
    public List<Word> GetAllWords();
    
    public void AddWords(Collection<Word> words);
}