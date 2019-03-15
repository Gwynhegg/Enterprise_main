using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Enterprise_main
{
    public partial class form_Sellment : Form
    {
        Graphics g;
        public bool isDone;
        private void btn_Close_Click(object sender, EventArgs e)
        {
            isDone = true;
            this.Close();
        }

        Pen pen1 = new Pen(Color.Black, 1);
        Random r = new Random();

        public form_Sellment(int population, double rating, int sellment)
        {
            InitializeComponent();
            this_Population.Text = population.ToString();
            this_Rating.Text = rating.ToString("0.00");
            this_Sellment.Text = sellment.ToString();
        }
    }
}
