using MemoryTrainer.Environment;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MemoryTrainer.Service
{
    public class IoService : IIOService
    {
        public IoService()
        {

        }

        public DeckConfiguration LoadDeck(TextReader reader)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PAOResult> LoadResult(string filename)
        {
            throw new NotImplementedException();
        }

        public void SaveResult(IEnumerable<PAOResult> result, string filename)
        {
            throw new NotImplementedException();
        }
    }
}
