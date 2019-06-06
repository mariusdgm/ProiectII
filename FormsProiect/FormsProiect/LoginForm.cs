using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormsProiect
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            //StreamReader str = new StreamReader("userpass.txt");
            //user_text.Text = str.ReadLine();
            //pass_text.Text = str.ReadLine();
        }

        private void log_button_Click(object sender, EventArgs e)
        {
            if (user_text.Text == "admin" && pass_text.Text == "admin")
            {
                new BrowseForm().Show();
            }
            else
            {
                MessageBox.Show("Incorrect username or password!");
            }
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}