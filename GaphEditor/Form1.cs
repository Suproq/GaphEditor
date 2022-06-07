using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GaphEditor
{
    public partial class Form1 : Form
    {
        Bitmap pic;
        Dictionary<int, int> figures = new Dictionary<int, int>();
        
        int x1, y1, countrect = 0, cr2 = 0, countsq = 0, cs2 = 0, countCircle = 0, cc2 = 0, selected = 0, fig, id, pfig = 0, pid = 0, count = 0;

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void сохранитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                pic.Save(saveFileDialog1.FileName);
            }
        }

        Color[] colors = new Color [5] { Color.Black, Color.Red, Color.Blue, Color.Green, Color.Yellow };
        Triangle[] triangles;
        Square[] squares;
        Circle[] circles;
        public Form1()
        {
            InitializeComponent();
            updateDraw();
            
            x1 = y1 = 0;
            triangles = new Triangle[100];
            triangles[0] = new Triangle();
            squares = new Square[100];
            squares[0] = new Square();
            circles = new Circle[100];
            circles[0] = new Circle();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Point cord;
            //cord.X = e.X;
            //triangles[0].SetPoints(e);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if(selected != 0)
            {
                switch (fig)
                {
                    case 1:
                        triangles[id].SetSize(trackBar1.Value);
                        break;
                    case 2:
                        squares[id].SetSize(trackBar1.Value);
                        break;
                    case 3:
                        circles[id].SetSize(trackBar1.Value);
                        break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            /*DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите удалить эту фигуру?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                countrect--;
                count--;
                switch (fig)
                {
                    case 1:
                        if (countrect == 1)
                        {
                            triangles[0] = new Triangle();
                            for (int i = selected; i < count; i++)
                            {
                                figures[i] = figures[i + 1] - 1;
                            }
                        }
                        else
                        {
                            for (int i = id; i <= countrect; i++)
                            {
                                triangles[i] = triangles[i + 1];
                            }
                            triangles[countrect + 1] = new Triangle();
                            for (int i = selected; i < count; i++)
                            {
                                figures[i] = figures[i + 1] - 1;
                            }
                        }
                        comboBox3.Items.RemoveAt(selected);
                        selected = 0;
                        comboBox3.SelectedIndex = 0;
                        break;
                }
            }*/
            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected = comboBox3.SelectedIndex;
            if (selected != 0)
            {
                int a = figures[comboBox3.SelectedIndex];
                fig = a / 100;
                id = a % 100;
                comboBox1.Enabled = false;
                //button1.Enabled = true;
                switch (fig)
                {
                    case 1:
                        comboBox2.SelectedIndex = Array.IndexOf(colors, triangles[id].GetColor());
                        trackBar1.Value = triangles[id].GetSize();
                        triangles[id].SetWidth(5);
                        break;
                    case 2:
                        comboBox2.SelectedIndex = Array.IndexOf(colors, squares[id].GetColor());
                        trackBar1.Value = squares[id].GetSize();
                        squares[id].SetWidth(5);
                        break;
                    case 3:
                        comboBox2.SelectedIndex = Array.IndexOf(colors, circles[id].GetColor());
                        trackBar1.Value = circles[id].GetSize();
                        circles[id].SetWidth(5);
                        break;
                }
                switch (pfig)
                {
                    case 1:
                        triangles[pid].SetWidth(2);
                        break;
                    case 2:
                        squares[pid].SetWidth(2);
                        break;
                    case 3:
                        circles[pid].SetWidth(2);
                        break;
                }
                pfig = fig;
                pid = id;
            }
            else
            {
                comboBox1.Enabled = true;
                //button1.Enabled = false;
                comboBox2.SelectedIndex = 0;
                trackBar1.Value = 50;
                switch (fig)
                {
                    case 1:
                        triangles[id].SetWidth(2);
                        break;
                    case 2:
                        squares[id].SetWidth(2);
                        break;
                    case 3:
                        circles[id].SetWidth(2);
                        break;
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (selected == 0)
            {
                switch (fig)
                {
                    case 1:
                        triangles[countrect].SetColor(colors[comboBox2.SelectedIndex]);
                        break;
                    case 2:
                        squares[countsq].SetColor(colors[comboBox2.SelectedIndex]);
                        break;
                    case 3:
                        circles[countCircle].SetColor(colors[comboBox2.SelectedIndex]);
                        break;
                }
            }
            else
            {
                switch (fig)
                {
                    case 1:
                        triangles[id].SetColor(colors[comboBox2.SelectedIndex]);
                        break;
                    case 2:
                        squares[id].SetColor(colors[comboBox2.SelectedIndex]);
                        break;
                    case 3:
                        circles[id].SetColor(colors[comboBox2.SelectedIndex]);
                        break;
                }
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point cord = new Point(e.X, e.Y);
                if (selected == 0)
                {
                    count++;
                    
                    switch (comboBox1.SelectedIndex)
                    {
                        case 0:
                            cr2++;
                            //triangles[countrect] = new Triangle();
                            triangles[countrect].SetColor(colors[comboBox2.SelectedIndex]);
                            triangles[countrect].SetSize(trackBar1.Value);
                            triangles[countrect].SetPoints(cord);
                            //pictureBox1.Image = triangles[countrect].Draw(pic);
                            //добавляем в combobox
                            figures[comboBox3.Items.Count] = 100 + countrect;
                            comboBox3.Items.Add("Треугольник " + cr2.ToString());
                                //создаем новый треугольник
                            countrect++;
                            triangles[countrect] = new Triangle();
                            triangles[countrect].SetColor(colors[comboBox2.SelectedIndex]);
                            break;
                        case 1:
                            cs2++;
                            squares[countsq].SetColor(colors[comboBox2.SelectedIndex]);
                            squares[countsq].SetSize(trackBar1.Value);
                            squares[countsq].SetPoints(cord);
                            //добавляем в combobox
                            figures[comboBox3.Items.Count] = 200 + countsq;
                            comboBox3.Items.Add("Квадрат " + cs2.ToString());
                            //создаем новый квадрат
                            countsq++;
                            squares[countsq] = new Square();
                            squares[countsq].SetColor(colors[comboBox2.SelectedIndex]);
                            break;
                        case 2:
                            cc2++;
                            circles[countCircle].SetColor(colors[comboBox2.SelectedIndex]);
                            circles[countCircle].SetSize(trackBar1.Value);
                            circles[countCircle].SetPoints(cord);
                            //добавляем в combobox
                            figures[comboBox3.Items.Count] = 300 + countCircle;
                            comboBox3.Items.Add("Круг " + cc2.ToString());
                            //создаем новый круг
                            countCircle++;
                            circles[countCircle] = new Circle();
                            circles[countCircle].SetColor(colors[comboBox2.SelectedIndex]);
                            break;
                    }
                }
                else
                {
                    switch (fig)
                    {
                        case 1:
                            triangles[id].SetPoints(cord);
                            break;
                        case 2:
                            squares[id].SetPoints(cord);
                            break;
                        case 3:
                            circles[id].SetPoints(cord);
                            break;
                    }
                }

            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //Pen p;
            //p = new Pen(Color.Black);
            //Graphics g = Graphics.FromImage(pic);
            /*if (e.Button == MouseButtons.Left)
            {
                //g.DrawLine(p, x1, y1, e.X, e.Y);
                Point cord = new Point(e.X, e.Y);
                Triangle rect = new Triangle();
                rect.SetPoints(cord);
                pictureBox1.Image = rect.Draw(pic);

            }*/
            //x1 = e.X;
            //y1 = e.Y;
            if(selected != 0 && e.Button == MouseButtons.Left)
            {
                Point cord = new Point(e.X, e.Y);
                switch (fig)
                {
                    case 1:
                        triangles[id].SetPoints(cord);
                        break;
                    case 2:
                        squares[id].SetPoints(cord);
                        break;
                    case 3:
                        circles[id].SetPoints(cord);
                        break;
                }
            }
        }

        public async void updateDraw()//Асинхронный метод, который обновляет холст
        {
            int a = 1;
            while (true)
            {
                //Bitmap pic;
                pic = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                //picSave = pic;
                using (Graphics grfx = Graphics.FromImage(pic))
                {
                    // Рисуем.
                    grfx.Clear(Color.White);
                    //grfx.DrawPolygon(p, points);

                }
                //pictureBox1.Image = null;
                //pictureBox1.CreateGraphics().Clear(Color.White);
                for (int i = 0; i < countrect; i++)
                {
                    pictureBox1.Image = triangles[i].Draw(pic);
                }
                for (int i = 0; i < countsq; i++)
                {
                    pictureBox1.Image = squares[i].Draw(pic);
                }
                for (int i = 0; i < countCircle; i++)
                {
                    pictureBox1.Image = circles[i].Draw(pic);
                }
                //textBox1.Text = a.ToString() + ":::" + countrect.ToString() + ":::" + comboBox3.SelectedIndex.ToString() + ":::" + countrect.ToString();
                a++;
                await Task.Delay(TimeSpan.FromMilliseconds(10));
            }
        }
    }
}
