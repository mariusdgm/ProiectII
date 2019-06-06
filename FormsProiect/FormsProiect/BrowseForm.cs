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
    public partial class BrowseForm : Form
    {
        FormsProiect.ServiceReference1.WebService1SoapClient service = new FormsProiect.ServiceReference1.WebService1SoapClient();

        public BrowseForm()
        {
            InitializeComponent();
        }

        private void b_populate_list_click(object sender, EventArgs e)
        {
            cat_list.DataSource = service.afiseazaMagazin();
        }
    }
}
