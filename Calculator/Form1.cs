using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        string expression = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonOne_Click(object sender, EventArgs e)
        {
            setNum("1");
        }

        private void buttonTwo_Click(object sender, EventArgs e)
        {
            setNum("2");
        }

        private void buttonThree_Click(object sender, EventArgs e)
        {
            setNum("3");
        }

        private void buttonFour_Click(object sender, EventArgs e)
        {
            setNum("4");
        }

        private void buttonFive_Click(object sender, EventArgs e)
        {
            setNum("5");
        }

        private void buttonSix_Click(object sender, EventArgs e)
        {
            setNum("6");
        }

        private void buttonSeven_Click(object sender, EventArgs e)
        {
            setNum("7");
        }

        private void buttonEight_Click(object sender, EventArgs e)
        {
            setNum("8");
        }

        private void buttonNine_Click(object sender, EventArgs e)
        {
            setNum("9");
        }

        private void buttonZero_Click(object sender, EventArgs e)
        {
            setNum("0");
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            expression = richTextBox1.Text;
            label1.Visible = false;
        }

        private void buttonPlusMinus_Click(object sender, EventArgs e)
        {
            label1.Visible = !label1.Visible;
        }

        
        private void buttonMinus_Click(object sender, EventArgs e)
        {
            checkExpression();
            setSign("-");
        }
        private void buttonDivide_Click(object sender, EventArgs e)
        {
            checkExpression();
            setSign("/");
        }
        private void buttonSum_Click(object sender, EventArgs e)
        {
            checkExpression();
            setSign("+");
        }   
        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            checkExpression();
            setSign("*");
        }
       

        private void buttonEquals_Click(object sender, EventArgs e)
        {
            string result;
            if (expression != "")
            {
                if (!int.TryParse(expression[expression.Length - 1].ToString(), out var number))
                {
                    expression = expression.Substring(0, expression.Length - 1);
                }
                if (label1.Visible)
                {
                    result = new MyCalc().Calc("-" + expression);
                }
                else
                {
                    result = new MyCalc().Calc(expression);
                }
                if (int.TryParse(result, out var num))
                {
                    checkNum(int.Parse(result));
                }
                else
                {
                    richTextBox1.Text = result;
                }
            }
        }

        private void checkExpression()
        {
            string result;
            Regex regex = new Regex(@"[+, -]?\d+[+, \-, *, /]\d+");
            if (regex.IsMatch(expression))
            {
                if (label1.Visible)
                {
                    result = new MyCalc().Calc("-" + expression);
                }
                else
                {
                    result = new MyCalc().Calc(expression);
                }
                if (int.TryParse(result, out var num))
                {
                    checkNum(int.Parse(result));
                }
                else
                {
                    richTextBox1.Text = result;
                }
            }
        }

        private void checkNum(int result)
        {
            if (result < 0)
            {
                richTextBox1.Text = (result * -1).ToString();
                label1.Visible = true;
                expression = "-" + richTextBox1.Text;
            }
            else
            {
                richTextBox1.Text = result.ToString();
                label1.Visible = false;
                expression = richTextBox1.Text;
            }
        }

        private void setNum(string num)
        {
            if (richTextBox1.Text.Length <= 8)
            {
                if (expression != "" && int.TryParse(expression[expression.Length - 1].ToString(), out var number))
                {
                    richTextBox1.Text += num;
                }
                else
                {
                    richTextBox1.Text = num;
                }
                expression += num;
            }
        }

        private void setSign(string sign)
        {
            if (expression == "" && sign == "-")
            {
                label1.Visible = !label1.Visible;
            }
            else
            {
                if (expression != "")
                {
                    if (int.TryParse(expression[expression.Length - 1].ToString(), out var number))
                    {
                        expression += sign;
                    }
                    else
                    {
                        expression = expression.Substring(0, expression.Length - 1).Insert(expression.Length - 1, sign);
                    }
                }
            }
        }
    }
}
