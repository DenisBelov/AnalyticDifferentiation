using KursProject1.Context;

namespace KursProject1.DifferentiationStrategies
{
    class LogarifmProcessStrategy : IStrategy
    {
        public ElementOfTree Process(ElementOfTree element, IContext context)
        {
            element.Value = "*";
            element.Type = NodeType.Multiply;
            element.Right = new ElementOfTree
            {
                Value = "/",
                Type = NodeType.Divide,
                Left = new ElementOfTree
                {
                    Type = NodeType.Const,
                    Value = "1"
                },
                Right = element.Left
            };
            element.Left = context.Process(element.Left.Copy());
            return element;
        }
    }
}
