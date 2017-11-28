using KursProject1.Context;

namespace KursProject1.DifferentiationStrategies
{
    class TanProcessStrategy : IStrategy
    {
        public ElementOfTree Process(ElementOfTree element, IContext context)
        {
            element.Right = new ElementOfTree
            {
                Type = NodeType.Degree,
                Node = "^",
                Right = new ElementOfTree
                {
                    Node = "2",
                    Type = NodeType.Const,
                },
                Left = new ElementOfTree
                {
                    Type = NodeType.Cos,
                    Node = "]",
                    Left = element.Left
                }
            };
            element.Left = new ElementOfTree
            {
                Node = "1",
                Type = NodeType.Const,
            };
            element.Type = NodeType.Divide;
            element.Node = "/";
            return element;
        }
    }
}
