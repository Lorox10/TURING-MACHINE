using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ROBOT
{
    public partial class GAME : Form
    {
        public GAME()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnInstrucciones_Click(object sender, EventArgs e)
        {
            Instrucciones2 instrucciones2 = new Instrucciones2();
            instrucciones2.Show();
        }
    }
}
