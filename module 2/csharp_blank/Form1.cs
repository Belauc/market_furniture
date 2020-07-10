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

namespace csharp_blank
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            refreshFileList2();
            refreshFileList3();
        }

        private void refreshFileList2()
        {
            listBox2.Items.Clear();
            DirectoryInfo di = new DirectoryInfo(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Base");
            FileInfo[] All = di.GetFiles();
            for (int i = 0; i < All.Count(); i++)
            {
                StreamReader LI = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Base\" + All[i].ToString());
                listBox2.Items.Add(LI.ReadLine() + " " + LI.ReadLine() + " " + LI.ReadLine());
                LI.Close();
            }

        }

        private void refreshFileList3()
        {
            listBox3.Items.Clear();
            DirectoryInfo di = new DirectoryInfo(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\MebelOb");
            FileInfo[] All = di.GetFiles();

            for (int i = 0; i < All.Count(); i++)
            {
                StreamReader LI = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\MebelOb\" + All[i].ToString());
                listBox3.Items.Add(LI.ReadLine());
                LI.Close();
            }

        }

        private void AddClient_Click(object sender, EventArgs e)
        {

            FileInfo fi = new FileInfo(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Base\" + maskedTextBox3.Text + ".txt");
            if (fi.Exists)
            {
                MessageBox.Show("Данный пользователь уже добавлен");
                maskedTextBox2.Text = maskedTextBox3.Text;
                StreamReader Sr = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Base\" + maskedTextBox3.Text + ".txt");

                show_inform.Text += "Фамилия - " + Sr.ReadLine() + "\n";
                show_inform.Text += "Имя - " + Sr.ReadLine() + "\n";
                show_inform.Text += "Отчество - " + Sr.ReadLine() + "\n";
                show_inform.Text += "Номер Паспорта - " + Sr.ReadLine() + "\n";
                show_inform.Text += "Номер Снилса - " + Sr.ReadLine() + "\n";
                show_inform.Text += "Город проживаия - " + Sr.ReadLine() + "\n";
                while (Sr.ReadLine() != null)
                {
                    show_inform.Text += Sr.ReadLine() + "\n";
                    show_inform.Text += "Город - " + Sr.ReadLine() + "\n";
                    show_inform.Text += "Телефон - " + Sr.ReadLine() + "\n";
                    show_inform.Text += "Дата доставки - " + Sr.ReadLine() + "\n";
                    show_inform.Text += "Способ доставки - " + Sr.ReadLine() + "\n";
                    show_inform.Text += "Наименование  " + Sr.ReadLine() + "\n";
                    show_inform.Text += "Цвет  - " + Sr.ReadLine() + "\n";
                    show_inform.Text += "Производитель - " + Sr.ReadLine() + "\n";

                }

                Sr.Close();
                refreshFileList2();
                return;
            }
            StreamWriter w = fi.CreateText();

            w.WriteLine(LastName.Text);
            w.WriteLine(FirstName.Text);
            w.WriteLine(OtName.Text);
            if (maskedTextBox3.Text.Length == 12)
            {
                w.WriteLine(maskedTextBox3.Text);
            }
            else
            {

                MessageBox.Show("Длина номера пасспорта должна быть равна 8 символам!");
                return;
            }
            if (maskedTextBox4.Text.Length == 14)
            {
                w.WriteLine(maskedTextBox4.Text);
            }
            else
            {

                MessageBox.Show("Длина номера снилса должна быть равна 11 символам!");
                return;
            }
            w.WriteLine(City.Text);
            w.Close();
            refreshFileList2();
            Floper.SelectedTab = tabPage2;

        }


        private void AddOrder_Click(object sender, EventArgs e)
        {
            FileInfo fi = new FileInfo(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Base\" + maskedTextBox2.Text + ".txt");
            StreamWriter w = fi.AppendText();
            if (maskedTextBox2.Text.Length != 12)
            {
                if (maskedTextBox2.Text.Length == 0)
                {
                    MessageBox.Show("Необхдимо ввести номер паспорта для добавления заказа");
                    return;
                }
                else
                {
                    MessageBox.Show("Заполните поля пасспорт правильно");
                    return;
                }
            }


            w.WriteLine("\n");
            w.WriteLine(textBox1.Text);
            w.WriteLine(maskedTextBox1.Text);
            w.WriteLine(dateTimePicker1.Text);
            w.WriteLine(comboBox5.SelectedItem);
            w.WriteLine(textBox3.Text);
            w.WriteLine(comboBox1.SelectedItem);
            w.WriteLine(textBox2.Text);
            w.WriteLine(comboBox2.SelectedItem);
            w.Close();

            StreamReader sr = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Base\" + maskedTextBox2.Text + ".txt");

            Show_Order.Text += "Фамилия - " + sr.ReadLine() + "\n";
            Show_Order.Text += "Имя - " + sr.ReadLine() + "\n";
            Show_Order.Text += "Отчество - " + sr.ReadLine() + "\n";
            Show_Order.Text += "Номер Паспорта - " + sr.ReadLine() + "\n";
            Show_Order.Text += "Номер Снилса - " + sr.ReadLine() + "\n";
            Show_Order.Text += "Город проживаия - " + sr.ReadLine() + "\n";
            while (sr.ReadLine() != null)
            {
                Show_Order.Text += sr.ReadLine() + "\n";
                Show_Order.Text += "Город - " + sr.ReadLine() + "\n";
                Show_Order.Text += "Телефон - " + sr.ReadLine() + "\n";
                Show_Order.Text += "Дата доставки - " + sr.ReadLine() + "\n";
                Show_Order.Text += "Способ доставки - " + sr.ReadLine() + "\n";
                Show_Order.Text += "Наименование  " + sr.ReadLine() + "\n";
                Show_Order.Text += "Цвет  - " + sr.ReadLine() + "\n";
                Show_Order.Text += "Артикул  - " + sr.ReadLine() + "\n";
                Show_Order.Text += "Производитель - " + sr.ReadLine() + "\n";

            }

            sr.Close();
        }

        private void Search_Click_1(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            switch (comboBox6.SelectedIndex)
            {
                case 0:
                    DirectoryInfo di = new DirectoryInfo(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Base");
                    FileInfo[] fia = di.GetFiles();
                    for (int i = 0; i < fia.Count(); i++)
                    {
                        StreamReader Sr = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Base\" + fia[i].ToString());
                        if (textBox4.Text == Sr.ReadLine())
                        {
                            Sr.Close();
                            Sr = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Base\" + fia[i].ToString());
                            listBox2.Items.Add(Sr.ReadLine() + " " + Sr.ReadLine() + " " + Sr.ReadLine());

                        }
                        else Sr.Close();
                        Sr.Close();

                    }

                    break;

                case 1:
                    di = new DirectoryInfo(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Base");
                    fia = di.GetFiles();
                    for (int i = 0; i < fia.Count(); i++)
                    {
                        StreamReader Sr = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Base\" + fia[i].ToString());
                        Sr.ReadLine();
                        if (textBox4.Text == Sr.ReadLine())
                        {
                            Sr.Close();
                            Sr = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Base\" + fia[i].ToString());
                            listBox2.Items.Add(Sr.ReadLine() + " " + Sr.ReadLine() + " " + Sr.ReadLine());
                        }
                        else Sr.Close();
                        Sr.Close();
                    }
                    break;

                case 2:
                    di = new DirectoryInfo(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Base");
                    fia = di.GetFiles();
                    for (int i = 0; i < fia.Count(); i++)
                    {
                        StreamReader Sr = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Base\" + fia[i].ToString());
                        for (int j = 0; j < 2; j++)
                        {
                            Sr.ReadLine();
                        }

                        if (textBox4.Text == Sr.ReadLine())
                        {
                            Sr.Close();
                            Sr = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Base\" + fia[i].ToString());
                            listBox2.Items.Add(Sr.ReadLine() + " " + Sr.ReadLine() + " " + Sr.ReadLine());
                        }
                        else Sr.Close();
                        Sr.Close();
                    }
                    break;

                case 3:
                    di = new DirectoryInfo(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Base");
                    fia = di.GetFiles();
                    for (int i = 0; i < fia.Count(); i++)
                    {
                        StreamReader Sr = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Base\" + fia[i].ToString());
                        for (int j = 0; j < 3; j++)
                        {
                            Sr.ReadLine();
                        }

                        if (textBox4.Text == Sr.ReadLine())
                        {
                            Sr.Close();
                            Sr = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Base\" + fia[i].ToString());
                            listBox2.Items.Add(Sr.ReadLine() + " " + Sr.ReadLine() + " " + Sr.ReadLine());
                        }
                        else Sr.Close();
                        Sr.Close();
                    }
                    break;

                case 4:
                    di = new DirectoryInfo(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Base");
                    fia = di.GetFiles();

                    for (int i = 0; i < fia.Count(); i++)
                    {
                        StreamReader Sr = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Base\" + fia[i].ToString());
                        for (int j = 0; j < 4; j++)
                        {
                            Sr.ReadLine();
                        }
                        if (textBox4.Text == Sr.ReadLine())
                        {
                            Sr.Close();
                            Sr = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Base\" + fia[i].ToString());
                            listBox2.Items.Add(Sr.ReadLine() + " " + Sr.ReadLine() + " " + Sr.ReadLine());
                        }
                        else Sr.Close();
                        Sr.Close();
                    }
                    break;


            }
        }




        private void Delete_Click_1(object sender, EventArgs e)
        {
            int ind = listBox2.SelectedIndex;
            DirectoryInfo di = new DirectoryInfo(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Base\");
            FileInfo[] list = di.GetFiles();
            list[ind].Delete();
            refreshFileList2();
            show_inform.Clear();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Floper.SelectedTab = tabPage2;
        }





        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            comboBox6.Items.Clear();
            textBox4.Clear();
            listBox2.Items.Clear();
        }

        private void информациюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Show_Order.Clear();
        }



        private void SelectOrder_Click(object sender, EventArgs e)
        {
            if ((comboBox4.SelectedIndex == -1) && (listBox3.SelectedIndex == -1))
            {
                MessageBox.Show("Выберите что-то");
                return;
            }
            int i = listBox3.SelectedIndex;
            if (comboBox4.SelectedIndex == -1)
            {

                DirectoryInfo di = new DirectoryInfo(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\MebelOb");
                FileInfo[] SH = di.GetFiles();

                StreamReader sr1 = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\MebelOb\" + SH[i].ToString());

                textBox3.Text = sr1.ReadLine();
                sr1.ReadLine();
                sr1.ReadLine();
                textBox2.Text = sr1.ReadLine();
                sr1.Close();
                Floper.SelectedTab = tabPage1;
            }


            if (comboBox4.SelectedIndex == 0)
            {
                DirectoryInfo di = new DirectoryInfo(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Кровати");
                FileInfo[] SH = di.GetFiles();

                StreamReader sr = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Кровати\" + SH[i].ToString());
                textBox3.Text = sr.ReadLine();
                sr.ReadLine();
                sr.ReadLine();
                textBox2.Text = sr.ReadLine();
                Floper.SelectedTab = tabPage1;
            }
            if (comboBox4.SelectedIndex == 1)
            {
                DirectoryInfo di = new DirectoryInfo(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Диваны");
                FileInfo[] SH = di.GetFiles();

                StreamReader sr = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Диваны\" + SH[i].ToString());
                textBox3.Text = sr.ReadLine();
                sr.ReadLine();
                sr.ReadLine();
                textBox2.Text = sr.ReadLine();
                Floper.SelectedTab = tabPage1;
            }
            if (comboBox4.SelectedIndex == 2)

            {
                DirectoryInfo di = new DirectoryInfo(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Кресла");
                FileInfo[] SH = di.GetFiles();

                StreamReader sr = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Кресла\" + SH[i].ToString());
                textBox3.Text = sr.ReadLine();
                sr.ReadLine();
                sr.ReadLine();
                textBox2.Text = sr.ReadLine();
                Floper.SelectedTab = tabPage1;

            }
        }



        private void SearchMebelDivan()
        {
            switch (comboBox3.SelectedIndex)
            {
                case 0:
                    DirectoryInfo di = new DirectoryInfo(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Диваны");
                    FileInfo[] fia = di.GetFiles();
                    for (int i = 0; i < fia.Count(); i++)
                    {
                        StreamReader Sr = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Диваны\" + fia[i].ToString());
                        if (textBox5.Text == Sr.ReadLine())
                        {
                            Sr.Close();
                            Sr = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Диваны\" + fia[i].ToString());
                            listBox3.Items.Add(Sr.ReadLine());

                        }
                        else

                            Sr.Close();


                        Sr.Close();

                    }

                    break;

                case 1:
                    di = new DirectoryInfo(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Диваны");
                    fia = di.GetFiles();
                    for (int i = 0; i < fia.Count(); i++)
                    {
                        StreamReader Sr = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Диваны\" + fia[i].ToString());
                        Sr.ReadLine();
                        if (textBox5.Text == Sr.ReadLine())
                        {
                            Sr.Close();
                            Sr = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Диваны\" + fia[i].ToString());
                            listBox3.Items.Add(Sr.ReadLine());
                        }
                        else

                            Sr.Close();


                        Sr.Close();
                    }
                    break;

                case 2:
                    di = new DirectoryInfo(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Диваны");
                    fia = di.GetFiles();
                    for (int i = 0; i < fia.Count(); i++)
                    {
                        StreamReader Sr = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Диваны\" + fia[i].ToString());
                        for (int j = 0; j < 2; j++)
                        {
                            Sr.ReadLine();
                        }

                        if (textBox5.Text == Sr.ReadLine())
                        {
                            Sr.Close();
                            Sr = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Диваны\" + fia[i].ToString());
                            listBox3.Items.Add(Sr.ReadLine());
                        }
                        else

                            Sr.Close();


                        Sr.Close();
                    }
                    break;

                case 3:
                    di = new DirectoryInfo(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Диваны");
                    fia = di.GetFiles();
                    for (int i = 0; i < fia.Count(); i++)
                    {
                        StreamReader Sr = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Диваны\" + fia[i].ToString());
                        for (int j = 0; j < 3; j++)
                        {
                            Sr.ReadLine();
                        }

                        if (textBox5.Text == Sr.ReadLine())
                        {
                            Sr.Close();
                            Sr = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Диваны\" + fia[i].ToString());
                            listBox3.Items.Add(Sr.ReadLine());
                        }
                        else
                            Sr.Close();
                        Sr.Close();
                    }
                    break;

                case 4:
                    di = new DirectoryInfo(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Диваны");
                    fia = di.GetFiles();

                    for (int i = 0; i < fia.Count(); i++)
                    {
                        StreamReader Sr = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Диваны\" + fia[i].ToString());
                        for (int j = 0; j < 4; j++)
                        {
                            Sr.ReadLine();
                        }
                        if (textBox5.Text == Sr.ReadLine())
                        {
                            Sr.Close();
                            Sr = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Диваны\" + fia[i].ToString());
                            listBox3.Items.Add(Sr.ReadLine());
                        }
                        else

                            Sr.Close();


                        Sr.Close();
                    }
                    break;


            }
        }
        private void SearchMebelKrovat()
        {
            switch (comboBox3.SelectedIndex)
            {
                case 0:
                    DirectoryInfo di = new DirectoryInfo(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Кровати");
                    FileInfo[] fia = di.GetFiles();
                    for (int i = 0; i < fia.Count(); i++)
                    {
                        StreamReader Sr = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Кровати\" + fia[i].ToString());
                        if (textBox5.Text == Sr.ReadLine())
                        {
                            Sr.Close();
                            Sr = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Кровати\" + fia[i].ToString());
                            listBox3.Items.Add(Sr.ReadLine());

                        }
                        else
                        {
                            MessageBox.Show("На найдено");
                            Sr.Close();

                        }
                        Sr.Close();

                    }

                    break;

                case 1:
                    di = new DirectoryInfo(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Кровати");
                    fia = di.GetFiles();
                    for (int i = 0; i < fia.Count(); i++)
                    {
                        StreamReader Sr = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Кровати\" + fia[i].ToString());
                        Sr.ReadLine();
                        if (textBox5.Text == Sr.ReadLine())
                        {
                            Sr.Close();
                            Sr = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Кровати\" + fia[i].ToString());
                            listBox3.Items.Add(Sr.ReadLine());
                        }
                        else
                        {
                            MessageBox.Show("На найдено");
                            Sr.Close();

                        }
                        Sr.Close();
                    }
                    break;

                case 2:
                    di = new DirectoryInfo(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Кровати");
                    fia = di.GetFiles();
                    for (int i = 0; i < fia.Count(); i++)
                    {
                        StreamReader Sr = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Кровати\" + fia[i].ToString());
                        for (int j = 0; j < 2; j++)
                        {
                            Sr.ReadLine();
                        }

                        if (textBox5.Text == Sr.ReadLine())
                        {
                            Sr.Close();
                            Sr = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Кровати\" + fia[i].ToString());
                            listBox3.Items.Add(Sr.ReadLine());
                        }
                        else
                        {
                            MessageBox.Show("На найдено");
                            Sr.Close();

                        }
                        Sr.Close();
                    }
                    break;

                case 3:
                    di = new DirectoryInfo(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Кровати");
                    fia = di.GetFiles();
                    for (int i = 0; i < fia.Count(); i++)
                    {
                        StreamReader Sr = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Кровати\" + fia[i].ToString());
                        for (int j = 0; j < 3; j++)
                        {
                            Sr.ReadLine();
                        }

                        if (textBox5.Text == Sr.ReadLine())
                        {
                            Sr.Close();
                            Sr = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Кровати\" + fia[i].ToString());
                            listBox3.Items.Add(Sr.ReadLine());
                        }
                        else
                        {
                            MessageBox.Show("На найдено");
                            Sr.Close();

                        }
                        Sr.Close();
                    }
                    break;

                case 4:
                    di = new DirectoryInfo(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Кровати");
                    fia = di.GetFiles();

                    for (int i = 0; i < fia.Count(); i++)
                    {
                        StreamReader Sr = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Кровати\" + fia[i].ToString());
                        for (int j = 0; j < 4; j++)
                        {
                            Sr.ReadLine();
                        }
                        if (textBox5.Text == Sr.ReadLine())
                        {
                            Sr.Close();
                            Sr = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Кровати\" + fia[i].ToString());
                            listBox3.Items.Add(Sr.ReadLine());
                        }
                        else
                        {
                            MessageBox.Show("На найдено");
                            Sr.Close();

                        }
                        Sr.Close();
                    }
                    break;

                default:
                    MessageBox.Show("Заполните все поля");
                    break;

            }
        }
        private void SearchMebelKreslo()
        {
            switch (comboBox3.SelectedIndex)
            {
                case 0:
                    DirectoryInfo di = new DirectoryInfo(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Кресла");
                    FileInfo[] fia = di.GetFiles();
                    for (int i = 0; i < fia.Count(); i++)
                    {
                        StreamReader Sr = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Кресла\" + fia[i].ToString());
                        if (textBox5.Text == Sr.ReadLine())
                        {
                            Sr.Close();
                            Sr = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Кресла\" + fia[i].ToString());
                            listBox3.Items.Add(Sr.ReadLine());

                        }
                        else
                        {
                            MessageBox.Show("На найдено");
                            Sr.Close();

                        }
                        Sr.Close();

                    }

                    break;

                case 1:
                    di = new DirectoryInfo(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Кресла");
                    fia = di.GetFiles();
                    for (int i = 0; i < fia.Count(); i++)
                    {
                        StreamReader Sr = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Кресла\" + fia[i].ToString());
                        Sr.ReadLine();
                        if (textBox5.Text == Sr.ReadLine())
                        {
                            Sr.Close();
                            Sr = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Кресла\" + fia[i].ToString());
                            listBox3.Items.Add(Sr.ReadLine());
                        }
                        else
                        {
                            MessageBox.Show("На найдено");
                            Sr.Close();

                        }
                        Sr.Close();
                    }
                    break;

                case 2:
                    di = new DirectoryInfo(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Кресла");
                    fia = di.GetFiles();
                    for (int i = 0; i < fia.Count(); i++)
                    {
                        StreamReader Sr = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Кресла\" + fia[i].ToString());
                        for (int j = 0; j < 2; j++)
                        {
                            Sr.ReadLine();
                        }

                        if (textBox5.Text == Sr.ReadLine())
                        {
                            Sr.Close();
                            Sr = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Кресла\" + fia[i].ToString());
                            listBox3.Items.Add(Sr.ReadLine());
                        }
                        else
                        {
                            MessageBox.Show("На найдено");
                            Sr.Close();

                        }
                        Sr.Close();
                    }
                    break;

                case 3:
                    di = new DirectoryInfo(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Кресла");
                    fia = di.GetFiles();
                    for (int i = 0; i < fia.Count(); i++)
                    {
                        StreamReader Sr = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Кресла\" + fia[i].ToString());
                        for (int j = 0; j < 3; j++)
                        {
                            Sr.ReadLine();
                        }

                        if (textBox5.Text == Sr.ReadLine())
                        {
                            Sr.Close();
                            Sr = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Кресла\" + fia[i].ToString());
                            listBox3.Items.Add(Sr.ReadLine());
                        }
                        else
                        {
                            MessageBox.Show("На найдено");
                            Sr.Close();

                        }
                        Sr.Close();
                    }
                    break;

                case 4:
                    di = new DirectoryInfo(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Кресла");
                    fia = di.GetFiles();

                    for (int i = 0; i < fia.Count(); i++)
                    {
                        StreamReader Sr = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Кресла\" + fia[i].ToString());
                        for (int j = 0; j < 4; j++)
                        {
                            Sr.ReadLine();
                        }
                        if (textBox5.Text == Sr.ReadLine())
                        {
                            Sr.Close();
                            Sr = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Кресла\" + fia[i].ToString());
                            listBox3.Items.Add(Sr.ReadLine());
                        }
                        else
                        {
                            MessageBox.Show("На найдено");
                            Sr.Close();

                        }
                        Sr.Close();
                    }
                    break;

                default:
                    MessageBox.Show("Заполните все поля");
                    break;

            }
        }

        private void SearchMebel_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            if (comboBox4.SelectedIndex == -1) return;
            if (comboBox4.SelectedIndex == 0)
                SearchMebelKrovat();
            if (comboBox4.SelectedIndex == 1)
                SearchMebelDivan();
            if (comboBox4.SelectedIndex == 2)
                SearchMebelKreslo();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            show_inform.Clear();
            if (listBox2.SelectedIndex == -1) return;
            int i = listBox2.SelectedIndex;

            DirectoryInfo di = new DirectoryInfo(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Base");
            FileInfo[] SH = di.GetFiles();

            StreamReader sr = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Base\" + SH[i].ToString());


            show_inform.Text += "Фамилия - " + sr.ReadLine() + "\n";
            show_inform.Text += "Имя - " + sr.ReadLine() + "\n";
            show_inform.Text += "Отчество - " + sr.ReadLine() + "\n";
            show_inform.Text += "Номер Паспорта - " + sr.ReadLine() + "\n";
            show_inform.Text += "Номер Снилса - " + sr.ReadLine() + "\n";
            show_inform.Text += "Город проживаия - " + sr.ReadLine() + "\n";
            while (sr.ReadLine() != null)
            {
                show_inform.Text += sr.ReadLine() + "\n";
                show_inform.Text += "Город - " + sr.ReadLine() + "\n";
                show_inform.Text += "Телефон - " + sr.ReadLine() + "\n";
                show_inform.Text += "Дата доставки - " + sr.ReadLine() + "\n";
                show_inform.Text += "Способ доставки - " + sr.ReadLine() + "\n";
                show_inform.Text += "Наименование  " + sr.ReadLine() + "\n";
                show_inform.Text += "Цвет  - " + sr.ReadLine() + "\n";
                show_inform.Text += "Артикул  - " + sr.ReadLine() + "\n";
                show_inform.Text += "Производитель - " + sr.ReadLine() + "\n";

            }

            sr.Close();
            refreshFileList2();
        }

        private void Info_Mebel_Click_1(object sender, EventArgs e)
        {
            Show_Mebel.Clear();
            if (comboBox4.SelectedIndex == -1)
            {
                int i = listBox3.SelectedIndex;
                DirectoryInfo di = new DirectoryInfo(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\MebelOb");
                FileInfo[] SH = di.GetFiles();

                StreamReader sr1 = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\MebelOb\" + SH[i].ToString());
                Show_Mebel.Text += "Наименование - " + sr1.ReadLine() + "\n";
                Show_Mebel.Text += "Вид - " + sr1.ReadLine() + "\n";
                Show_Mebel.Text += "Цвет - " + sr1.ReadLine() + "\n";
                Show_Mebel.Text += "Артикул - " + sr1.ReadLine() + "\n";
                Show_Mebel.Text += "Цена - " + sr1.ReadLine() + "\n";

                sr1.Close();
            }
            if (comboBox4.SelectedIndex == 0)

            {
                int i = listBox3.SelectedIndex;
                DirectoryInfo di = new DirectoryInfo(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Кровати");
                FileInfo[] SH = di.GetFiles();

                StreamReader sr1 = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Кровати\" + SH[i].ToString());
                Show_Mebel.Text += "Наименование - " + sr1.ReadLine() + "\n";
                Show_Mebel.Text += "Вид - " + sr1.ReadLine() + "\n";
                Show_Mebel.Text += "Цвет - " + sr1.ReadLine() + "\n";
                Show_Mebel.Text += "Артикул - " + sr1.ReadLine() + "\n";
                Show_Mebel.Text += "Цена - " + sr1.ReadLine() + "\n";

                sr1.Close();
            }

            if (comboBox4.SelectedIndex == 1)
            {
                int i = listBox3.SelectedIndex;
                DirectoryInfo di = new DirectoryInfo(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Диваны");
                FileInfo[] SH = di.GetFiles();

                StreamReader sr1 = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Диваны\" + SH[i].ToString());
                Show_Mebel.Text += "Наименование - " + sr1.ReadLine() + "\n";
                Show_Mebel.Text += "Вид - " + sr1.ReadLine() + "\n";
                Show_Mebel.Text += "Цвет - " + sr1.ReadLine() + "\n";
                Show_Mebel.Text += "Артикул - " + sr1.ReadLine() + "\n";
                Show_Mebel.Text += "Цена - " + sr1.ReadLine() + "\n";

                sr1.Close();
            }
            if (comboBox4.SelectedIndex == 2)
            {
                int i = listBox3.SelectedIndex;
                DirectoryInfo di = new DirectoryInfo(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Кресла");
                FileInfo[] SH = di.GetFiles();

                StreamReader sr1 = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Mebel\Кресла\" + SH[i].ToString());
                Show_Mebel.Text += "Наименование - " + sr1.ReadLine() + "\n";
                Show_Mebel.Text += "Вид - " + sr1.ReadLine() + "\n";
                Show_Mebel.Text += "Цвет - " + sr1.ReadLine() + "\n";
                Show_Mebel.Text += "Артикул - " + sr1.ReadLine() + "\n";
                Show_Mebel.Text += "Цена - " + sr1.ReadLine() + "\n";

                sr1.Close();
            }





        }

        private void Select_Click(object sender, EventArgs e)
        {
            int i = listBox2.SelectedIndex;
            DirectoryInfo di = new DirectoryInfo(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Base");
            FileInfo[] SH = di.GetFiles();            

            StreamReader sr1 = new StreamReader(@"C:\Users\Univer\Desktop\Модуль\csharp_blank\Base\" + SH[i].ToString());
            sr1.ReadLine();
            sr1.ReadLine();
            sr1.ReadLine();
            maskedTextBox2.Text= sr1.ReadLine();

            sr1.Close();
            Floper.SelectedTab = tabPage2;
        }

        private void добавлениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LastName.Clear();
            FirstName.Clear();
            OtName.Clear();
            maskedTextBox3.Clear();
            maskedTextBox4.Clear();
            City.Clear(); 
        }

        private void поискToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            textBox4.Clear();
        }
    }
}