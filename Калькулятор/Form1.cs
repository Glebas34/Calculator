using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Калькулятор
{
    public partial class Калькулятор : Form
    {
        private double left_operand;
        private double right_operand;
        private char operation;
        private double res;
        private bool flag;
        private int pos;
        public Калькулятор()
        {
            InitializeComponent();
            res = 0;
            textBox1.Text = string.Empty;
            textBox1.ReadOnly = true;
            flag = false;
            pos = -1;
        }


        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "0" || textBox1.Text == "")
            {
                textBox1.Text = "1";
                return;
            }
            if (flag && textBox1.Text.EndsWith("0"))
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.TextLength - 1) + "1";
                return;
            }
            textBox1.Text += "1";

        }
        private void add_button_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox1.Text.IndexOf("+", 0, textBox1.Text.Length) < 0 && textBox1.Text.IndexOf("/", 0, textBox1.Text.Length) < 0 && textBox1.Text.IndexOf("*", 0, textBox1.Text.Length) < 0&& flag == false)
            {
                if (textBox1.Text.EndsWith(","))
                {
                    textBox1.Text += "0";
                }
                flag = double.TryParse(textBox1.Text, out left_operand);
                pos = textBox1.Text.Length;
                textBox1.Text += "+";
            }
        }

        private void substract_button_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text += "-";
                return;
            }

            if (pos==-1)
            {
                if (textBox1.Text.EndsWith(","))
                {
                    textBox1.Text += "0";
                }
                flag = double.TryParse(textBox1.Text, out left_operand);
                if (flag)
                {
                    pos = textBox1.Text.Length;
                    textBox1.Text += "-";
                }
                return;
            }
            if (pos == textBox1.TextLength - 1&& textBox1.TextLength>1)
            {
                textBox1.Text += "-";
                return;
            }
            
        }

        private void divide_button_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox1.Text.IndexOf("+", 0, textBox1.Text.Length) < 0 && textBox1.Text.IndexOf("/", 0, textBox1.Text.Length) < 0 && textBox1.Text.IndexOf("*", 0, textBox1.Text.Length) < 0 && flag == false )
            {
                if (textBox1.Text.EndsWith(","))
                {
                    textBox1.Text += "0";
                }
                flag = double.TryParse(textBox1.Text, out left_operand);
                pos = textBox1.Text.Length;
                textBox1.Text += "/";
            }
        }

        private void multiply_button_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0 && textBox1.Text.IndexOf("+", 0, textBox1.Text.Length) < 0 && textBox1.Text.IndexOf("/", 0, textBox1.Text.Length) < 0 && textBox1.Text.IndexOf("*", 0, textBox1.Text.Length) < 0 && flag == false)
            {
                if (textBox1.Text.EndsWith(","))
                {
                    textBox1.Text += "0";
                }
                flag = double.TryParse(textBox1.Text, out left_operand);
                pos = textBox1.Text.Length;
                textBox1.Text += "*";
            }
        }

        public void BinOperation()
        {
            switch (operation)
            {
                case '+': res = left_operand + right_operand; textBox1.Text = res.ToString(); pos = -1; flag = false; break;
                case '-': res = left_operand - right_operand; textBox1.Text = res.ToString(); pos = -1; flag = false; break;
                case '*': res = left_operand * right_operand; textBox1.Text = res.ToString(); pos = -1; flag = false; break;
                case '/': if (right_operand != 0) { res = left_operand / right_operand; textBox1.Text = res.ToString(); pos = -1; flag = false; } else { MessageBox.Show("Деление на ноль!"); return; } break;
            }
        }
        private void equal_button_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.EndsWith(","))
            {
                textBox1.Text += "0";
            }
            if (textBox1.Text.Length > 0)
            {
                
                  if(flag && double.TryParse(textBox1.Text.Substring(pos+1,textBox1.Text.Length-pos-1),out right_operand))
                    {
                        operation = textBox1.Text[pos];
                        BinOperation();
                    return;
                    }
                
                else
                {
                    if (pos == textBox1.TextLength - 1)
                    {
                        left_operand = res;
                        operation = textBox1.Text[pos];
                        right_operand = Convert.ToDouble(textBox1.Text.Substring(0,textBox1.TextLength-1)); 
                        BinOperation();
                    }
                    else
                    {
                        left_operand = Convert.ToDouble(textBox1.Text);
                        BinOperation();

                    }
                }
            }
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length>0)
                textBox1.Text= textBox1.Text.Substring(0, textBox1.Text.Length - 1);
        }

        private void button0_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text += "0";
                return;
            }
            if (!textBox1.Text.EndsWith("0"))
            {
                textBox1.Text += "0";
            }
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "0"||textBox1.Text=="")
            {
                textBox1.Text = "2";
                return;
            }
            if (flag && textBox1.Text.EndsWith("0"))
            {
                textBox1.Text = textBox1.Text.Substring(0,textBox1.TextLength-1)+"2";
                return;
            }
            textBox1.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "0" || textBox1.Text == "")
            {
                textBox1.Text = "3";
                return;
            }
            if (flag && textBox1.Text.EndsWith("0"))
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.TextLength - 1) + "3";
                return;
            }
            textBox1.Text += "3";

        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "0" || textBox1.Text == "")
            {
                textBox1.Text = "4";
                return;
            }
            if (flag && textBox1.Text.EndsWith("0"))
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.TextLength - 1) + "4";
                return;
            }
            textBox1.Text += "4";

        }

        private void button5_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "0" || textBox1.Text == "")
            {
                textBox1.Text = "5";
                return;
            }
            if (flag && textBox1.Text.EndsWith("0"))
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.TextLength - 1) + "5";
                return;
            }
            textBox1.Text += "5";

        }

        private void button6_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "0" || textBox1.Text == "")
            {
                textBox1.Text = "6";
                return;
            }
            if (flag && textBox1.Text.EndsWith("0"))
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.TextLength - 1) + "6";
                return;
            }
            textBox1.Text += "6";

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" || textBox1.Text == "")
            {
                textBox1.Text = "7";
                return;
            }
            if (flag && textBox1.Text.EndsWith("0"))
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.TextLength - 1) + "7";
                return;
            }
            textBox1.Text += "7";

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" || textBox1.Text == "")
            {
                textBox1.Text = "8";
                return;
            }
            if (flag && textBox1.Text.EndsWith("0"))
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.TextLength - 1) + "8";
                return;
            }
            textBox1.Text += "8";
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" || textBox1.Text == "")
            {
                textBox1.Text = "9";
                return;
            }
            if (flag && textBox1.Text.EndsWith("0"))
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.TextLength - 1) + "9";
                return;
            }
            textBox1.Text += "9";
            
        }

        private void clear_button_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            flag = false;
            res = 0;
        }
        private void comma_button_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == ""||pos==textBox1.TextLength-1)
            {
                textBox1.Text += "0,";
                return;
            }
            if (flag)
            {
                if (textBox1.Text.IndexOf(',', pos)==-1)
                {
                    textBox1.Text += ",";
                   
                }
                return;
            }
            if (textBox1.Text != "") {
                if(!textBox1.Text.EndsWith(",")&&textBox1.Text.IndexOf(',')==-1)
                textBox1.Text += ",";
            }
        }
    }
}
