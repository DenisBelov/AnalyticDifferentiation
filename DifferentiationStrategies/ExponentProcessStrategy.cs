using KursProject1.Context;

namespace KursProject1.DifferentiationStrategies {
    class ExponentProcessStrategy : IStrategy {
        public ElementOfTree Process(ElementOfTree element, IContext context)
        {
            element.Right = element.Copy();
            element.Type = NodeType.Multiply;
            element.Left = context.Process(element.Right?.Left.Copy());
            element.Node = "*";
            return element;
        }
    }
}
