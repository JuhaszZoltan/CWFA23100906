using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrvosiNobelDijasokGUI
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            btnMentes.Click += BtnMentes_Click;
        }

        private void BtnMentes_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxEv.Text)
                || string.IsNullOrEmpty(tbxNev.Text)
                || string.IsNullOrEmpty(tbxSzH.Text)
                || string.IsNullOrEmpty(tbxOrszag.Text))
            {
                MessageBox.Show("Tölts ki menden mezőt!");
            }
            else if (int.Parse(tbxEv.Text) <= 1989)
            {
                MessageBox.Show("Hiba! Az évszám nem megfelelő!");
            }
            else
            {
                try
                {
                    using (var sw = new StreamWriter(
                        @"..\..\src\uj_dijazott.txt", false, Encoding.UTF8))
                    {
                        sw.WriteLine("Év;Név;SzületésHalálozás;Országkód");
                        sw.WriteLine($"{tbxEv.Text};{tbxNev.Text};{tbxSzH.Text};{tbxOrszag.Text}");
                    }
                    tbxEv.Clear();
                    tbxNev.Clear();
                    tbxSzH.Clear();
                    tbxOrszag.Clear();
                }
                catch (Exception)
                {
                    MessageBox.Show("Hiba az állomány írásánál!");
                    throw;
                }
                
            }
        }
    }
}
