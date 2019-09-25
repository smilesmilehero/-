using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 五子棋
{
    class Game
    {
        private Board board = new Board();

        private PieceType currentPlayer = PieceType.BLACK;

        private PieceType winner=PieceType.NONE;

        public PieceType Winner { get { return winner; } }

        public bool CanBePlaced(int x,int y)
        {
            return board.CanBePlaced(x, y);
        }

        public Piece PlacePiece(int x,int y)
        {
            Piece piece = board.PlacePiece(x, y, currentPlayer);
            Random random = new Random();
            if (piece != null)
            {
                //檢查下棋人是否勝利
                CheckWinner();

                //交換選手
                if (currentPlayer == PieceType.BLACK)
                    currentPlayer = PieceType.WHITE;
                else if (currentPlayer == PieceType.WHITE)

                            

                    currentPlayer = PieceType.BLACK;
                return piece;
            }

            return null;
        }

        private void CheckWinner()
        {
            int centerX = board.LastPlaceNode.X;
            int centerY = board.LastPlaceNode.Y;

            //檢查8個方向
            for(int xDir=-1;xDir<=1;xDir++){
                for(int yDir=-1;yDir<=1;yDir++){
                    //排除中間情況

                    if(xDir==0&&yDir==0){
                        continue;
                    }                                             

                    //紀錄現在看到幾顆相同旗子
                    int count = 1;
                    int count2 = 1;
                    while (count < 5)
                    {
                        int targetX = centerX + count * xDir;
                        int targetY = centerY + count * yDir;
                
                        //檢查顏色是否相同
                        if (targetX<=0||targetX>=Board.NODE_COUNT||
                            targetY <= 0 || targetY >= Board.NODE_COUNT ||
                            board.GetPieceType(targetX, targetY) != currentPlayer)
                            break;

                        count++;
                    }

                    while (count2 < 5)
                    {
                        int targetX = centerX - count2 * xDir;
                        int targetY = centerY - count2 * yDir;

                    if (targetX < 0 || targetX >= Board.NODE_COUNT ||
                        targetY < 0 || targetY >= Board.NODE_COUNT ||
                        board.GetPieceType(targetX, targetY) != currentPlayer)
                    {
                        break;
                    }
                        count2++;
                    }
                    
                    //檢查是否看到5科旗子
                    if (count + count2 > 5)
                    {
                        winner = currentPlayer;
                    }
                    else if(count==5){
                        winner = currentPlayer;
                    }
                }
            }
        }
    }
}
