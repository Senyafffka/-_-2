using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace ООАП_Лаб2БезПаттерна
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listBox1.Items.AddRange(str);
        }

        string[] str = { "Правила игры", "Быстрый старт", "Подготовка к игре", "Поле" };


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var name = listBox1.SelectedItem;
            switch (name)
            {
                case "Правила игры":
                    listBox1.Items.Clear();
                    listBox1.Items.Add("Приступайте к игре!");
                    break;
                case "Быстрый старт":
                    listBox1.Items.Clear();
                    listBox1.Items.Add("Разложите фишки, подготовьте кубики и карты");
                    break;
                case "Подготовка к игре":
                    listBox1.Items.Clear();
                    listBox1.Items.AddRange(new object[] { "В верхнем левом углу выложите карты победы",  
                                                          "В правом нижнем углу выставите фишки героев",
                                                          "Раздайте каждому игроку по три карты победы"} );
                    break;
                case "Поле":
                    listBox1.Items.Clear();
                    listBox1.Items.Add("Движение героев осуществляется по героической тропе, всем удачи! ");
                    break;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox1.Items.AddRange(str);
        }
    }
}
