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

            string[] arr = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "j", "i", "k", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "!", "@", "#", "$", "%", "^", "&", "*", "-", "_", "=", "+", "/", "\\", "?", "~" };

            Random rnd = new Random();

            for (int i = 0; i < dlina; i++)
            {
                iPass = iPass + arr[rnd.Next(0, 76)];
                Thread.Sleep(1);
            }

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
    }
}
