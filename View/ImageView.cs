using Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class ImageView : Form
    {
        private Dictionary<string, ICommand> _commands;

        Action<ICommand> _executePointer;


        public Action<ICommand> ExecutePointer
        {
            set { _executePointer = value; }
        }

        public Dictionary<string, ICommand> Commands
        {
            get { return _commands; }
            set { _commands = value; }
        }

        public ImageView()
        {
            InitializeComponent();

            _commands = new Dictionary<string, ICommand>();
        }

        private void ImageView_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        public void InjectCurrentImage(Image pImageList)
        {
            
        }
    }
}
