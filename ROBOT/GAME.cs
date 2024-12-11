using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ROBOT
{
    public partial class GAME : Form
    {
        public GAME()
        {
            InitializeComponent();

            ConfigurarEventosArrastre();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

        private void ConfigurarEventosArrastre()
        {
            pctVerde.MouseDown += Color_MouseDown;
            pctAzul.MouseDown += Color_MouseDown;
            pctAmarillo.MouseDown += Color_MouseDown;
            pctRojo.MouseDown += Color_MouseDown;

            pct1.AllowDrop = true;
            pct2.AllowDrop = true;
            pct3.AllowDrop = true;
            pct4.AllowDrop = true;
            pct5.AllowDrop = true;
            pct6.AllowDrop = true;
            pct7.AllowDrop = true;
            pct8.AllowDrop = true;

            pct1.DragEnter += Celda_DragEnter;
            pct2.DragEnter += Celda_DragEnter;
            pct3.DragEnter += Celda_DragEnter;
            pct4.DragEnter += Celda_DragEnter;
            pct5.DragEnter += Celda_DragEnter;
            pct6.DragEnter += Celda_DragEnter;
            pct7.DragEnter += Celda_DragEnter;
            pct8.DragEnter += Celda_DragEnter;

            pct1.DragDrop += Celda_DragDrop;
            pct2.DragDrop += Celda_DragDrop;
            pct3.DragDrop += Celda_DragDrop;
            pct4.DragDrop += Celda_DragDrop;
            pct5.DragDrop += Celda_DragDrop;
            pct6.DragDrop += Celda_DragDrop;
            pct7.DragDrop += Celda_DragDrop;
            pct8.DragDrop += Celda_DragDrop;
        }

        private void Color_MouseDown(object sender, MouseEventArgs e)
        {
            var pictureBox = sender as PictureBox;
            if (pictureBox != null)
            {
                DoDragDrop(pictureBox.BackColor, DragDropEffects.Copy);
            }
        }

        private void Celda_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(Color)))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Celda_DragDrop(object sender, DragEventArgs e)
        {
            var pictureBox = sender as PictureBox;
            if (pictureBox != null)
            {
                pictureBox.BackColor = (Color)e.Data.GetData(typeof(Color));
            }
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            pct1.BackColor = Color.DarkGreen;
            pct2.BackColor = Color.DarkBlue;
            pct3.BackColor = Color.DarkBlue;
            pct4.BackColor = Color.Yellow;
            pct5.BackColor = Color.DarkRed;
            pct6.BackColor = Color.DarkGreen;
            pct7.BackColor = Color.Yellow;
            pct8.BackColor = Color.DarkRed;
        }

        private void btnComprobar_Click(object sender, EventArgs e)
        {
            Dictionary<PictureBox, Color> coloresCorrectos = new Dictionary<PictureBox, Color>
    {
        { pct1, Color.Yellow },
        { pct2, Color.DarkGreen },
        { pct3, Color.DarkGreen },
        { pct4, Color.DarkGreen },
        { pct5, Color.DarkGreen },
        { pct6, Color.Yellow },
        { pct7, Color.DarkGreen },
        { pct8, Color.DarkGreen }
    };

            int celdasIncorrectas = 0;

            foreach (var celda in coloresCorrectos)
            {
                if (celda.Key.BackColor != celda.Value)
                {
                    celdasIncorrectas++;
                }
            }

            if (celdasIncorrectas == 0)
            {
                MessageBox.Show("¡Has ganado el reto!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"Hay {celdasIncorrectas} celdas incorrectas. ¡Intenta de nuevo!", "Intenta otra vez", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAleatorio_Click(object sender, EventArgs e)
        {
            Color[] colores = { Color.Yellow, Color.DarkGreen, Color.DarkBlue, Color.DarkRed };

            Random random = new Random();

            PictureBox[] celdas = { pct1, pct2, pct3, pct4, pct5, pct6, pct7, pct8 };

            foreach (var celda in celdas)
            {
                int indiceColor = random.Next(colores.Length);
                celda.BackColor = colores[indiceColor];
            }
        }

    }
}
