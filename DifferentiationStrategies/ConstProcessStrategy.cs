using KursProject1.Context;

namespace KursProject1.DifferentiationStrategies
{
    class ConstProcessStrategy : IStrategy
    {
        public ElementOfTree Process(ElementOfTree element, IContext context)
        {
            element.Type = NodeType.Const;
            element.Value = "0";
            return element;
        }
    }
}
