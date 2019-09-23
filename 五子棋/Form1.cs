using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 五子棋
{    

    public partial class Form1 : Form
    {

        private Board board = new Board();

        private bool isBlack = true;

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (isBlack)
            {
                Piece piece = board.PlacePiece(e.X, e.Y, PieceType.BLACK);
                if (piece != null)
                {
                    this.Controls.Add(piece);
                    isBlack = false;
                }
            }
            else
            {
                Piece piece = board.PlacePiece(e.X, e.Y, PieceType.WHITE);
                if (piece != null)
                {
                    this.Controls.Add(piece);
                    isBlack = true;
                }
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (board.CanBePlaced(e.X, e.Y))
            {
                this.Cursor = Cursors.Hand;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }
    }
}
