using KursProject1.Context;
namespace KursProject1.DifferentiationStrategies
{
    class LogarifmProcessStrategy : IStrategy
    {
        public ElementOfTree Process(ElementOfTree element, IContext context)
        {
            element.Node = "*";
            element.Type = NodeType.Multiply;
            element.Right = new ElementOfTree
            {
                Node = "/",
                Type = NodeType.Divide,
                Left = new ElementOfTree
                {
                    Type = NodeType.Const,
                    Node = "1"
                },
                Right = element.Left
            };
            element.Left = context.Process(element.Left.Copy());
            return element;
        }
    }
}
