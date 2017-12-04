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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnProcess = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.языкToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.franceToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.русскийToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.DifferentiationBox = new System.Windows.Forms.GroupBox();
            this.chkSimplify = new System.Windows.Forms.CheckBox();
            this.btnSimplify = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.DifferentiationBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            resources.ApplyResources(this.btnProcess, "btnProcess");
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.button1_Click);
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
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem,
            this.языкToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            resources.ApplyResources(this.открытьToolStripMenuItem, "открытьToolStripMenuItem");
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // языкToolStripMenuItem
            // 
            this.языкToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englshToolStripMenuItem,
            this.franceToolStripMenuItem1,
            this.русскийToolStripMenuItem1});
            this.языкToolStripMenuItem.Name = "языкToolStripMenuItem";
            resources.ApplyResources(this.языкToolStripMenuItem, "языкToolStripMenuItem");
            // 
            // englshToolStripMenuItem
            // 
            this.englshToolStripMenuItem.Name = "englshToolStripMenuItem";
            resources.ApplyResources(this.englshToolStripMenuItem, "englshToolStripMenuItem");
            this.englshToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem2_Click);
            // 
            // franceToolStripMenuItem1
            // 
            this.franceToolStripMenuItem1.Name = "franceToolStripMenuItem1";
            resources.ApplyResources(this.franceToolStripMenuItem1, "franceToolStripMenuItem1");
            this.franceToolStripMenuItem1.Click += new System.EventHandler(this.françaisToolStripMenuItem1_Click);
            // 
            // русскийToolStripMenuItem1
            // 
            this.русскийToolStripMenuItem1.Name = "русскийToolStripMenuItem1";
            resources.ApplyResources(this.русскийToolStripMenuItem1, "русскийToolStripMenuItem1");
            this.русскийToolStripMenuItem1.Click += new System.EventHandler(this.русскийToolStripMenuItem3_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // DifferentiationBox
            // 
            resources.ApplyResources(this.DifferentiationBox, "DifferentiationBox");
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
            // chkSimplify
            // 
            resources.ApplyResources(this.chkSimplify, "chkSimplify");
            this.chkSimplify.Name = "chkSimplify";
            this.chkSimplify.UseVisualStyleBackColor = true;
            this.chkSimplify.CheckedChanged += new System.EventHandler(this.chkbtnSimplify_CheckedChanged);
            // 
            // btnSimplify
            // 
            resources.ApplyResources(this.btnSimplify, "btnSimplify");
            this.btnSimplify.Name = "btnSimplify";
            this.btnSimplify.UseVisualStyleBackColor = true;
            this.btnSimplify.Click += new System.EventHandler(this.btnSimplify_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DifferentiationBox);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
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
        private ToolStripMenuItem открытьToolStripMenuItem;
        private OpenFileDialog openFileDialog1;
        private ToolStripMenuItem языкToolStripMenuItem;
        private ToolStripMenuItem englshToolStripMenuItem;
        private ToolStripMenuItem franceToolStripMenuItem1;
        private ToolStripMenuItem русскийToolStripMenuItem1;
    }
}

