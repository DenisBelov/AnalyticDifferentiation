using System;
using System.Windows.Forms;
using KursProject1.DifferentiationStrategies;
using KursProject1.SimplifyStrategies;

namespace KursProject1
{
    public partial class Form1 : Form
    {
        public Tree Tree { get; set; }

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var s = textBox1.Text.Replace(" ", String.Empty);

            var chkbtn = sender as CheckBox;
            
            Tree = new Tree(s, new NodeTypeDeterminator());

            Tree.ProcessTree(new Context.Context(new DifferentiationStrategiesSetter()));

            if (chkbtn?.Checked ?? false)
            {
                Tree.ProcessTree(new Context.SimplifyContext(new SimplifyStrategiesSetter()));
            }

            textBox2.Text = Tree.Head.Output();
        }

        private void chkbtnSimplify_CheckedChanged(object sender, EventArgs e)
        {
            var chkbtn = sender as CheckBox;
            btnSimplify.Visible = !chkbtn?.Checked ?? true;
        }

        private void btnSimplify_Click(object sender, EventArgs e)
        {
            Tree?.ProcessTree(new Context.SimplifyContext(new SimplifyStrategiesSetter()));
            textBox2.Text = Tree?.Head.Output();
        }
    }
}
