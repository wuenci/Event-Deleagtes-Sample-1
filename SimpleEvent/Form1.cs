using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleEvent
{
    public partial class Form1 : Form
    {

        Randomizer rnd = new Randomizer();
        public Form1()
        {
            InitializeComponent();
            var t = rnd.ProcessGeneratorAsync();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            rnd.RandomizerEventCalculated += Rnd_RandomizerEventCalculated;
            btnStart.Enabled = false;
            btnStop.Enabled = true;
        }

        private void Rnd_RandomizerEventCalculated(object sender, EventArgs e)
        {
            var lista = (sender as Randomizer).Numbers;
            listBox1.DataSource = lista;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            rnd.RandomizerEventCalculated -= Rnd_RandomizerEventCalculated;
            btnStop.Enabled = false;
            btnStart.Enabled = true;
        }
    }
}
