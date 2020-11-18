using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class AdvancedInherited : Advanced
    {
        public AdvancedInherited(int val) : base(val)
        {
        }

        new public void JustSayHello()
        {
            Console.WriteLine("Hello, i'm Event More Advanced!");
        }
    }
}
