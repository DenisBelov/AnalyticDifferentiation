using KursProject1.Context;

namespace KursProject1.SimplifyStrategies {
    class PlusMinusSimplifyStrategy : IStrategy {
        public ElementOfTree Process(ElementOfTree element, IContext context)
        {
            ((SimplifyContext)context).IsChanged = true;
            if (element.Left.Type == NodeType.Const && element.Right.Type == NodeType.Const)
            {
                int a, b;
                if (int.TryParse(element.Left.Value, out a) && int.TryParse(element.Right.Value, out b))
                {
                    element.Value = element.Value == "+" ? (a + b).ToString() : (a - b).ToString();
                    element.Type = NodeType.Const;
                    element.Right = null;
                    element.Left = null;
                    return element;
                }
            }
            if(element.Right.Type == NodeType.Const && element.Right.Value == "0")
            {
                element = element.Left;
                return element;
            }
            if (element.Left.Type == NodeType.Const && element.Left.Value == "0")
            {
                if (element.Value == "-")
                {
                    element.Type = NodeType.MinusU;
                    element.Value = "-";
                    element.Left = element.Right;
                    element.Right = null;
                }
                else
                {
                    element = element.Right;
                }
            }
            if (element.Left.Type == NodeType.Multiply && element.Right?.Type == NodeType.Multiply 
                && element.Left.Right.Equals(element.Right.Right))
            {
                var tempElemR = element.Right.Left.Copy();
                var tempElemL = element.Left.Left.Copy();
                
                int a, b;
                if (int.TryParse(tempElemL.Value, out a) && int.TryParse(tempElemR.Value, out b)) {
                    element = element.Right;
                    element.Left.Value = (a + b).ToString();
                    return element;
                }
                return element;
            }
            if (element.Right?.Type == NodeType.X && element.Left?.Type == NodeType.X)
            {
                element.Type = NodeType.Multiply;
                element.Left = new ElementOfTree
                {
                    Value = "2",
                    Type = NodeType.Const
                };
                element.Value = "*";
            }
            if (element.Right?.Type == NodeType.MinusU && element.Left.Type == NodeType.Const)
            {
                int a, b;
                if (int.TryParse(element.Right?.Left.Value, out a) && int.TryParse(element.Left.Value, out b))
                {
                    if (element.Value == "-")
                    {
                        element.Right.Left.Value = (a + b).ToString();
                    }
                    else
                    {
                        element.Right.Left.Value = (a - b).ToString();
                    }
                    element = element.Right;
                    return element;
                }
                
            }
            ((SimplifyContext) context).IsChanged = false;
            return element;
        }
    }
}
