using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboAutomation.Utilities
{
    public static class DependencyInjectionHelper
    {
        private static MEFContainer _conatiner = new MEFContainer();

        public static void Resolve(object value)
        {
            _conatiner.SatisfyImports(value);
        }
    }
}
