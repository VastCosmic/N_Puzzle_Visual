using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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

        //默认Block坐标 16 Blocks with x,y
        public int[,] Block_default = new int[17, 2];    
        private void N_Puzzle_Visual_Form_Load(object sender, EventArgs e)  //窗体加载
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

            //获取默认Block坐标
            for(int i = 1; i <= 16; ++i)
            {
                if (i == 16)
                {
                    Block_default[i, 0] = num[0].Location.X;
                    Block_default[i, 1] = num[0].Location.Y;
                    //MessageBox.Show(Block_default[i, 0] + " , " + Block_default[i, 1]);
                }
                else
                {
                    Block_default[i, 0] = num[i].Location.X;
                    Block_default[i, 1] = num[i].Location.Y;
                    //MessageBox.Show(Block_default[i, 0] + " , " + Block_default[i, 1]);
                }
            }
        }

        public string path;
        private void file_chose_Click(object sender, EventArgs e)   //路径选择
        {
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = " ";
            file.ShowDialog();
            path = file.FileName;
            if(path != string.Empty)
            {
                file_chose.Text = "已选择路径文件";
                try
                {
                    Load_block();   //加载初始状态
                }
                catch
                {
                    MessageBox.Show("路径文件格式错误！", "警告");
                }
            }
            
        }

        public int[] Block_F = new int[16]; //存储初始的格子顺序
        public void Load_block()    //加载初始状态
        {
            string[] lines = System.IO.File.ReadAllLines(@path);
            
            //将首行读入字符串中，将其以空格为标识分割成int数组
            string str_Block_F = lines[0];
            string[] str_Arr_Block_F = str_Block_F.Split(' '); 
            try
            {
                for(int i = 0; i < 16; ++i)
                {
                    Block_F[i]=int.Parse(str_Arr_Block_F[i]);
                    //MessageBox.Show("i=" + i + "b=" + Block_F[i]);
                }               
            }
            catch
            {
                MessageBox.Show("路径文件格式错误！", "警告");
            }

            int j = 1;
            //排列Blocks
            foreach (int i in Block_F)
            {               
                num[i].Location = new System.Drawing.Point(Block_default[j, 0], Block_default[j, 1]);
                ++j;
            }
        }

        //创建按钮控件数组
        private Button[] num = new Button[16];
        private void button_start_Click(object sender, EventArgs e)
        {
            //文件读取
            if(path == null)
            {
                MessageBox.Show("请选择路径文件！","警告");
                return;
            }
            string[] lines = System.IO.File.ReadAllLines(@path);
            for (int i = 0; i < lines.Length; ++i)
            {
                if (i == 0) { }
                else
                {
                    //MessageBox.Show(line);
                    Move_block(Convert.ToInt32(lines[i]));
                    Thread.Sleep(10);
                }
            }
        }

        public void Move_block(int block)
        {
            //block的坐标，作为空格目标坐标
            int Next_locationX = num[block].Location.X;
            int Next_locationY = num[block].Location.Y;

            //由于交换的格与空格相比，必有X或Y坐标其一相等，所以只需改变他们的其中一个坐标，进行移动
            if (num[block].Location.X > num[0].Location.X)
            {
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
                return; //直接结束
            }


            if (num[block].Location.X < num[0].Location.X)
            {
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
                return; //直接结束
            }


            if (num[block].Location.Y > num[0].Location.Y)
            {
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
                return; //直接结束
            }

            if (num[block].Location.Y < num[0].Location.Y)
            {
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
                return;//直接结束
            }
        }
    }
}
