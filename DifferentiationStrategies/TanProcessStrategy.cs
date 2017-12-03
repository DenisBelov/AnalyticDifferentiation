using KursProject1.Context;

namespace KursProject1.DifferentiationStrategies {
    class TanProcessStrategy : IStrategy {
        public ElementOfTree Process(ElementOfTree element, IContext context)
        {
            var leftResult = new ElementOfTree
            {
                Right = new ElementOfTree
                {
                    Type = NodeType.Degree,
                    Value = "^",
                    Right = new ElementOfTree
                    {
                        Value = "2",
                        Type = NodeType.Const
                    },
                    Left = new ElementOfTree
                    {
                        Type = NodeType.Cos,
                        Value = "]",
                        Left = element.Left
                    }
                },
                Left = new ElementOfTree
                {
                    Value = "1",
                    Type = NodeType.Const
                },
                Type = NodeType.Divide,
                Value = "/"
            };
            var result = new ElementOfTree
            {
                Left = leftResult,
                Right = context.Process(element.Left.Copy()),
                Type = NodeType.Multiply,
                Value = "*"
            };
            return result;
        }
    }
}
