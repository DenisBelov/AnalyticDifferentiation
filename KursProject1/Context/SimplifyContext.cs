using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursProject1.Context {
    class SimplifyContext : IContext {
        readonly IDictionary<NodeType, IStrategy> _strategies;

        public SimplifyContext(IStrategiesSetter setter)
        {
            _strategies = setter.GetStrategies();
        }
        public ElementOfTree Process(ElementOfTree element)
        {
            if(element.Right != null)
            {
                element.Right = Process(element.Right);
            }
            if(element.Left != null)
            {
                element.Left = Process(element.Left);
            }
            return ProcessElement(element);
        }
        private ElementOfTree ProcessElement(ElementOfTree element)
        {
            return _strategies.Keys.Contains(element.Type) ? _strategies[element.Type].Process(element, this) : element;
        }
    }
}
