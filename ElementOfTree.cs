﻿using System;
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

        public void S(string s)
        {
            if (String.IsNullOrWhiteSpace(s))
            {
                throw new EmptyMemberException();
            }
            try
            {
                int sk = 0;
                for (int i = s.Length - 1; i >= 0; i--)
                {
                    if (s[i] == '(')
                    {
                        sk++;
                        continue;
                    }
                    if (s[i] == ')')
                    {
                        sk--;
                        continue;
                    }
                    if ((s[i] == '+' || s[i] == '-' && i != 0) && sk == 0)
                    {
                        Value = s[i].ToString();
                        Type = NodeType.PlusMinus;
                        Left = new ElementOfTree();
                        Left.S(s.Substring(0, i));
                        Right = new ElementOfTree();
                        Right.T(s.Substring(i + 1));
                        return;
                    }
                }
                if (s[0] == '-')
                {
                    Value = s[0].ToString();
                    Type = NodeType.MinusU;
                    Left = new ElementOfTree();
                    Left.T(s.Substring(1, s.Length - 1));
                    return;
                }
                T(s);
            }
            catch (ExpressionException e)
            {
                e.Node = GetNormalNodeState(s);
                throw;
            }
        }

        public void T(string s)
        {
            if (String.IsNullOrWhiteSpace(s))
            {
                throw new EmptyMemberException();
            }
            try
            {
                int sk = 0;
                int divide = -1;
                int multiply = -1;
                int degree = -1;
                for (int i = s.Length - 1; i >= 0; i--)
                {
                    if (s[i] == '(')
                    {
                        sk++;
                    }
                    else
                    if (s[i] == ')')
                    {
                        sk--;
                    }
                    else
                    if (sk == 0)
                    {
                        if (s[i] == '/' && divide == -1)
                        {
                            divide = i;
                        }
                        else
                        if (s[i] == '*' && multiply == -1)
                        {
                            multiply = i;
                        }
                        else
                        if (s[i] == '^' && degree == -1)
                        {
                            degree = i;
                        }
                    }
                }

                if (divide != -1)
                {
                    Value = s[divide].ToString();
                    Type = NodeType.Divide;
                    Left = new ElementOfTree();
                    Left.T(s.Substring(0, divide));
                    Right = new ElementOfTree();
                    Right.T(s.Substring(divide + 1));
                    return;
                }
                if (multiply != -1)
                {
                    Value = s[multiply].ToString();
                    Type = NodeType.Multiply;
                    Left = new ElementOfTree();
                    Left.T(s.Substring(0, multiply));
                    Right = new ElementOfTree();
                    Right.T(s.Substring(multiply + 1));
                    return;
                }
                if (degree != -1)
                {
                    Value = s[degree].ToString();
                    Type = NodeType.Degree;
                    Left = new ElementOfTree();
                    Left.T(s.Substring(0, degree));
                    Right = new ElementOfTree();
                    Right.Z(s.Substring(degree + 1));
                    return;
                }
                M(s);

            }
            catch (ExpressionException e)
            {
                e.Node = GetNormalNodeState(s);
                throw;
            }
        }

        public void M(string s)
        {
            if (String.IsNullOrWhiteSpace(s))
            {
                throw new EmptyMemberException();
            }
            try
            {
                if (s[0] == '(' && s[s.Length - 1] == ')')
                {
                    S(s.Substring(1, s.Length - 2));
                    return;
                }
                if (s[0] > 47 && s[0] < 58 || (new Regex("^([a-w]|[y-z])$", RegexOptions.IgnoreCase)).IsMatch(s))
                {
                    Z(s);
                    return;
                }
                if (s == "X" || s == "x")
                {
                    Value = s;
                    Type = NodeType.X;
                    return;
                }

                F(s);
            }
            catch (ExpressionException e)
            {
                e.Node = GetNormalNodeState(s);
                throw;
            }
        }

        public void Z(string s)
        {
            if (String.IsNullOrWhiteSpace(s))
            {
                throw new EmptyMemberException();
            }

            try
            {
                if (s[0] == '(' && s[s.Length - 1] == ')')
                {
                    if (s[1] == '-')
                    {
                        Value = "-";
                        Type = NodeType.MinusU;
                        Left = new ElementOfTree();
                        Left.N(s.Substring(2, s.Length - 3));
                    }
                    else
                    {
                        Type = NodeType.Const;
                        N(s.Substring(1, s.Length - 2));
                    }
                }
                else
                {
                    Regex constant = new Regex("^([a-w]|[y-z])$", RegexOptions.IgnoreCase);
                    if (constant.IsMatch(s))
                    {
                        Value = s;
                        Type = NodeType.Const;
                        return;
                    }
                    N(s);
                }
            }
            catch (ExpressionException e)
            {
                e.Node = GetNormalNodeState(s);
                throw;
            }
        }

        public void N(string s)
        {
            if (String.IsNullOrWhiteSpace(s))
            {
                throw new EmptyMemberException();
            }

            Regex number = new Regex("^[1-9][0-9]*$");
            if (number.IsMatch(s))
            {
                Value = s;
                Type = NodeType.Const;
                return;
            }
            throw new IncorrectNumberDefinitionException();
        }

        public void F(string s)
        {
            if (String.IsNullOrWhiteSpace(s))
            {
                throw new EmptyMemberException();
            }

            try
            {
                switch (s[0])
                {
                    case '[': Value = "["; Type = NodeType.Sin; Left = new ElementOfTree(); Left.S(s.Substring(2, s.Length - 3)); return;
                    case ']': Value = "]"; Type = NodeType.Cos; Left = new ElementOfTree(); Left.S(s.Substring(2, s.Length - 3)); return;
                    case '!': Value = "!"; Type = NodeType.Tan; Left = new ElementOfTree(); Left.S(s.Substring(2, s.Length - 3)); return;
                    case '?': Value = "?"; Type = NodeType.Ln; Left = new ElementOfTree(); Left.S(s.Substring(2, s.Length - 3)); return;
                    case '#': Value = "#"; Type = NodeType.Exp; Left = new ElementOfTree(); Left.S(s.Substring(2, s.Length - 3)); return;
                    case '%': Value = "%"; Type = NodeType.Sqrt; Left = new ElementOfTree(); Left.S(s.Substring(2, s.Length - 3)); return;
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

        private string GetNormalNodeState(string s)
        {
            s = Regex.Replace(s, "[[]", "sin");
            s = Regex.Replace(s, "[]]", "cos");
            s = Regex.Replace(s, "[!]", "tan");
            s = Regex.Replace(s, "[?]", "ln");
            s = Regex.Replace(s, "[#]", "exp");
            s = Regex.Replace(s, "[%]", "sqrt");

            return s;
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
