using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDP23
{
    public class Calculator
    {
        public int x { get; set; }
        public int y { get; set; }

        public int Add()
        {
            return x + y;
        }

        public int Subtract()
        {
            return x - y;
        }

        public double Delta(double a, double b, double c)
        {
            var delta = b * b - 4 * a * c;
            return delta;
        }

    }
}
