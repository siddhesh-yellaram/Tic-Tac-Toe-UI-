using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToeLib;

namespace TicTacToeUI.Presentation
{
    class MainForm : Form
    {
        Game game;
        Label playerName;
        Button[] buttons = new Button[9];

        public MainForm(string p1, string p2)
        {
            string player1Name = p1;
            string player2Name = p2;
            var board = new Board(3);
            game = new Game(board);
            game.AddPlayers(new Player(player1Name, Mark.X));
            game.AddPlayers(new Player(player2Name, Mark.O));

            this.Size = new Size(315, 369);

            playerName = new Label();
            playerName.Location = new Point(110,0);
            playerName.Text = game.getCurrentPlayer().GetName() + " Turn!!";
            playerName.ForeColor = Color.Green;
            
            var titlePanel = new Panel();
            titlePanel.Size = new Size(315, 30);
            titlePanel.BackColor = Color.LightSkyBlue;
            titlePanel.Font = new Font("Arial", 10);
            titlePanel.Controls.Add(playerName);
            Controls.Add(titlePanel);

            var buttonPanel = new Panel();
            buttonPanel.Location = new Point(0, 30);
            buttonPanel.Size = new Size(300, 300);
            Controls.Add(buttonPanel);

            int x = 0;
            int y = 0;
            for (int i = 0; i < 9; i++)
            {
                if (x == 3)
                {
                    x = 0;
                    y++;
                }
                buttons[i] = new Button();
                buttons[i].Text = i.ToString();
                buttons[i].Size = new Size(100, 100);
                buttons[i].Location = new Point(100 * x, 100 * y);
                buttons[i].Font = new Font("Arial", 13);
                x++;
                buttons[i].Click += GameHandler;
                buttonPanel.Controls.Add(buttons[i]);
            }
        }
        private void GameHandler(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;

            int cellIndex = Convert.ToInt32(button.Text);

            if (game.getCurrentPlayer().GetMark().Equals(Mark.X))
            {
                button.Text = "X";
                button.ForeColor = Color.Green;
            }
            else
            {
                button.Text = "O";
                button.ForeColor = Color.Red;
            }

            game.Play(cellIndex);

            playerName.Text = game.getCurrentPlayer().GetName() + " Turn!!";

            GameResult();
        }

        private void GameResult()
        {
            if (game.getGameStatus().Equals(GameState.FINISHED))
            {
                playerName.Text = game.getNextPlayer().GetName() + " Has Won";
            }
            if (game.getGameStatus().Equals(GameState.DRAW))
            {
                playerName.Text = "Game Has Drawn";
            }
            if (game.getGameStatus().Equals(GameState.FINISHED) || game.getGameStatus().Equals(GameState.DRAW))
            {
                for (int i = 0; i < 9; i++)
                {
                    buttons[i].Enabled = false;
                }
            }
        }
    }
}
