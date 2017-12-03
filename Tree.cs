using System.Text.RegularExpressions;
using KursProject1.Context;

namespace KursProject1
{
    public class Tree
    {
        public ElementOfTree Head { get; private set; }
        
        public Tree(string s, NodeTypeDeterminator determinator)
        {
            s = Regex.Replace(s, "[s][i][n]", "[", RegexOptions.IgnoreCase);
            s = Regex.Replace(s, "[c][o][s]", "]", RegexOptions.IgnoreCase);
            s = Regex.Replace(s, "[t][a][n]", "!", RegexOptions.IgnoreCase);
            s = Regex.Replace(s, "[l][n]", "?", RegexOptions.IgnoreCase);
            s = Regex.Replace(s, "[e][x][p]", "#", RegexOptions.IgnoreCase);
            s = Regex.Replace(s, "[s][q][r][t]", "%", RegexOptions.IgnoreCase);

            Head = new ElementOfTree();
            Head.S(s);
            determinator.Determinate(Head);
        }

        public void ProcessTree(IContext processContext)
        {
            Head = processContext.Process(Head);
        }

        public string Output()
        {
            var result = Head.Output();

            result = Regex.Replace(result, "[[]", "sin");
            result = Regex.Replace(result, "[]]", "cos");
            result = Regex.Replace(result, "[!]", "tan");
            result = Regex.Replace(result, "[?]", "ln");
            result = Regex.Replace(result, "[#]", "exp");
            result = Regex.Replace(result, "[%]", "sqrt");

            return result;
        }
    }
}
