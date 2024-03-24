using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ООАП_Лаб1test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tank = new Tank();
            tank.SetCord(50, 50);
            timer1.Start();
            bullet = new Bullet(course, -100, -100);
        }

        public enum Course { UP, DOWN, LEFT, RIGHT };
        public Course course;
        
        Tank tank;
        Rectangle tankRect;
        Graphics g;
        GraphicsUnit units = GraphicsUnit.Pixel;
        Bullet bullet;
        bool f = false;

        class Tank
        {
            Image image = Image.FromFile(@"D:\Visual Studio\Project\ООАП_Лаб1\ООАП_Лаб1\TrackedTank.jpg");
            public Course course;
            public int x, y;

            public Tank()
            {

            }
            public void Run(Course course)
            {
                this.course = course;
                if (this.course == Course.UP)
                {
                    y -= 4;
                    image = Image.FromFile(@"D:\Visual Studio\Project\ООАП_Лаб1\ООАП_Лаб1\TrackedTank.jpg");
                }
                if (this.course == Course.DOWN)
                {
                    y += 4;
                    image = Image.FromFile(@"D:\Visual Studio\Project\ООАП_Лаб1\ООАП_Лаб1\TrackedTank.jpg");
                    image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                }
                if (this.course == Course.LEFT)
                {
                    x -= 4;
                    image = Image.FromFile(@"D:\Visual Studio\Project\ООАП_Лаб1\ООАП_Лаб1\TrackedTank.jpg");
                    image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                }
                if (this.course == Course.RIGHT)
                {
                    x += 4;
                    image = Image.FromFile(@"D:\Visual Studio\Project\ООАП_Лаб1\ООАП_Лаб1\TrackedTank.jpg");
                    image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                }
                if (x > 380) x = -50;
                if (x < -50) x = 380;
                if (y < -50) y = 280;
                if (y > 280) y = -50;
            }

            public void SetCord(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public int GetX()
            {
                return x;
            }
            public int GetY()
            {
                return y;
            }

            public System.Drawing.Image GetImage()
            {
                return image;
            }
        }

        class Bullet
        {
            Image img = Image.FromFile(@"D:\Visual Studio\Project\ООАП_Лаб1\ООАП_Лаб1\Bullet.jpg");
            Course course;
            int x, y;
            const int cord = 10;
            public Bullet(Course course, int x, int y)
            {
                this.course = course;
                this.x = x;
                this.y = y;
            }
            public void RunBullet()
            {
                if (course == Course.UP) y -= cord;
                if (course == Course.DOWN) y += cord;
                if (course == Course.LEFT) x -= cord;
                if (course == Course.RIGHT) x += cord;
            }
            public Image GetImage()
            {
                return img;
            }

            public int GetX()
            {
                return x;
            }
            public int GetY()
            {
                return y;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            g = panel1.CreateGraphics();
            g.Clear(Color.White);
            tankRect = new Rectangle(tank.GetX(), tank.GetY(), 50, 50);

            tank.Run(course);
            g.DrawImage(tank.GetImage(), tankRect, 0, 0, 50, 50, units);

            if (f)
            {
                tankRect = new Rectangle(bullet.GetX(), bullet.GetY(), 20, 20);
                bullet.RunBullet();
                g.DrawImage(bullet.GetImage(), tankRect, 0, 0, 180, 180, units);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                course = Course.UP;
            }
            if (e.KeyCode == Keys.Down)
            {
                course = Course.DOWN;
            }
            if (e.KeyCode == Keys.Left)
            {
                course = Course.LEFT;
            }
            if (e.KeyCode == Keys.Right)
            {
                course = Course.RIGHT;
            }
            
            if (e.KeyCode == Keys.X)
            {
                if (bullet.GetX() > 380
                        || bullet.GetX() < -50
                        || bullet.GetY() < -50
                        || bullet.GetY() > 280)
                {
                    bullet = new Bullet(course, tank.GetX() + 20, tank.GetY() + 20);
                }
                f = true;
            }
        }
    }
}
