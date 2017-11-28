﻿using KursProject1.Context;

namespace KursProject1.DifferentiationStrategies {
    class TanProcessStrategy : IStrategy {
        public ElementOfTree Process(ElementOfTree element, IContext context)
        {
            var leftResult = new ElementOfTree
            {
                Right = new ElementOfTree
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
                },
                Left = new ElementOfTree
                {
                    Node = "1",
                    Type = NodeType.Const,
                },
                Type = NodeType.Divide,
                Node = "/"
            };
            var result = new ElementOfTree
            {
                Left = leftResult,
                Right = context.Process(element.Left.Copy()),
                Type = NodeType.Multiply,
                Node = "*"
            };
            return result;
        }
    }
}
