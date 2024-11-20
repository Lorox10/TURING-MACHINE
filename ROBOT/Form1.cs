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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MusicPlayer.PlayMusicFromResources();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            MusicPlayer.StopMusic();
            Application.Exit();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            Instrucciones instrucciones = new Instrucciones();
            instrucciones.Show();
            this.Hide();

        }
    }
}
