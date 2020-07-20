using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship
{
    public class Battlefield
    {
        public delegate void MyEventHandler(object source, MyEventArgs e);
        public MyEventHandler Click { set; get; } = null;

        Button[,] buttonGrid;
        public Battlefield(Form form, int m, int n, int top, int left, int buttonSize)
        {
            buttonGrid = new Button[m,n];
            for (int i = 0; i<m; i++) //column of number coordinates
            {
                Label label = new Label();
                label.Text = ""+i;
                label.Top = top + (i+1) * buttonSize;
                label.Left = left;
                label.Width = buttonSize;
                label.TextAlign = ContentAlignment.MiddleCenter;
                form.Controls.Add(label);
            }

            for (int j = 0; j < n; j++) //row of letter coordinates
            {
                Label label = new Label();
                label.Text = "" + (char)('a'+ j);
                label.Top = top;
                label.Left = left + (j + 1) * buttonSize;
                label.Width = buttonSize;
                label.TextAlign = ContentAlignment.MiddleCenter;
                form.Controls.Add(label);
            }

            for (int i = 0; i < m; i++) //adding rows of buttons
            {
                for (int j = 0; j < n; j++)
                {
                    Button button = new Button();
                    //button.Text = "" + i;
                    button.Top = top + (i + 1) * buttonSize;
                    button.Left = left+(j+1)*buttonSize;
                    button.Width = buttonSize;
                    button.Height = buttonSize;
                    button.Click += button_Click;
                    form.Controls.Add(button);
                    buttonGrid[i,j] = button;
                }
            }
        }

        private void button_Click(object sender, EventArgs e)
        {
            int I = -1;
            int J = -1;
            int m = buttonGrid.GetLength(0);
            int n = buttonGrid.GetLength(1);
            for (int i = 0; i<m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if(buttonGrid[i,j] == (Button)sender)
                    {
                        I = i;
                        J = j;
                    }
                }
            }
            //MyEventArgs E = new MyEventArgs(I, J);
            if (Click != null) Click(this, new MyEventArgs(I, J));
        }

        public void fillAcc2Map(int[,] map)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (map[i, j] == 1)
                        buttonGrid[i, j].BackColor = Color.Green;
                    else
                        buttonGrid[i, j].BackColor = default(Color);
                }

            }
        }

        public class MyEventArgs : EventArgs
        {
            public int i {get; }
            public int j {get; } 
            public MyEventArgs(int i, int j)
            {
                this.i = i;
                this.j = j;
            }
        }
    }
}