using KursProject1.Context;

namespace KursProject1.DifferentiationStrategies
{
    class MultiplyProcessStrategy : IStrategy
    {
        public ElementOfTree Process(ElementOfTree element, IContext context)
        {
            element.Type = NodeType.PlusMinus;
            element.Value = "+";
            var leftTemp = element.Left.Copy();
            element.Left = new ElementOfTree
            { 
                Value = "*",
                Type = NodeType.Multiply,
                Left = element.Left,
                Right = context.Process(element.Right.Copy())
            };
            element.Right = new ElementOfTree
            {
                Value = "*",
                Type = NodeType.Multiply,
                Left = context.Process(leftTemp),
                Right = element.Right
            };
            return element;
        }
    }
}
