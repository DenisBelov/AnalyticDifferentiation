using KursProject1.Context;

namespace KursProject1.DifferentiationStrategies
{
    class MultiplyProcessStrategy : IStrategy
    {
        public ElementOfTree Process(ElementOfTree element, IContext context)
        {
            element.Type = NodeType.PlusMinus;
            element.Node = "+";
            var leftTemp = element.Left.Copy();
            element.Left = new ElementOfTree
            { 
                Node = "*",
                Type = NodeType.Multiply,
                Left = element.Left,
                Right = context.Process(element.Right.Copy())
            };
            element.Right = new ElementOfTree
            {
                Node = "*",
                Type = NodeType.Multiply,
                Left = context.Process(leftTemp),
                Right = element.Right
            };
            return element;
        }
    }
}
