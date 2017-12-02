using System;
using System.Windows.Forms;
using KursProject1.DifferentiationStrategies;
using KursProject1.SimplifyStrategies;
using System.Text.RegularExpressions;
using System.Threading;
using System.Globalization;
using System.ComponentModel;

namespace KursProject1 {
    public partial class MainForm : Form {
        public Tree Tree { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //try {
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
            //}
            //catch (Exception exc)
            //{
            //    MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
        }

        private void chkbtnSimplify_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                var chkbtn = sender as CheckBox;
                btnSimplify.Visible = !chkbtn?.Checked ?? true;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnSimplify_Click(object sender, EventArgs e)
        {
            //try {
                Tree?.ProcessTree(new Context.SimplifyContext(new SimplifyStrategiesSetter(), chkSimpliestForm?.Checked ?? false));
                string result = Tree.Head.Output();
                result = Regex.Replace(result, "[[]", "sin");
                result = Regex.Replace(result, "[]]", "cos");
                result = Regex.Replace(result, "[!]", "tan");
                result = Regex.Replace(result, "[?]", "ln");
                result = Regex.Replace(result, "[#]", "exp");
                result = Regex.Replace(result, "[%]", "sqrt");
                textBox2.Text = result;
           // }
            //catch (Exception exc)
            //{
            //    MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    textBox1.Text = FileReader.GetExpressionFromFile(openFileDialog1.FileName);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new HelpForm().Show();
        }

        private void englishToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ChangeLanguage("en-US");
        }

        private void françaisToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ChangeLanguage("fr-FR");
        }

        private void русскийToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ChangeLanguage("ru-RU");
        }

        private void ChangeLanguage(string culture)
        {
            var cultureInfo = new CultureInfo(culture);
            var forms = Application.OpenForms;
            foreach (var form in forms)
            {
                var manager = new ComponentResourceManager(form.GetType());
                foreach (Control control in ((Form) form).Controls)
                {
                    ChangeControl(control, cultureInfo, manager);
                }
            }
        }

        private void ChangeControl(Control control, CultureInfo info, ComponentResourceManager manager)
        {
            foreach(Control c in control.Controls)
            {
                ChangeControl(c, info, manager);
                manager.ApplyResources(c, c.Name, info);
            }
            if(control is MenuStrip)
            {
                foreach (ToolStripMenuItem c in (control as MenuStrip).Items)
                {
                    ChangeMetuItem(c as ToolStripMenuItem, info, manager);
                    manager.ApplyResources(c, c.Name, info);
                }
            }
            manager.ApplyResources(control, control.Name, info);
        }

        private void ChangeMetuItem(ToolStripMenuItem item, CultureInfo info, ComponentResourceManager manager)
        {
            foreach (ToolStripMenuItem c in item.DropDownItems)
            {
                ChangeMetuItem(c, info, manager);
                manager.ApplyResources(c, c.Name, info);
            }
        }
    }
}
