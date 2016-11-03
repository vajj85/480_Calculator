using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {

    

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            textBox1.Text = textBox1.Text + button.Text;
        }

        private void click_equals(object sender, EventArgs e)
        {
        try { 
            //postfix = textBox1.Text.Trim();
            string[] ans = textBox1.Text.Split(' ');
            Stack<double> eval = new Stack<double>();
            for (int x = 0; x < ans.Length; x++)
            {
                if ("*+%/-^".Contains(ans[x]))
                {
                    double temp1;
                    double  temp2;

                    switch (ans[x])
                    {
                        case ("*"):
                            eval.Push(eval.Pop() * eval.Pop());
                            break;
                        case "-":
                            temp1 = eval.Pop();
                            temp2 = eval.Pop();
                            eval.Push(temp2 - temp1);
                            break;
                        case "%":
                            temp1 = eval.Pop();
                            temp2 = eval.Pop();
                            eval.Push(temp2 % temp1);
                            break;
                        case "+":
                            eval.Push(eval.Pop() + eval.Pop());
                            break;
                        case "/":
                            temp1 = eval.Pop();
                            temp2 = eval.Pop();
                            eval.Push(temp2 / temp1);
                            break;
                        case "^":
                            temp1 = eval.Pop();
                            temp2 = eval.Pop();
                         
                            eval.Push(Math.Pow(temp2, temp1));
                            break;
                    }

                }
                else
                    eval.Push(Convert.ToInt32(ans[x]));
            }

            double answer = eval.Pop();
            String final = answer.ToString();
            textBox2.Text = final;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Invalid operations, please try again");
            }
        }

    



        private void click_clear(object sender, EventArgs e)
        {
            textBox1.Text = String.Empty;
        }

        private void click_back(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
