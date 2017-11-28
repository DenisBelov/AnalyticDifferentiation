using KursProject1.Context;

namespace KursProject1.SimplifyStrategies
{
    class DegreeSimplifyStrategy : IStrategy
    {
        public ElementOfTree Process(ElementOfTree element, IContext context)
        {
            if (element.Right.Type == NodeType.Const && element.Right.Node == "1")
            {
                element = element.Left;
                return element;
            }
            if (element.Right.Type == NodeType.Const && element.Right.Node == "0")
            {
                element = new ElementOfTree
                {
                    Type = NodeType.Const,
                    Node = "1"
                };
                return element;
            }
            return element;
        }
    }
}
