using KursProject1.Context;
namespace KursProject1.DifferentiationStrategies
{
    class MultiplyProcessStrategy : IStrategy
    {
        public ElementOfTree Process(ElementOfTree element, IContext context)
        {
            element.Type = NodeType.PlusMinus;
            element.Left = new ElementOfTree
            { 
                Type = NodeType.Multiply,
                Left = element.Left,
                Right = context.Process(element.Right.Copy())
            };
            element.Right = new ElementOfTree
            {
                Type = NodeType.Multiply,
                Left = context.Process(element.Left.Copy()),
                Right = element.Right
            };
            return element;
        }
    }
}
