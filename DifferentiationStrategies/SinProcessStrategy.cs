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
                Value = element.Value.Replace("[", "]"),
                Left = element.Left
            };
            element.Left = context.Process(tempElem.Left);    
            element.Type = NodeType.Multiply;
            element.Value = "*";
            return element;
        }
    }
}
