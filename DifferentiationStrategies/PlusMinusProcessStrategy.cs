using KursProject1.Context;
namespace KursProject1.DifferentiationStrategies
{
    class PlusMinusProcessStrategy : IStrategy
    {
        public ElementOfTree Process(ElementOfTree element, IContext context)
        {
            element.Left = context.Process(element.Left);
            element.Right = context.Process(element.Right);
            return element;
        }
    }
}
