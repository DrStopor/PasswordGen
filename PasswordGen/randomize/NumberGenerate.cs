using Fortuna;
using Fortuna.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordGen.randomize
{
    class NumberGenerate
    {
        private int maxValue;

        public NumberGenerate(int value)
        {
            maxValue = value;
        }
        public int GetOne()
        {
            var rng = PRNGFortunaProviderFactory.Create();
            int result = rng.RandomNumber(maxValue);
            return result;
        }
    }
}
