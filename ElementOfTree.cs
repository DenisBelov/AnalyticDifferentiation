using System;
using System.Text.RegularExpressions;
using KursProject1.Exceptions;

namespace KursProject1
{
    public class ElementOfTree
    {
        public string Value { get; set; }
        public ElementOfTree Left;
        public ElementOfTree Right;
        public NodeType Type;

        public string Output()
        {
            if (Left != null && Right != null)
            {
                switch (Value)
                {
                    case "+":
                        {
                            if (Right.Value == "-" && Right.Right == null)
                            {
                                return Left.Output() + Value + "(" + Right.Output() + ")";
                            }
                            return Left.Output() + Value + Right.Output();
                        }
                    case "-":
                        {
                            if (Right.Value == "+" || Right.Value == "-")
                                return Left.Output() + Value + "(" + Right.Output() + ")";
                            return Left.Output() + Value + Right.Output();
                        }
                    case "*":
                        {
                            if (Left.Value == "/" || Left.Value == "+" || Left.Value == "-")
                            {
                                if (Right.Value == "/" || Right.Value == "+" || Right.Value == "-")
                                {
                                    return "(" + Left.Output() + ")" + Value + "(" + Right.Output() + ")";
                                }
                                return "(" + Left.Output() + ")" + Value + Right.Output();
                            }
                            if (Right.Value == "/" || Right.Value == "+" || Right.Value == "-")
                            {
                                return Left.Output() + Value + "(" + Right.Output() + ")";
                            }
                            return Left.Output() + Value + Right.Output();
                        }
                    case "/":
                        {
                            if (Left.Value == "+" || Left.Value == "-")
                            {
                                if (Right.Value == "/" || Right.Value == "+" || Right.Value == "-")
                                {
                                    return "(" + Left.Output() + ")" + Value + "(" + Right.Output() + ")";
                                }
                                return "(" + Left.Output() + ")" + Value + Right.Output();
                            }
                            if (Right.Value == "/" || Right.Value == "+" || Right.Value == "-")
                            {
                                return Left.Output() + Value + "(" + Right.Output() + ")";
                            }
                            return Left.Output() + Value + Right.Output();
                        }
                    case "^":
                        {
                            if (Left.Value == "+" || Left.Value == "-" || Left.Value == "*" || Left.Value == "/"
                                    || Left.Value == "[" || Left.Value == "]" || Left.Value == "!" || Left.Value == "?" || Left.Value == "#" || Left.Value == "%")

                            {
                                if (Right.Value == "-")
                                {
                                    return "(" + Left.Output() + ")" + Value + "(" + Right.Output() + ")";
                                }
                                return "(" + Left.Output() + ")" + Value + Right.Output();
                            }
                            if (Right.Value == "-")
                            {
                                return Left.Output() + Value + "(" + Right.Output() + ")";
                            }
                            return Left.Output() + Value + Right.Output();
                        }
                    default: throw new TreeOutputException();
                }
            }
            if (Left != null && Right == null)
            {
                if (Value == "-")
                {
                    if (Left.Value == "+" || Left.Value == "-")
                    {
                        return Value + "(" + Left.Output() + ")";
                    }
                    if (Left.Value == "*" || Left.Value == "/")
                    {
                        return Value + Left.Output();
                    }
                    return Value + Left.Output();
                }
                return Value + "(" + Left.Output() + ")";
            }
            return Value;
        }

        public void S(string partOfstring)
        {
            if (String.IsNullOrWhiteSpace(partOfstring))
            {
                throw new EmptyMemberException();
            }
            try
            {
                int sk = 0;
                for (int i = partOfstring.Length - 1; i >= 0; i--)
                {
                    if (partOfstring[i] == '(')
                    {
                        sk++;
                        continue;
                    }
                    if (partOfstring[i] == ')')
                    {
                        sk--;
                        continue;
                    }
                    if ((partOfstring[i] == '+' || partOfstring[i] == '-' && i != 0) && sk == 0)
                    {
                        Value = partOfstring[i].ToString();
                        Type = NodeType.PlusMinus;
                        Left = new ElementOfTree();
                        Left.S(partOfstring.Substring(0, i));
                        Right = new ElementOfTree();
                        Right.T(partOfstring.Substring(i + 1));
                        return;
                    }
                }
                if (partOfstring[0] == '-')
                {
                    Value = partOfstring[0].ToString();
                    Type = NodeType.MinusU;
                    Left = new ElementOfTree();
                    Left.T(partOfstring.Substring(1, partOfstring.Length - 1));
                    return;
                }
                T(partOfstring);
            }
            catch (ExpressionException e)
            {
                e.Node = GetNormalNodeState(partOfstring);
                throw;
            }
        }

        public void T(string partOfString)
        {
            if (String.IsNullOrWhiteSpace(partOfString))
            {
                throw new EmptyMemberException();
            }
            try
            {
                int sk = 0;
                int divide = -1;
                int multiply = -1;
                int degree = -1;
                for (int i = partOfString.Length - 1; i >= 0; i--)
                {
                    if (partOfString[i] == '(')
                    {
                        sk++;
                    }
                    else
                    if (partOfString[i] == ')')
                    {
                        sk--;
                    }
                    else
                    if (sk == 0)
                    {
                        if (partOfString[i] == '/' && divide == -1)
                        {
                            divide = i;
                        }
                        else
                        if (partOfString[i] == '*' && multiply == -1)
                        {
                            multiply = i;
                        }
                        else
                        if (partOfString[i] == '^' && degree == -1)
                        {
                            degree = i;
                        }
                    }
                }

                if (divide != -1)
                {
                    Value = partOfString[divide].ToString();
                    Type = NodeType.Divide;
                    Left = new ElementOfTree();
                    Left.T(partOfString.Substring(0, divide));
                    Right = new ElementOfTree();
                    Right.T(partOfString.Substring(divide + 1));
                    return;
                }
                if (multiply != -1)
                {
                    Value = partOfString[multiply].ToString();
                    Type = NodeType.Multiply;
                    Left = new ElementOfTree();
                    Left.T(partOfString.Substring(0, multiply));
                    Right = new ElementOfTree();
                    Right.T(partOfString.Substring(multiply + 1));
                    return;
                }
                if (degree != -1)
                {
                    Value = partOfString[degree].ToString();
                    Type = NodeType.Degree;
                    Left = new ElementOfTree();
                    Left.T(partOfString.Substring(0, degree));
                    Right = new ElementOfTree();
                    Right.Z(partOfString.Substring(degree + 1));
                    return;
                }
                M(partOfString);

            }
            catch (ExpressionException e)
            {
                e.Node = GetNormalNodeState(partOfString);
                throw;
            }
        }

        public void M(string partOfString)
        {
            if (String.IsNullOrWhiteSpace(partOfString))
            {
                throw new EmptyMemberException();
            }
            try
            {
                if (partOfString[0] == '(' && partOfString[partOfString.Length - 1] == ')')
                {
                    S(partOfString.Substring(1, partOfString.Length - 2));
                    return;
                }
                if (partOfString[0] > 47 && partOfString[0] < 58 || (new Regex("^([a-w]|[y-z])$", RegexOptions.IgnoreCase)).IsMatch(partOfString))
                {
                    Z(partOfString);
                    return;
                }
                if (partOfString == "X" || partOfString == "x")
                {
                    Value = partOfString;
                    Type = NodeType.X;
                    return;
                }

                F(partOfString);
            }
            catch (ExpressionException e)
            {
                e.Node = GetNormalNodeState(partOfString);
                throw;
            }
        }

        public void Z(string pertOfString)
        {
            if (String.IsNullOrWhiteSpace(pertOfString))
            {
                throw new EmptyMemberException();
            }

            try
            {
                if (pertOfString[0] == '(' && pertOfString[pertOfString.Length - 1] == ')')
                {
                    if (pertOfString[1] == '-')
                    {
                        Value = "-";
                        Type = NodeType.MinusU;
                        Left = new ElementOfTree();
                        Left.N(pertOfString.Substring(2, pertOfString.Length - 3));
                    }
                    else
                    {
                        Type = NodeType.Const;
                        N(pertOfString.Substring(1, pertOfString.Length - 2));
                    }
                }
                else
                {
                    Regex constant = new Regex("^([a-w]|[y-z])$", RegexOptions.IgnoreCase);
                    if (constant.IsMatch(pertOfString))
                    {
                        Value = pertOfString;
                        Type = NodeType.Const;
                        return;
                    }
                    N(pertOfString);
                }
            }
            catch (ExpressionException e)
            {
                e.Node = GetNormalNodeState(pertOfString);
                throw;
            }
        }

        public void N(string partOfString)
        {
            if (String.IsNullOrWhiteSpace(partOfString))
            {
                throw new EmptyMemberException();
            }

            Regex number = new Regex("^[1-9][0-9]*$");
            if (number.IsMatch(partOfString))
            {
                Value = partOfString;
                Type = NodeType.Const;
                return;
            }
            throw new IncorrectNumberDefinitionException();
        }

        public void F(string partOfString)
        {
            if (String.IsNullOrWhiteSpace(partOfString))
            {
                throw new EmptyMemberException();
            }

            try
            {
                switch (partOfString[0])
                {
                    case '[': Value = "["; Type = NodeType.Sin; Left = new ElementOfTree(); Left.S(partOfString.Substring(2, partOfString.Length - 3)); return;
                    case ']': Value = "]"; Type = NodeType.Cos; Left = new ElementOfTree(); Left.S(partOfString.Substring(2, partOfString.Length - 3)); return;
                    case '!': Value = "!"; Type = NodeType.Tan; Left = new ElementOfTree(); Left.S(partOfString.Substring(2, partOfString.Length - 3)); return;
                    case '?': Value = "?"; Type = NodeType.Ln; Left = new ElementOfTree(); Left.S(partOfString.Substring(2, partOfString.Length - 3)); return;
                    case '#': Value = "#"; Type = NodeType.Exp; Left = new ElementOfTree(); Left.S(partOfString.Substring(2, partOfString.Length - 3)); return;
                    case '%': Value = "%"; Type = NodeType.Sqrt; Left = new ElementOfTree(); Left.S(partOfString.Substring(2, partOfString.Length - 3)); return;
                    default: throw new IncorrectFunctionDefinitionException();
                }
            }
            catch (ArgumentOutOfRangeException e)
            {
                throw new BracketsMissingException();
            }

        }

        public ElementOfTree Copy()
        {
            return new ElementOfTree
            {
                Value = Value,
                Left = Left?.Copy(),
                Right = Right?.Copy(),
                Type = Type
            };
        }

        private string GetNormalNodeState(string partOfString)
        {
            partOfString = Regex.Replace(partOfString, "[[]", "sin");
            partOfString = Regex.Replace(partOfString, "[]]", "cos");
            partOfString = Regex.Replace(partOfString, "[!]", "tan");
            partOfString = Regex.Replace(partOfString, "[?]", "ln");
            partOfString = Regex.Replace(partOfString, "[#]", "exp");
            partOfString = Regex.Replace(partOfString, "[%]", "sqrt");

            return partOfString;
        }

        public override bool Equals(object obj)
        {
            var el = obj as ElementOfTree;
            return el.Value == Value
                && !(el.Right != null ^ Right != null) && Right == el.Right
                && !(el.Left != null ^ Left != null) && Left == el.Left;
        }

    }
}
