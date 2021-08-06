using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToeUI.Presentation
{
    class LoginForm:Form
    {
        public LoginForm()
        {
            this.Size = new Size(400, 400);
            this.BackColor = Color.LightBlue;
            
            Label p1Name = new Label();
            Label p2Name = new Label();
            p1Name.Text = "Player 1 Name: ";
            p2Name.Text = "Player 2 Name: ";
            p1Name.Location = new Point(100,100);
            p2Name.Location = new Point(100, 150);
            p1Name.Font = new Font("Arial", 10);
            p2Name.Font = new Font("Arial", 10);

            TextBox p1Data = new TextBox();
            TextBox p2Data = new TextBox();
            p1Data.Location = new Point(200,100);
            p2Data.Location = new Point(200,150);
            p1Data.Font = new Font("Arial", 10);
            p2Data.Font = new Font("Arial", 10);

            Button submitData = new Button();
            submitData.Text = "Submit";
            submitData.Location = new Point(180,200);
            submitData.Font = new Font("Arial", 10);
            submitData.BackColor = Color.LightGreen;
            
            submitData.Click += (sender, e) =>
            {
                string p1 = p1Data.Text;
                string p2 = p2Data.Text;

                MainForm m1 = new MainForm(p1,p2);
                m1.Show();
            };

            this.Controls.Add(p1Name);
            this.Controls.Add(p2Name);
            this.Controls.Add(p1Data);
            this.Controls.Add(p2Data);
            this.Controls.Add(submitData);

        }
    }
}
