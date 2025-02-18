using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KalandJatek
{
    class PlayerStats
    {
        public int Skill { get; set; }
        public int Stamina { get; set; }
        public int Luck { get; set; }
        public int Hp { get; set; }
        public int Coins { get; set; }

        private Random rand = new Random();

        public PlayerStats()
        {
            Skill = rand.Next(1, 7) + 6;
            Stamina = (rand.Next(1, 7) + rand.Next(1, 7)) + 12;
            Luck = rand.Next(1, 7) + 6;
            Hp = rand.Next(1, 7) + 6;
            Coins = 20;
        }
    }
    public partial class Form2 : Form
    {
        private PictureBox potionselect;
        private PictureBox Player;
        private PictureBox Enemy;
        private Button eletero;
        private Button szerencse;
        private Button ugyesseg;
        private Button tovabb;
        private Button tovabb2;
        private Button tovabb3;
        private Button tovabb4;
        private Button tovabb5;
        private Button tovabb6;
        private Button tovabb7;
        private Button tovabb8;
        private Button Exit;
        private Label italok;
        private Label hp;
        private Label stamina;
        private Label luck;
        private Label enemyhp;
        private Label playerhp;
        private Label Coins;
        private Label felszereles;
        private Label felszereles2;
        private Label Nyeremeny;
        private List<string> invlist = new List<string>();
        private List<Label> SzovegList = new List<Label>();
        private List<Button> SzamGombListegesz = new List<Button>();
        private PlayerStats playerStats = new PlayerStats();
        private int currentIndex = 0;

        public Form2()
        {
            Form2_Load(sender: null, e: null);

            this.MaximizeBox = false;
            this.MinimizeBox = true;
            this.Icon = new Icon("favicon.ico");
            this.WindowState = FormWindowState.Maximized;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            Image myimage = new Bitmap("bg.png");
            this.BackgroundImage = myimage;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            Exit = new Button
            {
                Text = "KILÉPÉS",
                Size = new Size(150, 100),
                Location = new Point(1750, 850),
                Font = new Font("Courier New", 20, FontStyle.Bold),
                BackColor = ColorTranslator.FromHtml("#a17e51"),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup
            };
            Exit.Click += exit_Click;
            Controls.Add(Exit);

            eletero = new Button
            {
                Text = "Kiválasztás",
                Size = new Size(140, 75),
                Location = new Point(810, 850),
                Font = new Font("Courier New", 12, FontStyle.Bold),
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
                Font = new Font("Courier New", 12, FontStyle.Bold),
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
                Font = new Font("Courier New", 12, FontStyle.Bold),
                BackColor = ColorTranslator.FromHtml("#a17e51"),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup
            };
            ugyesseg.Click += Third_Click;
            Controls.Add(ugyesseg);

            italok = new Label
            {
                Text = "Italok:",
                Size = new Size(160, 140),
                Location = new Point(50, 850),
                Font = new Font("Courier New", 16),
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup,
                Visible = false
            };
            Controls.Add(italok);

            hp = new Label
            {
                Text = $"HP: {playerStats.Hp}\n",
                Size = new Size(160, 160),
                Location = new Point(50, 50),
                Font = new Font("Courier New", 16),
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup,
                Visible = false
            };
            Controls.Add(hp);

            felszereles = new Label
            {
                Text = $"Felszerelés:\n",
                Size = new Size(200, 200),
                Location = new Point(50, 250),
                Font = new Font("Courier New", 16),
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup,
                Visible = false
            };
            Controls.Add(felszereles);

            felszereles2 = new Label
            {
                Size = new Size(180,200),
                Location = new Point(250, 250),
                Font = new Font("Courier New", 16),
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup,
                Visible = false
            };
            Controls.Add(felszereles2);

            stamina = new Label
            {
                Text = $"Stamina: {playerStats.Stamina}\n",
                Size = new Size(160, 160),
                Location = new Point(220, 50),
                Font = new Font("Courier New", 16),
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup,
                Visible = false
            };
            Controls.Add(stamina);
            
            luck = new Label
            {
                Text = $"Luck: {playerStats.Luck}\n",
                Size = new Size(160, 160),
                Location = new Point(390, 50),
                Font = new Font("Courier New", 16),
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup,
                Visible = false
            };
            Controls.Add(luck);

            Coins = new Label
            {
                Text = $"Coins: {playerStats.Coins}\n",
                Size = new Size(160, 160),
                Location = new Point(550, 50),
                Font = new Font("Courier New", 16),
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup,
                Visible = false
            };
            Controls.Add(Coins);

            Nyeremeny = new Label
            {
                Size = new Size(350, 50),
                Location = new Point(800,250),
                Font = new Font("Courier New", 16, FontStyle.Bold),
                BackColor = ColorTranslator.FromHtml("#a17e51"),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup,
                Visible = false
            };
            Controls.Add(Nyeremeny);

            tovabb2 = new Button
            {
                Text = "87",
                Size = new Size(150, 75),
                Location = new Point(750, 850),
                Font = new Font("Courier New", 12, FontStyle.Bold),
                BackColor = ColorTranslator.FromHtml("#a17e51"),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup,
                Visible = false
            };
            tovabb2.Click += Tovabb2_Click;
            Controls.Add(tovabb2);

            tovabb3 = new Button
            {
                Text = "6",
                Size = new Size(150, 75),
                Location = new Point(900, 850),
                Font = new Font("Courier New", 12, FontStyle.Bold),
                BackColor = ColorTranslator.FromHtml("#a17e51"),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup,
                Visible = false
            };
            tovabb3.Click += Tovabb3_Click;
            Controls.Add(tovabb3);
            
            tovabb4 = new Button
            {
                Text = "111",
                Size = new Size(150, 75),
                Location = new Point(1050, 850),
                Font = new Font("Courier New", 12, FontStyle.Bold),
                BackColor = ColorTranslator.FromHtml("#a17e51"),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup,
                Visible = false
            };
            tovabb4.Click += Tovabb4_Click;
            Controls.Add(tovabb4);
            
            tovabb5 = new Button
            {
                Text = "53",
                Size = new Size(150, 75),
                Location = new Point(1200, 850),
                Font = new Font("Courier New", 12, FontStyle.Bold),
                BackColor = ColorTranslator.FromHtml("#a17e51"),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup,
                Visible = false
            };
            tovabb5.Click += Tovabb5_Click;
            Controls.Add(tovabb5);
            
            tovabb6 = new Button
            {
                Text = "163",
                Size = new Size(150, 75),
                Location = new Point(750, 850),
                Font = new Font("Courier New", 12, FontStyle.Bold),
                BackColor = ColorTranslator.FromHtml("#a17e51"),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup,
                Visible = false
            };
            tovabb6.Click += Tovabb6_Click;
            Controls.Add(tovabb6);
            
            tovabb7 = new Button
            {
                Text = "185",
                Size = new Size(150, 75),
                Location = new Point(970, 850),
                Font = new Font("Courier New", 12, FontStyle.Bold),
                BackColor = ColorTranslator.FromHtml("#a17e51"),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup,
                Visible = false
            };
            tovabb7.Click += Tovabb7_Click;
            Controls.Add(tovabb7);
            
            tovabb8 = new Button
            {
                Text = "168",
                Size = new Size(150, 75),
                Location = new Point(1200, 850),
                Font = new Font("Courier New", 12, FontStyle.Bold),
                BackColor = ColorTranslator.FromHtml("#a17e51"),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup,
                Visible = false
            };
            tovabb8.Click += Tovabb8_Click;
            Controls.Add(tovabb8);

            tovabb = new Button
            {
                Text = "Tovább",
                Size = new Size(600, 75),
                Location = new Point(750, 850),
                Font = new Font("Courier New", 12, FontStyle.Bold),
                BackColor = ColorTranslator.FromHtml("#a17e51"),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup,
                Visible = false
            };
            tovabb.Click += Tovabb_Click;
            Controls.Add(tovabb);


            for (int i = 0; i < 200; i++)
            {
                Button btn = new Button();
                btn.Size = new Size(600, 75);
                btn.Text = i.ToString();
                btn.Location = new Point(750, 850);
                btn.Font = new Font("Courier New", 12, FontStyle.Bold);
                btn.BackColor = ColorTranslator.FromHtml("#a17e51");
                btn.ForeColor = Color.White;
                btn.Visible = false;
                SzamGombListegesz.Add(btn);
                Controls.Add(btn);
            }

            for (int i = 0; i < 200; i++)
            {
                Label lbl = new Label();
                lbl.Size = new Size(600, 300);
                lbl.Text = "#1\nBelöknek a lenti alagútba, és rád zárják az ajtót, kizárva ezzel a nyíláson át beszűrődő természetes világosságot. Innentől kezdve kizárólag a falra rögzített fáklyáktól remélhetsz valamennyi fényt. Ahogy szemed hozzászokik a homályhoz, látod, hogy az alagút észak felé indul. Nagyot sóhajtasz a dolog igazságtalansága felett, majd elindulsz abba az irányba. Lapozz a 41-re.";
                lbl.Location = new Point(750, 550);
                lbl.Font = new Font("Courier New", 12.7f, FontStyle.Bold);
                lbl.BackColor = Color.Transparent;
                lbl.ForeColor = Color.White;
                lbl.Visible = false;
                SzovegList.Add(lbl);
                Controls.Add(lbl);
            }

            potionselect = new PictureBox()
            {
                Image = Image.FromFile("Italvalasztas.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(800, 400),
                Location = new Point(650, 550)
            };
            Controls.Add(potionselect);
        }
        private void exit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void First_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Jó választás utazó!\n" + "Választásod: Életerő ital!", "Sikeres választás", MessageBoxButtons.OK, MessageBoxIcon.Information);
            invlist.Add("Életerő ital");
            potionselect.Visible = false;
            eletero.Visible = false;
            szerencse.Visible = false;
            ugyesseg.Visible = false;
            SzovegList[0].Visible = true;
            tovabb.Visible = true;
            italok.Visible = true;
            Image myimage = new Bitmap("hp.png");
            italok.Image = myimage;
            italok.ImageAlign = ContentAlignment.TopLeft;
            hp.Visible = true;
            Image hpstat = new Bitmap("hpstat.png");
            hp.Image = hpstat;
            hp.ImageAlign = ContentAlignment.MiddleLeft;
            stamina.Visible = true;
            Image staminastat = new Bitmap("staminastat.png");
            stamina.Image = staminastat;
            stamina.ImageAlign = ContentAlignment.MiddleLeft;
            luck.Visible = true;
            Image luckstat = new Bitmap("luckstat.png");
            luck.Image = luckstat;
            luck.ImageAlign = ContentAlignment.MiddleLeft;
            Image Coinsstat = new Bitmap("Coinsstat.png");
            Coins.Image = Coinsstat;
            Coins.ImageAlign = ContentAlignment.MiddleLeft;
            Coins.Visible = true;
            Image Kardstat = new Bitmap("Kard.png");
            felszereles.Image = Kardstat;
            felszereles.ImageAlign = ContentAlignment.TopLeft;
            felszereles.Visible = true;
            Image vertstat = new Bitmap("Bőrvért.png");
            felszereles2.Image = vertstat;
            felszereles2.ImageAlign = ContentAlignment.TopLeft;
            felszereles2.Visible = true;
        }
        private void Second_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Jó választás utazó!\n" + "Választásod: Szerencse ital!", "Sikeres választás", MessageBoxButtons.OK, MessageBoxIcon.Information);
            invlist.Add("Szerencse ital");
            potionselect.Visible = false;
            eletero.Visible = false;
            szerencse.Visible = false;
            ugyesseg.Visible = false;
            SzovegList[0].Visible = true;
            tovabb.Visible = true;
            italok.Visible = true;
            Image myimage = new Bitmap("luck.png");
            italok.Image = myimage;
            italok.ImageAlign = ContentAlignment.TopLeft;
            hp.Visible = true;
            Image hpstat = new Bitmap("hpstat.png");
            hp.Image = hpstat;
            hp.ImageAlign = ContentAlignment.MiddleLeft;
            stamina.Visible = true;
            Image staminastat = new Bitmap("staminastat.png");
            stamina.Image = staminastat;
            stamina.ImageAlign = ContentAlignment.MiddleLeft;
            luck.Visible = true;
            Image luckstat = new Bitmap("luckstat.png");
            luck.Image = luckstat;
            luck.ImageAlign = ContentAlignment.MiddleLeft;
            Image Coinsstat = new Bitmap("Coinsstat.png");
            Coins.Image = Coinsstat;
            Coins.ImageAlign = ContentAlignment.MiddleLeft;
            Coins.Visible = true;
            Image Kardstat = new Bitmap("Kard.png");
            felszereles.Image = Kardstat;
            felszereles.ImageAlign = ContentAlignment.TopLeft;
            felszereles.Visible = true;
            Image vertstat = new Bitmap("Bőrvért.png");
            felszereles2.Image = vertstat;
            felszereles2.ImageAlign = ContentAlignment.TopLeft;
            felszereles2.Visible = true;
        }
        private void Third_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Jó választás utazó!\n" + "Választásod: Ügyesség ital!", "Sikeres választás", MessageBoxButtons.OK, MessageBoxIcon.Information);
            invlist.Add("Ügyesség ital");
            potionselect.Visible = false;
            eletero.Visible = false;
            szerencse.Visible = false;
            ugyesseg.Visible = false;
            SzovegList[0].Visible = true;
            tovabb.Visible = true;
            italok.Visible = true;
            Image myimage = new Bitmap("skill.png");
            italok.Image = myimage;
            italok.ImageAlign = ContentAlignment.TopLeft;
            hp.Visible = true;
            Image hpstat = new Bitmap("hpstat.png");
            hp.Image = hpstat;
            hp.ImageAlign = ContentAlignment.MiddleLeft;
            stamina.Visible = true;
            Image staminastat = new Bitmap("staminastat.png");
            stamina.Image = staminastat;
            stamina.ImageAlign = ContentAlignment.MiddleLeft;
            luck.Visible = true;
            Image luckstat = new Bitmap("luckstat.png");
            luck.Image = luckstat;
            luck.ImageAlign = ContentAlignment.MiddleLeft;
            Image Coinsstat = new Bitmap("Coinsstat.png");
            Coins.Image = Coinsstat;
            Coins.ImageAlign = ContentAlignment.MiddleLeft;
            Coins.Visible = true;
            Image Kardstat = new Bitmap("Kard.png");
            felszereles.Image = Kardstat;
            felszereles.ImageAlign = ContentAlignment.TopLeft;
            felszereles.Visible = true;
            Image vertstat = new Bitmap("Bőrvért.png");
            felszereles2.Image = vertstat;
            felszereles2.ImageAlign = ContentAlignment.TopLeft;
            felszereles2.Visible = true;
        }
        private void Tovabb_Click(object sender, EventArgs e)
        {
            switch (currentIndex)
            {
                case 0:
                    tovabb.Text = "Tovabb";
                    SzovegList[0].Visible = false;
                    SzovegList[1].Visible = true;
                    SzovegList[1].Text = "#41\nAz alagút, bár folyamatosan jobbra-balra kanyarog, nagyjából mégis tartja az északi irányt, végül élesen oldalra kanyarodik, és ekkor majdnem belefutsz egy fekete köpenybe öltözött alakba. Tört tart a kezében, az arcán ülő tekintet rettegésről árulkodik! Rájössz, hogy nem te vagy az egyetlen, akit most próbára tesznek, és hogy mindketten ugyanazon Szobor után kutattok. A fickó rád veti magát, nyilvánvaló, hogy mielőbb végezni akar veled. Harcolnod kell!";
                    currentIndex++;
                    break;
                case 1:
                    tovabb.Visible = false;
                    SzovegList[1].Visible = false;
                    Tolvaj(7, 6);
                    tovabb.Visible = true;
                    tovabb.Text = "Tovabb";
                    SzovegList[87].Visible = true;
                    SzovegList[87].Text = "#85\nA Tolvajnál mindössze 3 Aranytallért és egy háromszög alakú, penészes gyümölcsöt találsz. Még soha nem láttál ehhez hasonlót, de gyanítod, hogy ez lehet a Xentos, a hosszú élet gyümölcse. Ha nem lenne ilyen borzalmas állapotban, gond nélkül megkockáztatnád, hogy belekóstolj, igy azonban úgy döntesz, hogy itt hagyod és folytatod az utad észak felé. Hamarosan egy útelágazáshoz érsz. Ha továbbra is északnak tartasz, lapozz a 108-ra. Ha a nyugati irányba leágazó új járaton mennél tovább, lapozz a 147-re.";
                    currentIndex++;
                    int choice = GetUserChoice();
                    if (choice == 108)
                    {
                        currentIndex = 108;
                    }else if (choice == 147)
                    {
                        currentIndex = 147;
                    }
                    break;
                case 108:
                    tovabb.Text = "Tovabb";
                    SzovegList[87].Visible = false;
                    SzovegList[108].Visible = true;
                    Nyeremeny.Visible = false;
                    SzovegList[108].Text = "#108\nÉszaki irányba követed az átjárót. Hamarosan elérsz egy keleti leágazáshoz. Hogyha egyenesen mész tovább, lapozz a 146-ra. Ha letérsz jobbra, lapozz a 79-re.";
                    currentIndex++;
                    int choice2 = GetUserChoice2();
                    if (choice2 == 146)
                    {
                        currentIndex = 146;
                    }
                    else if (choice2 == 79)
                    {
                        currentIndex = 79;
                    }
                    break;
                case 147:
                    tovabb.Text = "Tovabb";
                    SzovegList[87].Visible = false;
                    SzovegList[147].Visible = true;
                    Nyeremeny.Visible = false;
                    SzovegList[147].Text = "#147\nA járat egy ajtóban végződik. Hogyha ki szeretnéd nyitni, lapozz a 22-re. Ha visszatérnél az elágazáshoz, és észak felé folytatnád az utad, lapozz a 108-ra.";
                    currentIndex++;
                    int choice4 = GetUserChoice4();
                    if (choice4 == 22)
                    {
                        currentIndex = 22;
                    }
                    else if (choice4 == 108)
                    {
                        currentIndex = 108;
                        SzovegList[147].Visible = false;
                        SzovegList[108].Visible = true;
                        SzovegList[108].Text = "#108\nÉszaki irányba követed az átjárót. Hamarosan elérsz egy keleti leágazáshoz. Hogyha egyenesen mész tovább, lapozz a 146-ra. Ha letérsz jobbra, lapozz a 79-re.";
                        int choice5 = GetUserChoice5();
                        if (choice5 == 146)
                        {
                            currentIndex = 146;
                        }
                        else if (choice5 == 79)
                        {
                            currentIndex = 79;
                        }
                    }

                    break;
                case 146:
                    tovabb.Text = "Tovabb";
                    SzovegList[108].Visible = false;
                    SzovegList[146].Visible = true;
                    SzovegList[146].Text = "#146\nHamarosan egy ajtóhoz érsz, ami a nyugati falból nyílik. Ahogy végighúzod rajta a kezed, a kilincset keresve, egy keresztet sikerül kitapintanod rajta, amit nem túl mélyen véstek bele. Ha ki akarod nyitni az ajtót, lapozz az 51-re. Ha folytatnád az utad észak felé, lapozz a 80-ra.\r\n";
                    currentIndex++;
                    int choice3 = GetUserChoice3();
                    if (choice3 == 51)
                    {
                        currentIndex = 51;
                    }
                    else if (choice3 == 80)
                    {
                        currentIndex = 80;
                    }
                    break;
                case 79:
                    tovabb.Text = "Tovabb";
                    SzovegList[108].Visible = false;
                    SzovegList[79].Visible = true;
                    SzovegList[79].Text = "#79\nA keleti járat elég keskeny és sötét, és újabb leágazásba fut bele, ezúttal a balodon. Ha erre mennél tovább, északi irányba, lapozz a 141-re. Ha egyenesen folytatnád az utadat, lapozz a 122-re.";
                    currentIndex++;
                    int choice6 = GetUserChoice6();
                    if (choice6 == 141)
                    {
                        currentIndex = 141;
                    }
                    else if (choice6 == 122)
                    {
                        currentIndex = 122;
                    }
                    break;
                case 122:
                    tovabb.Text = "Tovabb";
                    SzovegList[79].Visible = false;
                    SzovegList[122].Visible = true;
                    SzovegList[122].Text = "#122\nAz alagút egy ideig kelet felé folytatódik. végül északra fordul. Ahogy a kanyar felé közeledsz, a szemben lévő falon egy lüktető fényfoltot veszel észre. Óvatosan nézel be balra. Lapozz a 144-re.\r\n";
                    currentIndex++;
                    int choice8 = GetUserChoice8();
                    if (choice8 == 144)
                    {
                        currentIndex = 144;
                    }
                    break;
                case 144:
                    tovabb.Text = "Tovabb";
                    SzovegList[122].Visible = false;
                    SzovegList[144].Visible = true;
                    SzovegList[144].Text = "#144\nMikor már félúton jársz a fényfolt felé, a talaj megnyílik alattad, de még az előtt sikerül visszalépned, hogy te is beleesnél, korábbi óvatosságod meghozta gyümölcsét. Ahogy közelebbről is megvizsgálod, megállapítod, hogy egy kis, kör alakú verem az a padló kellős közepén. Rozoga létra fut lefelé végig az oldalán. de vagy túl sötét van, vagy túl mély lyuk, mert nem látod az alját. Ha szét akarsz nézni benne, lapozz a 7-re. Ha inkább átugornád és kiderítenéd, mi a fényfolt forrása, lapozz a 96-ra.";
                    currentIndex++;
                    int choice10 = GetUserChoice10();
                    if (choice10 == 7)
                    {
                        currentIndex = 7;
                    }
                    else if (choice10 == 96)
                    {
                        currentIndex = 96;
                    }
                    break;
                case 141:
                    tovabb.Text = "Tovabb";
                    SzovegList[79].Visible = false;
                    SzovegList[141].Visible = true;
                    SzovegList[141].Text = "#141\nA járat hamarosan egy ajtóban ér véget. Ha ki szeretnéd nyitni és belépnél rajta, lapozz a 107-re. Ha nem akarod tudni, mi vár rád odabenn és inkább visszamennél az elágazáshoz, hogy kelet felé folytasd az utad, lapozz a 122-re.";
                    currentIndex++;
                    int choice7 = GetUserChoice7();
                    if (choice7 == 107)
                    {
                        currentIndex = 107;
                    }
                    else if (choice7 == 122)
                    {
                        
                        currentIndex = 122;
                        SzovegList[0].Visible = false;
                        SzovegList[141].Visible = false;
                        SzovegList[122].Visible = true;
                        SzovegList[122].Text = "#122\nAz alagút egy ideig kelet felé folytatódik. végül északra fordul. Ahogy a kanyar felé közeledsz, a szemben lévő falon egy lüktető fényfoltot veszel észre. Óvatosan nézel be balra. Lapozz a 144-re.\r\n";
                        int choice9 = GetUserChoice9();
                        if (choice9 == 144)
                        {
                            currentIndex = 144;
                        }
                    }
                    break;
                case 51:
                    tovabb.Text = "Tovabb";
                    SzovegList[146].Visible = false;
                    SzovegList[51].Visible = true;
                    SzovegList[51].Text = "#51\nEgy kis helyiségbe nyitsz be, mely első ránézésre nem tartalmaz semmi mást, csak nagy halom törmeléket a padlón. Ahogy beljebb lépsz, kellemetlen szag csapja meg az orrodat, és egy éles, magas és amenynyire meg tudod állapítani dühödt visitás kezd egyre erősödni. Végül egy rikoltás kiséretében két hatalmas Denevér ereszti el a plafont a szoba két sarkában, és feléd kezdenek repülni. Ahogy ösztönösen lebuksz, sikerül észrevenned a lények vicsorgó agyarait, melyek készek szétcincálni a torkodat. Ha gyorsan kihátrálsz, majd becsapod magad mögött a bejárati ajtót, lapozz a 80-ra. Hogyha megveted a lábad és megküzdesz ezekkel a szörnyű teremtményekkel, lapozz a 140-re.";
                    currentIndex++;
                    int choice11 = GetUserChoice11();
                    if (choice11 == 80)
                    {
                        currentIndex = 80;
                        SzovegList[0].Visible = false;
                        SzovegList[51].Visible = false;
                        SzovegList[80].Visible = true;
                        SzovegList[80].Text = "#80\nÉszak felé haladsz. Megszenvedsz az úttal, hisz eléggé hepchupás. Hamarosan elérsz egy elágazáshoz. A nyugat felé továbbinduló szakasz még rosszabb állapotúnak tűnik, mint az, ahol most jársz, ezért úgy döntesz. továbbra is tartod az irányt. Lapozz a 89-re.";
                        int choice12 = GetUserChoice12();
                        if (choice12 == 89)
                        {
                            currentIndex = 89;
                        }
                    }
                    else if (choice11 == 140)
                    {
                        currentIndex = 140;
                    }
                    break;
                case 80:
                    tovabb.Text = "Tovabb";
                    SzovegList[146].Visible = false;
                    SzovegList[80].Visible = true;
                    SzovegList[80].Text = "#80\nÉszak felé haladsz. Megszenvedsz az úttal, hisz eléggé hepchupás. Hamarosan elérsz egy elágazáshoz. A nyugat felé továbbinduló szakasz még rosszabb állapotúnak tűnik, mint az, ahol most jársz, ezért úgy döntesz. továbbra is tartod az irányt. Lapozz a 89-re.";
                    currentIndex++;

                    int choice13 = GetUserChoice13();
                    if (choice13 == 89)
                    {
                        currentIndex = 89;
                    }
                    break;
                case 89:
                    tovabb.Text = "Tovabb";
                    SzovegList[80].Visible = false;
                    SzovegList[89].Visible = true;
                    SzovegList[89].Text = "#89\nA járat meredeken emelkedik, te pedig gyorsan fáradni kezdesz. Figyelmed ellankad, és nem veszed észre a padlóban lévő, meglazult kõdarabot. Megbotlasz és elesel, közben pajzsod a fal egyik repedésébe ékelődik. Miközben próbálod kiszabadítani, elferdül. Sérült pajzsod miatt a soron következő csatákban 2-vel csökkentened kell majd Támadóerődet. Morogva mész tovább. míg végül egy újabb elágazáshoz nem érsz. Hogyha a nyugati ágon folytatnád az utad, lapozz a 95-re. Ha egyenesen mész tovább, lapozz a 127-re.";
                    currentIndex++;
                    int choice14 = GetUserChoice14();
                    if (choice14 == 95)
                    {
                        currentIndex = 95;
                    }
                    else if (choice14 == 127)
                    {
                        currentIndex = 127;
                    }
                    break;
                case 95:
                    tovabb.Text = "Tovabb";
                    SzovegList[89].Visible = false;
                    SzovegList[95].Visible = true;
                    SzovegList[95].Text = "#95\nNyugati irányba mész, le egy lejtős járaton, míg el nem érsz egy újabb elágazást. Úgy gondolod, a déli út visszafelé vezetne, így észak felé indulsz. Lapozz a 153-ra.";
                    currentIndex++;
                    int choice15 = GetUserChoice15();
                    if (choice15 == 153)
                    {
                        currentIndex = 153;
                    }
                    break;
                case 153:
                    tovabb.Text = "Tovabb";
                    SzovegList[95].Visible = false;
                    SzovegList[153].Visible = true;
                    SzovegList[153].Text = "#153\nA járat szélesedni kezd, repedések és hasadékok jelennek meg a falakon. Zörgö hang szűrődik ki valahonnan, és az egyik lyukból két különös teremtmény ugrik elő. Az egyértelműen látszik, hogy az alvilág lakója, mivel bőre teljesen fehér, vad szemei pedig rózsaszínűek. Feje a farkáig ér, veszedelmes tüskék borítják hátát, melyek járás közben jobbra-balra inganak. A lény hátat fordít neked, és már kezdesz megörülni, hogy megijedt tőled és elmenekül. Mekkorát tévedtél! Ez egy mérges Sündisznó, és épp arra készül, hogy halálos tüskéit beléd löje. A harc indul!";
                    Suni(7, 5);
                    playerStats.Hp -= 3;
                    playerhp.Text = $"Hp:{playerStats.Hp}";
                    currentIndex++;
                    int choice16 = GetUserChoice16();
                    if (choice16 == 42)
                    {
                        currentIndex = 42;
                    }
                    break;
                case 42:
                    tovabb.Text = "Tovabb";
                    SzovegList[153].Visible = false;
                    SzovegList[42].Visible = true;
                    SzovegList[42].Text = "#42\nA járat tovább szélesedik, végül egy hatalmas barlangüregben találod magad. Mindkét oldaladnál sztalagmitok és sztalaktitok meredeznek. Néhányuk hatalmas köoszloppá nőtt össze az idők folyamán, melyek mögött kimondhatatlan borzalmak lapulhatnak. Érzed, hogy a barlangban folyamatosan mozog a levegő, és rájössz, hogy ennek oka egy gyors folyású, igen veszedelmesnek tűnő folyó. Feltekintve szemeid követik a cseppköoszlopok vonalait, egészen addig, míg el nem tűnnek a plafont elrejtő végtelen sötétségben. Valahol a folyó mentén egy kis, nem túl bizalomgerjesztő híd körvonalát sikerül kivenni. Lapozz a 27-re.";
                    int choice17 = GetUserChoice17();
                    if (choice17 == 27)
                    {
                        currentIndex = 27;
                    }
                    break;
                case 27:
                    tovabb.Text = "Tovabb";
                    SzovegList[42].Visible = false;
                    SzovegList[27].Visible = true;
                    SzovegList[27].Text = "#27\nEgy hatalmas völgy lábánál állsz, melyet egy gyors folyású folyó vájt ki. Próbálsz valami megoldást találni az átkelésre. de csak egy kicsi, eléggé rozoga és korhadt hidat látsz. Ahogy megközelíted, a látod, amint két óriási termesz eszi a fát. Hófehér testükön igen nyugtalanítóan hat két vérvörös szemük. A lények bármelyike bármikor beléd marhatna. Ha sietsz, talán még sikerül átkelned rajta azelőtt, hogy végleg összeroskadna. A másik lehetőséged, hogy megpróbálsz átúszni a sebes folyón. Ha az első megoldást választod, lapozz a 40-re. Ha úgy gondolod, elég jó úszó vagy, és ezzel próbálkoznál, lapozz a 2-re.\r\n";
                    currentIndex++;
                    int choice18 = GetUserChoice18();
                    if (choice18 == 40)
                    {
                        currentIndex = 40;
                    }else if (choice18 == 2)
                    {
                        currentIndex = 2;
                    }
                    break;
                case 40:
                    tovabb.Text = "Tovabb";
                    SzovegList[27].Visible = false;
                    SzovegList[40].Visible = true;
                    SzovegList[40].Text = "#40\nMiközben a termeszektől nyüzsgő építményen haladsz, az baljósan recseg-ropog a talpad alatt. Minden egyes lépéssel újabb darabjai esnek bele a vizbe. Végül már csak egyetlen kötél marad épen, ami az utolsó deszkadarabot tartja. Tedd próbára SZERENCSED! Ha szerencsés vagy, lapozz a 60-ra. Ha nem, lapozz a 75-re.";
                    currentIndex++;
                    int choice19 = GetUserChoice19();
                    if (choice19 == 60)
                    {
                        currentIndex = 60;
                    }else if (choice19 == 75)
                    {
                        currentIndex = 75;
                    }
                    break;
                case 60:
                    tovabb.Text = "Tovabb";
                    SzovegList[40].Visible = false;
                    SzovegList[60].Visible = true;
                    SzovegList[60].Text = "#60\nA hid épp elég ideig marad épen ahhoz, hogy átérj a túloldalra. Ahogy lelépsz róla, összeomlik. Lapozz a 76-ra.";
                    currentIndex++;
                    int choice20 = GetUserChoice20();
                    if (choice20 == 76)
                    {
                        currentIndex = 76;
                    }
                    break;
                case 76:
                    tovabb.Visible = false;
                    tovabb2.Visible = true;
                    tovabb3.Visible = true;
                    tovabb4.Visible = true;
                    tovabb5.Visible = true;
                    SzovegList[60].Visible = false;
                    SzovegList[76].Visible = true;
                    SzovegList[76].Text = "#76\nHomokos parton találod magad, melynek félhold alakja van. Az elötted lévő sziklafal egy kis alkóvot alkot, és három ajtót foglal magában. Ezek közül választhatsz majd, mikor eljön a távozás ideje, előtte azonban még el kell döntened, át akarod-e kutatni a folyópartot ékkövek vagy aranyérmék után. Hogyha az északi ajtón át távoznál, lapozz a 87-re. Ha a nyugatin lépnél be, lapozz a 6-ra. Ha a keletivel próbálnál szerencsét, lapozz a 111-re. Ha előbb átkutatnád a partot, lapozz az 53-ra.";
                    currentIndex++;
                    break;
            }
        }
        private void Tovabb2_Click(object sender, EventArgs e)
        {
            tovabb2.Text = "Tovabb";
            tovabb2.Size = new Size(600, 75);
            tovabb3.Visible= false;
            tovabb4.Visible= false;
            tovabb5.Visible= false;
            SzovegList[76].Visible = false;
            SzovegList[87].Visible = true;
            SzovegList[87].Text = "#87\nAz alagutat egy jókora, vasveretes ajtó zárja le. Megpróbálod lenyomni a kilincset, de zárva van. A méretes kulcslyukon átnézve nem sokat tudsz kivenni a túloldalból. Mikor a füledet hozzászorítod, tollak suhogását és fütyülés-szerű sóhajtást hallasz. Ha van nálad egy Arany Kulcs, lapozz a 13-ra. Ha nincsen, lapozz a 121-re.";
            currentIndex++;
            int choice21 = GetUserChoice21();
            if (choice21 == 13)
            {
                currentIndex = 13;
                SzovegList[121].Visible = false;
                SzovegList[87].Visible = false;
                SzovegList[13].Visible = true;
                SzovegList[13].Text = "#13\nA zárba helyezed a kulcsot, de az sajnos nem illik bele, így nincs más választásod, minthogy megpróbáld betörni. Lapozz a 196-ra.";
                currentIndex++;
                int choice22 = GetUserChoice22();
                if (choice22 == 196)
                {
                    currentIndex = 196;
                    SzovegList[121].Visible = false;
                    SzovegList[13].Visible = false;
                    SzovegList[196].Visible = true;
                    SzovegList[196].Text = "#196\nAmennyire csak tudod, puha ruhadarabokkal béleled ki a vállad, behúzod a nyakad és az ajtónak rontasz. Dobj egy kockával. Ha az eredmény 1-4. megsérültél és vesztesz 2 ÉLETERŐ pontot. Ha azonban 5-öt vagy 6-ot dobtál, sikerült betörnöd az ajtót lapozz a 158-ra. Egészen addig kell próbálkoznod. míg ez nem sikerül.\r\n";
                    currentIndex++;
                    BetorAjto();
                    SzovegList[121].Visible = false;
                    SzovegList[196].Visible = false;
                    SzovegList[158].Visible = true;
                    SzovegList[158].Text = "#158\nAz ajtó becsapódik, te pedig végre felfedezed a füttyszerű sóhajok és susogások forrását. Előtted, a padlón guggolva megpillantod a Galont, a Madárembert. Börszárnyai két oldalt széttárva állnak, kezének éles karmai feléd mutatnak. Azonnal felismered zöldes bőrét, és tudod, hogy izmos karjaival és hatalmas szárnyaival megpróbál majd megfullasztani. Előhúzod kardodat, melynek látványára ellenfeled azonnal örjöngeni kezd, hiszen éhsége kielégíthetetlen. Ez a harc lesz az egyik legnehezebb, amit meg kell itt vívnod.\r\n";
                    currentIndex++;
                    Galon(12, 8);
                    int choice23 = GetUserChoice23();
                    if (choice23 == 61)
                    {
                        currentIndex = 61;
                        SzovegList[121].Visible = false;
                        SzovegList[158].Visible = false;
                        SzovegList[61].Visible = true;
                        SzovegList[61].Text = "#61\nA hatalmas Galon tetemét melynek madárszerű karmai még mindig megfeszülnek és elernyednek, mintha még holtukban is szét akarnának tépni téged megkerülve kiutat keresel a helyiségből. E közben szépen lassan az oszlás büze tölti be a levegőt. A Madárember teste felé fordulsz, és még éppen megpillantod, amint bőrszárnyai eltünnek egy csapat vonagló lárva alatt. Néhány másodperccel később már csak a lerágott csontok maradnak meg egykori ellenfeledből. Amint elfogy élelmük, a férgek feled indulnak, te pedig ráébredsz, hogy halálos veszélyben vagy. Mivel a fura teremtmények közted és a bejárat között állnak, egy másik kiutat kell találnod. Tedd próbára SZERENCSED! Ha szerencséd van, lapozz a 109-re. Hogyha nincs szerencséd, lapozz a 175-re.\r\n";
                        currentIndex++;
                    }

                }
            }else if (choice21 == 121)
            {
                currentIndex = 121;
                SzovegList[87].Visible = false;
                SzovegList[121].Visible = true;
                SzovegList[121].Text = "#121\nNincs más választásod, minthogy a válladdal ronts neki az ajtónak. Nem lesz egy egyszerű feladat, mivel a szegecsek igen hosszúak és hegyesek. Lapozz a 196-ra.";
                currentIndex++;
                int choice22 = GetUserChoice22();
                if (choice22 == 196)
                {
                    currentIndex = 196;
                    SzovegList[121].Visible = false;
                    SzovegList[196].Visible = true;
                    SzovegList[196].Text = "#196\nAmennyire csak tudod, puha ruhadarabokkal béleled ki a vállad, behúzod a nyakad és az ajtónak rontasz. Dobj egy kockával. Ha az eredmény 1-4. megsérültél és vesztesz 2 ÉLETERŐ pontot. Ha azonban 5-öt vagy 6-ot dobtál, sikerült betörnöd az ajtót lapozz a 158-ra. Egészen addig kell próbálkoznod. míg ez nem sikerül.\r\n";
                    currentIndex++;
                    BetorAjto();
                    SzovegList[196].Visible = false;
                    SzovegList[158].Visible = true;
                    SzovegList[158].Text = "#158\nAz ajtó becsapódik, te pedig végre felfedezed a füttyszerű sóhajok és susogások forrását. Előtted, a padlón guggolva megpillantod a Galont, a Madárembert. Börszárnyai két oldalt széttárva állnak, kezének éles karmai feléd mutatnak. Azonnal felismered zöldes bőrét, és tudod, hogy izmos karjaival és hatalmas szárnyaival megpróbál majd megfullasztani. Előhúzod kardodat, melynek látványára ellenfeled azonnal örjöngeni kezd, hiszen éhsége kielégíthetetlen. Ez a harc lesz az egyik legnehezebb, amit meg kell itt vívnod.\r\n";
                    currentIndex++;
                    Galon(12, 8);
                    int choice23 = GetUserChoice23();
                    if (choice23 == 61)
                    {
                        currentIndex = 61;
                        SzovegList[121].Visible = false;
                        SzovegList[158].Visible = false;
                        SzovegList[61].Visible = true;
                        SzovegList[61].Text = "#61\nA hatalmas Galon tetemét melynek madárszerű karmai még mindig megfeszülnek és elernyednek, mintha még holtukban is szét akarnának tépni téged megkerülve kiutat keresel a helyiségből. E közben szépen lassan az oszlás büze tölti be a levegőt. A Madárember teste felé fordulsz, és még éppen megpillantod, amint bőrszárnyai eltünnek egy csapat vonagló lárva alatt. Néhány másodperccel később már csak a lerágott csontok maradnak meg egykori ellenfeledből. Amint elfogy élelmük, a férgek feled indulnak, te pedig ráébredsz, hogy halálos veszélyben vagy. Mivel a fura teremtmények közted és a bejárat között állnak, egy másik kiutat kell találnod. Tedd próbára SZERENCSED! Ha szerencséd van, lapozz a 109-re. Hogyha nincs szerencséd, lapozz a 175-re.\r\n";
                        currentIndex++;
                    }
                }
            }
            
        }//Kész a játékos vesztett
        private void Tovabb3_Click(object sender, EventArgs e)
        {
            tovabb3.Text = "Tovabb";
            tovabb3.Size = new Size(600, 75);
            tovabb3.Location = new Point(750, 850);
            tovabb2.Visible = false;
            tovabb4.Visible = false;
            tovabb5.Visible = false;
            SzovegList[76].Visible = false;
            SzovegList[6].Visible = true;
            SzovegList[6].Text = "#6\nAz ajtó egy nyugat felé haladó alagútba nyílik. Követed, míg egy elágazáshoz nem érsz. Ha észak felé akarsz fordulni, lapozz a 172-re. Ha nem akarsz letérni ebből a járatból. lapozz a 168-ra.";
            currentIndex++;
            int choice24 = GetUserChoice24();
            if (choice24 == 172)
            {
                currentIndex = 172;
                tovabb3.Visible = false;
                tovabb6.Visible = true;
                tovabb7.Visible = true;
                tovabb8.Visible = true;
                SzovegList[6].Visible = false;
                SzovegList[168].Visible = false;
                SzovegList[172].Visible = true;
                SzovegList[172].Text = "#172\nA folyosó gyorsan szélesedik, végül egy kisebb szoba méreteit ölti magára. Nem messze töled ismét összeszűkül, és újra egyszerű járatként folytatja életét. A padló közepén egy sekély aknát látsz. Ha gyorsan átgázolsz rajta, hogy a túloldalon folytathasd az utad, lapozz a 163-ra. Ha bele akarsz ugrani, lapozz a 185-rc. Ha visszatérnél az előző elágazáshoz, és ott nyugati irányba mennél tovább, lapozz a 168-ra.";
                currentIndex++;
                

            }
            else if (choice24 == 168)
            {
                currentIndex = 168;
                SzovegList[6].Visible = false;
                SzovegList[168].Visible = true;
                SzovegList[168].Text = "#168\nEgy újabb elágazáshoz érkezel. Ha észak felé mennél, lapozz a 161-re. Ha továbbra is nyugati irányba haladnál, lapozz a 73-ra.";

            }
        }
        private void Tovabb4_Click(object sender, EventArgs e)
        {
            tovabb4.Text = "Tovabb";
            tovabb4.Size = new Size(600, 75);
            tovabb3.Visible = false;
            tovabb2.Visible = false;
            tovabb5.Visible = false;
            SzovegList[76].Visible = false;
            SzovegList[111].Visible = true;
            SzovegList[111].Text = "#111\n";
        }
        private void Tovabb5_Click(object sender, EventArgs e)
        {
            tovabb5.Text = "Tovabb";
            tovabb5.Size = new Size(600, 75);
            tovabb4.Visible = false;
            tovabb3.Visible = false;
            tovabb2.Visible = false;
            SzovegList[76].Visible = false;
            SzovegList[53].Visible = true;
            SzovegList[53].Text = "#53\n";
        }
        private void Tovabb6_Click(object sender, EventArgs e)
        {
            tovabb6.Text = "Tovabb";
            tovabb6.Size = new Size(600, 75);
            tovabb7.Visible = false;
            tovabb8.Visible = false;
            tovabb3.Visible = false;
            tovabb2.Visible = false;
            SzovegList[172].Visible = false;
            SzovegList[163].Visible = true;
            SzovegList[163].Text = "#163\nAz alagút egy tágas, vízzel telt szobába vezet. A falakat misztikus minták borítják. Megmártózol a hűs vízben, de kijövet egy víz alatti kijáratot veszel észre. Nem tudod kinyitni, így végül visszaöltözöl és távozol. Visszatérsz a vermes ajtóhoz. Ha leugrasz, lapozz a 185-re. Ha inkább nyugat felé mész, lapozz a 168-ra.";
            currentIndex++;
            int choice25 = GetUserChoice25();
            if (choice25 == 185)
            {
                currentIndex = 185;
                SzovegList[163].Visible = false;
                SzovegList[169].Visible = false;
                SzovegList[185].Visible = true;
                SzovegList[185].Text = "#185\nLeugrasz a verembe, miután meggyözödtél róla, hogy ki fogsz tudni belőle mászni, ha ez szükségesnek bizonyulna. Mikor körbenézel, egy alacsony bejáratra bukkansz az egyik kinyúló szikladarab alatt. Szinte négykézlábra kell leereszkedned, hogy be tudj kukkantani rajta. Ha alaposabban is szét akarsz odabenn nézni, úgy lapozz a 178-ra. Ha inkább visszatérnél a szobába, lapozz a 172-re és válassz valami mást.";
                currentIndex++;
                int choice26 = GetUserChoice26();
                if (choice26 == 178)
                {
                    currentIndex = 178;
                    SzovegList[185].Visible = false;
                    SzovegList[169].Visible = false;
                    SzovegList[178].Visible = true;
                    SzovegList[178].Text = "#178\nAz alagút egyre alacsonyabbá és szűkebbé válik, így nehéz nem észrevenni az itt heverő kis, kék folyadékot tartalmazó üvegcsét. Lapozz a 34-re.";
                    currentIndex++;
                    int choice27 = GetUserChoice27();
                    if (choice27 == 34)
                    {
                        currentIndex = 34;
                        SzovegList[178].Visible = false;
                        SzovegList[169].Visible = false;
                        SzovegList[34].Visible = true;
                        SzovegList[34].Text = "#34\nA fiola erős mentaillatot áraszt magából. Ha meg akarod inni, lapozz a 102-re. Ha inkább hagyod, ahol van, lapozz a 169-re.";
                        currentIndex++;
                        int choice28 = GetUserChoice28();
                        if (choice28 == 102)
                        {
                            currentIndex = 102;
                            SzovegList[34].Visible = false;
                            SzovegList[169].Visible = false;
                            SzovegList[102].Visible = true;
                            SzovegList[102].Text = "#102\nMiután felhajtod az üvegcsében lévő italt, megdöbbenve tapasztalod, mennyivel jobban érzed most magad. Az üvegben a Szerencse Italának egy adagja volt. Növeld meg 1-el Kezdeti SZERENCSÉDET, majd állítsd vissza jelenlegi pontjaidat erre az új értékre. Folytatod a kúszást észak felé. Lapozz a 169-re.";
                            currentIndex++;
                            int choice29 = GetUserChoice29();
                            if (choice29 == 169)
                            {
                                currentIndex = 169;
                                SzovegList[102].Visible = false;
                                SzovegList[169].Visible = false;
                                SzovegList[169].Visible = true;
                                SzovegList[169].Text = "#169\nA folyosó végén egy kicsiny ajtót találsz. Ahogy figyelsz, különös, csobogó hangot hallasz átszűrődni rajta. Érintésedre különösen hűvösnek tűnik az anyaga. Ha ki akarod nyitni, lapozz a 164-re. Ha inkább\r\nhagyod, ahol van, lapozz vissza a 172-re és válassz valami mást.";
                                currentIndex++;
                                int choice30 = GetUserChoice30();
                                if (choice30 == 164)
                                {
                                    currentIndex = 164;
                                    SzovegList[169].Visible = false;
                                    SzovegList[164].Visible = true;
                                    SzovegList[164].Text = "#164\nAhogy lenyomod a kilincset, az ajtó kicsapódik, mintha valami hatalmas súly nyomná ki a túloldalon. Azonnal rájössz, hogy nagy hibát vétettél, mikor vízsugarak kezdenek el kispriccelni az apró réseken. Kétségbeesetten próbálod újra bezárni a kitörni készülő víztömeget ám hamar rájössz, hogy erre semmi esélyed, így más választásod nem lévén menekülni próbálsz. Az ajtó kicsapódik, a szűk járatban pedig esélyed sincs rá, hogy túléld a dolgot. A víz teljes tömege rád zúdul, te pedig azon nyomban megfulladsz. Kalandod itt véget ér.";
                                    currentIndex++;
                                    ShowGameOver();
                                }else if (choice30 == 172)
                                {
                                    currentIndex = 172;
                                    tovabb6.Text = "163";
                                    tovabb6.Size = new Size(150, 75);
                                    tovabb6.Location = new Point(750, 850);
                                    tovabb6.Visible = true;
                                    tovabb7.Visible = true;
                                    tovabb8.Visible = true;
                                    SzovegList[169].Visible = false;
                                    SzovegList[172].Visible = true;
                                    SzovegList[172].Text = "#172\nA folyosó gyorsan szélesedik, végül egy kisebb szoba méreteit ölti magára. Nem messze töled ismét összeszűkül, és újra egyszerű járatként folytatja életét. A padló közepén egy sekély aknát látsz. Ha gyorsan átgázolsz rajta, hogy a túloldalon folytathasd az utad, lapozz a 163-ra. Ha bele akarsz ugrani, lapozz a 185-rc. Ha visszatérnél az előző elágazáshoz, és ott nyugati irányba mennél tovább, lapozz a 168-ra.";
                                    currentIndex++;
                                }
                            }
                        }else if (choice28 == 169)
                        {
                            currentIndex = 169;
                            SzovegList[34].Visible = false;
                            SzovegList[169].Visible = true;
                            SzovegList[169].Text = "#169\nA folyosó végén egy kicsiny ajtót találsz. Ahogy figyelsz, különös, csobogó hangot hallasz átszűrődni rajta. Érintésedre különösen hűvösnek tűnik az anyaga. Ha ki akarod nyitni, lapozz a 164-re. Ha inkább\r\nhagyod, ahol van, lapozz vissza a 172-re és válassz valami mást.";
                            currentIndex++;
                            int choice30 = GetUserChoice30();
                            if (choice30 == 164)
                            {
                                currentIndex = 164;
                                SzovegList[169].Visible = false;
                                SzovegList[164].Visible = true;
                                SzovegList[164].Text = "#164\nAhogy lenyomod a kilincset, az ajtó kicsapódik, mintha valami hatalmas súly nyomná ki a túloldalon. Azonnal rájössz, hogy nagy hibát vétettél, mikor vízsugarak kezdenek el kispriccelni az apró réseken. Kétségbeesetten próbálod újra bezárni a kitörni készülő víztömeget ám hamar rájössz, hogy erre semmi esélyed, így más választásod nem lévén menekülni próbálsz. Az ajtó kicsapódik, a szűk járatban pedig esélyed sincs rá, hogy túléld a dolgot. A víz teljes tömege rád zúdul, te pedig azon nyomban megfulladsz. Kalandod itt véget ér.";
                                currentIndex++;
                                ShowGameOver();
                            }
                            else if (choice30 == 172)
                            {
                                currentIndex = 172;
                                tovabb6.Text = "163";
                                tovabb6.Size = new Size(150, 75);
                                tovabb6.Location = new Point(750, 850);
                                tovabb6.Visible = true;
                                tovabb7.Visible = true;
                                tovabb8.Visible = true;
                                SzovegList[169].Visible = false;
                                SzovegList[172].Visible = true;
                                SzovegList[172].Text = "#172\nA folyosó gyorsan szélesedik, végül egy kisebb szoba méreteit ölti magára. Nem messze töled ismét összeszűkül, és újra egyszerű járatként folytatja életét. A padló közepén egy sekély aknát látsz. Ha gyorsan átgázolsz rajta, hogy a túloldalon folytathasd az utad, lapozz a 163-ra. Ha bele akarsz ugrani, lapozz a 185-rc. Ha visszatérnél az előző elágazáshoz, és ott nyugati irányba mennél tovább, lapozz a 168-ra.";
                                currentIndex++;
                            }
                        }
                    }
                }else if (choice26 == 172)
                {
                    currentIndex = 172;
                    tovabb6.Text = "163";
                    tovabb6.Size = new Size(150, 75);
                    tovabb6.Location = new Point(750, 850);
                    tovabb6.Visible = true;
                    tovabb7.Visible = true;
                    tovabb8.Visible = true;
                    SzovegList[185].Visible = false;
                    SzovegList[172].Visible = true;
                    SzovegList[172].Text = "#172\nA folyosó gyorsan szélesedik, végül egy kisebb szoba méreteit ölti magára. Nem messze töled ismét összeszűkül, és újra egyszerű járatként folytatja életét. A padló közepén egy sekély aknát látsz. Ha gyorsan átgázolsz rajta, hogy a túloldalon folytathasd az utad, lapozz a 163-ra. Ha bele akarsz ugrani, lapozz a 185-rc. Ha visszatérnél az előző elágazáshoz, és ott nyugati irányba mennél tovább, lapozz a 168-ra.";
                    currentIndex++;
                }
            
            }else if (choice25 == 168)
            {
                currentIndex = 168;
                SzovegList[163].Visible = false;
                SzovegList[168].Visible = true;
                SzovegList[168].Text = "#168\nEgy újabb elágazáshoz érkezel. Ha észak felé mennél, lapozz a 161-re. Ha továbbra is nyugati irányba haladnál, lapozz a 73-ra.";
                currentIndex++;
                int choice31 = GetUserChoice31();
                if (choice31 == 161)
                {
                    currentIndex = 161;
                    SzovegList[73].Visible = false;
                    SzovegList[168].Visible = false;
                    SzovegList[161].Visible = true;
                    SzovegList[161].Text = "#161\nA járat egy négyzet alakú szobában ér véget, melyet a rothadó hús szaga tölt meg. A padló nagy részét két óriási, bugyborékoló sármedence teszi ki. Egy keskeny kifutó mely nem sokkal szélesebb, mint a lábfejed halad középen, a terem széleit pedig hasonlóan keskeny szegélyek futják körbe. Mindhárom út egy nyilásban fut össze az északi falon. Ha a jobboldalin haladnál végig. lapozz a 181-re. Ha a baloldalin, lapozz a 193-ra. Amennyiben a középső utat választanád, lapozz a 171-re.";
                    currentIndex++;
                }else if (choice31 == 73)
                {
                    currentIndex = 73;
                    SzovegList[168].Visible = false;
                    SzovegList[73].Visible = true;
                    SzovegList[73].Text = "#73\nTovábbra is nyugati irányba haladva észreveszed, hogy a járat egy kisebb sziklahalomban ér véget. Csákány és ásó nélkül itt esélyed sem lenne átjutni. Ahogy megfordulsz, hogy visszatérj az előző elágazáshoz, egy sötétebb folt egy újabb észak felé vezető alagút jelenlétét árulja el. Úgy döntesz, erre mész tovább. Lapozz a 174-re.";
                    currentIndex++;
                }
            }
        }
        private void Tovabb7_Click(object sender, EventArgs e)
        {
            tovabb7.Text = "Tovabb";
            tovabb7.Size = new Size(600, 75);
            tovabb6.Visible = false;
            tovabb8.Visible = false;
            tovabb3.Visible = false;
            tovabb2.Visible = false;
            SzovegList[172].Visible = false;
            SzovegList[163].Visible = true;
            SzovegList[185].Text = "#185\n";
        }
        private void Tovabb8_Click(object sender, EventArgs e)
        {
            tovabb8.Text = "Tovabb";
            tovabb8.Size = new Size(600, 75);
            tovabb6.Visible = false;
            tovabb7.Visible = false;
            tovabb3.Visible = false;
            tovabb2.Visible = false;
            SzovegList[172].Visible = false;
            SzovegList[163].Visible = true;
            SzovegList[168].Text = "#168\n";
        }
        private int GetUserChoice()
        {
            DialogResult result108v147 = MessageBox.Show("Ha továbbra is északnak tartasz, lapozz a 108-ra.(IGEN)\nHa a nyugati irányba leágazó új járaton mennél tovább, lapozz a 147-re.(NEM)",
                                                  "Válassz egy irányt!", MessageBoxButtons.YesNo);

            if (result108v147 == DialogResult.Yes)
            {
                return 108;
            }
            else if (result108v147 == DialogResult.No)
            {
                return 147;
            }
            return 108;
        }
        private int GetUserChoice2()
        {
            DialogResult result146v79 = MessageBox.Show("Hogyha egyenesen mész tovább, lapozz a 146 - ra.(IGEN)\n Ha letérsz jobbra, lapozz a 79-re.(NEM)", "Válassz egy irányt!", MessageBoxButtons.YesNo);

            if (result146v79 == DialogResult.Yes)
            {
                return 146;
            }
            else if (result146v79 == DialogResult.No)
            {
                return 79;
            }
            return 146;
        }
        private int GetUserChoice3()
        {
            DialogResult result51v80 = MessageBox.Show("Ha ki akarod nyitni az ajtót, lapozz az 51-re.(IGEN)\nHa letérsz jobbra, lapozz a 80-ra.(NEM)", "Válassz egy irányt!", MessageBoxButtons.YesNo);

            if (result51v80 == DialogResult.Yes)
            {
                return 51;
            }
            else if (result51v80 == DialogResult.No)
            {
                return 80;
            }
            return 51;
        }
        private int GetUserChoice4()
        {
            DialogResult result22v108 = MessageBox.Show("Hogyha ki szeretnéd nyitni, lapozz a 22-re.(IGEN)\nHa visszatérnél az elágazáshoz, és észak felé folytatnád az utad, lapozz a 108-ra.(NEM)", "Válassz egy irányt!", MessageBoxButtons.YesNo);

            if (result22v108 == DialogResult.Yes)
            {
                return 22;
            }
            else if (result22v108 == DialogResult.No)
            {
                return 108;
            }
            return 22;
        }
        private int GetUserChoice5()
        {
            DialogResult result146v79 = MessageBox.Show("Hogyha egyenesen mész tovább, lapozz a 146 - ra.(IGEN)\n Ha letérsz jobbra, lapozz a 79-re.(NEM)", "Válassz egy irányt!", MessageBoxButtons.YesNo);

            if (result146v79 == DialogResult.Yes)
            {
                return 146;
            }
            else if (result146v79 == DialogResult.No)
            {
                return 79;
            }
            return 146;
        }
        private int GetUserChoice6()
        {
            DialogResult result141v122 = MessageBox.Show("Ha erre mennél tovább, északi irányba, lapozz a 141-re.(IGEN)\nHa egyenesen folytatnád az utadat, lapozz a 122-re.(NEM)", "Válassz egy irányt!", MessageBoxButtons.YesNo);

            if (result141v122 == DialogResult.Yes)
            {
                return 141;
            }
            else if (result141v122 == DialogResult.No)
            {
                return 122;
            }
            return 141;
        }
        private int GetUserChoice7()
        {
            DialogResult result107v122 = MessageBox.Show("Ha ki szeretnéd nyitni és belépnél rajta, lapozz a 107-re.(IGEN)\nHa egyenesen folytatnád az utadat, lapozz a 122-re.(NEM)", "Válassz egy irányt!", MessageBoxButtons.YesNo);

            if (result107v122 == DialogResult.Yes)
            {
                return 107;
            }
            else if (result107v122 == DialogResult.No)
            {
                return 122;
            }
            return 107;
        }
        private int GetUserChoice8()
        {
            DialogResult result144 = MessageBox.Show("Tovább mersz haladni a 144-es mezőre?", "Válaszolj!", MessageBoxButtons.YesNo);

            if (result144 == DialogResult.Yes)
            {
                return 144;
            }
            return 144;
        }
        private int GetUserChoice9()
        {
            DialogResult result144 = MessageBox.Show("Tovább mersz haladni a 144-es mezőre?", "Válaszolj!", MessageBoxButtons.YesNo);

            if (result144 == DialogResult.Yes)
            {
                return 144;
            }
            return 144;
        }
        private int GetUserChoice10()
        {
            DialogResult result7v96 = MessageBox.Show("Ha szét akarsz nézni benne, lapozz a 7-re.(IGEN)\nHa inkább átugornád és kiderítenéd, mi a fényfolt forrása, lapozz a 96-ra.(NEM)", "Válassz egy irányt!", MessageBoxButtons.YesNo);

            if (result7v96 == DialogResult.Yes)
            {
                return 7;
            }else if (result7v96 == DialogResult.No)
            {
                return 96;
            }
            return 7;
        }
        private int GetUserChoice11()
        {
            DialogResult result80v140 = MessageBox.Show("Ha gyorsan kihátrálsz, majd becsapod magad mögött a bejárati ajtót, lapozz a 80-ra.(IGEN)\nHogyha megveted a lábad és megküzdesz ezekkel a szörnyű teremtményekkel, lapozz a 140-re.(NEM)", "Válassz egy irányt!", MessageBoxButtons.YesNo);

            if (result80v140 == DialogResult.Yes)
            {
                return 80;
            }else if (result80v140 == DialogResult.No)
            {
                return 140;
            }
            return 80;
        }
        private int GetUserChoice12()
        {
            DialogResult result89 = MessageBox.Show("Tovább mersz haladni a 89-es mezőre?", "Válassz egy irányt!", MessageBoxButtons.YesNo);

            if (result89 == DialogResult.Yes)
            {
                return 89;
            }
            return 89;
        }
        private int GetUserChoice13()
        {
            DialogResult result89 = MessageBox.Show("Tovább mersz haladni a 89-es mezőre?", "Válaszolj!", MessageBoxButtons.YesNo);

            if (result89 == DialogResult.Yes)
            {
                return 89;
            }
            return 89;
        }
        private int GetUserChoice14()
        {
            DialogResult result95v127 = MessageBox.Show("Hogyha a nyugati ágon folytatnád az utad, lapozz a 95-re.(IGEN)\nHa egyenesen mész tovább, lapozz a 127-re.(NEM)", "Válaszolj!", MessageBoxButtons.YesNo);

            if (result95v127 == DialogResult.Yes)
            {
                return 95;
            }else if (result95v127 == DialogResult.No)
            {
                return 127;
            }
            return 95;
        }
        private int GetUserChoice15()
        {
            DialogResult result153 = MessageBox.Show("Indulás a 153-as mezőre!(IGEN/NEM)", "Válaszolj!", MessageBoxButtons.YesNo);

            if (result153 == DialogResult.Yes)
            {
                return 153;
            }
            return 153;
        }
        private int GetUserChoice16()
        {
            DialogResult result42 = MessageBox.Show("Indulás a 42-as mezőre!(IGEN/NEM)", "Válaszolj!", MessageBoxButtons.YesNo);

            if (result42 == DialogResult.Yes)
            {
                return 42;
            }
            return 42;
        }
        private int GetUserChoice17()
        {
            DialogResult result27 = MessageBox.Show("Tovább mersz haladni a 27-es mezőre?", "Válaszolj!", MessageBoxButtons.YesNo);

            if (result27 == DialogResult.Yes)
            {
                return 27;
            }
            return 27;
        }
        private int GetUserChoice18()
        {
            DialogResult result40v2 = MessageBox.Show("Ha az első megoldást választod, lapozz a 40-re.(IGEN)\nHa úgy gondolod, elég jó úszó vagy, és ezzel próbálkoznál, lapozz a 2-re.(NEM)", "Válaszolj!", MessageBoxButtons.YesNo);

            if (result40v2 == DialogResult.Yes)
            {
                return 40;
            }
            else if (result40v2 == DialogResult.No)
            {
                return 2;
            }
            return 40;
        }
        private int GetUserChoice19()
        {
            DialogResult result60v75 = MessageBox.Show("Ha szerencsés vagy, lapozz a 60-ra.(IGEN)\nHa nem, lapozz a 75-re.(NEM)", "Válaszolj!", MessageBoxButtons.YesNo);

            if (result60v75 == DialogResult.Yes)
            {
                return 60;
            }
            else if (result60v75 == DialogResult.No)
            {
                return 75;
            }
            return 60;
        }
        private int GetUserChoice20()
        {
            DialogResult result76 = MessageBox.Show("Indulás a 76-os mezőre!(IGEN/NEM)", "Válaszolj!", MessageBoxButtons.YesNo);

                if (result76 == DialogResult.Yes)
                {
                    return 76;
                }
                return 76;
        }
        private int GetUserChoice21()
        {
            DialogResult result13v121 = MessageBox.Show("Ha van nálad egy Arany Kulcs, lapozz a 13-ra.(IGEN)\nHa nincsen, lapozz a 121-re.(NEM)", "Válaszolj!", MessageBoxButtons.YesNo);

            if (result13v121 == DialogResult.Yes)
            {
                return 13;
            }
            else if (result13v121 == DialogResult.No)
            {
                return 121;
            }
            return 13;
        }
        private int GetUserChoice22()
        {
            DialogResult result196 = MessageBox.Show("Indulás a 196-as mezőre!(IGEN/NEM)", "Válaszolj!", MessageBoxButtons.YesNo);

            if (result196 == DialogResult.Yes)
            {
                return 196;
            }
            return 196;
        }
        private int GetUserChoice23()
        {
            DialogResult result61 = MessageBox.Show("Indulás a 61-es mezőre!(IGEN/NEM)", "Válaszolj!", MessageBoxButtons.YesNo);

            if (result61 == DialogResult.Yes)
            {
                return 61;
            }
            return 61;
        }
        private int GetUserChoice24()
        {
            DialogResult result172v168 = MessageBox.Show("Ha észak felé akarsz fordulni, lapozz a 172-re.(IGEN)\nHa nem akarsz letérni ebből a járatból. lapozz a 168-ra.(NEM)", "Válaszolj!", MessageBoxButtons.YesNo);

            if (result172v168 == DialogResult.Yes)
            {
                return 172;
            }
            else if (result172v168 == DialogResult.No)
            {
                return 168;
            }
            return 172;
        }
        private int GetUserChoice25()
        {
            DialogResult result185v168 = MessageBox.Show("Ha most le akarsz itt ugrani, lapozz a 185-re.(IGEN)\n Ha inkább visszatérnél a korábban látott elágazáshoz és nyugat felé folytatnád az utad, lapozz a 168-ra.(NEM)", "Válaszolj!", MessageBoxButtons.YesNo);

            if (result185v168 == DialogResult.Yes)
            {
                return 185;
            }else if (result185v168 == DialogResult.No)
            {
                return 168;
            }
            return 185;
        }
        private int GetUserChoice26()
        {
            DialogResult result178v172 = MessageBox.Show("Ha alaposabban is szét akarsz odabenn nézni, úgy lapozz a 178-ra.(IGEN)\nHa inkább visszatérnél a szobába, lapozz a 172-re és válassz valami mást.(NEM)", "Válaszolj!", MessageBoxButtons.YesNo);

            if (result178v172 == DialogResult.Yes)
            {
                return 178;
            }else if (result178v172 == DialogResult.No)
            {
                return 172;
            }
            return 178;
        }
        private int GetUserChoice27()
        {
            DialogResult result34 = MessageBox.Show("Indulás a 34-es mezőre!(IGEN/NEM)", "Válaszolj!", MessageBoxButtons.YesNo);

            if (result34 == DialogResult.Yes)
            {
                return 34;
            }
            return 34;
        }
        private int GetUserChoice28()
        {
            DialogResult result102v169 = MessageBox.Show("Ha meg akarod inni, lapozz a 102-re.(IGEN)\nHa inkább hagyod, ahol van, lapozz a 169-re.(NEM)", "Válaszolj!", MessageBoxButtons.YesNo);

            if (result102v169 == DialogResult.Yes)
            {
                return 102;
            }else if (result102v169 == DialogResult.No)
            {
                return 169;
            }
            return 102;
        }
        private int GetUserChoice29()
        {
            DialogResult result169 = MessageBox.Show("Indulás a 169-es mezőre!(IGEN/NEM)", "Válaszolj!", MessageBoxButtons.YesNo);

            if (result169 == DialogResult.Yes)
            {
                return 169;
            }
            return 169;
        }
        private int GetUserChoice30()
        {
            DialogResult result164v172 = MessageBox.Show("Ha ki akarod nyitni, lapozz a 164-re.(IGEN)\nHa inkább hagyod, ahol van, lapozz vissza a 172-re és válassz valami mást.(NEM)", "Válaszolj!", MessageBoxButtons.YesNo);

            if (result164v172 == DialogResult.Yes)
            {
                return 164;
            }else if (result164v172 == DialogResult.No)
            {
                return 172;
            }
            return 164;
        }
        private int GetUserChoice31()
        {
            DialogResult result161v73 = MessageBox.Show("Ha észak felé mennél, lapozz a 161-re.(IGEN)\nHa továbbra is nyugati irányba haladnál, lapozz a 73-ra.(NEM)", "Válaszolj!", MessageBoxButtons.YesNo);

            if (result161v73 == DialogResult.Yes)
            {
                return 161;
            }else if (result161v73 == DialogResult.No)
            {
                return 73;
            }
            return 161;
        }
        private void BetorAjto()
        {
            Random rand = new Random();
            int kockaErtek = rand.Next(1, 7);

            if (kockaErtek >= 1 && kockaErtek <= 4)
            {
                MessageBox.Show("Megsérültél és vesztesz 2 ÉLETERŐ pontot.");
                playerStats.Hp -= 2;
                playerhp.Text = $"Hp:{playerStats.Hp}";
            }
            else if (kockaErtek >= 5 && kockaErtek <= 6)
            {
                MessageBox.Show("Sikerült betörnöd az ajtót. Lapozz a 158-ra.");
                currentIndex = 158;
            }

            if (kockaErtek < 5)
            {
                BetorAjto();
            }
        }
        private void ShowGameOver()
        {
            this.Controls.Clear();
            this.BackgroundImage = null;
            this.BackgroundImage = Image.FromFile("gameover.png");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            MessageBox.Show("Game Over!", "Vesztettél!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
        }
        private void Tolvaj(int enemySkill, int enemyStamina)
        {
            Player = new PictureBox()
            {
                Image = Image.FromFile("Player.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Transparent,
                Size = new Size(200, 350),
                Location = new Point(885, 650),
            };
            Controls.Add(Player);

            Enemy = new PictureBox()
            {
                Image = Image.FromFile("Tolvaj.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Transparent,
                Size = new Size(200, 350),
                Location = new Point(885, 65),
            };
            Controls.Add(Enemy);

            playerhp = new Label()
            {
                Text = "Hp: "+ playerStats.Hp.ToString(),
                Font = new Font("Arial", 20, FontStyle.Bold),
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup,
                Size = new Size(250,250),
                Location = new Point(910, 620),
                Visible = true

            };
            Controls.Add(playerhp);

            enemyhp = new Label()
            {
                Text = "Hp: " + enemyStamina.ToString(),
                Font = new Font("Arial", 20, FontStyle.Bold),
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup,
                Size = new Size(250, 250),
                Location = new Point(910, 430),
                Visible = true

            };
            Controls.Add(enemyhp);
            this.BackgroundImage = Image.FromFile("fightscene.png");

            Random rand = new Random();
            int playerStamina = playerStats.Hp;

            while (enemyStamina > 0 && playerStamina > 0)
            {
                int enemyAttack = enemySkill + rand.Next(1, 7) + rand.Next(1, 7);
                int playerAttack = playerStats.Skill + rand.Next(1, 7) + rand.Next(1, 7);

                if (playerAttack > enemyAttack)
                {
                    enemyStamina -= 2;
                }
                else if (enemyAttack > playerAttack)
                {
                    playerStamina -= 2;
                }

                if (playerStamina <= 0)
                {
                    continue;
                }
                else if (enemyStamina <= 0)
                {
                    SzovegList[1].Visible = false;
                    tovabb.Visible = false;
                    italok.Visible = false;
                    hp.Visible = false;
                    stamina.Visible = false;
                    luck.Visible = false;
                    Coins.Visible = false;
                    felszereles.Visible = false;
                    felszereles2.Visible = false;
                    MessageBox.Show("Győztél!", "Siker", MessageBoxButtons.OK);
                    this.BackgroundImage = Image.FromFile("bg.png");
                    Enemy.Visible = false;
                    Player.Visible = false;
                    playerhp.Visible = false;
                    enemyhp.Visible = false;
                    SzovegList[87].Visible = true;
                    tovabb.Visible = true;
                    italok.Visible = true;
                    hp.Visible = true;
                    stamina.Visible = true;
                    luck.Visible = true;
                    felszereles.Visible = true;
                    felszereles2.Visible = true;
                    Coins.Visible = true;
                    Coins.Text =$"Coins:{playerStats.Coins+3}";
                    Nyeremeny.Visible = true;
                    Nyeremeny.Text = $"3 Coint kaptál";
                    playerhp.Text =$"Hp:{playerStats.Hp}";
                    return;
                }
            }
        }
        private void Suni(int enemySkill, int enemyStamina)
        {
            SzovegList[153].Visible = false;
            Player = new PictureBox()
            {
                Image = Image.FromFile("Player.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Transparent,
                Size = new Size(200, 350),
                Location = new Point(885, 650),
            };
            Controls.Add(Player);

            Enemy = new PictureBox()
            {
                Image = Image.FromFile("Suni.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Transparent,
                Size = new Size(200, 350),
                Location = new Point(885, 65),
            };
            Controls.Add(Enemy);

            playerhp = new Label()
            {
                Text = "Hp: " + playerStats.Hp.ToString(),
                Font = new Font("Arial", 20, FontStyle.Bold),
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup,
                Size = new Size(250, 250),
                Location = new Point(910, 620),
                Visible = true

            };
            Controls.Add(playerhp);

            enemyhp = new Label()
            {
                Text = "Hp: " + enemyStamina.ToString(),
                Font = new Font("Arial", 20, FontStyle.Bold),
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup,
                Size = new Size(250, 250),
                Location = new Point(910, 430),
                Visible = true

            };
            Controls.Add(enemyhp);
            this.BackgroundImage = Image.FromFile("fightscene.png");

            Random rand = new Random();
            int playerStamina = playerStats.Hp;

            while (enemyStamina > 0 && playerStamina > 0)
            {
                int enemyAttack = enemySkill + rand.Next(1, 7) + rand.Next(1, 7);
                int playerAttack = playerStats.Skill + rand.Next(1, 7) + rand.Next(1, 7);

                if (playerAttack > enemyAttack)
                {
                    enemyStamina -= 2;
                }
                else if (enemyAttack > playerAttack)
                {
                    playerStamina -= 2;
                }

                if (playerStamina <= 0)
                {
                    continue;
                }
                else if (enemyStamina <= 0)
                {
                    SzovegList[1].Visible = false;
                    tovabb.Visible = false;
                    italok.Visible = false;
                    hp.Visible = false;
                    stamina.Visible = false;
                    luck.Visible = false;
                    felszereles.Visible = false;
                    felszereles2.Visible = false;
                    Coins.Visible = false;
                    MessageBox.Show("Győztél!", "Siker", MessageBoxButtons.OK);
                    this.BackgroundImage = Image.FromFile("bg.png");
                    Enemy.Visible = false;
                    Player.Visible = false;
                    playerhp.Visible = false;
                    enemyhp.Visible = false;
                    SzovegList[153].Visible = true;
                    SzovegList[153].Text = "#153\nMivel a tüskék nagyon mérgezőek, valahányszor beléd áll valamelyik, a szokásos 2 helyett 3 ÉLETERŐ pontot kell levonnod magadtól. Lapozz a 42-re.";
                    tovabb.Visible = true;
                    italok.Visible = true;
                    felszereles.Visible = true;
                    felszereles2.Visible = true;
                    hp.Visible = true;
                    stamina.Visible = true;
                    luck.Visible = true;
                    Coins.Visible = true;
                    playerhp.Text = $"Hp:{playerStats.Hp}";
                    return;
                }
            }
        }
        private void Galon(int enemySkill, int enemyStamina)
        {
            SzovegList[158].Visible = false;
            Player = new PictureBox()
            {
                Image = Image.FromFile("Player.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Transparent,
                Size = new Size(200, 350),
                Location = new Point(885, 650),
            };
            Controls.Add(Player);

            Enemy = new PictureBox()
            {
                Image = Image.FromFile("Ork.png"),
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.Transparent,
                Size = new Size(200, 350),
                Location = new Point(885, 65),
            };
            Controls.Add(Enemy);

            playerhp = new Label()
            {
                Text = "Hp: " + playerStats.Hp.ToString(),
                Font = new Font("Arial", 20, FontStyle.Bold),
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup,
                Size = new Size(250, 250),
                Location = new Point(910, 620),
                Visible = true

            };
            Controls.Add(playerhp);

            enemyhp = new Label()
            {
                Text = "Hp: " + enemyStamina.ToString(),
                Font = new Font("Arial", 20, FontStyle.Bold),
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Popup,
                Size = new Size(250, 250),
                Location = new Point(910, 430),
                Visible = true

            };
            Controls.Add(enemyhp);
            this.BackgroundImage = Image.FromFile("fightscene.png");

            Random rand = new Random();
            int playerStamina = playerStats.Hp;

            while (enemyStamina > 0 && playerStamina > 0)
            {
                int enemyAttack = enemySkill + rand.Next(1, 7) + rand.Next(1, 7);
                int playerAttack = playerStats.Skill + rand.Next(1, 7) + rand.Next(1, 7);

                if (playerAttack > enemyAttack)
                {
                    enemyStamina -= 2;
                }
                else if (enemyAttack > playerAttack)
                {
                    playerStamina -= 2;
                }

                if (playerStamina >= 0)
                {
                    ShowGameOver();
                }
                else if (enemyStamina <= 0)
                {
                    SzovegList[1].Visible = false;
                    tovabb.Visible = false;
                    italok.Visible = false;
                    hp.Visible = false;
                    stamina.Visible = false;
                    luck.Visible = false;
                    felszereles.Visible = false;
                    felszereles2.Visible = false;
                    Coins.Visible = false;
                    MessageBox.Show("Győztél!", "Siker", MessageBoxButtons.OK);
                    this.BackgroundImage = Image.FromFile("bg.png");
                    Enemy.Visible = false;
                    Player.Visible = false;
                    playerhp.Visible = false;
                    enemyhp.Visible = false;
                    SzovegList[158].Visible = true;
                    SzovegList[158].Text = "#153\nHa nyertél, lapozz a 61-re.";
                    tovabb.Visible = true;
                    italok.Visible = true;
                    felszereles.Visible=true;
                    felszereles2.Visible=true;
                    hp.Visible = true;
                    stamina.Visible = true;
                    luck.Visible = true;
                    Coins.Visible = true;
                    playerhp.Text = $"Hp:{playerStats.Hp}";
                    return;
                }
            }
            ShowGameOver();
        }
    }
}