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
    public partial class CharacterPanel : Form
    {
        public CharacterPanel(string speciality)
        {
            InitializeComponent();
            this_Speciality.Text = speciality;
            if (speciality != "Programmer") txt_Coding.Visible = false;
            if (speciality == "Manager")
            {
                txt_Design.Text = "Скилл:";
                txt_Performance.Visible = false;
            }
        }

        public void updateParams(Developer dev)
        {
            this_Skill.Text = dev.getTotalDesignSkill().ToString();
            this_Fatigue.Text = dev.getFatigue().ToString();
            this_Performance.Text = dev.getTotalPerformance().ToString("0.00");
            if (dev is Programmer)
            {
                this_Coding.Text = dev.getTotalCodeSkill().ToString();
            }
            if (dev.getTired()) BackColor = Color.Gray; else
            {
                int n = dev.getFatigue();
                if (n < 100) BackColor = Color.Green; else
                {
                    if (dev.getFatigue() > 100) BackColor = Color.Orange; else
                    {
                        if (dev.getFatigue() > 200) BackColor = Color.Red;
                    }
                }
            }
        }

        public void updateParams(Manager man)
        {
            this_Skill.Text = man.getManagerSkill().ToString();
            this_Fatigue.Text = man.getFatigue().ToString();
            if (man.getTired()) BackColor = Color.Gray;
            else
            {
                int n = man.getFatigue();
                if (n < 100) BackColor = Color.Green;
                else
                {
                    if (man.getFatigue() > 100) BackColor = Color.Orange;
                    else
                    {
                        if (man.getFatigue() > 200) BackColor = Color.Red;
                    }
                }
            }
        }
    }
}
