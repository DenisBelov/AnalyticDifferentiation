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
                Node = "-",
                Left = new ElementOfTree
                {
                    Type = NodeType.Multiply,
                    Node = "*",
                    Left = context.Process(element.Left.Copy()),
                    Right = element.Right
                },
                Right = new ElementOfTree
                {
                    Type = NodeType.Multiply,
                    Node="*",
                    Left = element.Left,
                    Right = context.Process(element.Right.Copy())
                }
            };
            element.Right = new ElementOfTree
            {
                Type = NodeType.Degree,
                Node="^",
                Left = element.Right,
                Right = new ElementOfTree
                {
                    Type = NodeType.Const,
                    Node = "2"
                }
            };
            return element;
        }

    }

}
