using KursProject1.Context;

namespace KursProject1.SimplifyStrategies
{
    class MultiplySimplifyStrategy : IStrategy
    {
        public ElementOfTree Process(ElementOfTree element, IContext context)
        {
            if (element.Left.Type == NodeType.Const && element.Right.Type == NodeType.Const)
            {
                int a, b;
                if (int.TryParse(element.Right.Node, out a) && int.TryParse(element.Left.Node, out b))
                {
                    element.Node = (a * b).ToString();
                    element.Type = NodeType.Const;
                    element.Right = null;
                    element.Left = null;
                    return element;
                }
            }
            if (element.Right?.Type == NodeType.Const && element.Right.Node == "1")
            {
                element = element.Left;
                return element;
            }
            if (element.Left?.Type == NodeType.Const && element.Left.Node == "1")
            {
                element = element.Right;
                return element;
            }
            if (element.Right?.Type == NodeType.Const && element.Right.Node == "0")
            {
                element = element.Right;
                return element;
            }
            if (element.Left?.Type == NodeType.Const && element.Left.Node == "0")
            {
                element = element.Left;
                return element;
            }
            if (element.Type == NodeType.Multiply && element.Right?.Left?.Type == NodeType.Const &&
                element.Left?.Type == NodeType.Const)
            {
                int a, b;
                if (int.TryParse(element.Right.Left.Node, out a) && int.TryParse(element.Left.Node, out b))
                {
                    element.Left.Node = (a * b).ToString();
                    element.Right = element.Right.Right;
                    return element;
                }
            }
            if (element.Right?.Type == NodeType.MinusU && element.Right.Type == NodeType.Const && element.Left.Type == NodeType.Const)
            {
                element.Type = NodeType.MinusU;
                int a, b;
                if (int.TryParse(element.Right?.Left?.Node, out a) && int.TryParse(element.Left.Node, out b))
                {
                    element.Type = NodeType.MinusU;
                    element.Node = "-";
                    element.Right = null;
                    element.Left = new ElementOfTree
                    {
                        Type = NodeType.Const,
                        Node = (a * b).ToString()
                    };
                }
            }
            if (element.Type == NodeType.Multiply && element.Right?.Left?.Type == NodeType.MinusU &&
                element.Left?.Type == NodeType.Const)
            {
                element.Type = NodeType.MinusU;
                int a, b;
                if (int.TryParse(element.Right?.Left?.Left?.Node, out a) && int.TryParse(element.Left.Node, out b))
                {
                    element.Left.Type = NodeType.MinusU;
                    element.Left.Node = "-";
                    element.Left.Right = null;
                    element.Left.Left = new ElementOfTree
                    {
                        Type = NodeType.Const,
                        Node = (a * b).ToString()
                    };
                    element.Right = element.Right.Right;
                }
            }
            return element;
        }
    }
}
