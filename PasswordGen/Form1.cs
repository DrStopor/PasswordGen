using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Diagnostics;

namespace PasswordGen
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char vvod = e.KeyChar;

            if (!Char.IsDigit(vvod) && vvod != 8)
            {
                e.Handled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.TextLength < 1)
            {
                checkBox1.Checked = false;
            }

            richTextBox1.Clear();

            int dlina = int.Parse(textBox1.Text);

            string iPass = "";

            passwordHashing(ref iPass, dlina);

            richTextBox1.SelectedText = iPass;

            if (checkBox1.Checked && !textBox2.ReadOnly)
            {
                string imaja = textBox2.Text + ".txt";
                File.AppendAllText(imaja, Environment.NewLine + iPass + Environment.NewLine);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.ReadOnly = false;
            }
            else
                textBox2.ReadOnly = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(richTextBox1.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog raz = new SaveFileDialog();

            raz.DefaultExt = "*.rtf";
            raz.Filter = "RTF Files|*.rtf";

            if (raz.ShowDialog() == System.Windows.Forms.DialogResult.OK && raz.FileName.Length > 0)
            {
                richTextBox1.SaveFile(raz.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("mailto:dmitriy.rudov@list.ru");
        }

        /// <summary>
        /// полный набор
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void absolute(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
            int change;

            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 2);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)engAll();
                }
                else
                {
                    iPass += (char)cyrAll();
                }
            }
        }

        /// <summary>
        /// все, кроме особенных и кирилицы
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void allIn(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));

            for (int i = 0; i < dlina; i++)
            {
                    iPass += (char)rnd.Next(33, 127);
                    Thread.Sleep(1);
            }

        }

        /// <summary>
        /// все английские
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void engBoth(int dlina, ref string iPass)
        {
            for (int i = 0; i < dlina; i++)
            {
                iPass += (char)engAll();
            }
        }

        /// <summary>
        /// английский алфавит, верхний регистр
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void engUpper(int dlina, ref string iPass)
        {
            for (int i = 0; i < dlina; i++)
            {
                iPass += (char)engUp();
            }
        }

        /// <summary>
        /// английский алфавит, нижний регистр
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void engLower(int dlina, ref string iPass)
        {

            for (int i = 0; i < dlina; i++)
            {
                iPass += (char)engLow();
            }
        }

        /// <summary>
        /// криллица, все регистры
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void cyrillicBoth(int dlina, ref string iPass)
        {
            for (int i = 0; i < dlina; i++)
            {
                iPass += (char)cyrAll();
            }
        }

        /// <summary>
        /// кириллица, верхний регистр
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void cyrillicUpper(int dlina, ref string iPass)
        {
            for (int i = 0; i < dlina; i++)
            {
                iPass += (char)cyrUp();
            }
        }

        /// <summary>
        /// кириллица, нижний регистр
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void cyrillicLower(int dlina, ref string iPass)
        {
            for (int i = 0; i < dlina; i++)
            {
                iPass += (char)cyrLow();
            }
        }

        /// <summary>
        /// англ.все + кирил.все
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void engCyrBoth(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));

            int change;

            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 2);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)engAll();
                }
                else
                {
                    iPass += (char)cyrAll();
                }
            }
        }

        /// <summary>
        /// английский верхний регистры и кириллица все регистры
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void engUpCyrBoth(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));

            int change;

            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 2);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)engUp();
                }
                else
                {
                    iPass += (char)cyrAll();
                }
            }
        }

        /// <summary>
        /// английский нижний регистр, кириллица все регистры
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void engLowCyrBoth(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));

            int change;

            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 2);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)engLow();
                }
                else
                {
                    iPass += (char)cyrAll();
                }
            }
        }

        /// <summary>
        /// англ.все и крил.верх
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void engBothCyrUp(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));

            int change;

            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 2);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)engAll();
                }
                else
                {
                    iPass += (char)cyrUp();
                }
            }
        }

        /// <summary>
        /// англ.верх и крил.верх
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void engUpCyrUp(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));

            int change;

            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 2);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)engUp();
                }
                else
                {
                    iPass += (char)cyrUp();
                }
            }
        }

        /// <summary>
        /// англ.низ и кирил.верх
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void engLowpCyrUp(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));

            int change;

            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 2);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)engLow();
                }
                else
                {
                    iPass += (char)cyrUp();
                }
            }
        }

        /// <summary>
        /// англ.все и кирил.низ
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void engBothpCyrLow(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));

            int change;

            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 2);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)engAll();
                }
                else
                {
                    iPass += (char)cyrLow();
                }
            }
        }

        /// <summary>
        /// анг.верх и кирил.низ
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void engUpCyrLow(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));

            int change;

            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 2);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)engUp();
                }
                else
                {
                    iPass += (char)cyrLow();
                }
            }
        }

        /// <summary>
        /// англ.низ и кирил.низ
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void engLowCyrLow(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));

            int change;

            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 2);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)engLow();
                }
                else
                {
                    iPass += (char)cyrLow();
                }
            }
        }

        /// <summary>
        /// агнл.все и цифры
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void engAllDig(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));

            int change;

            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 2);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)engAll();
                }
                else
                {
                    iPass += (char)digChar();
                }
            }
        }

        /// <summary>
        /// англ.верх и цифры
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void engUpDig(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));

            int change;

            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 2);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)engUp();
                }
                else
                {
                    iPass += (char)digChar();
                }
            }
        }

        /// <summary>
        /// англ.низ и цифры
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void engLowDig(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));

            int change;

            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 2);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)engLow();
                }
                else
                {
                    iPass += (char)digChar();
                }
            }
        }       

        /// <summary>
        /// англ.все и символы
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void engAllSymb(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));

            int change;

            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 2);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)engAll();
                }
                else
                {
                    iPass += (char)symbChar();
                }
            }
        }

        /// <summary>
        /// англ.верх и символы
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void engUpSymb(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));

            int change;

            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 2);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)engUp();
                }
                else
                {
                    iPass += (char)symbChar();
                }
            }
        }

        /// <summary>
        /// англ.низ и символы
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void engLowSymb(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));

            int change;

            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 2);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)engLow();
                }
                else
                {
                    iPass += (char)symbChar();
                }
            }
        }

        /// <summary>
        /// англ.все, кирил.все и цифры
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void engBothСyrBothDig(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
            int change;
            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 3);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)engAll();
                }
                else if (change == 1)
                {
                    iPass += (char)cyrAll();
                }
                else
                    iPass += (char)digChar();
            }
        }

        /// <summary>
        /// англ.верх, кирил.все и цифры
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void engUpСyrBothDig(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
            int change;
            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 3);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)engUp();
                }
                else if (change == 1)
                {
                    iPass += (char)cyrAll();
                }
                else
                    iPass += (char)digChar();
            }
        }

        /// <summary>
        /// англ.низ, кирил.все и цифры
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void engLowСyrBothDig(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
            int change;
            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 3);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)engLow();
                }
                else if (change == 1)
                {
                    iPass += (char)cyrAll();
                }
                else
                    iPass += (char)digChar();
            }
        }

        /// <summary>
        /// англ.все, кирил.верх и цифры
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void engBothСyrUpDig(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
            int change;
            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 3);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)engAll();
                }
                else if (change == 1)
                {
                    iPass += (char)cyrUp();
                }
                else
                    iPass += (char)digChar();
            }
        }

        /// <summary>
        /// англ.верх, кирил.верх и цифры
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void engUpСyrUpDig(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
            int change;
            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 3);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)engUp();
                }
                else if (change == 1)
                {
                    iPass += (char)cyrUp();
                }
                else
                    iPass += (char)digChar();
            }
        }

        /// <summary>
        /// англ.низ, кирил.верх и цифры
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void engLowСyrUpDig(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
            int change;
            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 3);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)engLow();
                }
                else if (change == 1)
                {
                    iPass += (char)cyrUp();
                }
                else
                    iPass += (char)digChar();
            }
        }

        /// <summary>
        /// англ.все, кирил.низ и цифры
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void engBothСyrLowDig(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
            int change;
            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 3);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)engAll();
                }
                else if (change == 1)
                {
                    iPass += (char)cyrLow();
                }
                else
                    iPass += (char)digChar();
            }
        }

        /// <summary>
        /// англ.верх, кирил.низ и цифры
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void engUpСyrLowDig(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
            int change;
            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 3);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)engUp();
                }
                else if (change == 1)
                {
                    iPass += (char)cyrLow();
                }
                else
                    iPass += (char)digChar();
            }
        }

        /// <summary>
        /// англ.низ, кирил.низ и цифры
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void engLowСyrLowDig(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
            int change;
            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 3);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)engLow();
                }
                else if (change == 1)
                {
                    iPass += (char)cyrLow();
                }
                else
                    iPass += (char)digChar();
            }
        }

        /// <summary>
        /// англ.все, кирил.все и символы
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void engBothСyrBothSymb(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
            int change;
            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 3);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)engAll();
                }
                else if (change == 1)
                {
                    iPass += (char)cyrAll();
                }
                else
                    iPass += (char)symbChar();
            }
        }

        /// <summary>
        /// англ.верх, кирил.все и символы
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void engUpСyrBothSymb(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
            int change;
            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 3);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)engUp();
                }
                else if (change == 1)
                {
                    iPass += (char)cyrAll();
                }
                else
                    iPass += (char)symbChar();
            }
        }

        /// <summary>
        /// англ.низ, кирил.все и символы
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void engLowСyrBothSymb(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
            int change;
            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 3);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)engLow();
                }
                else if (change == 1)
                {
                    iPass += (char)cyrAll();
                }
                else
                    iPass += (char)symbChar();
            }
        }

        /// <summary>
        /// англ.все, кирил.верх и символы
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void engBothСyrUpSymb(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
            int change;
            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 3);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)engAll();
                }
                else if (change == 1)
                {
                    iPass += (char)cyrUp();
                }
                else
                    iPass += (char)symbChar();
            }
        }

        /// <summary>
        /// англ.верх, кирил.верх и символы
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void engUpСyrUpSymb(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
            int change;
            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 3);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)engUp();
                }
                else if (change == 1)
                {
                    iPass += (char)cyrUp();
                }
                else
                    iPass += (char)symbChar();
            }
        }

        /// <summary>
        /// англ.низ, кирил.верх и символы
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void engLowСyrUpSymb(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
            int change;
            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 3);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)engLow();
                }
                else if (change == 1)
                {
                    iPass += (char)cyrUp();
                }
                else
                    iPass += (char)symbChar();
            }
        }

        /// <summary>
        /// англ.все, кирил.низ и символы
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void engBothСyrLowSymb(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
            int change;
            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 3);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)engAll();
                }
                else if (change == 1)
                {
                    iPass += (char)cyrLow();
                }
                else
                    iPass += (char)symbChar();
            }
        }

        /// <summary>
        /// англ.верх, кирил.низ и символы
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void engUpСyrLowSymb(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
            int change;
            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 3);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)engUp();
                }
                else if (change == 1)
                {
                    iPass += (char)cyrLow();
                }
                else
                    iPass += (char)symbChar();
            }
        }

        /// <summary>
        /// англ.низ, кирил.низ и символы
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void engLowСyrLowSymb(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
            int change;
            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 3);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)engLow();
                }
                else if (change == 1)
                {
                    iPass += (char)cyrLow();
                }
                else
                    iPass += (char)symbChar();
            }
        }

        /// <summary>
        /// англ.все, кирил.верх, цифры и символы
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void engBothСyrUpDigSymb(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
            int change;
            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 4);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)engAll();
                }
                else if (change == 1)
                {
                    iPass += (char)cyrUp();
                }
                else if(change == 2)
                {
                    iPass += (char)digChar();
                }else
                    iPass += (char)symbChar();
            }
        }

        /// <summary>
        /// англ.верх, кирил.верх, цифры и символы
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void engUpСyrUpDigSymb(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
            int change;
            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 4);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)engUp();
                }
                else if (change == 1)
                {
                    iPass += (char)cyrUp();
                }
                else if (change == 2)
                {
                    iPass += (char)digChar();
                }
                else
                    iPass += (char)symbChar();
            }
        }

        /// <summary>
        /// англ.низ, кирил.верх, цифры и символы
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void engLowСyrUpDigSymb(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
            int change;
            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 4);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)engLow();
                }
                else if (change == 1)
                {
                    iPass += (char)cyrUp();
                }
                else if (change == 2)
                {
                    iPass += (char)digChar();
                }
                else
                    iPass += (char)symbChar();
            }
        }

        /// <summary>
        /// англ.все, кирил.низ, цифры и символы
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void engBothСyrLowDigSymb(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
            int change;
            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 4);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)engAll();
                }
                else if (change == 1)
                {
                    iPass += (char)cyrLow();
                }
                else if (change == 2)
                {
                    iPass += (char)digChar();
                }
                else
                    iPass += (char)symbChar();
            }
        }

        /// <summary>
        /// англ.верх, кирил.низ, цифры и символы
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void engUpСyrLowDigSymb(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
            int change;
            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 4);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)engUp();
                }
                else if (change == 1)
                {
                    iPass += (char)cyrLow();
                }
                else if (change == 2)
                {
                    iPass += (char)digChar();
                }
                else
                    iPass += (char)symbChar();
            }
        }

        /// <summary>
        /// англ.низ, кирил.низ, цифры и низ
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void engLowСyrLowDigSymb(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
            int change;
            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 4);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)engLow();
                }
                else if (change == 1)
                {
                    iPass += (char)cyrLow();
                }
                else if (change == 2)
                {
                    iPass += (char)digChar();
                }
                else
                    iPass += (char)symbChar();
            }
        }

        /// <summary>
        /// кирил.все и цифры
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void cyrBothDig(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
            int change;
            for(int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 2);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)cyrAll();
                }
                else
                    iPass += (char)digChar();
            }
        }

        /// <summary>
        /// кирил.верх и цифры
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void cyrUpDig(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
            int change;
            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 2);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)cyrUp();
                }
                else
                    iPass += (char)digChar();
            }
        }

        /// <summary>
        /// кирил.низ и цифры
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void cyrLowDig(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
            int change;
            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 2);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)cyrLow();
                }
                else
                    iPass += (char)digChar();
            }
        }

        /// <summary>
        /// кирил.все и символы
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void cyrBothSymb(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
            int change;
            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 2);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)cyrAll();
                }
                else
                    iPass += (char)symbChar();
            }
        }

        /// <summary>
        /// кирил.верх и символ
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void cyrUpSymb(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
            int change;
            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 2);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)cyrUp();
                }
                else
                    iPass += (char)symbChar();
            }
        }

        /// <summary>
        /// англ.низ и символы
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void cyrLowSymb(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
            int change;
            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 2);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)cyrLow();
                }
                else
                    iPass += (char)symbChar();
            }
        }

        /// <summary>
        /// кирил.все, цифры и символы
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void cyrBothDigSymb(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
            int change;
            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 3);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)cyrAll();
                }
                else if (change == 1)
                    iPass += (char)digChar();
                else
                    iPass += (char)symbChar();
            }
        }

        /// <summary>
        /// англ.верх, цифры и символы
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void cyrUpDigSymb(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
            int change;
            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 3);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)cyrUp();
                }
                else if (change == 1)
                    iPass += (char)digChar();
                else
                    iPass += (char)symbChar();
            }
        }

        /// <summary>
        /// англ.низ, цифры и символы
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void cyrLowDigSymb(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
            int change;
            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 3);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)cyrLow();
                }
                else if (change == 1)
                    iPass += (char)digChar();
                else
                    iPass += (char)symbChar();
            }
        }

        /// <summary>
        /// англ.верх, цифры и символы
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void engUpDigSymb(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
            int change;
            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 3);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)engUp();
                }
                else if (change == 1)
                    iPass += (char)digChar();
                else
                    iPass += (char)symbChar();
            }
        }

        /// <summary>
        /// англ.них. цифры и символы
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void engLowDigSymb(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
            int change;
            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 3);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)engLow();
                }
                else if (change == 1)
                    iPass += (char)digChar();
                else
                    iPass += (char)symbChar();
            }
        }

        private void digSymb(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
            int change;
            for (int i = 0; i < dlina; i++)
            {
                change = rnd.Next(0, 3);
                Thread.Sleep(1);
                if (change == 0)
                {
                    iPass += (char)digChar();
                }
                else
                    iPass += (char)symbChar();
            }
        }

        /// <summary>
        /// формирует значение в полном английском
        /// </summary>
        /// <returns></returns>
        private static int engAll()
        {
            int A = 32;

            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));

            int change = 0;
            change = rnd.Next(0, 2);
            Thread.Sleep(1);

            if (change == 0)
            {
                A = rnd.Next(65, 91);
                Thread.Sleep(1);
            }
            else if (change == 1)
            {
                A = rnd.Next(97, 123);
                Thread.Sleep(1);
            }

            return A;
        }

        /// <summary>
        /// цифры
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void dig(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));

            for (int i = 0; i < dlina; i++)
            {                
                 iPass += (char)digChar();
                
            }
        }

        /// <summary>
        /// символы
        /// </summary>
        /// <param name="dlina"></param>
        /// <param name="iPass"></param>
        private void symbol(int dlina, ref string iPass)
        {
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));

            for (int i = 0; i < dlina; i++)
            {
                iPass += (char)symbChar();

            }
        }

        /// <summary>
        /// формирует символ
        /// </summary>
        /// <returns></returns>
        private static int symbChar()
        {
            int symChar = 33;

            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));

            int change = rnd.Next(0, 4);
            Thread.Sleep(1);

            if (change == 0)
            {
                symChar = rnd.Next(33, 48);
                Thread.Sleep(1);
            }
            else if (change == 1)
            {
                symChar = rnd.Next(58, 65);
                Thread.Sleep(1);
            }
            else if (change == 2)
            {
                symChar = rnd.Next(93, 98);
                Thread.Sleep(1);
            }
            else if (change == 3)
            {
                symChar = rnd.Next(123, 127);
                Thread.Sleep(1);
            }

            return symChar;
        }

        /// <summary>
        /// формирует цифру
        /// </summary>
        /// <returns></returns>
        private static int digChar()
        {
            int symbol = 48;
            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));
            symbol = rnd.Next(48, 58);
            Thread.Sleep(1);
            return symbol;
        }

        /// <summary>
        /// формирует англ.верх
        /// </summary>
        /// <returns></returns>
        private static int engUp()
        {
            int symbol = 65;

            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));

            symbol = rnd.Next(65, 91);
            Thread.Sleep(1);

            return symbol;
        }

        /// <summary>
        /// формирует англ.низ
        /// </summary>
        /// <returns></returns>
        private static int engLow()
        {
            int symbol = 97;

            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));

            symbol = rnd.Next(97, 123);
            Thread.Sleep(1);

            return symbol;
        }

        /// <summary>
        /// формирует кирил.все
        /// </summary>
        /// <returns></returns>
        private static int cyrAll()
        {
            int symbol = 1040;

            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));

            symbol = rnd.Next(1040, 1104);
            Thread.Sleep(1);

            return symbol;
        }
        /// <summary>
        /// формирует кирил.верх
        /// </summary>
        /// <returns></returns>
        private static int cyrUp()
        {
            int symbol = 1040;

            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));

            symbol = rnd.Next(1040, 1072);
            Thread.Sleep(1);

            return symbol;
        }

        /// <summary>
        /// формирует кирил.низ
        /// </summary>
        /// <returns></returns>
        private static int cyrLow()
        {
            int symbol = 1072;

            Random rnd = new Random(unchecked((int)DateTime.Now.Ticks));

            symbol = rnd.Next(1072, 1104);
            Thread.Sleep(1);

            return symbol;
        }
        
        /// <summary>
        /// применение условия "все", если по отдельности выбраны параметры подподающие под это правило
        /// </summary>
        private void checkCheked()
        {
            if(bothToolStripMenuItem1.Checked && bothToolStripMenuItem2.Checked && digitToolStripMenuItem.Checked && symbolToolStripMenuItem.Checked)
            {
                bothToolStripMenuItem.Checked = true;
                bothToolStripMenuItem1.Checked = false;
                bothToolStripMenuItem2.Checked = false;
                digitToolStripMenuItem.Checked = false;
                symbolToolStripMenuItem.Checked = false;
            }
        }
        
        /// <summary>
        /// проверка на ошибочное отключение всех наборов, кнопка "все"
        /// </summary>
        private void lamerCheckAll()
        {
            if (!bothToolStripMenuItem.Checked && !bothToolStripMenuItem1.Checked && !bothToolStripMenuItem2.Checked && !upperCaseToolStripMenuItem.Checked && !upperCaseToolStripMenuItem1.Checked & !lowerCaseToolStripMenuItem.Checked && !lowerCaseToolStripMenuItem1.Checked && !digitToolStripMenuItem.Checked && !symbolToolStripMenuItem.Checked)
                bothToolStripMenuItem.Checked = true;
        }

        /// <summary>
        /// проверка на ошибочное отключение всех наборов, кнопка "англ - все"
        /// </summary>
        private void lamerCheckEngBoth()
        {
            if (!bothToolStripMenuItem.Checked && !bothToolStripMenuItem1.Checked && !bothToolStripMenuItem2.Checked && !upperCaseToolStripMenuItem.Checked && !upperCaseToolStripMenuItem1.Checked & !lowerCaseToolStripMenuItem.Checked && !lowerCaseToolStripMenuItem1.Checked && !digitToolStripMenuItem.Checked && !symbolToolStripMenuItem.Checked)
                bothToolStripMenuItem1.Checked = true;
        }

        /// <summary>
        /// проверка на ошибочное отключение всех наборов, кнопка "кирил - все"
        /// </summary>
        private void lamerCheckCyrBoth()
        {
            if (!bothToolStripMenuItem.Checked && !bothToolStripMenuItem1.Checked && !bothToolStripMenuItem2.Checked && !upperCaseToolStripMenuItem.Checked && !upperCaseToolStripMenuItem1.Checked & !lowerCaseToolStripMenuItem.Checked && !lowerCaseToolStripMenuItem1.Checked && !digitToolStripMenuItem.Checked && !symbolToolStripMenuItem.Checked)
                bothToolStripMenuItem2.Checked = true;
        }

        /// <summary>
        /// проверка на ошибочное отключение всех наборов, кнопка "кирил - верх"
        /// </summary>
        private void lamerCheckCyrUp()
        {
            if (!bothToolStripMenuItem.Checked && !bothToolStripMenuItem1.Checked && !bothToolStripMenuItem2.Checked && !upperCaseToolStripMenuItem.Checked && !upperCaseToolStripMenuItem1.Checked & !lowerCaseToolStripMenuItem.Checked && !lowerCaseToolStripMenuItem1.Checked && !digitToolStripMenuItem.Checked && !symbolToolStripMenuItem.Checked)
                upperCaseToolStripMenuItem1.Checked = true;
        }

        /// <summary>
        /// проверка на ошибочное отключение всех наборов, кнопка "кирил - низ"
        /// </summary>
        private void lamerCheckCyrLow()
        {
            if (!bothToolStripMenuItem.Checked && !bothToolStripMenuItem1.Checked && !bothToolStripMenuItem2.Checked && !upperCaseToolStripMenuItem.Checked && !upperCaseToolStripMenuItem1.Checked & !lowerCaseToolStripMenuItem.Checked && !lowerCaseToolStripMenuItem1.Checked && !digitToolStripMenuItem.Checked && !symbolToolStripMenuItem.Checked)
                lowerCaseToolStripMenuItem1.Checked = true;
        }

        /// <summary>
        /// проверка на ошибочное отключение всех наборов, кнопка "англ - верх"
        /// </summary>
        private void lamerCheckEngUp()
        {
            if (!bothToolStripMenuItem.Checked && !bothToolStripMenuItem1.Checked && !bothToolStripMenuItem2.Checked && !upperCaseToolStripMenuItem.Checked && !upperCaseToolStripMenuItem1.Checked & !lowerCaseToolStripMenuItem.Checked && !lowerCaseToolStripMenuItem1.Checked && !digitToolStripMenuItem.Checked && !symbolToolStripMenuItem.Checked)
                upperCaseToolStripMenuItem.Checked = true;
        }

        /// <summary>
        /// проверка на ошибочное отключение всех наборов, кнопка "англ - низ"
        /// </summary>
        private void lamerCheckEngLow()
        {
            if (!bothToolStripMenuItem.Checked && !bothToolStripMenuItem1.Checked && !bothToolStripMenuItem2.Checked && !upperCaseToolStripMenuItem.Checked && !upperCaseToolStripMenuItem1.Checked & !lowerCaseToolStripMenuItem.Checked && !lowerCaseToolStripMenuItem1.Checked && !digitToolStripMenuItem.Checked && !symbolToolStripMenuItem.Checked)
                lowerCaseToolStripMenuItem.Checked = true;
        }

        /// <summary>
        /// проверка на ошибочное отключение всех наборов, кнопка "цифры"
        /// </summary>
        private void lamerCheckDig()
        {
            if (!bothToolStripMenuItem.Checked && !bothToolStripMenuItem1.Checked && !bothToolStripMenuItem2.Checked && !upperCaseToolStripMenuItem.Checked && !upperCaseToolStripMenuItem1.Checked & !lowerCaseToolStripMenuItem.Checked && !lowerCaseToolStripMenuItem1.Checked && !digitToolStripMenuItem.Checked && !symbolToolStripMenuItem.Checked)
                digitToolStripMenuItem.Checked = true;
        }

        /// <summary>
        /// проверка на ошибочное отключение всех наборов, кнопка "символы"
        /// </summary>
        private void lamerCheckSymb()
        {
            if (!bothToolStripMenuItem.Checked && !bothToolStripMenuItem1.Checked && !bothToolStripMenuItem2.Checked && !upperCaseToolStripMenuItem.Checked && !upperCaseToolStripMenuItem1.Checked & !lowerCaseToolStripMenuItem.Checked && !lowerCaseToolStripMenuItem1.Checked && !digitToolStripMenuItem.Checked && !symbolToolStripMenuItem.Checked)
                symbolToolStripMenuItem.Checked = true;
        }

        /// <summary>
        /// кнопка "все наборы"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bothToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bothToolStripMenuItem.Checked)
            {
                bothToolStripMenuItem1.Checked = false;
                bothToolStripMenuItem2.Checked = false;
                upperCaseToolStripMenuItem.Checked = false;
                upperCaseToolStripMenuItem1.Checked = false;
                lowerCaseToolStripMenuItem.Checked = false;
                lowerCaseToolStripMenuItem1.Checked = false;
                digitToolStripMenuItem.Checked = false;
                symbolToolStripMenuItem.Checked = false;
            }
            else if (bothToolStripMenuItem1.Checked || bothToolStripMenuItem2.Checked || upperCaseToolStripMenuItem.Checked || upperCaseToolStripMenuItem1.Checked || lowerCaseToolStripMenuItem.Checked || lowerCaseToolStripMenuItem1.Checked || digitToolStripMenuItem.Checked || symbolToolStripMenuItem.Checked)
            {
                bothToolStripMenuItem.Checked = false;
            }
            
            lamerCheckAll();

            checkCheked();
        }

        /// <summary>
        /// кнопка "англ - все"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bothToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (bothToolStripMenuItem1.Checked)
            {
                bothToolStripMenuItem.Checked = false;
                upperCaseToolStripMenuItem.Checked = false;
                lowerCaseToolStripMenuItem.Checked = false;
            }
            else if (bothToolStripMenuItem1.Checked && bothToolStripMenuItem2.Checked && digitToolStripMenuItem.Checked && symbolToolStripMenuItem.Checked)
                bothToolStripMenuItem.Checked = true;
            lamerCheckEngBoth();
            checkCheked();
        }

        /// <summary>
        /// кнопка "англ - верх"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void upperCaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (upperCaseToolStripMenuItem.Checked)
            {
                bothToolStripMenuItem.Checked = false;
                bothToolStripMenuItem1.Checked = false;
                lowerCaseToolStripMenuItem.Checked = false;
            }
            lamerCheckEngUp();
            checkCheked();
        }

        /// <summary>
        /// кнопка "англ - низ"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lowerCaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lowerCaseToolStripMenuItem.Checked)
            {
                bothToolStripMenuItem.Checked = false;
                upperCaseToolStripMenuItem.Checked = false;
                bothToolStripMenuItem1.Checked = false;
            }
            lamerCheckEngLow();
            checkCheked();
        }

        /// <summary>
        /// кнопка "кирил -все"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bothToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (bothToolStripMenuItem2.Checked)
            {
                bothToolStripMenuItem.Checked = false;
                upperCaseToolStripMenuItem1.Checked = false;
                lowerCaseToolStripMenuItem1.Checked = false;
            }
            else if (bothToolStripMenuItem1.Checked && bothToolStripMenuItem2.Checked && digitToolStripMenuItem.Checked && symbolToolStripMenuItem.Checked)
                bothToolStripMenuItem.Checked = true;
            lamerCheckCyrBoth();
            checkCheked();
        }

        /// <summary>
        /// кнопка "кирил - верх"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void upperCaseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (upperCaseToolStripMenuItem1.Checked)
            {
                bothToolStripMenuItem.Checked = false;
                bothToolStripMenuItem2.Checked = false;
                lowerCaseToolStripMenuItem1.Checked = false;
            }
            lamerCheckCyrUp();
            checkCheked();
        }

        /// <summary>
        /// кнопка "кирил - низ"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lowerCaseToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (lowerCaseToolStripMenuItem1.Checked)
            {
                bothToolStripMenuItem.Checked = false;
                bothToolStripMenuItem2.Checked = false;
                upperCaseToolStripMenuItem1.Checked = false;
            }
            lamerCheckCyrLow();
            checkCheked();
        }

        /// <summary>
        /// кнопка "цифры"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void digitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (digitToolStripMenuItem.Checked)
            {
                bothToolStripMenuItem.Checked = false;
            }
            else if (bothToolStripMenuItem1.Checked && bothToolStripMenuItem2.Checked && digitToolStripMenuItem.Checked && symbolToolStripMenuItem.Checked)
                bothToolStripMenuItem.Checked = true;
            lamerCheckDig();
            checkCheked();
        }

        /// <summary>
        /// кнопка "символы"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void symbolToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (symbolToolStripMenuItem.Checked)
            {
                bothToolStripMenuItem.Checked = false;
            }
            else if (bothToolStripMenuItem1.Checked && bothToolStripMenuItem2.Checked && digitToolStripMenuItem.Checked && symbolToolStripMenuItem.Checked)
                bothToolStripMenuItem.Checked = true;
            lamerCheckSymb();
            checkCheked();
        }

        private void passwordHashing(ref string iPass, int dlina)
        {
            if (bothToolStripMenuItem.Checked)
            {
                absolute(dlina, ref iPass);
            }else if(bothToolStripMenuItem1.Checked && !bothToolStripMenuItem2.Checked && !upperCaseToolStripMenuItem1.Checked && !lowerCaseToolStripMenuItem1.Checked && !digitToolStripMenuItem.Checked && !symbolToolStripMenuItem.Checked)
            {
                engBoth(dlina, ref iPass);
            }else if(upperCaseToolStripMenuItem.Checked && !bothToolStripMenuItem2.Checked && !upperCaseToolStripMenuItem1.Checked && !lowerCaseToolStripMenuItem1.Checked && !digitToolStripMenuItem.Checked && !symbolToolStripMenuItem.Checked)
            {
                engUpper(dlina, ref iPass);
            }else if(lowerCaseToolStripMenuItem.Checked && !bothToolStripMenuItem2.Checked && !upperCaseToolStripMenuItem1.Checked && !lowerCaseToolStripMenuItem1.Checked && !digitToolStripMenuItem.Checked && !symbolToolStripMenuItem.Checked)
            {
                engLower(dlina, ref iPass);
            }else if(bothToolStripMenuItem1.Checked && bothToolStripMenuItem2.Checked && !digitToolStripMenuItem.Checked && !symbolToolStripMenuItem.Checked)
            {
                engCyrBoth(dlina, ref iPass);
            }else if(upperCaseToolStripMenuItem.Checked && bothToolStripMenuItem2.Checked && !digitToolStripMenuItem.Checked && !symbolToolStripMenuItem.Checked)
            {
                engUpCyrBoth(dlina, ref iPass);
            }else if(lowerCaseToolStripMenuItem.Checked && bothToolStripMenuItem2.Checked && !digitToolStripMenuItem.Checked && !symbolToolStripMenuItem.Checked)
            {
                engLowpCyrUp(dlina, ref iPass);
            }else if(bothToolStripMenuItem1.Checked && upperCaseToolStripMenuItem1.Checked && !digitToolStripMenuItem.Checked && !symbolToolStripMenuItem.Checked)
            {
                engBothCyrUp(dlina, ref iPass);
            }else if(upperCaseToolStripMenuItem.Checked && upperCaseToolStripMenuItem1.Checked && !digitToolStripMenuItem.Checked && !symbolToolStripMenuItem.Checked)
            {
                engUpCyrUp(dlina, ref iPass);
            }else if(lowerCaseToolStripMenuItem.Checked && upperCaseToolStripMenuItem1.Checked && !digitToolStripMenuItem.Checked && !symbolToolStripMenuItem.Checked)
            {
                engLowpCyrUp(dlina, ref iPass);
            }else if(bothToolStripMenuItem1.Checked && lowerCaseToolStripMenuItem1.Checked && !digitToolStripMenuItem.Checked && !symbolToolStripMenuItem.Checked)
            {
                engBothpCyrLow(dlina, ref iPass);
            }else if(upperCaseToolStripMenuItem.Checked && lowerCaseToolStripMenuItem1.Checked && !digitToolStripMenuItem.Checked && !symbolToolStripMenuItem.Checked)
            {
                engUpCyrLow(dlina, ref iPass);
            }else if(lowerCaseToolStripMenuItem.Checked && lowerCaseToolStripMenuItem1.Checked && !digitToolStripMenuItem.Checked && !symbolToolStripMenuItem.Checked)
            {
                engLowCyrLow(dlina, ref iPass);
            }else if(bothToolStripMenuItem1.Checked && digitToolStripMenuItem.Checked && !upperCaseToolStripMenuItem1.Checked && !bothToolStripMenuItem2.Checked && !lowerCaseToolStripMenuItem1.Checked && !symbolToolStripMenuItem.Checked)
            {
                engAllDig(dlina, ref iPass);
            }else if(upperCaseToolStripMenuItem.Checked && digitToolStripMenuItem.Checked && !upperCaseToolStripMenuItem1.Checked && !bothToolStripMenuItem2.Checked && !lowerCaseToolStripMenuItem1.Checked && !symbolToolStripMenuItem.Checked)
            {
                engUpDig(dlina, ref iPass);
            }else if(lowerCaseToolStripMenuItem.Checked && digitToolStripMenuItem.Checked && !upperCaseToolStripMenuItem1.Checked && !bothToolStripMenuItem2.Checked && !lowerCaseToolStripMenuItem1.Checked && !symbolToolStripMenuItem.Checked)
            {
                engLowDig(dlina, ref iPass);
            }else if(bothToolStripMenuItem1.Checked && symbolToolStripMenuItem.Checked && !bothToolStripMenuItem2.Checked && !upperCaseToolStripMenuItem1.Checked && !lowerCaseToolStripMenuItem1.Checked && !digitToolStripMenuItem.Checked)
            {
                engAllSymb(dlina, ref iPass);
            }else if(upperCaseToolStripMenuItem.Checked && symbolToolStripMenuItem.Checked && !bothToolStripMenuItem2.Checked && !upperCaseToolStripMenuItem1.Checked && !lowerCaseToolStripMenuItem1.Checked && !digitToolStripMenuItem.Checked)
            {
                engUpSymb(dlina, ref iPass);
            }else if(lowerCaseToolStripMenuItem.Checked && symbolToolStripMenuItem.Checked && !bothToolStripMenuItem2.Checked && !upperCaseToolStripMenuItem1.Checked && !lowerCaseToolStripMenuItem1.Checked && !digitToolStripMenuItem.Checked)
            {
                engLowSymb(dlina, ref iPass);
            }else if(bothToolStripMenuItem1.Checked && bothToolStripMenuItem2.Checked && digitToolStripMenuItem.Checked && !symbolToolStripMenuItem.Checked)
            {
                engBothСyrBothDig(dlina, ref iPass);
            }else if(upperCaseToolStripMenuItem.Checked && bothToolStripMenuItem2.Checked && digitToolStripMenuItem.Checked && !symbolToolStripMenuItem.Checked)
            {
                engUpСyrBothDig(dlina, ref iPass);
            }else if(lowerCaseToolStripMenuItem.Checked && bothToolStripMenuItem2.Checked && digitToolStripMenuItem.Checked && !symbolToolStripMenuItem.Checked)
            {
                engLowСyrBothDig(dlina, ref iPass);
            }else if(bothToolStripMenuItem1.Checked && upperCaseToolStripMenuItem1.Checked && digitToolStripMenuItem.Checked && !symbolToolStripMenuItem.Checked)
            {
                engBothСyrUpDig(dlina, ref iPass);
            }else if(upperCaseToolStripMenuItem.Checked && upperCaseToolStripMenuItem1.Checked && digitToolStripMenuItem.Checked && !symbolToolStripMenuItem.Checked)
            {
                engUpСyrUpDig(dlina, ref iPass);
            }else if(lowerCaseToolStripMenuItem.Checked && upperCaseToolStripMenuItem1.Checked && digitToolStripMenuItem.Checked && digitToolStripMenuItem.Checked && !symbolToolStripMenuItem.Checked)
            {
                engLowСyrUpDig(dlina, ref iPass);
            }else if(bothToolStripMenuItem1.Checked && lowerCaseToolStripMenuItem1.Checked && digitToolStripMenuItem.Checked && !symbolToolStripMenuItem.Checked)
            {
                engBothСyrLowDig(dlina, ref iPass);
            }else if(upperCaseToolStripMenuItem.Checked && lowerCaseToolStripMenuItem1.Checked && digitToolStripMenuItem.Checked && !symbolToolStripMenuItem.Checked)
            {
                engUpСyrLowDig(dlina, ref iPass);
            }else if(lowerCaseToolStripMenuItem.Checked && lowerCaseToolStripMenuItem1.Checked && digitToolStripMenuItem.Checked && !symbolToolStripMenuItem.Checked)
            {
                engLowСyrLowDig(dlina, ref iPass);
            }else if(bothToolStripMenuItem1.Checked && bothToolStripMenuItem2.Checked && symbolToolStripMenuItem.Checked && !digitToolStripMenuItem.Checked)
            {
                engBothСyrBothSymb(dlina, ref iPass);
            }else if(upperCaseToolStripMenuItem.Checked && bothToolStripMenuItem2.Checked && symbolToolStripMenuItem.Checked && !digitToolStripMenuItem.Checked)
            {
                engUpСyrBothSymb(dlina, ref iPass);
            }else if(lowerCaseToolStripMenuItem.Checked && bothToolStripMenuItem2.Checked && symbolToolStripMenuItem.Checked && !digitToolStripMenuItem.Checked)
            {
                engLowСyrBothSymb(dlina, ref iPass);
            }else if(bothToolStripMenuItem1.Checked && upperCaseToolStripMenuItem1.Checked && symbolToolStripMenuItem.Checked && !digitToolStripMenuItem.Checked)
            {
                engBothСyrUpDig(dlina, ref iPass);
            }else if(upperCaseToolStripMenuItem.Checked && upperCaseToolStripMenuItem1.Checked && symbolToolStripMenuItem.Checked && !digitToolStripMenuItem.Checked)
            {
                engUpСyrUpSymb(dlina, ref iPass);
            }else if(lowerCaseToolStripMenuItem.Checked && upperCaseToolStripMenuItem1.Checked && symbolToolStripMenuItem.Checked && !digitToolStripMenuItem.Checked)
            {
                engLowСyrUpSymb(dlina, ref iPass);
            }else if(bothToolStripMenuItem1.Checked && lowerCaseToolStripMenuItem1.Checked && symbolToolStripMenuItem.Checked && !digitToolStripMenuItem.Checked)
            {
                engBothСyrLowSymb(dlina, ref iPass);
            }else if(upperCaseToolStripMenuItem.Checked && lowerCaseToolStripMenuItem1.Checked && symbolToolStripMenuItem.Checked && !digitToolStripMenuItem.Checked)
            {
                engUpСyrLowSymb(dlina, ref iPass);
            }else if(lowerCaseToolStripMenuItem.Checked && lowerCaseToolStripMenuItem1.Checked && symbolToolStripMenuItem.Checked && !digitToolStripMenuItem.Checked)
            {
                engLowСyrLowSymb(dlina, ref iPass);
            }else if(bothToolStripMenuItem1.Checked && upperCaseToolStripMenuItem1.Checked && digitToolStripMenuItem.Checked && symbolToolStripMenuItem.Checked)
            {
                engBothСyrUpDigSymb(dlina, ref iPass);
            }else if(upperCaseToolStripMenuItem.Checked && upperCaseToolStripMenuItem1.Checked && digitToolStripMenuItem.Checked && symbolToolStripMenuItem.Checked)
            {
                engUpСyrUpDigSymb(dlina, ref iPass);
            }else if(lowerCaseToolStripMenuItem.Checked && upperCaseToolStripMenuItem1.Checked && digitToolStripMenuItem.Checked && symbolToolStripMenuItem.Checked)
            {
                engLowСyrUpDigSymb(dlina, ref iPass);
            }else if(bothToolStripMenuItem1.Checked && lowerCaseToolStripMenuItem1.Checked && digitToolStripMenuItem.Checked && symbolToolStripMenuItem.Checked)
            {
                engBothСyrLowDigSymb(dlina, ref iPass);
            }else if(upperCaseToolStripMenuItem.Checked && lowerCaseToolStripMenuItem1.Checked && digitToolStripMenuItem.Checked && symbolToolStripMenuItem.Checked)
            {
                engUpСyrLowDigSymb(dlina, ref iPass);
            }else if(lowerCaseToolStripMenuItem.Checked && lowerCaseToolStripMenuItem1.Checked && digitToolStripMenuItem.Checked && symbolToolStripMenuItem.Checked)
            {
                engLowСyrLowDigSymb(dlina, ref iPass);
            }else if(bothToolStripMenuItem2.Checked && !bothToolStripMenuItem1.Checked && !upperCaseToolStripMenuItem.Checked && !lowerCaseToolStripMenuItem.Checked && !digitToolStripMenuItem.Checked && !symbolToolStripMenuItem.Checked)
            {
                cyrillicBoth(dlina, ref iPass);
            }else if(upperCaseToolStripMenuItem1.Checked && !bothToolStripMenuItem1.Checked && !upperCaseToolStripMenuItem.Checked && !lowerCaseToolStripMenuItem.Checked && !digitToolStripMenuItem.Checked && !symbolToolStripMenuItem.Checked)
            {
                cyrillicUpper(dlina, ref iPass);
            }else if(lowerCaseToolStripMenuItem1.Checked && !bothToolStripMenuItem1.Checked && !upperCaseToolStripMenuItem.Checked && !lowerCaseToolStripMenuItem.Checked && !digitToolStripMenuItem.Checked && !symbolToolStripMenuItem.Checked)
            {
                cyrillicLower(dlina, ref iPass);
            }else if(bothToolStripMenuItem2.Checked && digitToolStripMenuItem.Checked && !bothToolStripMenuItem1.Checked && !upperCaseToolStripMenuItem.Checked && !lowerCaseToolStripMenuItem.Checked && !symbolToolStripMenuItem.Checked)
            {
                cyrBothDig(dlina, ref iPass);
            }else if(upperCaseToolStripMenuItem1.Checked && digitToolStripMenuItem.Checked && !bothToolStripMenuItem1.Checked && !upperCaseToolStripMenuItem.Checked && !lowerCaseToolStripMenuItem.Checked && !symbolToolStripMenuItem.Checked)
            {
                cyrUpDig(dlina, ref iPass);
            }else if(lowerCaseToolStripMenuItem1.Checked && digitToolStripMenuItem.Checked && !bothToolStripMenuItem1.Checked && !upperCaseToolStripMenuItem.Checked && !lowerCaseToolStripMenuItem.Checked && !symbolToolStripMenuItem.Checked)
            {
                cyrLowDig(dlina, ref iPass);
            }else if(bothToolStripMenuItem2.Checked && symbolToolStripMenuItem.Checked && !bothToolStripMenuItem1.Checked && !upperCaseToolStripMenuItem.Checked && !lowerCaseToolStripMenuItem.Checked && !digitToolStripMenuItem.Checked)
            {
                cyrBothSymb(dlina, ref iPass);
            }else if(upperCaseToolStripMenuItem1.Checked && symbolToolStripMenuItem.Checked && !bothToolStripMenuItem1.Checked && !upperCaseToolStripMenuItem.Checked && !lowerCaseToolStripMenuItem.Checked && !digitToolStripMenuItem.Checked)
            {
                cyrUpSymb(dlina, ref iPass);
            }else if(lowerCaseToolStripMenuItem1.Checked && symbolToolStripMenuItem.Checked && !bothToolStripMenuItem1.Checked && !upperCaseToolStripMenuItem.Checked && !lowerCaseToolStripMenuItem.Checked && !digitToolStripMenuItem.Checked)
            {
                cyrLowSymb(dlina, ref iPass);
            }else if(bothToolStripMenuItem2.Checked && digitToolStripMenuItem.Checked && symbolToolStripMenuItem.Checked && !bothToolStripMenuItem1.Checked && !upperCaseToolStripMenuItem.Checked && !lowerCaseToolStripMenuItem.Checked)
            {
                cyrBothDigSymb(dlina, ref iPass);
            }else if(upperCaseToolStripMenuItem1.Checked && digitToolStripMenuItem.Checked && symbolToolStripMenuItem.Checked && !bothToolStripMenuItem1.Checked && !upperCaseToolStripMenuItem.Checked && !lowerCaseToolStripMenuItem.Checked)
            {
                cyrUpDigSymb(dlina, ref iPass);
            }else if(lowerCaseToolStripMenuItem1.Checked && digitToolStripMenuItem.Checked && symbolToolStripMenuItem.Checked && !bothToolStripMenuItem1.Checked && !upperCaseToolStripMenuItem.Checked && !lowerCaseToolStripMenuItem.Checked)
            {
                cyrLowDigSymb(dlina, ref iPass);
            }else if(digitToolStripMenuItem.Checked && !bothToolStripMenuItem1.Checked && !upperCaseToolStripMenuItem.Checked && !lowerCaseToolStripMenuItem.Checked && !bothToolStripMenuItem2.Checked && !upperCaseToolStripMenuItem1.Checked && !lowerCaseToolStripMenuItem1.Checked && !symbolToolStripMenuItem.Checked)
            {
                dig(dlina, ref iPass);
            }else if(digitToolStripMenuItem.Checked && symbolToolStripMenuItem.Checked && !bothToolStripMenuItem1.Checked && !upperCaseToolStripMenuItem.Checked && !lowerCaseToolStripMenuItem.Checked && !bothToolStripMenuItem2.Checked && !upperCaseToolStripMenuItem1.Checked && !lowerCaseToolStripMenuItem1.Checked)
            {
                digSymb(dlina, ref iPass);
            }else if(symbolToolStripMenuItem.Checked && !bothToolStripMenuItem1.Checked && !upperCaseToolStripMenuItem.Checked && !lowerCaseToolStripMenuItem.Checked && !bothToolStripMenuItem2.Checked && !upperCaseToolStripMenuItem1.Checked && !lowerCaseToolStripMenuItem1.Checked && !digitToolStripMenuItem.Checked)
            {
                symbol(dlina, ref iPass);
            }else if(bothToolStripMenuItem1.Checked && digitToolStripMenuItem.Checked && symbolToolStripMenuItem.Checked && !bothToolStripMenuItem2.Checked && !upperCaseToolStripMenuItem1.Checked && !lowerCaseToolStripMenuItem1.Checked)
            {
                allIn(dlina, ref iPass);
            }else if(upperCaseToolStripMenuItem.Checked && digitToolStripMenuItem.Checked && symbolToolStripMenuItem.Checked && !bothToolStripMenuItem2.Checked && !upperCaseToolStripMenuItem1.Checked && !lowerCaseToolStripMenuItem1.Checked)
            {
                engUpDigSymb(dlina, ref iPass);
            }else if(lowerCaseToolStripMenuItem1.Checked && digitToolStripMenuItem.Checked && symbolToolStripMenuItem.Checked && !bothToolStripMenuItem2.Checked && !upperCaseToolStripMenuItem1.Checked && !lowerCaseToolStripMenuItem1.Checked)
            {
                engLowDigSymb(dlina, ref iPass);
            }
        }
    }
}
