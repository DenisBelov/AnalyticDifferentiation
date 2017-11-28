using KursProject1.Context;

namespace KursProject1.DifferentiationStrategies {
    class MinusUProcessStrategy : IStrategy {
        public ElementOfTree Process(ElementOfTree element, IContext context)
        {
            element.Left = context.Process(element.Left);
            return element;
        }
    }
}
