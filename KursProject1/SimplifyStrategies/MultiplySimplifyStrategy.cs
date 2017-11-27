using KursProject1.Context;

namespace KursProject1.SimplifyStrategies
{
    class MultiplySimplifyStrategy : IStrategy
    {
        public ElementOfTree Process(ElementOfTree element, IContext context)
        {
            if (element.Left.Type == NodeType.Const && element.Right.Type == NodeType.Const)
            {
                if (int.TryParse(element.Right.Node, out var a) && int.TryParse(element.Left.Node, out var b))
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
            return element;
        }
    }
}
