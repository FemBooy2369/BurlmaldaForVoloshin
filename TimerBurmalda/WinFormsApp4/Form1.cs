using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        private int timeLeft = 0;
        private System.Windows.Forms.Timer timer;   

        public Form1()
        {
            // InitializeComponent();  
            SetupTimer();
        }

        private void SetupTimer()
        {
            this.Text = "Бурмалдачный Таймер";
            this.Size = new Size(420, 480);
            this.BackColor = Color.FromArgb(30, 30, 30);
            this.StartPosition = FormStartPosition.CenterScreen;

            this.Controls.Add(new Label
            {
                Text = "БУРМАЛДАЧНЫЙ ТАЙМЕР",
                Font = new Font("Arial", 16, FontStyle.Bold),
                ForeColor = Color.Cyan,
                Location = new Point(60, 20),
                AutoSize = true
            });

            Label display = new Label
            {
                Name = "display",
                Text = "00:00:00:00",
                Font = new Font("Consolas", 32, FontStyle.Bold),
                ForeColor = Color.Cyan,
                BackColor = Color.FromArgb(20, 20, 20),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(50, 80),
                Size = new Size(320, 80),
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(display);

            this.Controls.Add(new Label
            {
                Text = "Время в секундах:",
                ForeColor = Color.Cyan,
                Location = new Point(50, 180),
                AutoSize = true
            });

            TextBox inputTime = new TextBox
            {
                Name = "inputTime",
                Text = "60",
                Font = new Font("Consolas", 18),
                BackColor = Color.FromArgb(50, 50, 50),
                ForeColor = Color.White,
                TextAlign = HorizontalAlignment.Center,
                Location = new Point(50, 210),
                Size = new Size(320, 45)
            };
            this.Controls.Add(inputTime);

            Button btnStart = new Button
            {
                Text = "ЗАПУСТИТЬ",
                BackColor = Color.LimeGreen,
                ForeColor = Color.Black,
                Font = new Font("Arial", 12, FontStyle.Bold),
                Location = new Point(50, 280),
                Size = new Size(140, 50)
            };
            btnStart.Click += BtnStart_Click;
            this.Controls.Add(btnStart);

            Button btnPause = new Button
            {
                Text = "ПАУЗА",
                BackColor = Color.Orange,
                ForeColor = Color.Black,
                Font = new Font("Arial", 12, FontStyle.Bold),
                Location = new Point(210, 280),
                Size = new Size(140, 50)
            };
            btnPause.Click += BtnPause_Click;
            this.Controls.Add(btnPause);

            Button btnReset = new Button
            {
                Text = "СБРОСИТЬ",
                BackColor = Color.OrangeRed,
                ForeColor = Color.White,
                Font = new Font("Arial", 12, FontStyle.Bold),
                Location = new Point(50, 345),
                Size = new Size(320, 45)
            };
            btnReset.Click += BtnReset_Click;
            this.Controls.Add(btnReset);

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 10;
            timer.Tick += Timer_Tick;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            TextBox input = (TextBox)this.Controls["inputTime"];

            if (timeLeft == 0)
            {
                if (!int.TryParse(input.Text, out int seconds) || seconds <= 0)
                {
                    MessageBox.Show("Введите корректное время в секундах (больше 0)!");
                    return;
                }
                timeLeft = seconds * 1000;
            }

            timer.Start();
        }

        private void BtnPause_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            timer.Stop();
            timeLeft = 0;
            ((Label)this.Controls["display"]).Text = "00:00:00:00";
            ((TextBox)this.Controls["inputTime"]).Text = "60";
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (timeLeft <= 0)
            {
                timer.Stop();
                MessageBox.Show("Время вышло! 🔔", "Таймер", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            timeLeft -= 10;

            int totalMs = timeLeft;
            int hours = totalMs / 3600000;
            int minutes = (totalMs % 3600000) / 60000;
            int seconds = (totalMs % 60000) / 1000;
            int ms = (totalMs % 1000) / 10;

            ((Label)this.Controls["display"]).Text =
                $"{hours:00}:{minutes:00}:{seconds:00}:{ms:00}";
        }
    }
}