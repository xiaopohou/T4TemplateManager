using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Codenesium.TemplateGenerator.Classes.Utility
{
    static class RandomNumber
    {
        static Random random;
        static RandomNumber()
        {
            random = new Random(DateTime.Now.TimeOfDay.Milliseconds);
        }

        public static int GetRandomNumber()
        {
            return random.Next();
        }
    }
}
