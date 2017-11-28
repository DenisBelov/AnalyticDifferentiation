using System;
using KursProject1.Context;

namespace KursProject1.SimplifyStrategies {
    class PlusMinusSimplifyStrategy : IStrategy {
        public ElementOfTree Process(ElementOfTree element, IContext context)
        {
            ((SimplifyContext)context).IsChanged = true;
            if (element.Left.Type == NodeType.Const && element.Right.Type == NodeType.Const)
            {
                int a, b;
                if (int.TryParse(element.Left.Node, out a) && int.TryParse(element.Right.Node, out b))
                {
                    element.Node = element.Node == "+" ? (a + b).ToString() : (a - b).ToString();
                    element.Type = NodeType.Const;
                    element.Right = null;
                    element.Left = null;
                    return element;
                }
            }
            if(element.Right.Type == NodeType.Const && element.Right.Node == "0")
            {
                element = element.Left;
                return element;
            }
            if (element.Left.Type == NodeType.Const && element.Left.Node == "0")
            {
                element = element.Right;
            }
            if (element.Left.Type == NodeType.Multiply && element.Right.Type == NodeType.Multiply 
                && element.Left.Right.Equals(element.Right.Right))
            {
                var tempElemR = element.Right.Left.Copy();
                var tempElemL = element.Left.Left.Copy();
                
                int a, b;
                if (int.TryParse(tempElemL.Node, out a) && int.TryParse(tempElemR.Node, out b)) {
                    element = element.Right;
                    element.Left.Node = (a + b).ToString();
                    return element;
                }
                return element;
            }
            if (element.Right?.Type == NodeType.X && element.Left?.Type == NodeType.X)
            {
                element.Type = NodeType.Multiply;
                element.Left = new ElementOfTree
                {
                    Node = "2",
                    Type = NodeType.Const
                };
                element.Node = "*";
            }
            if (element.Right?.Type == NodeType.MinusU && element.Left.Type == NodeType.Const)
            {
                int a, b;
                if (int.TryParse(element.Right?.Left.Node, out a) && int.TryParse(element.Left.Node, out b))
                {
                    if (element.Node == "-")
                    {
                        element.Right.Left.Node = (a + b).ToString();
                    }
                    else
                    {
                        element.Right.Left.Node = (a - b).ToString();
                    }
                    element = element.Right;
                    return element;
                }
                
            }
            ((SimplifyContext) context).IsChanged = false;
            return element;
        }
    }
}
