using System.Collections.Generic;

namespace KursProject1.Context {
    class SimplifyContext : IContext {
        readonly IDictionary<NodeType, List<IStrategy>> _strategies;

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
            if (_strategies.Keys.Contains(element.Type))
            {
                foreach (var strategy in _strategies[element.Type])
                {
                    element = strategy.Process(element, this);
                }
            }
            return element;
        }
    }
}
