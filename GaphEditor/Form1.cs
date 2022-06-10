using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace GaphEditor
{
    public partial class Form1 : Form
    {
        Bitmap pic;
        Dictionary<int, int> figures = new Dictionary<int, int>();
        
        int countrect = 0, cr2 = 0, countsq = 0, cs2 = 0, countCircle = 0, cc2 = 0, selected = 0, fig, id, pfig = 0, pid = 0, count = 0;

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

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.R: comboBox2.SelectedIndex = 1; break;
                    case Keys.B: comboBox2.SelectedIndex = 2; break;
                    case Keys.G: comboBox2.SelectedIndex = 3; break;
                    case Keys.Y: comboBox2.SelectedIndex = 4; break;
                    case Keys.D0: comboBox3.SelectedIndex = 0; break;
                    case Keys.D1: if (comboBox3.Items.Count > 1) comboBox3.SelectedIndex = 1; else SystemSounds.Exclamation.Play(); break;
                    case Keys.D2: if (comboBox3.Items.Count > 2) comboBox3.SelectedIndex = 2; else SystemSounds.Exclamation.Play(); break;
                    case Keys.D3: if (comboBox3.Items.Count > 3) comboBox3.SelectedIndex = 3; else SystemSounds.Exclamation.Play(); break;
                    case Keys.D4: if (comboBox3.Items.Count > 4) comboBox3.SelectedIndex = 4; else SystemSounds.Exclamation.Play(); break;
                    case Keys.D5: if (comboBox3.Items.Count > 5) comboBox3.SelectedIndex = 5; else SystemSounds.Exclamation.Play(); break;
                    case Keys.D6: if (comboBox3.Items.Count > 6) comboBox3.SelectedIndex = 6; else SystemSounds.Exclamation.Play(); break;
                    case Keys.D7: if (comboBox3.Items.Count > 7) comboBox3.SelectedIndex = 7; else SystemSounds.Exclamation.Play(); break;
                    case Keys.D8: if (comboBox3.Items.Count > 8) comboBox3.SelectedIndex = 8; else SystemSounds.Exclamation.Play(); break;
                    case Keys.D9: if (comboBox3.Items.Count > 9) comboBox3.SelectedIndex = 9; else SystemSounds.Exclamation.Play(); break;

                }
            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 a = new AboutBox1();
            a.Show();
        }

        Triangle[] triangles;
        Square[] squares;
        Circle[] circles;
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            comboBox3.SelectedIndex = 0;
            this.KeyPreview = true;
            this.MouseWheel += new MouseEventHandler(this_MouseWheel);
            triangles = new Triangle[10000];
            triangles[0] = new Triangle();
            squares = new Square[10000];
            squares[0] = new Square();
            circles = new Circle[10000];
            circles[0] = new Circle();
        }

        private void this_MouseWheel(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control) trackBar1.Value += e.Delta / 100;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
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

        private void button1_Click(object sender, EventArgs e)//Здесь могла быть функция удаления фигуры...
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
                    if (count == 0)
                    {
                        updateDraw();
                    }
                    count++;
                    switch (comboBox1.SelectedIndex)
                    {
                        case 0:
                            cr2++;
                            triangles[countrect].SetColor(colors[comboBox2.SelectedIndex]);
                            triangles[countrect].SetSize(trackBar1.Value);
                            triangles[countrect].SetPoints(cord);
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
            while (true)
            {
                pic = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                using (Graphics grfx = Graphics.FromImage(pic))
                {
                    grfx.Clear(Color.White);
                }
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
                await Task.Delay(TimeSpan.FromMilliseconds(10));
            }
        }
    }
}
