using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryTrainer.Environment
{
    public class NumberSet
    {
        private readonly List<Number> numbers;

        public NumberSet()
        {
            numbers = new List<Number>();  
        }

        public IEnumerable<Number> Numbers => numbers;

        public void Add(Number number)
        {
            if (number == null)
            {
                throw new ArgumentNullException("number");
            }

            numbers.Add(number);
        }

        public void Remove(Number number)
        {
            if (number == null)
            {
                throw new ArgumentNullException("number");
            }

            var found = numbers.Contains(number);
            if (found)
            {
                numbers.Remove(number);
            }
        }

    }
}
