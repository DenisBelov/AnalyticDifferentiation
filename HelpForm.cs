using System.IO;
using System.Windows.Forms;

namespace KursProject1 {
    public partial class HelpForm : Form {
        public HelpForm()
        {
            InitializeComponent();
            richTextBox1.Rtf = new StreamReader(new FileStream("help.rtf", FileMode.Open)).ReadToEnd();
        }
    }
}
