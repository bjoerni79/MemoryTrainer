using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace MemoryTrainer.Environment
{
    public class ResultOverview
    {
        private List<PAOResult> paoResults;

        public ResultOverview()
        {
            paoResults = new List<PAOResult>();

            var localAppData = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            var filename = "paotrainer.json";
            var sourceFile = Path.Combine(localAppData, filename);

            Source = sourceFile;
        }

        public IEnumerable<PAOResult> PAOResults
        {
            get
            {
                var newList = new List<PAOResult>(paoResults);
                return newList;
            }
        }

        public string Source { get; set; }

        public void Reload(IEnumerable<PAOResult> newResults)
        {
            paoResults = new List<PAOResult>(newResults);
        }

        public void Add(PAOResult result)
        {
            paoResults.Add(result);
        }
    }
}
