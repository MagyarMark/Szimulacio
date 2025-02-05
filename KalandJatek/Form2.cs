﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace KalandJatek
{
    public partial class Form2 : Form
    {
        private Button eletero;
        private Button szerencse;
        private Button ugyesseg;
        private PictureBox potionselect;

        public Form2()
        {
            Form2_Load(sender: null, e: null);

            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            Image myimage = new Bitmap("main.png");
            this.BackgroundImage = myimage;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            eletero = new Button
            {
                Text = "Kiválasztás",
                Size = new Size(140, 75),
                Location = new Point(810, 850),
                Font = new Font("Arial", 12, FontStyle.Bold),
                BackColor = ColorTranslator.FromHtml("#a17e51"),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup
            };
            eletero.Click += First_Click;
            Controls.Add(eletero);

            szerencse = new Button
            {
                Text = "Kiválasztás",
                Size = new Size(150, 75),
                Location = new Point(975, 850),
                Font = new Font("Arial", 12, FontStyle.Bold),
                BackColor = ColorTranslator.FromHtml("#a17e51"),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup
            };
            szerencse.Click += Second_Click;
            Controls.Add(szerencse);

            ugyesseg = new Button
            {
                Text = "Kiválasztás",
                Size = new Size(140, 75),
                Location = new Point(1150, 850),
                Font = new Font("Arial", 12, FontStyle.Bold),
                BackColor = ColorTranslator.FromHtml("#a17e51"),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup
            };
            ugyesseg.Click += Third_Click;
            Controls.Add(ugyesseg);

            potionselect = new PictureBox()
            {
                Image = Image.FromFile("Italvalasztas.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(800, 400),
                Location = new Point(650, 550)
            };
            Controls.Add(potionselect);


        }

        private void First_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kiválasztás Megvalositva!\n"+"Választásod: Életerő ital!");
            potionselect.Visible = false;
            eletero.Visible = false;
            szerencse.Visible = false;
            ugyesseg.Visible = false;
        }
        private void Second_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kiválasztás Megvalositva!\n" + "Választásod: Szerencse ital!");
            potionselect.Visible = false;
            eletero.Visible = false;
            szerencse.Visible = false;
            ugyesseg.Visible = false;
        }
        private void Third_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kiválasztás Megvalositva!\n" + "Választásod: Ügyesség ital!");
            potionselect.Visible = false;
            eletero.Visible = false;
            szerencse.Visible = false;
            ugyesseg.Visible = false;
        }
    }
}