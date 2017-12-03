using KursProject1.Context;

namespace KursProject1.DifferentiationStrategies
{
    class DegreeProcessStrategy : IStrategy
    {
        public ElementOfTree Process(ElementOfTree element, IContext context)
        {
            element.Type = NodeType.Multiply;
            element.Value = "*";
            var tempL = element.Left.Copy();
            var tempR = element.Right.Copy();
            element.Left = context.Process(element.Left);
            element.Right = new ElementOfTree
            {
                Value = "*",
                Type = NodeType.Multiply,
                Left = tempR,
                Right = new ElementOfTree
                {
                    Value = "^",
                    Type = NodeType.Degree,
                    Right = new ElementOfTree
                    {
                        Type = NodeType.PlusMinus,
                        Value = "-",
                        Left = element.Right.Copy(),
                        Right =  new ElementOfTree
                        {
                            Value = "1",
                            Type = NodeType.Const
                        }
                    },
                    Left = tempL
                }
            };
            
            return element;
        }
    }
}
