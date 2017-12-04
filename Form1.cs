using System;
using System.ComponentModel;
using System.Globalization;
using System.Resources;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using KursProject1.Context;
using KursProject1.DifferentiationStrategies;
using KursProject1.Exceptions;
using KursProject1.SimplifyStrategies;

namespace KursProject1 {
    public partial class MainForm : Form {
        public Tree Tree { get; set; }
        public ResourceManager ResourceManager { get; set; }

        public MainForm()
        {
            ResourceManager = new ResourceManager("KursProject1.ExceptionLocalization", typeof(MainForm).Assembly);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            var s = textBox1.Text.Replace(" ", String.Empty);


            try
            {
                Tree = new Tree(s);


                Tree.ProcessTree(new Context.Context(new DifferentiationStrategiesSetter()));

                if (chkSimplify?.Checked ?? false)
                {
                    Tree.ProcessTree(new SimplifyContext(new SimplifyStrategiesSetter(),
                        chkSimplify?.Checked ?? false));
                }
                string result = Tree.Output();

                textBox2.Text = result;
            }
            catch (ExpressionException ex)
            {
                MessageBox.Show(ResourceManager.GetString(ex.GetType().Name) + $" [{ex.Node}]");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            Tree?.ProcessTree(new SimplifyContext(new SimplifyStrategiesSetter(), chkSimplify?.Checked ?? false));
            string result = Tree?.Output();
            textBox2.Text = result;

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
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
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
                    ChangeMetuItem(c, info, manager);
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
