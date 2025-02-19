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
        private Button jobb;
        private Button bal;
        private Label Kszoveg;
        private Label Ht;
        public Form1()
        {
            InitializeComponent();

            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.Icon = new Icon("favicon.ico");
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            Image myimage = new Bitmap("hatter2.png");
            this.BackgroundImage = myimage;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Exit = new Button
            {
                Text = "KILÉPÉS",
                Size = new Size(150, 100),
                Location = new Point(1250,550),
                Font = new Font("Courier New", 20, FontStyle.Bold),
                BackColor = ColorTranslator.FromHtml("#a17e51"),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup
            };
            Exit.Click += exit_Click;
            Controls.Add(Exit);

            Start = new Button
            {
                Text = "JÁTEK",
                Size = new Size(150, 100),
                Location = new Point(1450, 550),
                Font = new Font("Courier New", 20, FontStyle.Bold),
                BackColor = ColorTranslator.FromHtml("#a17e51"),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup
            };
            Start.Click += Start_Click;
            Controls.Add(Start);

            jobb = new Button
            {
                Text = ">",
                Size = new Size(30,25),
                Location = new Point(650, 770),
                Font = new Font("Courier New", 11, FontStyle.Bold),
                BackColor = ColorTranslator.FromHtml("#a17e51"),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup
            };
            jobb.Click += Jobb_Click;
            Controls.Add(jobb);

            bal = new Button
            {
                Text = "<",
                Size = new Size(30, 25),
                Location = new Point(650, 770),
                Font = new Font("Courier New", 11, FontStyle.Bold),
                BackColor = ColorTranslator.FromHtml("#a17e51"),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup,
                Visible = false
            };
            bal.Click += Bal_Click;
            Controls.Add(bal);

            Kszoveg = new Label
            {
                Text = "Az Osztriga-öböltől délre, nagyjából nyolcvan kilométerre terül el a Koponyák Sivataga. Forró, veszedelmes és mindent egybevetve igen kellemetlen hely, ám te kénytelen vagy átkelni rajta, hisz déli felén terül el a drágakőbányáiról messze földön híres és gazdag Zafirváros. Vonz a hatalmas vagyon, mely minden harcos számára elérhető, aki hajlandó akár a köveket, akár a pénzt kísérni egyik településből a másikba. A munka azonban nem veszélytelen.\r\nAhogy a sivatag felé közeledsz, segélykiáltásokat hallasz az utat szegélyező bozótos túloldaláról. Mikor közelebb lépsz, még épp látod, ahogy egy ocsmány Goblin tört márt egy igen fontosnak látszó Elf férfi szívébe, aki azonnal a földre roskad.\r\nEgyből előre rontasz, hogy elkapd a gyilkost, ám pechedre megbotlasz, az aljas teremtmény pedig észrevesz téged, és eltűnik az aljnövényzetben.Csak állsz, és a halott Elf tetemét bámulod. Amennyire meg tudod állapítani, az egyik helyi törzs vezetője lehetett. Kezében egy nagy, kék színű gyémántot szorongat. Hirtelen megrezzennek körülötted a bokrok! Arra gondolsz, talán a Goblin tért vissza, így előhúzod kardodat. Legnagyobb meglepetésedre azonban húsz vagy harminc Elf gyűrűjében találod magadat, akik megfeszített íjakkal vesznek körbe. Egyikük előre lép, és komoran megszólít.\r\n",
                Size = new Size(600, 600),
                Location = new Point(100, 200),
                Font = new Font("Courier New", 14, FontStyle.Bold),
                BackColor = ColorTranslator.FromHtml("#a17e51"),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup
            };
            Controls.Add(Kszoveg);

            Ht = new Label
            {
                Text = "HÁTTÉRTÖRTÉNET",
                Size = new Size(230, 25),
                Location = new Point(250, 180),
                Font = new Font("Courier New", 16, FontStyle.Bold),
                BackColor = ColorTranslator.FromHtml("#a17e51"),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup
            };
            Controls.Add(Ht);

            
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

        private void Jobb_Click(object sender, EventArgs e)
        {
            Kszoveg.Text = "Ember! kezdi.\nKarddal a kezedben, apám, a Törzsfőnökünk meggyilkolt testével a lábad előtt találtunk rád.\r\nRájössz, hogy ezek azt hiszik, te vagy a gyilkos.\nTiltakozni próbálnál, azonban az Elf egy intésére elhallgatsz.\nAz ítélet Labirintusához viszünk fejezi be mondanivalóját. Hátat fordít neked, és elsétál, te pedig kísérőid körében kénytelen vagy követni.\nMiközben az örök egymás közt vitatják meg a látottakat, megtudod, hogy a labirintus egy titkos hely, ahol a bűnösöket teszik próbára. Minden ..próba\" előtt egy kis Aranyszobrot rejtenek el annak mélyén, a próba alanyának pedig meg kell találnia azt.\nHa ez nem sikerül, bünösnek ítélik, ám ha rálel, és sikerül kijuttatnia odabentről, ártatlannak találják, és szabadon engedik.\r\nA fak ritkulni kezdenek, a menet pedig egy hatalmas fa törzsénél megtorpan.\nA Főnök fia motyog pár szót, mire a kéreg egy része kinyílik, mögötte pedig feltűnik a labirintus bejárata...\r\n";
            jobb.Visible = false;
            bal.Visible = true;
            
        }

        private void Bal_Click(object sender, EventArgs e)
        {
            Kszoveg.Text = "Az Osztriga-öböltől délre, nagyjából nyolcvan kilométerre terül el a Koponyák Sivataga. Forró, veszedelmes és mindent egybevetve igen kellemetlen hely, ám te kénytelen vagy átkelni rajta, hisz déli felén terül el a drágakőbányáiról messze földön híres és gazdag Zafirváros. Vonz a hatalmas vagyon, mely minden harcos számára elérhető, aki hajlandó akár a köveket, akár a pénzt kísérni egyik településből a másikba. A munka azonban nem veszélytelen.\r\nAhogy a sivatag felé közeledsz, segélykiáltásokat hallasz az utat szegélyező bozótos túloldaláról. Mikor közelebb lépsz, még épp látod, ahogy egy ocsmány Goblin tört márt egy igen fontosnak látszó Elf férfi szívébe, aki azonnal a földre roskad.\r\nEgyből előre rontasz, hogy elkapd a gyilkost, ám pechedre megbotlasz, az aljas teremtmény pedig észrevesz téged, és eltűnik az aljnövényzetben.Csak állsz, és a halott Elf tetemét bámulod. Amennyire meg tudod állapítani, az egyik helyi törzs vezetője lehetett. Kezében egy nagy, kék színű gyémántot szorongat. Hirtelen megrezzennek körülötted a bokrok! Arra gondolsz, talán a Goblin tért vissza, így előhúzod kardodat. Legnagyobb meglepetésedre azonban húsz vagy harminc Elf gyűrűjében találod magadat, akik megfeszített íjakkal vesznek körbe. Egyikük előre lép, és komoran megszólít.\r\n";
            bal.Visible= false;
            jobb.Visible= true;
        }
    }
}
