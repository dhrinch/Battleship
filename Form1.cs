using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship
{
    public partial class Form1 : Form
    {
        Battlefield bf1, bf2;
        int mode = 0;
        CGame game1, game2;

        public Form1()
        {
            InitializeComponent();
            bf1 = new Battlefield(this, 10, 10, 20, 20, 30);
            bf2 = new Battlefield(this, 10, 10, 20, 420, 30);
            //bf1.Click += buttonClick;
            //bf2.Click += buttonClick;
            bf1.Click += buttonSetup_Click;
            bf2.Click += buttonSetup_Click;
            comboBox1.SelectedItem = comboBox1.Items[0];
            game1 = new CGame();
            game2 = new CGame();
        }

        private void buttonMode_Click(object sender, EventArgs e)
        {
            mode = 1 - mode;
            if (mode == 0)
            {
                buttonMode.Text = "Setup";
                bf1.Click -= buttonPlay_Click;
                bf1.Click += buttonSetup_Click;
                bf2.Click -= buttonPlay_Click;
                bf2.Click += buttonSetup_Click;
                comboBox1.Visible = true;
            }
            if (mode == 1)
            {
                buttonMode.Text = "Play";
                bf1.Click -= buttonSetup_Click;
                bf1.Click += buttonPlay_Click;
                bf2.Click -= buttonSetup_Click;
                bf2.Click += buttonPlay_Click;
                comboBox1.Visible = false;
            }
        }

        public void buttonClick(object sender, Battlefield.MyEventArgs e)
        {
            string name = "bf1";
            if ((Battlefield)sender == bf2) name = "bf2";
            //MessageBox.Show(name+" (" + e.i + ", " + e.j + ")");
        }

        private void buttonSetup_Click(object sender, Battlefield.MyEventArgs e)
        {
            if((Battlefield)sender == bf1)
            {
                Ship ship = game1.getShipByPosition(e.i, e.j);

                if (ship == null)
                    addShip(e.i, e.j);
                else
                    game1.delete(ship);

                bf1.fillAcc2Map(game1.fillMap());
            }
        }

        private void buttonPlay_Click(object sender, Battlefield.MyEventArgs e)
        {

        }

        public void addShip(int i, int j)
        {
            string s = comboBox1.Text;
            Ship.Direction dir = Ship.Direction.horiz;
            int size = 1;
            switch (s)
            {
                case "2 deck vertical":
                    dir = Ship.Direction.vert;
                    size = 2;
                    break;
                case "2 deck horizontal":
                    dir = Ship.Direction.horiz;
                    size = 2;
                    break;
                case "3 deck vertical":
                    dir = Ship.Direction.vert;
                    size = 3;
                    break;
                case "3 deck horizontal":
                    dir = Ship.Direction.horiz;
                    size = 3;
                    break;
                case "4 deck vertical":
                    dir = Ship.Direction.vert;
                    size = 4;
                    break;
                case "4 deck horizontal":
                    dir = Ship.Direction.horiz;
                    size = 4;
                    break;
            }
            //MessageBox.Show(" (" + e.j + ", " + e.i + ")");
            Ship ship = new Ship(i, j, dir, size);
            if (!game1.addShip(ship))
            {
                MessageBox.Show("Cannot place ship here");
            }
        }
    }
}
