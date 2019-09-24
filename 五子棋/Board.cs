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
        public static readonly int NODE_COUNT=9;
        private static readonly Point NO_MATCH_NODE = new Point(-1, - 1);

        private static readonly int OFFSET = 50;
        private static readonly int Radius = 10;
        private static readonly int distance = 47;
        private Piece[,] pieces = new Piece[9, 9];

        private Point lastPlaceNode = NO_MATCH_NODE;
        public Point LastPlaceNode { get { return lastPlaceNode; } }

        public PieceType GetPieceType(int nodeIdX,int nodeIdY)
        {
            if (pieces[nodeIdX, nodeIdY] == null)
                return PieceType.NONE;
            else
                return pieces[nodeIdX, nodeIdY].GetPieceType();
        }

        public bool CanBePlaced(int x, int y)
        {
            Point nodeId = findTheClosetNode(x, y);

            if (nodeId == NO_MATCH_NODE)
            {
                return false;
            }
            return true;
        }

        public Piece PlacePiece(int x,int y ,PieceType type)
        {
            Point nodeId=findTheClosetNode(x,y);
            if (nodeId == NO_MATCH_NODE)
            {
                return null;
            }

            if (pieces[nodeId.X, nodeId.Y] != null)
                return null;
            Point formPos=convertToFromPosition(nodeId);

            if (type == PieceType.BLACK)
                pieces[nodeId.X, nodeId.Y] = new BlackPiece(formPos.X,formPos.Y);
            else if (type == PieceType.WHITE)
                pieces[nodeId.X, nodeId.Y] = new WhitePiece(formPos.X,formPos.Y);


            //紀錄最後下棋子的位置
            lastPlaceNode = nodeId;

            return pieces[nodeId.X, nodeId.Y];
            
        }

        private Point convertToFromPosition(Point nodeId)
        {
            Point formPosition=new Point();
            formPosition.X=nodeId.X*distance+OFFSET;
            formPosition.Y=nodeId.Y*distance+OFFSET;
            return formPosition;
        }

        private Point findTheClosetNode(int x, int y)
        {
            int nodeX = findTheClosetNode(x);
            if (nodeX == -1||nodeX>=NODE_COUNT)
               return NO_MATCH_NODE;
            int nodeY = findTheClosetNode(y);
            if (nodeY == -1||nodeY>=NODE_COUNT)
                return NO_MATCH_NODE;
            
            return new Point(nodeX, nodeY);
        }


        private int findTheClosetNode(int pos)
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
