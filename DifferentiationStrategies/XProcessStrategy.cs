using KursProject1.Context;

namespace KursProject1.DifferentiationStrategies
{
    class XProcessStrategy : IStrategy
    {
        public ElementOfTree Process(ElementOfTree element, IContext context)
        {
            element.Type = NodeType.Const;
            element.Left = null;
            element.Value = "1";
            return element;
        }
    }
}
