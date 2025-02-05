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

namespace program
{
    public partial class Form1 : Form
    {
        private int stepCount = 0;
        private List<int> stepData = new List<int>();
        private List<string> weatherData = new List<string>();
        private List<double> alcoholData = new List<double>();
        private Timer stepTimer = new Timer();
        private Timer weatherTimer = new Timer();
        private Timer alcoholTimer = new Timer();
        private Random random = new Random();
        private Label lblSteps, lblStepWarning, lblWeather, lblWeatherWarning, lblAlcohol, lblAlcoholWarning;
        private Button btnExit;

        public Form1()
        {
            InitializeComponent();

            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            stepTimer.Interval = 1000;
            stepTimer.Tick += StepTimer_Tick;
            stepTimer.Start();

            weatherTimer.Interval = 2000;
            weatherTimer.Tick += WeatherTimer_Tick;
            weatherTimer.Start();

            alcoholTimer.Interval = 3000;
            alcoholTimer.Tick += AlcoholTimer_Tick;
            alcoholTimer.Start();

            InitializeUI();
        }

        private void InitializeUI()
        {
            lblSteps = new Label
            {
                Text = "Lépések: 0",
                Location = new Point(20, 20),
                Size = new Size(200, 30),
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.Black
            };
            this.Controls.Add(lblSteps);

            lblStepWarning = new Label
            {
                Location = new Point(20, 50),
                Size = new Size(250, 30),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.Red
            };
            this.Controls.Add(lblStepWarning);

            lblWeather = new Label
            {
                Text = "Időjárás: -",
                Location = new Point(20, 80),
                Size = new Size(250, 30),
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.Black
            };
            this.Controls.Add(lblWeather);

            lblWeatherWarning = new Label
            {
                Location = new Point(20, 110),
                Size = new Size(250, 30),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.Red
            };
            this.Controls.Add(lblWeatherWarning);

            lblAlcohol = new Label
            {
                Text = "Alkoholszint: -",
                Location = new Point(20, 140),
                Size = new Size(250, 30),
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.Black
            };
            this.Controls.Add(lblAlcohol);

            lblAlcoholWarning = new Label
            {
                Location = new Point(20, 170),
                Size = new Size(250, 45),
                Font = new Font("Arial", 10, FontStyle.Bold),
                ForeColor = Color.Red
            };
            this.Controls.Add(lblAlcoholWarning);

            btnExit = new Button
            {
                Text = "Kilépés és mentés",
                Location = new Point(20, 220),
                Size = new Size(200, 40),
                Font = new Font("Arial", 12, FontStyle.Bold),
                BackColor = ColorTranslator.FromHtml("#08121A"),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup
            };
            btnExit.Click += btnExit_Click;
            this.Controls.Add(btnExit);
        }

        private void StepTimer_Tick(object sender, EventArgs e)
        {
            stepCount += random.Next(50, 300);
            stepData.Add(stepCount);
            lblSteps.Text = $"Lépések: {stepCount}";
            lblStepWarning.Text = stepCount < 5000 ? "Mozogj többet!" : stepCount > 15000 ? "Pihenj egy kicsit!" : "";
        }

        private void WeatherTimer_Tick(object sender, EventArgs e)
        {
            int temp = random.Next(-5, 40);
            int humidity = random.Next(10, 90);
            string data = $"Hőmérséklet: {temp}°C, Páratartalom: {humidity}%";
            weatherData.Add(data);
            lblWeather.Text = data;
            lblWeatherWarning.Text = temp < 0 ? "Figyelem! Fagyveszély!" : temp > 35 ? "Figyelem! Túl meleg van!" : "";
        }

        private void AlcoholTimer_Tick(object sender, EventArgs e)
        {
            double alcoholLevel = Math.Round(random.NextDouble() * 0.15, 3);
            alcoholData.Add(alcoholLevel);
            lblAlcohol.Text = $"Alkoholszint: {alcoholLevel}%";
            lblAlcoholWarning.Text = alcoholLevel > 0.08 ? "Ne vezess! Túl magas az alkoholszint!" : "";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            using (StreamWriter writer = new StreamWriter("data.txt"))
            {
                writer.WriteLine("=== Lépésszámláló adatok ===");
                foreach (var step in stepData)
                    writer.WriteLine($"Lépésszám: {step}");
                writer.WriteLine("\n=== Időjárás adatok ===");
                foreach (var weather in weatherData)
                    writer.WriteLine(weather);
                writer.WriteLine("\n=== Alkoholteszt adatok ===");
                foreach (var alcohol in alcoholData)
                    writer.WriteLine($"Alkoholszint: {alcohol}%");
            }
            MessageBox.Show("Adatok elmentve: data.txt");
            Application.Exit();
        }
    }
}
