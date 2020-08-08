using System;
using System.Collections.Generic;
using System.Text;

namespace MemoryTrainer.Environment
{
    public class PAOResultItem
    {
        public PAOResultItem()
        {

        }

        /// <summary>
        /// The Person
        /// </summary>
        public PlayingCard Person { get; set; }

        /// <summary>
        /// The Action
        /// </summary>
        public PlayingCard Action { get; set; }
        /// <summary>
        /// The Object
        /// </summary>
        public PlayingCard Object { get; set; }

        /// <summary>
        /// Property for the user feedback. 0 is unknown, 1 is true and 2 is false
        /// </summary>
        public int RecallState { get; set; }

    }
}
