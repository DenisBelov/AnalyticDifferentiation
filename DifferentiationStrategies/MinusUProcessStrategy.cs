using KursProject1.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursProject1.DifferentiationStrategies {
    class MinusUProcessStrategy : IStrategy {
        public ElementOfTree Process(ElementOfTree element, IContext context)
        {
            element.Left = context.Process(element.Left);
            return element;
        }
    }
}
