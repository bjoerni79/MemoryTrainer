using MemoryTrainer.Environment;
using MemoryTrainer.Misc;
using MemoryTrainer.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MemoryTrainer.Service
{
    /// <summary>
    /// Service for the I/O operations 
    /// </summary>
    public interface IIOService
    {
        /// <summary>
        /// Loads a deck from a external source
        /// </summary>
        /// <param name="reader">the external source</param>
        /// <returns>A new deck</returns>
        DeckConfiguration LoadDeck(TextReader reader);

        /// <summary>
        /// Saves a result of the PAO card game to the writer
        /// </summary>
        /// <param name="results">the result</param>
        /// <param name="filename">the writer target</param>
        void SaveResult(IEnumerable<PAOResult> result,string filename);

        /// <summary>
        /// Reads a PAO result from an external source
        /// </summary>
        /// <param name="filename">the reader source</param>
        /// <returns>The PAOResult collection </returns>
        IEnumerable<PAOResult> LoadResult(string filename);
    }
}
