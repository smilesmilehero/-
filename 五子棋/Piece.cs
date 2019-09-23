using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace 五子棋
{
    abstract class Piece : PictureBox //加上abstract，其他地方無法建立Piece類別
    {
        private static readonly int IMG_WIDTH = 35;

        public Piece(int x,int y)
        {   
            //網路找使用方式MSDN，找型態使用語法 (微軟官方手冊
            this.BackColor = Color.Transparent;
            this.Location = new Point(x - IMG_WIDTH / 2, y - IMG_WIDTH / 2);
            
            this.Size = new Size(IMG_WIDTH, IMG_WIDTH);
        }
    }
}
