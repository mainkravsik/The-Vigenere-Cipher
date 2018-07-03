using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace protect_inf_LR1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            N = characters.Length;
        }
        char[] characters = new char[] { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и',
                                                        'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с',
                                                        'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ь', 'ы', 'ъ',
                                                        'э', 'ю', 'я', 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И',
                                                        'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С', 
                                                        'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь', 'Ы', 'Ъ',
                                                        'Э', 'Ю', 'Я', ' ', '.', ',', '?', '!', '1', '2', '3', '4', '5', '6', '7',
                                                        '8', '9', '0', 'A', 'E', 'I', 'O', 'U', 'Y', 'B', 'C', 'D', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'V', 'W', 'X', 'Y', 'Z',
                                        'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p', 'a', 's', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'z', 'x', 'c', 'v', 'b', 'n', 'm'};

        private int N; //длина алфавита

        //Основной цикл шифровки
        private void buttonEncrypt_Click(object sender, EventArgs e)
        {
            if (radioButtonChezar.Checked)
            {
                if (textBoxKeyWord.Text.Length > 0 )
                {
                    int key = 1;
                string s = textBox2.Text;
                key = Convert.ToInt32(textBoxKeyWord.Text);
                textBox1.Text = Encodeche(s,key);
                }
                else
                    MessageBox.Show("Введите ключевое слово!");
            }
            if (radioButtonVizhener.Checked)
            {
                if (textBoxKeyWord.Text.Length > 0)
                {
                    string s = textBox2.Text;
                    textBox1.Text = Encode(s, Convert.ToString(textBoxKeyWord.Text));
                }
                else
                     MessageBox.Show("Введите ключевое слово!");
            }


        }

        //Основной цикл расшифровки
        private void buttonDecipher_Click(object sender, EventArgs e)
        {
            if (radioButtonChezar.Checked)
            {
                if (textBoxKeyWord.Text.Length > 0)
                {
                    int key = 1;
                    string s = textBox1.Text;
                    key = Convert.ToInt32(textBoxKeyWord.Text);
                    textBox2.Text = Decodeche(s, key);
                }
                else
                    MessageBox.Show("Введите ключевое слово!");
            }
            if (radioButtonVizhener.Checked)
            {
                if (textBoxKeyWord.Text.Length > 0)
                {
                    string s = textBox1.Text;
                    textBox2.Text = Decode(s, Convert.ToString(textBoxKeyWord.Text));
                }
                else
                    MessageBox.Show("Введите ключевое слово!");
            }
        }

        //Метод шифрования Виженера
        private string Encode(string input, string keyword)
        {
            
            string result = "";

            int keyword_index = 0;

            foreach (char symbol in input)
            {
                int c = (Array.IndexOf(characters, symbol) +
                    Array.IndexOf(characters, keyword[keyword_index])) % N;

                result += characters[c];

                keyword_index++;

                if ((keyword_index + 1) == keyword.Length)
                    keyword_index = 0;
            }

            return result;
        }

        //Метод расшифрования Виженера 
        private string Decode(string input, string keyword)
        {
            
            string result = "";

            int keyword_index = 0;

            foreach (char symbol in input)
            {
                int p = (Array.IndexOf(characters, symbol) + N -
                    Array.IndexOf(characters, keyword[keyword_index])) % N;

                result += characters[p];

                keyword_index++;

                if ((keyword_index + 1) == keyword.Length)
                    keyword_index = 0;
            }

            return result;
        }

        //Метод шифрования Цезаря
        private string Encodeche(string input, int keyword)
        {
            string result = "";

            int p = 0;

            foreach (char symbol in input)
            {
                for (int i = 0;i< N; i++)
                {
                    if(symbol==characters[i])
                    {
                        p = i + keyword;
                        while (p >= N)
                            p -= N;
                    }
                }
                result += characters[p];
            }

            return result;
        }

        //Метод расшифрования Цезаря
        private string Decodeche(string input, int keyword)
        {
            string result = "";

            int p = 0;

            foreach (char symbol in input)
            {
                for (int i = 0; i < N; i++)
                {
                    if (symbol == characters[i])
                    {
                        p = i - keyword;
                        while (p < 0)
                            p += N;
                    }
                }
                result += characters[p];
            }

            return result;
        }

        private int mousex = 0; private int mousey = 0;

        private void pictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            mousex = e.X; mousey = e.Y;
        }

        private void pictureBox3_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.Location = new System.Drawing.Point(this.Location.X + (e.X - mousex), this.Location.Y + (e.Y - mousey));

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char word = e.KeyChar;
            for (int i = 0; i < N; i++)
            {
                if (!Char.IsDigit(word) && !Char.IsLetter (word) && word != 0x08 && word != 0x17 && word != ' ' && word != '.' && word != ',' && word != '?' && word != '!')
                {
                    e.Handled = true;
                }
            }
            if (word == 13)
            {
                buttonEncrypt_Click(this, EventArgs.Empty);

            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char word = e.KeyChar;
            for (int i = 0; i < N; i++)
            {
                if (!Char.IsDigit(word) && !Char.IsLetter(word) && word != 0x08 && word != 0x17 && word != ' ' && word != '.' && word != ',' && word != '?' && word != '!')
                {
                    e.Handled = true;
                }
            }
            if (word == 13)
            {
                buttonEncrypt_Click(this, EventArgs.Empty);

            }
        }

        private void textBoxKeyWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            char word = e.KeyChar;
            if (radioButtonChezar.Checked)
            {
                if (!Char.IsDigit(word) && word != 0x08 && word != 0x17)
                {
                    e.Handled = true;
                }
                if (word == 13)
                {
                    buttonEncrypt_Click(this, EventArgs.Empty);

                }
            }
            else if (radioButtonVizhener.Checked)
            {
                if (!Char.IsLetter(word) && word != 0x08 && word != 0x17)
                {
                    e.Handled = true;
                }
                if (word == 13)
                {
                    buttonEncrypt_Click(this, EventArgs.Empty);

                }
            }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.V))
                (sender as TextBox).Paste();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.V))
                (sender as TextBox).Paste();
        }
    }
}