using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KursProject1
{
    class NodeTypeDeterminator
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
            Regex Const= new Regex("[0-9]*|[a-z]", RegexOptions.IgnoreCase);
            switch (element.Node)
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
                    if (element.Left.Type != NodeType.X && element.Left.Type != NodeType.Const)
                    {
                        element.Type = NodeType.DegreeC;
                        return;
                    }
                    element.Type = NodeType.Degree;
                    return;
                case "[":
                    if (element.Left.Type!=NodeType.X && element.Left.Type!=NodeType.Const)
                    {
                        element.Type = NodeType.SinC;
                        return;
                    }
                    element.Type = NodeType.Sin;
                    return;
                case "]":
                    if (element.Left.Type != NodeType.X && element.Left.Type != NodeType.Const)
                    {
                        element.Type = NodeType.CosC;
                        return;
                    }
                    element.Type = NodeType.Cos;
                    return;
                case "!":
                    if (element.Left.Type != NodeType.X && element.Left.Type != NodeType.Const)
                    {
                        element.Type = NodeType.TanC;
                        return;
                    }
                    element.Type = NodeType.Tan;
                    return;
                case "?":
                    if (element.Left.Type != NodeType.X && element.Left.Type != NodeType.Const)
                    {
                        element.Type = NodeType.LnC;
                        return;
                    }
                    element.Type = NodeType.Ln;
                    return;
                case "#":
                    if (element.Left.Type != NodeType.X && element.Left.Type != NodeType.Const)
                    {
                        element.Type = NodeType.ExpC;
                        return;
                    }
                    element.Type = NodeType.Exp;
                    return;
                case "X": element.Type = NodeType.X; return;
                default: element.Type = NodeType.Const; return;
            }
        }
    }
}
