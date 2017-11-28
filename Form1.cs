using System;
using System.Windows.Forms;
using KursProject1.DifferentiationStrategies;
using KursProject1.SimplifyStrategies;
using System.Text.RegularExpressions;

namespace KursProject1 {
    public partial class Form1 : Form {
        public Tree Tree { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var s = textBox1.Text.Replace(" ", String.Empty);
            s = Regex.Replace(s, "[s][i][n]", "[", RegexOptions.IgnoreCase);
            s = Regex.Replace(s, "[c][o][s]", "]", RegexOptions.IgnoreCase);
            s = Regex.Replace(s, "[t][a][n]", "!", RegexOptions.IgnoreCase);
            s = Regex.Replace(s, "[l][n]", "?", RegexOptions.IgnoreCase);
            s = Regex.Replace(s, "[e][x][p]", "#", RegexOptions.IgnoreCase);
            s = Regex.Replace(s, "[s][q][r][t]", "%", RegexOptions.IgnoreCase);


            Tree = new Tree(s, new NodeTypeDeterminator());

            Tree.ProcessTree(new Context.Context(new DifferentiationStrategiesSetter()));

            if (chkSimplify?.Checked ?? false)
            {
                Tree.ProcessTree(new Context.SimplifyContext(new SimplifyStrategiesSetter(), chkSimpliestForm?.Checked ?? false));
            }
            string result = Tree.Head.Output();
            result = Regex.Replace(result, "[[]", "sin");
            result = Regex.Replace(result, "[]]", "cos");
            result = Regex.Replace(result, "[!]", "tan");
            result = Regex.Replace(result, "[?]", "ln");
            result = Regex.Replace(result, "[#]", "exp");
            result = Regex.Replace(result, "[%]", "sqrt");
            textBox2.Text = result;
        }

        private void chkbtnSimplify_CheckedChanged(object sender, EventArgs e)
        {
            var chkbtn = sender as CheckBox;
            btnSimplify.Visible = !chkbtn?.Checked ?? true;
        }

        private void btnSimplify_Click(object sender, EventArgs e)
        {
            Tree?.ProcessTree(new Context.SimplifyContext(new SimplifyStrategiesSetter(), chkSimpliestForm?.Checked ?? false));
            string result = Tree.Head.Output();
            result = Regex.Replace(result, "[[]", "sin");
            result = Regex.Replace(result, "[]]", "cos");
            result = Regex.Replace(result, "[!]", "tan");
            result = Regex.Replace(result, "[?]", "ln");
            result = Regex.Replace(result, "[#]", "exp");
            result = Regex.Replace(result, "[%]", "sqrt");
            textBox2.Text = result;
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = FileReader.GetExpressionFromFile(openFileDialog1.FileName);
            }
            
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new HelpForm().Show();
        }
    }
}
