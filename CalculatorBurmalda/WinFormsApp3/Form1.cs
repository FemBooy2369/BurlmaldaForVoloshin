using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SimpleSetup();
        }

        private void SimpleSetup()
        {
            this.Text = "Бурмалдачный Калькулятор";
            this.Size = new Size(420, 520);
            this.BackColor = Color.FromArgb(30, 30, 30);

            this.Controls.Add(new Label
            {
                Text = "БУРМАЛДАЧНЫЙ КАЛЬКУЛЯТОР",
                Font = new Font("Arial", 15, FontStyle.Bold),
                ForeColor = Color.Cyan,
                Location = new Point(45, 15),
                AutoSize = true
            });

            TextBox display = new TextBox
            {
                Name = "display",
                Text = "0",
                Font = new Font("Consolas", 24, FontStyle.Bold),
                BackColor = Color.Black,
                ForeColor = Color.Cyan,
                TextAlign = HorizontalAlignment.Right,
                Location = new Point(35, 65),
                Size = new Size(340, 55),
                ReadOnly = true
            };
            this.Controls.Add(display);

            GroupBox gb = new GroupBox
            {
                Text = "Операция",
                ForeColor = Color.Cyan,
                BackColor = Color.FromArgb(40, 40, 40),
                Location = new Point(35, 135),
                Size = new Size(340, 70)
            };
            this.Controls.Add(gb);

            RadioButton rPlus = new RadioButton
            {
                Text = "+",
                Checked = true,
                Location = new Point(30, 28),
                ForeColor = Color.White,
                Font = new Font("Arial", 14, FontStyle.Bold),
                AutoSize = true
            };
            RadioButton rMinus = new RadioButton
            {
                Text = "-",
                Location = new Point(100, 28),
                ForeColor = Color.White,
                Font = new Font("Arial", 14, FontStyle.Bold),
                AutoSize = true
            };
            RadioButton rMul = new RadioButton
            {
                Text = "×",
                Location = new Point(170, 28),
                ForeColor = Color.White,
                Font = new Font("Arial", 14, FontStyle.Bold),
                AutoSize = true
            };
            RadioButton rDiv = new RadioButton
            {
                Text = "÷",
                Location = new Point(240, 28),
                ForeColor = Color.White,
                Font = new Font("Arial", 14, FontStyle.Bold),
                AutoSize = true
            };

            gb.Controls.Add(rPlus);
            gb.Controls.Add(rMinus);
            gb.Controls.Add(rMul);
            gb.Controls.Add(rDiv);

            Button calc = new Button
            {
                Text = "РАСЧИТАТЬ",
                BackColor = Color.LimeGreen,
                ForeColor = Color.Black,
                Font = new Font("Arial", 13, FontStyle.Bold),
                Location = new Point(35, 220),
                Size = new Size(340, 55)
            };
            calc.Click += Calculate;
            this.Controls.Add(calc);

            Button clear = new Button
            {
                Text = "СБРОСИТЬ",
                BackColor = Color.OrangeRed,
                ForeColor = Color.White,
                Font = new Font("Arial", 12, FontStyle.Bold),
                Location = new Point(35, 285),
                Size = new Size(340, 45)
            };
            clear.Click += ClearAll;
            this.Controls.Add(clear);

            TextBox num1 = new TextBox
            {
                Name = "num1",
                Text = "0",
                Location = new Point(35, 370),
                Size = new Size(150, 40),
                TextAlign = HorizontalAlignment.Center,
                BackColor = Color.FromArgb(50, 50, 50),
                ForeColor = Color.White
            };

            TextBox num2 = new TextBox
            {
                Name = "num2",
                Text = "0",
                Location = new Point(225, 370),
                Size = new Size(150, 40),
                TextAlign = HorizontalAlignment.Center,
                BackColor = Color.FromArgb(50, 50, 50),
                ForeColor = Color.White
            };

            this.Controls.Add(num1);
            this.Controls.Add(num2);

            this.Controls.Add(new Label
            {
                Text = "Число 1",
                ForeColor = Color.Cyan,
                Location = new Point(35, 350),
                AutoSize = true
            });

            this.Controls.Add(new Label
            {
                Text = "Число 2",
                ForeColor = Color.Cyan,
                Location = new Point(225, 350),
                AutoSize = true
            });
        }

        private void Calculate(object sender, EventArgs e)
        {
            TextBox display = (TextBox)this.Controls["display"];
            TextBox n1 = (TextBox)this.Controls["num1"];
            TextBox n2 = (TextBox)this.Controls["num2"];

            if (!double.TryParse(n1.Text, out double a) || !double.TryParse(n2.Text, out double b))
            {
                MessageBox.Show("Введите оба числа!");
                return;
            }

            char op = '+';
            GroupBox gb = (GroupBox)this.Controls[2]; 
            foreach (RadioButton r in gb.Controls)
            {
                if (r.Checked)
                {
                    op = r.Text[0];
                    break;
                }
            }

            double res = 0;
            if (op == '+') res = a + b;
            else if (op == '-') res = a - b;
            else if (op == '×') res = a * b;
            else if (op == '÷')
            {
                if (b == 0)
                {
                    MessageBox.Show("Деление на ноль запрещено!");
                    return;
                }
                res = a / b;
            }

            display.Text = res.ToString();

            if (res == 67)
            {
                MakeSixSeven();
            }
        }

        private void MakeSixSeven()
        {
            foreach (Control c in this.Controls)
            {
                if (c is Button btn)
                {
                    btn.Text = "six seven";
                    btn.BackColor = Color.Gold;
                }
            }
            ((TextBox)this.Controls["display"]).Text = "six seven";
            ((TextBox)this.Controls["display"]).ForeColor = Color.Gold;
        }

        private void ClearAll(object sender, EventArgs e)
        {
            ((TextBox)this.Controls["display"]).Text = "0";
            ((TextBox)this.Controls["num1"]).Text = "0";
            ((TextBox)this.Controls["num2"]).Text = "0";
            ((TextBox)this.Controls["display"]).ForeColor = Color.Cyan;
        }
    }
}