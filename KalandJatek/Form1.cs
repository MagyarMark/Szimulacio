using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KalandJatek
{
    public partial class Form1 : Form
    {
        private Button Exit;
        private Button Start;
        private Label Kszöveg;
        public Form1()
        {
            InitializeComponent();

            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            Image myimage = new Bitmap("hatter2.png");
            this.BackgroundImage = myimage;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Exit = new Button
            {
                Text = "Kilépés",
                Size = new Size(100, 50),
                Location = new Point(800,600),
                BackColor = ColorTranslator.FromHtml("#a17e51"),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup
            };
            Exit.Click += exit_Click;
            Controls.Add(Exit);

            Start = new Button
            {
                Text = "Indulás!",
                Size = new Size(100, 50),
                Location = new Point(950, 600),
                BackColor = ColorTranslator.FromHtml("#a17e51"),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup
            };
            Start.Click += Start_Click;
            Controls.Add(Start);

            Kszöveg = new Label
            {
                Text = "Kalandjáték",
                Size = new Size(300, 50),
                Location = new Point(700, 100),
                BackColor = ColorTranslator.FromHtml("#a17e51"),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup
            };
            Controls.Add(Kszöveg);
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void Start_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }
    }
}
