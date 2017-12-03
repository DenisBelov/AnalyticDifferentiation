using KursProject1.Context;

namespace KursProject1.SimplifyStrategies
{
    class DegreeSimplifyStrategy : IStrategy
    {
        public ElementOfTree Process(ElementOfTree element, IContext context)
        {
            ((SimplifyContext) context).IsChanged = true;
            if (element.Right.Type == NodeType.Const && element.Right.Value == "1")
            {
                element = element.Left;
                return element;
            }
            if (element.Right.Type == NodeType.Const && element.Right.Value == "0")
            {
                element = new ElementOfTree
                {
                    Type = NodeType.Const,
                    Value = "1"
                };
                return element;
            }
            if (element.Right.Type == NodeType.MinusU && element.Left.Value == "0")
            {
                element = new ElementOfTree
                {
                    Type = NodeType.Const,
                    Value = "1"
                };
                return element;
            }
            ((SimplifyContext)context).IsChanged = false;
            return element;
        }
    }
}
