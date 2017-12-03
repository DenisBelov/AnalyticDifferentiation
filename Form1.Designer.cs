using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace KursProject1
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));
            this.btnProcess = new Button();
            this.textBox1 = new TextBox();
            this.textBox2 = new TextBox();
            this.menuStrip1 = new MenuStrip();
            this.fileToolStripMenuItem = new ToolStripMenuItem();
            this.открытьToolStripMenuItem = new ToolStripMenuItem();
            this.helpToolStripMenuItem = new ToolStripMenuItem();
            this.языкToolStripMenuItem = new ToolStripMenuItem();
            this.englshToolStripMenuItem = new ToolStripMenuItem();
            this.franceToolStripMenuItem1 = new ToolStripMenuItem();
            this.русскийToolStripMenuItem1 = new ToolStripMenuItem();
            this.label1 = new Label();
            this.DifferentiationBox = new GroupBox();
            this.chkSimpliestForm = new CheckBox();
            this.chkSimplify = new CheckBox();
            this.btnSimplify = new Button();
            this.label2 = new Label();
            this.openFileDialog1 = new OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.DifferentiationBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            resources.ApplyResources(this.btnProcess, "btnProcess");
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            // 
            // textBox2
            // 
            resources.ApplyResources(this.textBox2, "textBox2");
            this.textBox2.Name = "textBox2";
            // 
            // menuStrip1
            // 
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.BackColor = SystemColors.ButtonHighlight;
            this.menuStrip1.Items.AddRange(new ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.языкToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            this.fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            this.открытьToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            // 
            // открытьToolStripMenuItem
            // 
            resources.ApplyResources(this.открытьToolStripMenuItem, "открытьToolStripMenuItem");
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Click += new EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Click += new EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // языкToolStripMenuItem
            // 
            resources.ApplyResources(this.языкToolStripMenuItem, "языкToolStripMenuItem");
            this.языкToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            this.englshToolStripMenuItem,
            this.franceToolStripMenuItem1,
            this.русскийToolStripMenuItem1});
            this.языкToolStripMenuItem.Name = "языкToolStripMenuItem";
            // 
            // englshToolStripMenuItem
            // 
            resources.ApplyResources(this.englshToolStripMenuItem, "englshToolStripMenuItem");
            this.englshToolStripMenuItem.Name = "englshToolStripMenuItem";
            this.englshToolStripMenuItem.Click += new EventHandler(this.englishToolStripMenuItem2_Click);
            // 
            // franceToolStripMenuItem1
            // 
            resources.ApplyResources(this.franceToolStripMenuItem1, "franceToolStripMenuItem1");
            this.franceToolStripMenuItem1.Name = "franceToolStripMenuItem1";
            this.franceToolStripMenuItem1.Click += new EventHandler(this.françaisToolStripMenuItem1_Click);
            // 
            // русскийToolStripMenuItem1
            // 
            resources.ApplyResources(this.русскийToolStripMenuItem1, "русскийToolStripMenuItem1");
            this.русскийToolStripMenuItem1.Name = "русскийToolStripMenuItem1";
            this.русскийToolStripMenuItem1.Click += new EventHandler(this.русскийToolStripMenuItem3_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // DifferentiationBox
            // 
            resources.ApplyResources(this.DifferentiationBox, "DifferentiationBox");
            this.DifferentiationBox.Controls.Add(this.chkSimpliestForm);
            this.DifferentiationBox.Controls.Add(this.chkSimplify);
            this.DifferentiationBox.Controls.Add(this.btnSimplify);
            this.DifferentiationBox.Controls.Add(this.textBox1);
            this.DifferentiationBox.Controls.Add(this.btnProcess);
            this.DifferentiationBox.Controls.Add(this.textBox2);
            this.DifferentiationBox.Controls.Add(this.label2);
            this.DifferentiationBox.Controls.Add(this.label1);
            this.DifferentiationBox.Name = "DifferentiationBox";
            this.DifferentiationBox.TabStop = false;
            // 
            // chkSimpliestForm
            // 
            resources.ApplyResources(this.chkSimpliestForm, "chkSimpliestForm");
            this.chkSimpliestForm.Name = "chkSimpliestForm";
            this.chkSimpliestForm.UseVisualStyleBackColor = true;
            // 
            // chkSimplify
            // 
            resources.ApplyResources(this.chkSimplify, "chkSimplify");
            this.chkSimplify.Name = "chkSimplify";
            this.chkSimplify.UseVisualStyleBackColor = true;
            this.chkSimplify.CheckedChanged += new EventHandler(this.chkbtnSimplify_CheckedChanged);
            // 
            // btnSimplify
            // 
            resources.ApplyResources(this.btnSimplify, "btnSimplify");
            this.btnSimplify.Name = "btnSimplify";
            this.btnSimplify.UseVisualStyleBackColor = true;
            this.btnSimplify.Click += new EventHandler(this.btnSimplify_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = AutoScaleMode.Font;
            this.Controls.Add(this.DifferentiationBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.DifferentiationBox.ResumeLayout(false);
            this.DifferentiationBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnProcess;
        private TextBox textBox1;
        private TextBox textBox2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private Label label1;
        private GroupBox DifferentiationBox;
        private Label label2;
        private CheckBox chkSimplify;
        private Button btnSimplify;
        private CheckBox chkSimpliestForm;
        private ToolStripMenuItem открытьToolStripMenuItem;
        private OpenFileDialog openFileDialog1;
        private ToolStripMenuItem языкToolStripMenuItem;
        private ToolStripMenuItem englshToolStripMenuItem;
        private ToolStripMenuItem franceToolStripMenuItem1;
        private ToolStripMenuItem русскийToolStripMenuItem1;
    }
}

