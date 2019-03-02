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
    //Выбор жанра, размера и имени игры с последующей передачей на главную форму
    public partial class form_GameCreation : Form
    {
        public bool isDone = false;

        public form_GameCreation()
        {
            InitializeComponent();
        }

        private void Genre_TextChanged(object sender, EventArgs e)
        {
            txt_size.Visible = true;
            GameSize.Visible = true;
        }

        private void Size_TextChanged(object sender, EventArgs e)
        {
            txt_name.Visible = true;
            GameName.Visible = true;
            btn_Create.Visible = true;
        }

        private void btn_Create_Click(object sender, EventArgs e)
        {
            if (GameSize.Text!="" && Genre.Text != "")
            {
                isDone = true;
                this.Close();
            } else
            {
                MessageBox.Show("Введите необходимые параметры!", "Error", MessageBoxButtons.OK);
            }
        }

        public string getGenre()
        {
            return Genre.Text;
        }

        public string getSize()
        {
            return GameSize.Text;
        }

        public string getName()
        {
            return GameName.Text;
        }

    }
}
