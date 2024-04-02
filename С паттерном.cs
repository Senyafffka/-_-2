using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace ООАП_Лаб2GUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            Root = new Composite("Правила игры", listBox1);
            Branch1 = new Composite("Быстрый старт", listBox1);
            Branch2 = new Composite("Подготовка к игре", listBox1);
            Branch3 = new Composite("Поле", listBox1);


            Leaf1 = new Leaf("Приступайте к игре!", listBox1);
            Leaf2 = new Leaf("Разложите фишки, подготовьте кубики и карты", listBox1);
            Leaf3 = new Leaf("В верхнем левом углу выложите карты победы, в правом нижнем углу выставите фишки героев", listBox1);
            Leaf4 = new Leaf("Раздайте каждому игроку по три карты победы", listBox1);
            Leaf5 = new Leaf("Движение героев осуществляется по героической тропе, всем удачи! ", listBox1);

            Root.Add(Branch1);
            Root.Add(Branch2);
            Root.Add(Branch3);


            Branch1.Add(Leaf1);
            Branch2.Add(Leaf2);
            Branch3.Add(Leaf3);
            Branch2.Add(Leaf4);
            Branch3.Add(Leaf5);
            inik();


            dictionary = new Dictionary<string, Component>()
            {
                { "Быстрый старт", Branch1 },
                { "Подготовка к игре", Branch2 },
                { "Поле", Branch3 }
            };

        }

        public void inik()
        {
            listBox1.Items.Clear();
            Root.i_Display();
            Branch1.i_Display();
            Branch2.i_Display();
            Branch3.i_Display();
        }

        abstract class Component
        {
            public string name;

            public Component(string name)
            {
                this.name = name;
            }

            public abstract void Display();
            public abstract void Add(Component c);

            public abstract int CountChildren();
        }

        class Composite : Component
        {
            List<Component> children = new List<Component>();
            public ListBox _listBox1 = new ListBox();

            public Composite(string name, ListBox listBox1)
                : base(name)
            {
                _listBox1 = listBox1;
            }

            public override void Add(Component component)
            {
                children.Add(component);
            }

            public override void Display()
            {
                _listBox1.Items.Add(name);

                foreach (Component component in children)
                {
                    component.Display();
                }
            }

            public void i_Display()
            {
                _listBox1.Items.Add(name);

            }

            public override int CountChildren()
            {
                return children.Count;
            }
        }

        class Leaf : Component
        {
            ListBox _listBox1 = new ListBox();
            public Leaf(string name, ListBox listBoxK)
                : base(name)
            {
                _listBox1 = listBoxK;
            }

            public override void Display()
            {
                _listBox1.Items.Add(name);
            }

            public override void Add(Component component)
            {
                throw new NotImplementedException();
            }

            public override int CountChildren()
            {
                throw new NotImplementedException();
            }
        }

        
        Dictionary<string, Component> dictionary;
        Composite Root;
        Composite Branch1;
        Composite Branch2;
        Composite Branch3;
        Component Leaf1;
        Component Leaf2;
        Component Leaf3;
        Component Leaf4;
        Component Leaf5;

        bool f = false;
        

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex.Equals(-1) || listBox1.SelectedIndex.Equals(0) || f)
            {
                f = false;
                inik();
                return;
            }
                
            Component b = dictionary[listBox1.Items[listBox1.SelectedIndex].ToString()];
            
            listBox1.Items.Clear();
            b.Display();
            f = true;
        }
    }
}
