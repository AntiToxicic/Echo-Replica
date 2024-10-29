﻿using System.Collections.ObjectModel;
using Echo_Replica.Core.Entities;

namespace Echo_Replica.Core.Interfaces.Repositories;

public interface IWordRepository
{
    public Task<Word> GetWord(string word);
    
    public Task<IReadOnlyCollection<Word>> GetAllWords();
    
    public Task AddWords(Collection<Word> words);
}