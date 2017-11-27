using KursProject1.Context;

namespace KursProject1.DifferentiationStrategies
{
    class ConstProcessStrategy : IStrategy
    {
        public ElementOfTree Process(ElementOfTree element, IContext context)
        {
            element.Type = NodeType.Const;
            element.Node = "0";
            return element;
        }
    }
}
