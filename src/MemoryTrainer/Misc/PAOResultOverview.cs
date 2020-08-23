using System;
using System.Collections.Generic;
using System.Text;

namespace MemoryTrainer.Misc
{
    public class PAOResultOverview
    {
        public PAOResultOverview(int id)
        {
            this.Id = id;
        }

        public string Deck { get; set; }

        public string Comment { get; set; }

        public bool Selected { get; set; }

        public int Id { get; private set; }
    }
}
