using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoryTrainer.Environment
{
    public class NumberGenerator
    {
        public NumberGenerator()
        {

        }

        public Number CreateCreditCard()
        {
            // 49xx xxxx xxxx xxxx
            var creditCard = "49xx xxxx xxxx xxxx";

            return new Number(creditCard);
        }

        public string CreateIban()
        {
            // DExx xxxx xxxx xxxx xxxx xx

            return "DExx xxxx xxxx xxxx xxxx xx";
        }

        public string CreateNumber(int length)
        {
            return "123";
        }
    }
}
