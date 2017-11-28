using KursProject1.Context;

namespace KursProject1.SimplifyStrategies
{
    class NodeOrderSimplifyStrategy : IStrategy
    {
        public ElementOfTree Process(ElementOfTree element, IContext context)
        {
            ((SimplifyContext)context).IsChanged = true;
            if (element.Type == NodeType.Multiply && element.Right?.Type == NodeType.Const && element.Left?.Type != NodeType.Const)
            {
                var temp = element.Right;
                element.Right = element.Left;
                element.Left = temp;
            }
            ((SimplifyContext)context).IsChanged = false;
            return element;
        }
    }
}
