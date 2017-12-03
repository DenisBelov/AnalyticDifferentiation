using KursProject1.Context;

namespace KursProject1.DifferentiationStrategies
{
    class SinProcessStrategy : IStrategy
    {
        public ElementOfTree Process(ElementOfTree element, IContext context)
        {
            var tempElem = element.Copy();
            element.Right = new ElementOfTree
            {
                Type = NodeType.Cos,
                Node = element.Node.Replace("[", "]"),
                Left = element.Left
            };
            element.Left = context.Process(tempElem.Left);    
            element.Type = NodeType.Multiply;
            element.Node = "*";
            return element;
        }
    }
}
