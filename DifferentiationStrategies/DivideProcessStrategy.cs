using KursProject1.Context;

namespace KursProject1.DifferentiationStrategies
{
    class DivideProcessStrategy : IStrategy
    {
        public ElementOfTree Process(ElementOfTree element, IContext context)
        {
            element.Left = new ElementOfTree
            {
                Type = NodeType.PlusMinus,
                Value = "-",
                Left = new ElementOfTree
                {
                    Type = NodeType.Multiply,
                    Value = "*",
                    Left = context.Process(element.Left.Copy()),
                    Right = element.Right
                },
                Right = new ElementOfTree
                {
                    Type = NodeType.Multiply,
                    Value="*",
                    Left = element.Left,
                    Right = context.Process(element.Right.Copy())
                }
            };
            element.Right = new ElementOfTree
            {
                Type = NodeType.Degree,
                Value="^",
                Left = element.Right,
                Right = new ElementOfTree
                {
                    Type = NodeType.Const,
                    Value = "2"
                }
            };
            return element;
        }

    }

}
