using KursProject1.Context;

namespace KursProject1.DifferentiationStrategies {
    class SqrtProcessStrategy : IStrategy {
        public ElementOfTree Process(ElementOfTree element, IContext context)
        {
            var result = new ElementOfTree
            {
                Right = context.Process(element.Left.Copy()),
                Left = new ElementOfTree
                {
                    Left = new ElementOfTree
                    {
                        Type = NodeType.Const,
                        Value = "1"
                    },
                    Right = new ElementOfTree
                    {
                        Left = new ElementOfTree
                        {
                            Type = NodeType.Const,
                            Value = "2"
                        },
                        Right = element,
                        Type = NodeType.Multiply,
                        Value = "*"
                    },
                    Value = "/",
                    Type = NodeType.Divide
                },
                Value = "*",
                Type = NodeType.Multiply
            };
            return result;
        }
    }
}
