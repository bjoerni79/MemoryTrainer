using System;
using System.Collections.Generic;
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
        }

        public IEnumerable<PAOResult> PAOResults
        {
            get
            {
                var newList = new List<PAOResult>(paoResults);
                return newList;
            }
        }

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
