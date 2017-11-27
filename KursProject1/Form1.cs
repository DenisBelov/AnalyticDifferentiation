using System;
using System.Windows.Forms;
using KursProject1.DifferentiationStrategies;
using KursProject1.SimplifyStrategies;

namespace KursProject1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var s = textBox1.Text;
            var tree = new Tree(s, new NodeTypeDeterminator());
            tree.ProcessTree(new Context.Context(new DifferentiationStrategiesSetter()));
            tree.ProcessTree(new Context.SimplifyContext(new SimplifyStrategiesSetter()));
            textBox2.Text = tree.Head.Output();
        }
    }
}
