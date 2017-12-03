using System.Text.RegularExpressions;

namespace KursProject1 {
    public class NodeTypeDeterminator
    {
        public void Determinate(ElementOfTree element)
        {
            if (element.Left!=null)
            {
                Determinate(element.Left);
            }
            if (element.Right!=null)
            {
                Determinate(element.Right);
            }
            Regex Const= new Regex("[x]", RegexOptions.IgnoreCase);
            switch (element.Value)
            {
                case "-":
                    if (element.Right == null)
                    {
                        element.Type = NodeType.MinusU;
                        return;
                    }
                    element.Type = NodeType.PlusMinus;
                    return;
                case "+": element.Type = NodeType.PlusMinus; return;
                case "*": element.Type = NodeType.Multiply; return;
                case "/": element.Type = NodeType.Divide; return;
                case "^":
                    element.Type = NodeType.Degree;
                    return;
                case "[":
                    element.Type = NodeType.Sin;
                    return;
                case "]":
                    element.Type = NodeType.Cos;
                    return;
                case "!":
                    element.Type = NodeType.Tan;
                    return;
                case "?":
                    element.Type = NodeType.Ln;
                    return;
                case "#":
                    element.Type = NodeType.Exp;
                    return;
                case "%":
                    element.Type = NodeType.Sqrt;
                    return;
                case "X":
                case "x": element.Type = NodeType.X; return;
                default: element.Type = NodeType.Const; return;
            }
        }
    }
}
