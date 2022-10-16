using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace N_Puzzle_Visual
{
    public partial class N_Puzzle_Visual_Form : Form
    {
        public N_Puzzle_Visual_Form()
        {
            InitializeComponent();
        }

        /*
        1 2 3 4 5 6 7 8 9 10 0 12 13 14 11 15
        1 2 3 4 5 6 7 8 9 10 11 12 13 14 0 15
        1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 0
        */
        //创建按钮控件数组
        private Button[] num = new Button[16];
        private void button_start_Click(object sender, EventArgs e)
        {
            //使用控件数组绑定设计器中设定好的按钮
            num[0] = num_empty;
            num[1] = num1;
            num[2] = num2;
            num[3] = num3;
            num[4] = num4;
            num[5] = num5;              
            num[6] = num6;
            num[7] = num7;
            num[8] = num8;
            num[9] = num9;
            num[10] = num10;
            num[11] = num11;
            num[12] = num12;
            num[13] = num13;
            num[14] = num14;
            num[15] = num15;

            Move_block(15);
            Thread.Sleep(100);
            Move_block(11);
            Thread.Sleep(100);
        }
    
        public void Move_block(int block)
        {
            //block的坐标，作为空格目标坐标
            int Next_locationX = num[block].Location.X;
            int Next_locationY = num[block].Location.Y;

            //由于交换的格与空格相比，必有X或Y坐标其一相等，所以只需改变他们的其中一个坐标，进行移动
            while (num[block].Location.X > num[0].Location.X)
            {
                num[block].Location = new System.Drawing.Point(num[block].Location.X - 1, num[block].Location.Y);
                Thread.Sleep(1);
            }
            while (num[0].Location.X < Next_locationX)
            {
                num[0].Location = new System.Drawing.Point(num[0].Location.X + 1, num[0].Location.Y);
                //Thread.Sleep(1);
            }


            while (num[block].Location.X < num[0].Location.X)
            {
                num[block].Location = new System.Drawing.Point(num[block].Location.X + 1, num[block].Location.Y);
                Thread.Sleep(1);
            }
            while (num[0].Location.X > Next_locationX)
            {
                num[0].Location = new System.Drawing.Point(num[0].Location.X - 1, num[0].Location.Y);
                //Thread.Sleep(1);
            }


            while (num[block].Location.Y > num[0].Location.Y)
            {
                num[block].Location = new System.Drawing.Point(num[block].Location.X, num[block].Location.Y - 1);
                Thread.Sleep(1);
            }
            while (num[0].Location.Y < Next_locationY)
            {
                num[0].Location = new System.Drawing.Point(num[0].Location.X, num[0].Location.Y + 1);
                //Thread.Sleep(1);
            }

            while (num[block].Location.Y < num[0].Location.Y)
            {
                num[block].Location = new System.Drawing.Point(num[block].Location.X, num[block].Location.Y + 1);
                Thread.Sleep(1);
            }
            while (num[0].Location.Y > Next_locationY)
            {
                num[0].Location = new System.Drawing.Point(num[0].Location.X, num[0].Location.Y - 1);
                //Thread.Sleep(1);
            }
        }
        
    }
}
