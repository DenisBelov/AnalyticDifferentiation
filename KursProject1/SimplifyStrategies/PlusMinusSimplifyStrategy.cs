using System;
using KursProject1.Context;

namespace KursProject1.SimplifyStrategies {
    class PlusMinusSimplifyStrategy : IStrategy {
        public ElementOfTree Process(ElementOfTree element, IContext context)
        {
            if (element.Left.Type == NodeType.Const && element.Right.Type == NodeType.Const)
            {
                int a, b;
                if (int.TryParse(element.Right.Node, out a) && int.TryParse(element.Left.Node, out b))
                {
                    element.Node = element.Node == "+" ? (a + b).ToString() : (a - b).ToString();
                    element.Type = NodeType.Const;
                    element.Right = null;
                    element.Left = null;
                    return element;
                }
            }
            return element;
        }
    }
}
