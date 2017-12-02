using System.IO;
using System.Windows.Forms;

namespace KursProject1 {
    public partial class HelpForm : Form {
        public HelpForm()
        {
            InitializeComponent();
            using (var stream = new FileStream("help.rtf", FileMode.Open))
            {
                richTextBox1.Rtf = new StreamReader(stream).ReadToEnd();
            }
        }
    }
}
