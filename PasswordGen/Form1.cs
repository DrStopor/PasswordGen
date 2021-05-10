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
using PasswordGen.buildSymbols;
using PasswordGen.randomize;

namespace PasswordGen
{
    public partial class Form1 : Form
    {
        private bool selectEngLarge = false;
        private bool selectEngSmall = false;
        private bool selectRusLarge = false;
        private bool selectRusSmall = false;
        private bool selectNumber = false;
        private bool selectSymbol = false;
        private bool selectAll = false;
        private bool selectBothEng = false;
        private bool selectBothRus = false;

        private const string nameSelectedEngLarge = "engLarge";
        private const string nameSelectedEngSmall = "ensSmall";
        private const string nameSelectedRusLarge = "rusLarge";
        private const string nameSelectedRusSmall = "rusSmall";
        private const string nameSelectedNumber = "number";
        private const string nameSelectedSymbol = "symbol";

        private string genarateWorker(List<char> readyListChars, int maxLong)
        {
            NumberGenerate rand = new NumberGenerate(readyListChars.Count);
            string result = default;
            for (int i = 0, end = maxLong + 1; i < end; i++)
            {
                int randNumber = rand.GetOne();
                result += readyListChars[randNumber];
            }
            return result;
        }

        private void engBothCheckMenu_Click(object sender, EventArgs e)
        {
            if (engBothCheckMenu.Checked)
            {
                fullCheckMenu.Checked = false;
                engLargeCheckMenu.Checked = false;
                engSmallCheckMenu.Checked = false;
            }

            if (engBothCheckMenu.Checked
                && rusBothCheckMenu.Checked
                && digitCheckMenu.Checked
                && symbolCheckMenu.Checked)
                fullCheckMenu.Checked = true;
            lamerCheckEngBoth();
            checkCheked();
        }

        private void checkBoxMenuSelecting()
        {
            selectEngLarge = engLargeCheckMenu.Checked;
            selectEngSmall = engSmallCheckMenu.Checked;
            selectRusLarge = rusLargeCheckMenu.Checked;
            selectRusSmall = rusSmallCheckMenu.Checked;
            selectNumber = digitCheckMenu.Checked;
            selectSymbol = symbolCheckMenu.Checked;
            selectAll = checkBoxCollision(selectEngLarge, selectEngSmall, selectRusLarge, selectRusSmall, selectNumber, selectSymbol);
            selectBothEng = checkBoxCollision(selectEngLarge, selectEngSmall);
            selectBothRus = checkBoxCollision(selectRusLarge, selectRusSmall);

            if (selectAll)
            {
                engSmallCheckMenu.Checked = !selectEngLarge;
                rusLargeCheckMenu.Checked = !selectEngSmall;
                engLargeCheckMenu.Checked = !selectRusLarge;
                rusSmallCheckMenu.Checked = !selectRusSmall;
                digitCheckMenu.Checked = !selectNumber;
                symbolCheckMenu.Checked = !selectSymbol;
                rusBothCheckMenu.Checked = true;
                engBothCheckMenu.Checked = true;
            }

            if (selectBothEng || engBothCheckMenu.Checked)
            {
                engLargeCheckMenu.Checked = !selectEngLarge;
                engSmallCheckMenu.Checked = !selectEngSmall;
            }

            if (selectBothRus || rusBothCheckMenu.Checked)
            {
                rusLargeCheckMenu.Checked = !selectRusLarge;
                rusSmallCheckMenu.Checked = !selectRusSmall;
            }
        }

        private bool checkBoxCollision(bool one, bool two, bool three, bool four, bool five, bool six)
        {
            return (one && two && three && four && five && six);
        }
        private bool checkBoxCollision(bool one, bool two)
        {
            return one && two;
        }

        private Array createListLanguage()
        {
            List<string> result = new List<string>();

            if (selectAll)
            {
                addAllNameToList(result);
            }
            else
            {
                if (selectBothEng)
                {
                    result.Add(nameSelectedEngLarge);
                    result.Add(nameSelectedEngSmall);
                }
                else
                {
                    addOneNameEng(result);
                }

                if (selectBothRus)
                {
                    result.Add(nameSelectedRusLarge);
                    result.Add(nameSelectedRusSmall);
                }
                else
                {
                    addOneNameRus(result);
                }

                if (selectNumber)
                    result.Add(nameSelectedNumber);

                if (selectSymbol)
                    result.Add(nameSelectedSymbol);
            }
            return result.ToArray();
        }

        private void addOneNameRus(List<string> result)
        {
            if (selectRusLarge)
                result.Add(nameSelectedRusLarge);

            if (selectRusSmall)
                result.Add(nameSelectedRusSmall);
        }

        private void addOneNameEng(List<string> result)
        {
            if (selectEngLarge)
                result.Add(nameSelectedEngLarge);

            if (selectEngSmall)
                result.Add(nameSelectedEngSmall);
        }

        private static void addAllNameToList(List<string> result)
        {
            result.Add(nameSelectedEngLarge);
            result.Add(nameSelectedEngSmall);
            result.Add(nameSelectedRusLarge);
            result.Add(nameSelectedRusSmall);
            result.Add(nameSelectedNumber);
            result.Add(nameSelectedSymbol);
        }

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
            checkBoxMenuSelecting();
            if (textBox2.TextLength < 1)
            {
                setAutoSave.Checked = false;
            }

            string[] arrayAddedSymbols = (string[])createListLanguage();
            int lengthPass = int.Parse(setLengthString.Text);
            string iPass = "";
            var objectSymbols = new BuildingSymbols(arrayAddedSymbols);
            var tmp = objectSymbols.GetListSetSymbols();
            iPass = genarateWorker(tmp, lengthPass);

            richTextBox1.Clear();

            //int dlina = int.Parse(setLengthString.Text);

            

            //passwordHashing(ref iPass, dlina);

            richTextBox1.SelectedText = iPass;

            if (setAutoSave.Checked && !textBox2.ReadOnly)
            {
                string imaja = textBox2.Text + ".txt";
                File.AppendAllText(imaja, Environment.NewLine + iPass + Environment.NewLine);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (setAutoSave.Checked)
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
                else if (change == 2)
                {
                    iPass += (char)digChar();
                }
                else
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
            for (int i = 0; i < dlina; i++)
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
            if (engBothCheckMenu.Checked && rusBothCheckMenu.Checked && digitCheckMenu.Checked && symbolCheckMenu.Checked)
            {
                fullCheckMenu.Checked = true;
                engBothCheckMenu.Checked = false;
                rusBothCheckMenu.Checked = false;
                digitCheckMenu.Checked = false;
                symbolCheckMenu.Checked = false;
            }
        }

        /// <summary>
        /// проверка на ошибочное отключение всех наборов, кнопка "все"
        /// </summary>
        private void lamerCheckAll()
        {
            if (!fullCheckMenu.Checked && !engBothCheckMenu.Checked && !rusBothCheckMenu.Checked && !engLargeCheckMenu.Checked && !rusLargeCheckMenu.Checked & !engSmallCheckMenu.Checked && !rusSmallCheckMenu.Checked && !digitCheckMenu.Checked && !symbolCheckMenu.Checked)
                fullCheckMenu.Checked = true;
        }

        /// <summary>
        /// проверка на ошибочное отключение всех наборов, кнопка "англ - все"
        /// </summary>
        private void lamerCheckEngBoth()
        {
            if (!fullCheckMenu.Checked && !engBothCheckMenu.Checked && !rusBothCheckMenu.Checked && !engLargeCheckMenu.Checked && !rusLargeCheckMenu.Checked & !engSmallCheckMenu.Checked && !rusSmallCheckMenu.Checked && !digitCheckMenu.Checked && !symbolCheckMenu.Checked)
                engBothCheckMenu.Checked = true;
        }

        /// <summary>
        /// проверка на ошибочное отключение всех наборов, кнопка "кирил - все"
        /// </summary>
        private void lamerCheckCyrBoth()
        {
            if (!fullCheckMenu.Checked && !engBothCheckMenu.Checked && !rusBothCheckMenu.Checked && !engLargeCheckMenu.Checked && !rusLargeCheckMenu.Checked & !engSmallCheckMenu.Checked && !rusSmallCheckMenu.Checked && !digitCheckMenu.Checked && !symbolCheckMenu.Checked)
                rusBothCheckMenu.Checked = true;
        }

        /// <summary>
        /// проверка на ошибочное отключение всех наборов, кнопка "кирил - верх"
        /// </summary>
        private void lamerCheckCyrUp()
        {
            if (!fullCheckMenu.Checked && !engBothCheckMenu.Checked && !rusBothCheckMenu.Checked && !engLargeCheckMenu.Checked && !rusLargeCheckMenu.Checked & !engSmallCheckMenu.Checked && !rusSmallCheckMenu.Checked && !digitCheckMenu.Checked && !symbolCheckMenu.Checked)
                rusLargeCheckMenu.Checked = true;
        }

        /// <summary>
        /// проверка на ошибочное отключение всех наборов, кнопка "кирил - низ"
        /// </summary>
        private void lamerCheckCyrLow()
        {
            if (!fullCheckMenu.Checked && !engBothCheckMenu.Checked && !rusBothCheckMenu.Checked && !engLargeCheckMenu.Checked && !rusLargeCheckMenu.Checked & !engSmallCheckMenu.Checked && !rusSmallCheckMenu.Checked && !digitCheckMenu.Checked && !symbolCheckMenu.Checked)
                rusSmallCheckMenu.Checked = true;
        }

        /// <summary>
        /// проверка на ошибочное отключение всех наборов, кнопка "англ - верх"
        /// </summary>
        private void lamerCheckEngUp()
        {
            if (!fullCheckMenu.Checked && !engBothCheckMenu.Checked && !rusBothCheckMenu.Checked && !engLargeCheckMenu.Checked && !rusLargeCheckMenu.Checked & !engSmallCheckMenu.Checked && !rusSmallCheckMenu.Checked && !digitCheckMenu.Checked && !symbolCheckMenu.Checked)
                engLargeCheckMenu.Checked = true;
        }

        /// <summary>
        /// проверка на ошибочное отключение всех наборов, кнопка "англ - низ"
        /// </summary>
        private void lamerCheckEngLow()
        {
            if (!fullCheckMenu.Checked && !engBothCheckMenu.Checked && !rusBothCheckMenu.Checked && !engLargeCheckMenu.Checked && !rusLargeCheckMenu.Checked & !engSmallCheckMenu.Checked && !rusSmallCheckMenu.Checked && !digitCheckMenu.Checked && !symbolCheckMenu.Checked)
                engSmallCheckMenu.Checked = true;
        }

        /// <summary>
        /// проверка на ошибочное отключение всех наборов, кнопка "цифры"
        /// </summary>
        private void lamerCheckDig()
        {
            if (!fullCheckMenu.Checked && !engBothCheckMenu.Checked && !rusBothCheckMenu.Checked && !engLargeCheckMenu.Checked && !rusLargeCheckMenu.Checked & !engSmallCheckMenu.Checked && !rusSmallCheckMenu.Checked && !digitCheckMenu.Checked && !symbolCheckMenu.Checked)
                digitCheckMenu.Checked = true;
        }

        /// <summary>
        /// проверка на ошибочное отключение всех наборов, кнопка "символы"
        /// </summary>
        private void lamerCheckSymb()
        {
            if (!fullCheckMenu.Checked && !engBothCheckMenu.Checked && !rusBothCheckMenu.Checked && !engLargeCheckMenu.Checked && !rusLargeCheckMenu.Checked & !engSmallCheckMenu.Checked && !rusSmallCheckMenu.Checked && !digitCheckMenu.Checked && !symbolCheckMenu.Checked)
                symbolCheckMenu.Checked = true;
        }

        /// <summary>
        /// кнопка "все наборы"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bothToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fullCheckMenu.Checked)
            {
                engBothCheckMenu.Checked = false;
                rusBothCheckMenu.Checked = false;
                engLargeCheckMenu.Checked = false;
                rusLargeCheckMenu.Checked = false;
                engSmallCheckMenu.Checked = false;
                rusSmallCheckMenu.Checked = false;
                digitCheckMenu.Checked = false;
                symbolCheckMenu.Checked = false;
            }
            else if (engBothCheckMenu.Checked || rusBothCheckMenu.Checked || engLargeCheckMenu.Checked || rusLargeCheckMenu.Checked || engSmallCheckMenu.Checked || rusSmallCheckMenu.Checked || digitCheckMenu.Checked || symbolCheckMenu.Checked)
            {
                fullCheckMenu.Checked = false;
            }

            lamerCheckAll();

            checkCheked();
        }

        /// <summary>
        /// кнопка "англ - верх"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void upperCaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (engLargeCheckMenu.Checked)
            {
                fullCheckMenu.Checked = false;
                engBothCheckMenu.Checked = false;
                engSmallCheckMenu.Checked = false;
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
            if (engSmallCheckMenu.Checked)
            {
                fullCheckMenu.Checked = false;
                engLargeCheckMenu.Checked = false;
                engBothCheckMenu.Checked = false;
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
            if (rusBothCheckMenu.Checked)
            {
                fullCheckMenu.Checked = false;
                rusLargeCheckMenu.Checked = false;
                rusSmallCheckMenu.Checked = false;
            }
            else if (engBothCheckMenu.Checked && rusBothCheckMenu.Checked && digitCheckMenu.Checked && symbolCheckMenu.Checked)
                fullCheckMenu.Checked = true;
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
            if (rusLargeCheckMenu.Checked)
            {
                fullCheckMenu.Checked = false;
                rusBothCheckMenu.Checked = false;
                rusSmallCheckMenu.Checked = false;
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
            if (rusSmallCheckMenu.Checked)
            {
                fullCheckMenu.Checked = false;
                rusBothCheckMenu.Checked = false;
                rusLargeCheckMenu.Checked = false;
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
            if (digitCheckMenu.Checked)
            {
                fullCheckMenu.Checked = false;
            }
            else if (engBothCheckMenu.Checked && rusBothCheckMenu.Checked && digitCheckMenu.Checked && symbolCheckMenu.Checked)
                fullCheckMenu.Checked = true;
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
            if (symbolCheckMenu.Checked)
            {
                fullCheckMenu.Checked = false;
            }
            else if (engBothCheckMenu.Checked && rusBothCheckMenu.Checked && digitCheckMenu.Checked && symbolCheckMenu.Checked)
                fullCheckMenu.Checked = true;
            lamerCheckSymb();
            checkCheked();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkBoxMenuSelecting();
        }
    }
}
