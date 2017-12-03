using KursProject1.Context;

namespace KursProject1.SimplifyStrategies
{
    class MultiplySimplifyStrategy : IStrategy
    {
        public ElementOfTree Process(ElementOfTree element, IContext context)
        {
            ((SimplifyContext)context).IsChanged = true;
            if (element.Left?.Type == NodeType.Const && element.Right?.Type == NodeType.Const)
            {
                int a, b;
                if (int.TryParse(element.Right.Value, out a) && int.TryParse(element.Left.Value, out b))
                {
                    element.Value = (a * b).ToString();
                    element.Type = NodeType.Const;
                    element.Right = null;
                    element.Left = null;
                    return element;
                }
            }
            if (element.Right?.Type == NodeType.Const && element.Right.Value == "1")
            {
                element = element.Left;
                return element;
            }
            if (element.Left?.Type == NodeType.Const && element.Left.Value == "1")
            {
                element = element.Right;
                return element;
            }
            if (element.Right?.Type == NodeType.Const && element.Right.Value == "0")
            {
                element = element.Right;
                return element;
            }
            if (element.Left?.Type == NodeType.Const && element.Left.Value == "0")
            {
                element = element.Left;
                return element;
            }
            if (element.Right?.Type == NodeType.MinusU && element.Right.Left.Value == "0")
            {
                element = element.Right;
                return element;
            }
            if (element.Left?.Type == NodeType.MinusU && element.Left.Left.Value == "0")
            {
                element = element.Left;
                return element;
            }

            if (element.Type == NodeType.Multiply && element.Right?.Left?.Type == NodeType.Const &&
                element.Left?.Type == NodeType.Const)
            {
                int a, b;
                if (int.TryParse(element.Right.Left.Value, out a) && int.TryParse(element.Left.Value, out b))
                {
                    element.Left.Value = (a * b).ToString();
                    element.Right = element.Right.Right;
                    return element;
                }
            }
            if (element.Right?.Type == NodeType.MinusU && element.Right.Type == NodeType.Const && element.Left.Type == NodeType.Const)
            {
                element.Type = NodeType.MinusU;
                int a, b;
                if (int.TryParse(element.Right?.Left?.Value, out a) && int.TryParse(element.Left.Value, out b))
                {
                    element.Type = NodeType.MinusU;
                    element.Value = "-";
                    element.Right = null;
                    element.Left = new ElementOfTree
                    {
                        Type = NodeType.Const,
                        Value = (a * b).ToString()
                    };
                }
            }
            if (element.Type == NodeType.Multiply && element.Right?.Left?.Type == NodeType.MinusU &&
                element.Left?.Type == NodeType.Const)
            {
                element.Type = NodeType.MinusU;
                int a, b;
                if (int.TryParse(element.Right?.Left?.Left?.Value, out a) && int.TryParse(element.Left.Value, out b))
                {
                    element.Left.Type = NodeType.MinusU;
                    element.Left.Value = "-";
                    element.Left.Right = null;
                    element.Left.Left = new ElementOfTree
                    {
                        Type = NodeType.Const,
                        Value = (a * b).ToString()
                    };
                    element.Right = element.Right.Right;
                }
            }
            ((SimplifyContext)context).IsChanged = false;
            return element;
        }
    }
}
