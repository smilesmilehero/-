using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace 五子棋
{
    class Board
    {
        private static readonly Point NO_MATCH_NODE = new Point(-1, - 1);

        private static readonly int OFFSET = 50;
        private static readonly int Radius = 10;
        private static readonly int distance = 47;
        private Piece[,] pieces = new Piece[9, 9];

        public bool CanBePlaced(int x, int y)
        {
            Point nodeId = FindTheClosetNode(x, y);

            if (nodeId == NO_MATCH_NODE)
            {
                return false;
            }
            return true;
        }

        public Piece PlacePiece(int x,int y ,PieceType type)
        {
            Point nodeId = FindTheClosetNode(x, y);

            if (nodeId == NO_MATCH_NODE)
            {
                return null;
            }

            if (pieces[nodeId.X, nodeId.Y] != null)
                return null;

            if (type == PieceType.BLACK)
                pieces[nodeId.X, nodeId.Y] = new BlackPiece(x,y);
            else if (type == PieceType.WHITE)
                pieces[nodeId.X, nodeId.Y] = new WhitePiece(x,y);

            return pieces[nodeId.X, nodeId.Y];
            
        }

        private Point FindTheClosetNode(int x, int y)
        {
            int nodeX = FindTheClosetNode(x);
            if (nodeX == -1)
               return NO_MATCH_NODE;
            int nodeY = FindTheClosetNode(y);
            if (nodeY == -1)
                return NO_MATCH_NODE;
            
            return new Point(nodeX, nodeY);
        }


        private int FindTheClosetNode(int pos)
        {
            if (pos < OFFSET - Radius)
               return -1;

            pos -= OFFSET;
            int quoteitent = pos / distance;
            int reminder = pos % distance;

            if (reminder <= Radius)
                return quoteitent;
            else if (reminder >= distance - Radius)
                return quoteitent + 1;
            else
                return -1;
        }
    }
}
