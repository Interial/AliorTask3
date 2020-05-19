using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AliorTask3
{
    class Separator
    {
        //W tej klasie znajduje się funkcja do separacji liczb
        public int[] NumbersIn(int value)
        {
            var numbers = new Stack<int>();

            for (; value > 0; value /= 10)
                numbers.Push(value % 10);

            return numbers.ToArray();
        }
    }
}
