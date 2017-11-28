using KursProject1.Context;

namespace KursProject1.DifferentiationStrategies
{
    class DegreeProcessStrategy : IStrategy
    {
        public ElementOfTree Process(ElementOfTree element, IContext context)
        {
            element.Type = NodeType.Multiply;
            element.Node = "*";
            element.Right = new ElementOfTree
            {
                Node = "*",
                Type = NodeType.Multiply,
                Left = element.Right,
                Right = new ElementOfTree
                {
                    Node = "^",
                    Type = NodeType.Degree,
                    Right = new ElementOfTree
                    {
                        Type = NodeType.PlusMinus,
                        Node = "-",
                        Left = new ElementOfTree
                        {
                            Node = "1",
                            Type = NodeType.Const
                        },
                        Right = element.Right
                    },
                    Left = element.Left
                }
            };
            element.Left = context.Process(element.Left.Copy());
            return element;
        }
    }
}
