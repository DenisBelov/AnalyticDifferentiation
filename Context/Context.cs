using System.Collections.Generic;

namespace KursProject1.Context
{
    class DifferentiationContext : IContext
    {
        readonly IDictionary<NodeType, List<IStrategy>> _strategies;

        public DifferentiationContext(IStrategiesSetter setter)
        {
            _strategies = setter.GetStrategies();
        }

        public ElementOfTree Process(ElementOfTree element)
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
