using System;
using System.Text.RegularExpressions;

namespace KursProject1 {
    public class ElementOfTree {
        public string Node { get; set; }
        public ElementOfTree Left;
        public ElementOfTree Right;
        public NodeType Type;

        public ElementOfTree Copy()
        {
            return new ElementOfTree
            {
                Node = Node,
                Left = Left,
                Right = Right,
                Type = Type
            };
        }
        public void Determine()
        {

        }

        public string Output()
        {
            if (Left != null && Right != null)
            {
                switch (Node)
                {
                    case "+":
                        {
                            if (Right.Node == "-" && Right.Right == null)
                            {
                                return Left.Output() + Node + "(" + Right.Output() + ")";
                            }
                            return Left.Output() + Node + Right.Output();
                        }
                    case "-":
                        {
                            if (Right.Node == "+" || Right.Node == "-")
                                return Left.Output() + Node + "(" + Right.Output() + ")";
                            else
                                return Left.Output() + Node + Right.Output();
                        }
                    case "*":
                        {
                            if (Left.Node == "/" || Left.Node == "+" || Left.Node == "-")
                            {
                                if (Right.Node == "/" || Right.Node == "+" || Right.Node == "-")
                                {
                                    return "(" + Left.Output() + ")" + Node + "(" + Right.Output() + ")";
                                }
                                else
                                {
                                    return "(" + Left.Output() + ")" + Node + Right.Output();
                                }
                            }
                            else
                            {
                                if (Right.Node == "/" || Right.Node == "+" || Right.Node == "-")
                                {
                                    return Left.Output() + Node + "(" + Right.Output() + ")";
                                }
                                else
                                {
                                    return Left.Output() + Node + Right.Output();
                                }
                            }
                        }
                    case "/":
                        {
                            if (Left.Node == "+" || Left.Node == "-")
                            {
                                if (Right.Node == "/" || Right.Node == "+" || Right.Node == "-")
                                {
                                    return "(" + Left.Output() + ")" + Node + "(" + Right.Output() + ")";
                                }
                                else
                                {
                                    return "(" + Left.Output() + ")" + Node + Right.Output();
                                }
                            }
                            else
                            {
                                if (Right.Node == "/" || Right.Node == "+" || Right.Node == "-")
                                {
                                    return Left.Output() + Node + "(" + Right.Output() + ")";
                                }
                                else
                                {
                                    return Left.Output() + Node + Right.Output();
                                }
                            }
                        }
                    case "^":
                        {
                            if (Left.Node=="+"|| Left.Node =="-" || Left.Node =="*" || Left.Node =="/"
                                || Left.Node =="[" || Left.Node =="]" || Left.Node =="!" || Left.Node =="?" || Left.Node =="#"|| Left.Node=="%")

                            {
                                if (Right.Node == "-")
                                {
                                    return "(" + Left.Output() + ")" + Node + "(" + Right.Output() + ")";
                                }
                                else
                                {
                                    return "(" + Left.Output() + ")" + Node + Right.Output();
                                }
                            }
                            else
                            {
                                if (Right.Node == "-")
                                {
                                    return Left.Output() + Node + "(" + Right.Output() + ")";
                                }
                                else
                                {
                                    return Left.Output() + Node + Right.Output();
                                }
                            }
                        }
                    default: throw new Exception("Данные введены неверно!");
                }
            }
            if (Left != null && Right == null)
            {
                if (Node == "-")
                {
                    if (Left.Node == "+" || Left.Node == "-" || Left.Node == "*" || Left.Node == "/")
                    {
                        return Node + "(" + Left.Output() + ")";
                    }
                    else
                    {
                        return Node + Left.Output();
                    }
                }
                else
                {
                    return Node + "(" + Left.Output() + ")";
                }
            }
            return Node;
        }
        public void S(string s)
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
                    Node = s[i].ToString();
                    Left = new ElementOfTree();
                    Left.S(s.Substring(0, i));
                    Right = new ElementOfTree();
                    Right.T(s.Substring(i + 1));
                    return;
                }
            }
            if (s[0] == '-')
            {
                Node = s[0].ToString();
                Left = new ElementOfTree();
                Left.T(s.Substring(1, s.Length - 1));
                return;
            }
            T(s);
        }
        public void T(string s)
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
                Node = s[divide].ToString();
                Left = new ElementOfTree();
                Left.T(s.Substring(0, divide));
                Right = new ElementOfTree();
                Right.T(s.Substring(divide + 1));
                return;
            }
            else
            {
                if (multiply != -1)
                {
                    Node = s[multiply].ToString();
                    Left = new ElementOfTree();
                    Left.T(s.Substring(0, multiply));
                    Right = new ElementOfTree();
                    Right.T(s.Substring(multiply + 1));
                    return;
                }
                else
                {
                    if (degree != -1)
                    {
                        Node = s[degree].ToString();
                        Left = new ElementOfTree();
                        Left.T(s.Substring(0, degree));
                        Right = new ElementOfTree();
                        Right.Z(s.Substring(degree + 1));
                        return;
                    }
                }
            }
            M(s);
        }
        public void M(string s)
        {
            if (s[0] == '(' && s[s.Length - 1] == ')')
            {
                S(s.Substring(1, s.Length - 2));
                return;
            }
            if (s[0]>47 && s[0]<58 || (new Regex("^([a-w]|[y-z])$", RegexOptions.IgnoreCase)).IsMatch(s))
            {
                Z(s);
                return;
            }
            if (s == "X" || s == "x")
            {
                Node = s;
                return;
            }
            F(s);
        }
        public void Z(string s)
        {
            if (s[0] == '(' && s[s.Length - 1] == ')')
            {
                if (s[1] == '-')
                {
                    Node = "-";
                    Left = new ElementOfTree();
                    Left.N(s.Substring(2, s.Length - 3));
                }
                else
                {
                    N(s.Substring(1, s.Length - 2));
                }
            }
            else
            {
                Regex constant = new Regex("^([a-w]|[y-z])$", RegexOptions.IgnoreCase);
                if (constant.IsMatch(s))
                {
                    Node = s;
                    return;
                }
                N(s);
            }
        }
        public void N(string s)
        {
            Regex number = new Regex("[1-9][0-9]*");
            if (number.IsMatch(s))
            {
                Node = s;
                return;
            }
            throw new Exception("Степень записана некорректно!");
            //foreach (char ch in s)
            //{
            //    if (!D(ch))
            //        throw new Exception("Степень записана некорректно!");
            //}
            //Node = s;
        }
        public bool D(char ch)
        {
            if (ch > 47 && ch < 58)
                return true;
            return false;
        }

        public void F(string s)
        {
            switch (s[0])
            {
                case '[': Node = "["; Left = new ElementOfTree(); Left.S(s.Substring(2, s.Length - 3)); return;
                case ']': Node = "]"; Left = new ElementOfTree(); Left.S(s.Substring(2, s.Length - 3)); return;
                case '!': Node = "!"; Left = new ElementOfTree(); Left.S(s.Substring(2, s.Length - 3)); return;
                case '?': Node = "?"; Left = new ElementOfTree(); Left.S(s.Substring(2, s.Length - 3)); return;
                case '#': Node = "#"; Left = new ElementOfTree(); Left.S(s.Substring(2, s.Length - 3)); return;
                case '%': Node = "%"; Left = new ElementOfTree(); Left.S(s.Substring(2, s.Length - 3)); return;
                default: throw new Exception("Ошибка в записи функции!");
            }

        }
        public override bool Equals(object obj)
        {
            var el = obj as ElementOfTree;
            return el.Node == Node
                && !(el.Right != null ^ Right != null) && Right == el.Right
                && !(el.Left != null ^ Left != null) && Left == el.Left;
        }
    }
}
