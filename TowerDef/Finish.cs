using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TowerDef
{
    public partial class Finish : Form
    {
        public Finish(int type)
        {
            InitializeComponent();
            switch (type)
            {
                case 1: label1.Text = "Вы выиграли! Игра окончена"; break;
                case 2: label1.Text = "Вы проиграли! Попробуйте снова ;)"; break;
            }
        }

        private void Finish_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
