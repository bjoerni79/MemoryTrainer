using MemoryTrainer.Environment;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace MemoryTrainer.Service
{
    public class IoService : IIOService
    {
        private readonly JsonSerializerOptions defaultOptions;

        public IoService()
        {
            defaultOptions = new JsonSerializerOptions();
            defaultOptions.WriteIndented = true;

            // The cool kids are using JSON today!
            // https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-how-to
        }

        public DeckConfiguration LoadDeck(TextReader reader)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PAOResult> LoadResult(string filename)
        {
            List<PAOResult> results; ;

            try
            {
                //
                // 1. Read the JSON string
                //
                string jsonCoding;
                using (var textReader = File.OpenText(filename))
                {
                    jsonCoding = textReader.ReadToEnd();
                }

                //
                // 2. Deserialize to JSON
                //

                results = JsonSerializer.Deserialize<List<PAOResult>>(jsonCoding, defaultOptions);
            }
            catch (Exception ex)
            {
                throw new IOServiceException("Could not load PAO Results. " + ex.Message, ex);
            }

            return results;
        }

        public void SaveResult(IEnumerable<PAOResult> result, string filename)
        {
            try
            {
                //
                // 1. Serialize to JSON
                //
                var paoResultList = new List<PAOResult>();
                paoResultList.AddRange(result);
                var jsonCoding = JsonSerializer.Serialize(paoResultList, defaultOptions);

                //
                // 2. Write it to the file
                //
                using (var textwriter = File.CreateText(filename))
                {
                    textwriter.Write(jsonCoding);
                }
            }
            catch (Exception ex)
            {
                throw new IOServiceException("Could not save PAO Results " + ex.Message, ex);
            }

        }
    }
}
