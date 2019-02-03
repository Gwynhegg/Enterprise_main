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
    public partial class form_Enterprise : Form
    {
        Director director1;
        int days = 1;
        Game currentGame;
        List<Human> crew;
        public form_Enterprise()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_createFirm_Click(object sender, EventArgs e)
        {
            director1 = new Director(txt_nameofFirm.Text, Int32.Parse(txt_startBudget.Text));
            txt_Budget.Text = director1.returnBudget().ToString();
            txt_currName.Text = director1.returnName().ToString();

            crew = new List<Human>();
            txt_currentData.Text = days.ToString();
            run_of_time.Enabled = true;
        }

        private void run_of_time_Tick(object sender, EventArgs e)
        {
            days++;
            txt_currentData.Text = days.ToString();
            txt_Budget.Text = director1.returnBudget().ToString();

            if (!director1.hasProject)
            {
                director1.startProject("Horror", "Medium", "AAAAAAAA");
                currentGame = director1.getGame();
                director1.hasProject = true;
            } else
            {
                txt_currReadiness.Text = director1.readiness_ofProject().ToString();
            }

            if (crew.Count() == 0) crew.Add(new Programmer(200, 200));

            foreach(Human buddy in crew)
            {   
                if (days % 30 == 0)
                {
                    director1.setBudget(director1.returnBudget() - buddy.GetPaid());
                }
                buddy.ToWork(currentGame);
            }
        }
    }
}
