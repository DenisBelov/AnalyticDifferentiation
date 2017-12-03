using KursProject1.Context;

namespace KursProject1.DifferentiationStrategies
{
    class CosProcessStrategy : IStrategy
    {
        public ElementOfTree Process(ElementOfTree element, IContext context)
        {
            var tempElem = element.Copy();
            tempElem.Type = NodeType.Sin;
            tempElem.Value = tempElem.Value.Replace("]", "[");
            element.Left = context.Process(element.Left.Copy());
            element.Right = new ElementOfTree
            {
                Value = "-",
                Type = NodeType.MinusU,
                Left = tempElem
            };
            element.Value = "*";
            element.Type = NodeType.Multiply;
            return element;
        }
    }
}
