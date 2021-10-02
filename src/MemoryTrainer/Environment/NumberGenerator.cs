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

        public Number CreateIban()
        {
            // DExx xxxx xxxx xxxx xxxx xx
            var iban = "DExx xxxx xxxx xxxx xxxx xx";

            return new Number(iban);
        }

        public Number CreateNumber(int length, bool containsChars)
        {
            var number = "123";

            return new Number(number);
        }
    }
}
