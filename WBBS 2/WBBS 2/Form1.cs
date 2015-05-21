using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WBBS_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tabPage1.Parent = null;
            tabPage2.Parent = null;
            tabPage3.Parent = null;
            tabPage4.Parent = null;
            MoveToStart();
        }
        WebBrowser web = new WebBrowser();// создаем webbrowser
        int i = 0;
        int n = 0;
        // по двойному щелчку мыши активируем новую вкладку
        private void tabControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                    web = new WebBrowser();
                    web.NewWindow += web_NewWindow;
                    web.ScriptErrorsSuppressed = true;
                    web.Dock = DockStyle.Fill;
                    web.Visible = true;
                    web.DocumentCompleted += web_DocumentCompleted;
                    tabControl1.TabPages.Add("Новая вкладка");
                    tabControl1.SelectTab(i);
                    tabControl1.SelectedTab.Controls.Add(web);
                    ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate("http://yandex.ru");
                    i++;
            }
        }
        // Реализация истории посещения страниц
        void web_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            adress.Text = ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Url.ToString(); // полный адрес текущего сайта
            tabControl1.SelectedTab.Text = ((WebBrowser)tabControl1.SelectedTab.Controls[0]).DocumentTitle;
            if (!(textBox2.Text == adress.Text))
            {
                ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate(adress.Text);
                textBox2.Text = adress.Text;
                string data = DateTime.Now.ToString();
                using (StreamWriter we = new StreamWriter("history.txt", true))
                {
                    listBox2.Items.Add(textBox2.Text);
                    we.WriteLine(data + "           " + textBox2.Text);

                }
            }
        }

        void web_NewWindow(object sender, CancelEventArgs e)
        {
            web.Navigate(web.StatusText);
            e.Cancel = true;
        }
        // прогрузка основных рабочих элементов(рабочая страница webbrowser, отлов ошибок(ScriptErrorsSuppressed), запрет на выход в IE(web_NewWindow), определение границ рабочей страницы(DockStyle.Fill), создание новой вкладки)
        private void Form1_Load(object sender, EventArgs e)
        {
            web = new WebBrowser();
            web.NewWindow += web_NewWindow;
            web.ScriptErrorsSuppressed = true;
            web.Dock = DockStyle.Fill;
            web.Visible = true;
            web.DocumentCompleted += web_DocumentCompleted;
            tabControl1.TabPages.Add("Новая вкладка");
            tabControl1.SelectTab(i);
            tabControl1.SelectedTab.Controls.Add(web);
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate("http://yandex.ru");
            adress.Text = "";
            i++;
        }
        // Создаем  код для наших элементов picturebox(отслеживание сжатия, отжатия кнопки Mouse
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox1.BorderStyle = BorderStyle.None;
        }

        private void pictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox2.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox2_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox2.BorderStyle = BorderStyle.None;
        }

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox3.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox3_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox3.BorderStyle = BorderStyle.None;
        }

        private void pictureBox4_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox4.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox4_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox4.BorderStyle = BorderStyle.None;
        }

        private void pictureBox6_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox6.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox6_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox6.BorderStyle = BorderStyle.None;
        }

        private void pictureBox5_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox5.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox5_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox5.BorderStyle = BorderStyle.None;
        }

        private void pictureBox7_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox7.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox7_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox7.BorderStyle = BorderStyle.None;
        }

        private void pictureBox8_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox8.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox8_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox8.BorderStyle = BorderStyle.None;
        }
        // активируем меню
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (panel2.Visible == false)
            {
                panel2.Visible = true;
            }
            else
            {
                panel2.Visible = false;
            }
        }
        // назад
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).GoBack();
        }
        // вперед
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).GoForward();
        }
        // обновляем наш сайт
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Refresh();
        }
        // прекращаем загрузку сайта
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Stop();
        }
        // пишем домашний адрес нашего браузера
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate("http://yandex.ru");
        }
        // далее создаем кнопку новой вкладки
        private void pictureBox7_Click(object sender, EventArgs e)
        { 
                web = new WebBrowser();
                web.NewWindow += web_NewWindow;
                web.ScriptErrorsSuppressed = true;
                web.Dock = DockStyle.Fill;
                web.Visible = true;
                web.DocumentCompleted += web_DocumentCompleted;
                tabControl1.TabPages.Add("Новая вкладка");
                tabControl1.SelectTab(i);
                tabControl1.SelectedTab.Controls.Add(web);
                ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate("http://yandex.ru");
                adress.Text = "";
                i++;     
        }
        // Далее работаем с закладками!!!
        private void pictureBox8_Click(object sender, EventArgs e)
        {
             if (panel3.Visible == false)
             {
                 panel3.Visible = true;
             }
            else
             {
                 panel3.Visible = false;
                 listBox1.Visible = false;
             }
             listBox1.Items.Clear();
            using (StreamReader reader = new StreamReader("ssilky.txt"))
            {
                string z = reader.ReadLine();
                for (int j = 0; j < Convert.ToDouble(z); j++)
                {
                    listBox1.Items.Add(reader.ReadLine());
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (listBox1.Visible == false)
            {
                listBox1.Visible = true;
            }
            else
            {
                listBox1.Visible = false;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox1.Text + "-" + textBox2.Text);
            using (StreamWriter sw = new StreamWriter("ssilky.txt"))
            {
                sw.WriteLine(listBox1.Items.Count.ToString());
                for (int j = 0; j < listBox1.Items.Count; j++)
                {
                    sw.WriteLine(listBox1.Items[j]);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Нет выделенной строки");
            }
            else
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            using (StreamWriter sw = new StreamWriter("ssilky.txt"))
            {
                sw.WriteLine(listBox1.Items.Count.ToString());
                for (int j = 0; j < listBox1.Items.Count; j++)
                    sw.WriteLine(listBox1.Items[j]);
            }
        }
        // переход на страницу по заданному адресу через кнопку Enter
        private void adress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress.ToString();
                ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate(adress.Text);
                
                
                //web.Navigate("http://yandex.ru/search/?lr=213&text=" + adress.Text + "&suggest_reqid=722156446143055714248672459210016");
            }
        }
        // по двойному щелчку, ревлизуем переход на выбранную страницу
        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string str = listBox1.SelectedItem.ToString();
            string newstr = "";
            int flag = 0;
            char c;
            int k = str.Length;
            for (int j = 0; j < k; j++)
            {
                c = str[j];
                if (flag != 0) newstr += c;
                if (c == '-') flag = 1;
            }
            adress.Text = newstr;
            web.Navigate(adress.Text);
        }
        // Создаем новую вкладку через панель
        private void button1_Click(object sender, EventArgs e)
        {
                web = new WebBrowser();
                web.NewWindow += web_NewWindow;
                web.ScriptErrorsSuppressed = true;
                web.Dock = DockStyle.Fill;
                web.Visible = true;
                web.DocumentCompleted += web_DocumentCompleted;
                tabControl1.TabPages.Add("Новая вкладка");
                tabControl1.SelectTab(i);
                tabControl1.SelectedTab.Controls.Add(web);
                ((WebBrowser)tabControl1.SelectedTab.Controls[0]).Navigate("http://yandex.ru");
                panel2.Visible = false;
                adress.Text = "";
                i++;          
        }
        // Открываем вкладки через панель
        private void button2_Click(object sender, EventArgs e)
        {
            if (panel3.Visible == false)
            {
                panel3.Visible = true;
                panel2.Visible = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tabPage1.Parent == null)
            {
                i++;
                panel2.Visible = false;
                listBox2.Visible = true;
                tabControl1.TabPages.Add(tabPage1);
                this.toolTip1.SetToolTip(this.tabPage1, "История");
                using (StreamReader read = new StreamReader("history.txt"))
                {
                    listBox2.Items.AddRange(System.IO.File.ReadAllLines(@"history.txt"));

                }
            }
            
        }
        // при клике на адресную строку, тест "обнуляется"
        private void adress_MouseClick(object sender, MouseEventArgs e)
        {
            adress.Text = "";
        }

        private void tabControl1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                contextMenuStrip1.Visible = true;
                //if (tabControl1.TabPages.Count - 1 > 0)
                //{
                  //  tabControl1.TabPages.RemoveAt(tabControl1.SelectedIndex);
                  //  tabControl1.SelectTab(tabControl1.TabPages.Count - 1);
                   // i -= 1;
               // }
            }
        }


        private void pictureBox9_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox9.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox9_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox9.BorderStyle = BorderStyle.None;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count - 1 > 0)
            {
                tabControl1.TabPages.RemoveAt(tabControl1.SelectedIndex);
                tabControl1.SelectTab(tabControl1.TabPages.Count - 1);
                i -= 1;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
             if (tabPage2.Parent == null)
             {
                 i++;
                 tabControl1.TabPages.Add(tabPage2);
                 panel2.Visible = false;
             }
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            MessageBox.Show("Wins!!!");
        }
        
        private void MoveToStart()
        {
            Point startingPoint = panel4.Location;
            startingPoint.Offset(10, 10);
            Cursor.Position = PointToScreen(startingPoint);
        }

        private void label6_MouseEnter(object sender, EventArgs e)
        {
            MoveToStart();
        }

        int flag = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (flag == 0)
            {
                label18.Enabled = true;
                label18.Visible = true;
                label5.Enabled = true;
                label5.Visible = true;
                flag = 1;
            }
            else
            {
                label18.Enabled = false;
                label18.Visible = false;
                label5.Enabled = false;
                label5.Visible = false;
                flag = 0;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (tabPage3.Parent == null)
            {
                i++;
                panel2.Visible = false;
                tabPage3.Parent = tabControl1;
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }
        // при наведении на выбранную вкладку появляется полный путь страницы
        private void tabControl1_MouseHover(object sender, EventArgs e)
        {
           this.toolTip1.SetToolTip(this.tabControl1, adress.Text);
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabControl1.TabPages.Count - 1 > 0)
            {
                tabControl1.TabPages.RemoveAt(tabControl1.SelectedIndex);
                tabControl1.SelectTab(tabControl1.TabPages.Count - 1);
                i -= 1;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (listBox2.SelectedItem != null)
            {
                listBox2.Items.RemoveAt(listBox2.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Выберите значение");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            panel4.BackgroundImage = new Bitmap(pictureBox10.Image);
            panel5.BackgroundImage = new Bitmap(pictureBox10.Image);
            panel6.BackgroundImage = new Bitmap(pictureBox10.Image);
            pictureBox10.Visible = false;
            pictureBox11.Visible = true;
            pictureBox12.Visible = true;
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            panel4.BackgroundImage = new Bitmap(pictureBox11.Image);
            panel5.BackgroundImage = new Bitmap(pictureBox11.Image);
            panel6.BackgroundImage = new Bitmap(pictureBox11.Image);
            pictureBox10.Visible = true;
            pictureBox11.Visible = false;
            pictureBox12.Visible = true;
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            panel4.BackgroundImage = new Bitmap(pictureBox12.Image);
            panel5.BackgroundImage = new Bitmap(pictureBox12.Image);
            panel6.BackgroundImage = new Bitmap(pictureBox12.Image);
            pictureBox12.Visible = false;
            pictureBox10.Visible = true;
            pictureBox11.Visible = true;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            web.Navigate("http://yandex.ru/search/?lr=213&text=" + adress.Text + "&suggest_reqid=722156446143055714248672459210016");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (tabPage4.Parent == null)
            {
                i++;
                panel2.Visible = false;
                tabPage4.Parent = tabControl1;
                comboBox1.Text = "";
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
                adress.Text = comboBox1.Text;
                web = new WebBrowser();
                web.NewWindow += web_NewWindow;
                web.ScriptErrorsSuppressed = true;
                web.Dock = DockStyle.Fill;
                web.Visible = true;
                web.DocumentCompleted += web_DocumentCompleted;
                tabControl1.TabPages.Add("Новая вкладка");
                tabControl1.SelectTab(i);
                tabControl1.SelectedTab.Controls.Add(web);   
                web.Navigate("http://yandex.ru/search/?lr=213&text=" + adress.Text + "&suggest_reqid=722156446143055714248672459210016");
                i++;  
                tabPage4.Parent = null;
        }

        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress.ToString();
                adress.Text = comboBox1.Text;
                tabPage4.Parent = null;
                TabPage tabPage = new TabPage();
                web = new WebBrowser();
                web.NewWindow += web_NewWindow;
                web.ScriptErrorsSuppressed = true;
                web.Dock = DockStyle.Fill;
                web.Visible = true;
                web.DocumentCompleted += web_DocumentCompleted;
                tabControl1.TabPages.Add(tabPage);
                tabControl1.SelectTab(tabPage);
                web.Navigate("http://yandex.ru/search/?lr=213&text=" + adress.Text + "&suggest_reqid=722156446143055714248672459210016");
                tabControl1.SelectedTab.Controls.Add(web);
            }
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            tabPage4.Parent = null;
            TabPage tabPage = new TabPage();
            web = new WebBrowser();
            web.NewWindow += web_NewWindow;
            web.ScriptErrorsSuppressed = true;
            web.Dock = DockStyle.Fill;
            web.Visible = true;
            web.DocumentCompleted += web_DocumentCompleted;
            tabControl1.TabPages.Add(tabPage);
            tabControl1.SelectTab(tabPage);
            tabControl1.SelectedTab.Controls.Add(web);
            web.Navigate("http://yandex.ru");
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            tabPage4.Parent = null;
            TabPage tabPage = new TabPage();
            web = new WebBrowser();
            web.NewWindow += web_NewWindow;
            web.ScriptErrorsSuppressed = true;
            web.Dock = DockStyle.Fill;
            web.Visible = true;
            web.DocumentCompleted += web_DocumentCompleted;
            tabControl1.TabPages.Add(tabPage);
            tabControl1.SelectTab(tabPage);
            tabControl1.SelectedTab.Controls.Add(web);
            web.Navigate("http://google.ru/");
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            tabPage4.Parent = null;
            TabPage tabPage = new TabPage();
            web = new WebBrowser();
            web.NewWindow += web_NewWindow;
            web.ScriptErrorsSuppressed = true;
            web.Dock = DockStyle.Fill;
            web.Visible = true;
            web.DocumentCompleted += web_DocumentCompleted;
            tabControl1.TabPages.Add(tabPage);
            tabControl1.SelectTab(tabPage);
            tabControl1.SelectedTab.Controls.Add(web);
            web.Navigate("http://rambler.ru/");
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            tabPage4.Parent = null;
            TabPage tabPage = new TabPage();
            web = new WebBrowser();
            web.NewWindow += web_NewWindow;
            web.ScriptErrorsSuppressed = true;
            web.Dock = DockStyle.Fill;
            web.Visible = true;
            web.DocumentCompleted += web_DocumentCompleted;
            tabControl1.TabPages.Add(tabPage);
            tabControl1.SelectTab(tabPage);
            tabControl1.SelectedTab.Controls.Add(web);
            web.Navigate("http://ozon.ru/");
        }

        private void pictureBox18_Click(object sender, EventArgs e)
        {
            tabPage4.Parent = null;
            TabPage tabPage = new TabPage();
            web = new WebBrowser();
            web.NewWindow += web_NewWindow;
            web.ScriptErrorsSuppressed = true;
            web.Dock = DockStyle.Fill;
            web.Visible = true;
            web.DocumentCompleted += web_DocumentCompleted;
            tabControl1.TabPages.Add(tabPage);
            tabControl1.SelectTab(tabPage);
            tabControl1.SelectedTab.Controls.Add(web);
            web.Navigate("http://aliez.tv/");
        }

        private void button16_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            string del = "history.txt";
            File.AppendAllText("Empty.txt", "");
            File.Replace("Empty.txt",del, "copy.txt");
        }
    }
}
