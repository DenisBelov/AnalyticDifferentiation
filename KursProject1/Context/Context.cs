using System.Collections.Generic;

namespace KursProject1.Context
{
    class Context : IContext
    {
        readonly IDictionary<NodeType, IStrategy> _strategies;

        public Context(IStrategiesSetter setter)
        {
            _strategies = setter.GetStrategies();
        }

        public ElementOfTree Process(ElementOfTree element)
        {
            return _strategies[element.Type].Process(element.Copy(), this);
        }
    }
}
