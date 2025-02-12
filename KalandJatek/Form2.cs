﻿using System;
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
        private Button Exit;
        private Label italok;
        private Label hp;
        private Label stamina;
        private Label luck;
        private Label enemyhp;
        private Label playerhp;
        private Label Coins;
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
                lbl.Size = new Size(600, 250);
                lbl.Text = "#1\nBelöknek a lenti alagútba, és rád zárják az ajtót, kizárva ezzel a nyíláson át beszűrődő természetes világosságot. Innentől kezdve kizárólag a falra rögzített fáklyáktól remélhetsz valamennyi fényt. Ahogy szemed hozzászokik a homályhoz, látod, hogy az alagút észak felé indul. Nagyot sóhajtasz a dolog igazságtalansága felett, majd elindulsz abba az irányba. Lapozz a 41-re.";
                lbl.Location = new Point(750, 600);
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
                    Fight(7, 6);
                    tovabb.Visible = true;
                    tovabb.Text = "Tovabb";
                    SzovegList[87].Visible = true;
                    SzovegList[87].Text = "#85\r\nA Tolvajnál mindössze 3 Aranytallért és egy háromszög alakú, penészes gyümölcsöt találsz. Még soha nem láttál ehhez hasonlót, de gyanítod, hogy ez lehet a Xentos, a hosszú élet gyümölcse. Ha nem lenne ilyen borzalmas állapotban, gond nélkül megkockáztatnád, hogy belekóstolj, igy azonban úgy döntesz, hogy itt hagyod és folytatod az utad észak felé. Hamarosan egy útelágazáshoz érsz. Ha továbbra is északnak tartasz, lapozz a 108-ra. Ha a nyugati irányba leágazó új járaton mennél tovább, lapozz a 147-re.";
                    currentIndex++;

                    int choice = GetUserChoice();
                    if (choice == 108)
                    {
                        currentIndex = 108;
                    }
                    else if (choice == 147)
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
                    SzovegList[51].Text = "#51\n";
                    currentIndex++;
                    break;
                case 80:
                    tovabb.Text = "Tovabb";
                    SzovegList[146].Visible = false;
                    SzovegList[80].Visible = true;
                    SzovegList[80].Text = "#80\n";
                    currentIndex++;
                    break;
            }
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
            DialogResult result51v80 = MessageBox.Show("Ha ki akarod nyitni az ajtót, lapozz az 51-re.(IGEN)\nHa letérsz jobbra, lapozz a 79-re.(NEM)", "Válassz egy irányt!", MessageBoxButtons.YesNo);

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
        private void ShowGameOver()
        {
            this.Controls.Clear();
            this.BackgroundImage = null;
            this.BackgroundImage = Image.FromFile("gameover.png");
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void Fight(int enemySkill, int enemyStamina)
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
                    ShowGameOver();
                    Environment.Exit(0);
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
                    Coins.Visible = true;
                    Coins.Text =$"Coins:{playerStats.Coins+3}";
                    Nyeremeny.Visible = true;
                    Nyeremeny.Text = $"3 Coint kaptál";
                    playerhp.Text =$"Hp:{playerStats.Hp}";
                    return;
                }
            }
        }
    }
}