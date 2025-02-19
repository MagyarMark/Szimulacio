class Kaland{
    constructor(szoveg,akcio,ugras,ellenfelek,ellenfel,ellenfel2,ellenfel3,bg,TargyInfo,HaVan,ertek,haszeretne,haszeretnekopenyt,mennyiseg,targy){
        this.szoveg = szoveg;
        this.akcio = akcio;
        this.ugras = ugras;
        this.ellenfelek = ellenfelek;
        this.ellenfel = ellenfel;
        this.ellenfel2 = ellenfel2;
        this.ellenfel3 = ellenfel3;
        this.bg = bg;
        this.TargyInfo = TargyInfo;
        this.HaVan = HaVan;
        this.ertek = ertek;
        this.haszeretne = haszeretne;
        this.haszeretnekopenyt = haszeretnekopenyt
        this.mennyiseg = mennyiseg;
        this.targy = targy;
    }

}

class Jatekos {
    constructor(HP, Luck, Skill, Gold, Items = [], Crystals = [], Potions = [], Food = [], blessed = false, combatblessed = false, Halott = false, Elixir = false, firstBoot = true) {
        this.HP = HP;
        this.Luck = Luck;
        this.Skill = Skill;
        this.Gold = Gold;
        this.Items = [];
        this.Crystals = Crystals;
        this.Potions = Potions;
        this.Food = Food;
        this.lokacio = 0;
        this.kezdetiHP = HP;
        this.kezdetiLuck = Luck;
        this.kezdetiSkill = Skill;
        this.blessed = blessed;
        this.combatblessed = combatblessed;
        this.halott = Halott;
        this.Elixir = Elixir;
        this.firstBoot = firstBoot;
    }

    tortenetkezdes() {
        this.Items.push("Kard");
        this.Items.push("Bőrvért");
    }

    kezdetiszerencsenoveles(ertek) {
        this.kezdetiLuck += ertek;
        this.Luck = this.kezdetiLuck;
    }

    minuszluck(ertek) {
        if (this.blessed) {
            if (6 > this.Luck - ertek) {
                this.Luck = 6;
            } else {
                this.Luck -= ertek;
            }
        } else {
            this.Luck -= ertek;
        }
    }

    pluszluck(ertek) {
        if (this.Luck + ertek > this.kezdetiLuck) {
            this.Luck = this.kezdetiLuck;
        } else {
            this.Luck += ertek;
        }
    }

    jatekosSebzes(szam) {
        this.HP -= szam;
    }

    jatekosHeal(szam) {
        if (this.HP + szam > this.kezdetiHP) {
            this.HP = this.kezdetiHP;
        } else {
            this.HP += szam;
        }
    }

    lokaciovaltoztatas(szoba) {
        this.lokacio = szoba;
    }

    gameover() {
        this.HP = 0;
        this.Items = [];
        this.Potions = [];
        this.Crystals = [];
        this.halott = true;
    }

    pluszitem(inp) {
        this.Items.push(inp);
    }

    pluszpenz(inp) {
        this.Gold += inp;
    }

    pluszcrystal(inp) {
        this.Crystals.push(inp);
    }

    pluszital(inp) {
        this.Potions.push(inp);
    }

    JatekosBlessing() {
        this.blessed = true;
    }

    JatekosCombatBlessing() {
        this.combatblessed = true;
    }

    SzerencseElixirf() {
        this.Elixir = true;
    }

    lokaciostr() {
        this.lokacio = String(this.lokacio);
    }

    ugyessegitala() {
        this.Skill = this.kezdetiSkill;
        this.Potions = [];
    }

    hpital() {
        this.HP = this.kezdetiHP;
        this.Potions = [];
    }

    SzerencseItala() {
        this.Luck = this.kezdetiLuck;
        this.kezdetiLuck += 1;
        this.Potions = [];
    }

    toString() {
        return `Életerőd: ${this.HP}\nSzerencséd: ${this.Luck}\nÜgyeséged: ${this.Skill}\nHelyzeted: ${this.lokacio}\nPénzed: ${this.Gold}\nTárgyaid: ${this.Items}\nKristályaid: ${this.Crystals}\nItalaid: ${this.Potions}\nÉteleid: ${this.Food}`;
    }
}


var rooms = [];


async function loadKalandok() {
    const response = await fetch('Kaland.json');
    const data = await response.json();

    for (let key in data) {
        const kalandData = data[key];
        rooms.push(new Kaland(
            kalandData.szoveg,
            kalandData.akcio,
            kalandData.ugras,
            kalandData.ellenfelek,
            kalandData.ellenfel,
            kalandData.ellenfel2,
            kalandData.ellenfel3,
            kalandData.bg,
            kalandData.TargyInfo,
            kalandData.HaVan,
            kalandData.ertek,
            kalandData.haszeretne,
            kalandData.haszeretnekopenyt,
            kalandData.mennyiseg,
            kalandData.targy
        ));
    }
}
loadKalandok();

console.log(rooms)
let csatamod = 0;

function kockadobas() {
    return Math.floor(Math.random() * 6) + 1;
}

function duplakockadobas() {
    return kockadobas() + kockadobas();
}

player = new Jatekos(duplakockadobas() + 12, kockadobas() + 6, kockadobas() + 6, 20);
player.tortenetkezdes();
let probaltemar = false;
let fellvettekopenyt = false;

function szerencseproba(){
    if (player.Elixir) {
        if (duplakockadobas() + 1 <= player.Luck) {
            player.minuszluck(1);
            console.log("Szerencséd volt!");
            return true;
        } else {
            player.minuszluck(1);
            console.log("Nem szerencséd volt!");
            return false;
        }
    } else {
        if (duplakockadobas() <= player.Luck) {
            player.minuszluck(1);
            console.log("Szerencséd volt!");
            return true;
        } else {
            player.minuszluck(1);
            console.log("Nem szerencséd volt!");
            return false;
        }
    }
}

function start(){
    console.log("skibidi")
    document.getElementById("intro").style.display = "block";
    document.getElementById("nextBtn").style.display = "block";
    document.getElementById("title").style.display = "none";
    document.getElementById("bg").style.backgroundImage = 'url("/assets/bgs/test2.png")';
    document.getElementById("text").innerHTML = rooms[player.lokacio].szoveg;
}

function next(){
    player.lokaciovaltoztatas(rooms[player.lokacio].ugras[0])
    console.log(player.lokacio)
    document.getElementById("text").innerHTML = rooms[player.lokacio].szoveg;

    if(player.lokacio == 1){
        potionSelectScreen();
    }

}

function potionSelectScreen(){
    document.getElementById("potionSelectionScreen").style.display = "block";
    document.getElementById("intro").style.display = "none";
    document.getElementById("nextBtn").style.display = "none";
}

function selectedPotion(name){
    player.pluszital(name);
    document.getElementById("potionSelectionScreen").style.display = "none";
    //mehet a main game!
    document.getElementById("mainGame").style.display = "block";
    document.getElementById("mainGame").style.display = "block";
    document.getElementById("bg").style.backgroundImage = 'url("/assets/bg.png")';
    document.getElementById("bg").style.backgroundRepeat = 'no-repeat';
    document.getElementById("bg").style.backgroundSize = 'cover';
    document.getElementById("bg").style.backgroundPosition = "top bottom";
    document.getElementById("nextBtns").style.display = "block";

    nextTile(1);
    //D3A569
}

function nextTile(tileNum) {
    if(tileNum == -1){
        player.lokaciovaltoztatas(rooms[player.lokacio].ugras[0]);
    }else{
        player.lokaciovaltoztatas(tileNum);
    }
    document.getElementById("gametext").innerHTML = `<p>${rooms[player.lokacio].szoveg}</p>`;
    document.getElementById("gamenotifs").innerHTML = "";

    if(rooms[player.lokacio].ugras.length == 1){
        document.getElementById("nextBtn0").style.display = "block";
        document.getElementById("nextBtn0").setAttribute("onclick", `nextTile(${rooms[player.lokacio].ugras[0]})`);

        document.getElementById("nextBtn1").style.display = "none";
        document.getElementById("nextBtn2").style.display = "none";
        document.getElementById("nextBtn3").style.display = "none";
        document.getElementById("nextBtn4").style.display = "none";
    }else if(rooms[player.lokacio].ugras.length == 2){
        document.getElementById("nextBtn0").style.display = "none";
        document.getElementById("nextBtn1").style.display = "block";
        document.getElementById("nextBtn1").innerHTML = `<p>Lapozás: ${rooms[player.lokacio].ugras[0]}</p>`;
        document.getElementById("nextBtn1").setAttribute("onclick", `nextTile(${rooms[player.lokacio].ugras[0]})`);

        document.getElementById("nextBtn2").style.display = "block";
        document.getElementById("nextBtn2").innerHTML = `<p>Lapozás: ${rooms[player.lokacio].ugras[1]}</p>`;
        document.getElementById("nextBtn2").setAttribute("onclick", `nextTile(${rooms[player.lokacio].ugras[1]})`);

        document.getElementById("nextBtn3").style.display = "none";
        document.getElementById("nextBtn4").style.display = "none";
    }else if(rooms[player.lokacio].ugras.length == 3){
        document.getElementById("nextBtn0").style.display = "none";
        document.getElementById("nextBtn1").style.display = "block";
        document.getElementById("nextBtn1").innerHTML = `<p>Lapozás: ${rooms[player.lokacio].ugras[0]}</p>`;
        document.getElementById("nextBtn1").setAttribute("onclick", `nextTile(${rooms[player.lokacio].ugras[0]})`);

        document.getElementById("nextBtn2").style.display = "block";
        document.getElementById("nextBtn2").innerHTML = `<p>Lapozás: ${rooms[player.lokacio].ugras[1]}</p>`;
        document.getElementById("nextBtn2").setAttribute("onclick", `nextTile(${rooms[player.lokacio].ugras[1]})`);

        document.getElementById("nextBtn3").style.display = "block";
        document.getElementById("nextBtn3").innerHTML = `<p>Lapozás: ${rooms[player.lokacio].ugras[2]}</p>`;
        document.getElementById("nextBtn3").setAttribute("onclick", `nextTile(${rooms[player.lokacio].ugras[2]})`);

        document.getElementById("nextBtn4").style.display = "none";
    }else if(rooms[player.lokacio].ugras.length == 4){
        document.getElementById("nextBtn0").style.display = "none";
        document.getElementById("nextBtn1").style.display = "block";
        document.getElementById("nextBtn1").innerHTML = `<p>Lapozás: ${rooms[player.lokacio].ugras[0]}</p>`;
        document.getElementById("nextBtn1").setAttribute("onclick", `nextTile(${rooms[player.lokacio].ugras[0]})`);

        document.getElementById("nextBtn2").style.display = "block";
        document.getElementById("nextBtn2").innerHTML = `<p>Lapozás: ${rooms[player.lokacio].ugras[1]}</p>`;
        document.getElementById("nextBtn2").setAttribute("onclick", `nextTile(${rooms[player.lokacio].ugras[1]})`);

        document.getElementById("nextBtn3").style.display = "block";
        document.getElementById("nextBtn3").innerHTML = `<p>Lapozás: ${rooms[player.lokacio].ugras[2]}</p>`;
        document.getElementById("nextBtn3").setAttribute("onclick", `nextTile(${rooms[player.lokacio].ugras[2]})`);

        document.getElementById("nextBtn4").style.display = "block";
        document.getElementById("nextBtn4").innerHTML = `<p>Lapozás: ${rooms[player.lokacio].ugras[3]}</p>`;
        document.getElementById("nextBtn4").setAttribute("onclick", `nextTile(${rooms[player.lokacio].ugras[3]})`);
    }else{
        document.getElementById("nextBtn0").style.display = "none";
        document.getElementById("nextBtn1").style.display = "none";
        document.getElementById("nextBtn2").style.display = "none";
        document.getElementById("nextBtn3").style.display = "none";
        document.getElementById("nextBtn4").style.display = "none";
    }

    if (rooms[player.lokacio].akcio.includes("eleterovesztes")) {
        player.jatekosSebzes(rooms[player.lokacio].ertek);
        //            <p class="gamenotifsText"></p>
        document.getElementById("gamenotifs").innerHTML += `<p class="gamenotifsText">Elvesztettél ${rooms[player.lokacio].ertek}HP-t!</p>`;
    }
    if (rooms[player.lokacio].akcio.includes("hplossrng")) {
        let amt = kockadobas();
        player.jatekosSebzes(amt);
        document.getElementById("gamenotifs").innerHTML += `<p class="gamenotifsText">Elvesztettél ${amt}HP-t!</p>`;

    }
    if (rooms[player.lokacio].akcio.includes("szerencsevesztes")) {
        player.minuszluck(rooms[player.lokacio].ertek);
        document.getElementById("gamenotifs").innerHTML += `<p class="gamenotifsText">Elvesztettél ${rooms[player.lokacio].ertek} Szerencsét-t!</p>`;
    }
    if (rooms[player.lokacio].akcio.includes("Eleteronyeres")) {
        player.jatekosHeal(rooms[player.lokacio].ertek);
        document.getElementById("gamenotifs").innerHTML += `<p class="gamenotifsText">Nyertél ${rooms[player.lokacio].ertek}HP-t!</p>`;
    }
    if (rooms[player.lokacio].akcio.includes("szerencsenyeres")) {
        player.pluszluck(rooms[player.lokacio].ertek);
        document.getElementById("gamenotifs").innerHTML += `<p class="gamenotifsText">Nyertél ${rooms[player.lokacio].ertek}Szerencsét-t!</p>`;

    }
    if (rooms[player.lokacio].akcio.includes("luckblessing")) {
        document.getElementById("gamenotifs").innerHTML += `<p class="gamenotifsText">Kaptál egy Szerencse áldást!</p>`;
        player.JatekosBlessing();
    }
    if (rooms[player.lokacio].akcio.includes("combatblessing")) {
        document.getElementById("gamenotifs").innerHTML += `<p class="gamenotifsText">Kaptál egy Harci áldást!</p>`;
        player.JatekosCombatBlessing();
    }
    if (rooms[player.lokacio].akcio.includes("kezdetiszerencsenoveles")) {
        player.kezdetiszerencsenoveles(rooms[player.lokacio].ertek);
        document.getElementById("gamenotifs").innerHTML += `<p class="gamenotifsText">Nyertél ${rooms[player.lokacio].ertek}Kezdeti Szerencsét-t!</p>`;
    }
    if (rooms[player.lokacio].akcio.includes("szerencse+hpminusz")) {
        player.minuszluck(rooms[player.lokacio].ertek[0]);
        player.jatekosSebzes(rooms[player.lokacio].ertek[1]);
        document.getElementById("gamenotifs").innerHTML += `<p class="gamenotifsText">Vesztettél ${rooms[player.lokacio].ertek[1]}HP-t!</p>`;
        document.getElementById("gamenotifs").innerHTML += `<p class="gamenotifsText">Vesztettél ${rooms[player.lokacio].ertek[0]}Szerencsét-t!</p>`;
    }
    if (rooms[player.lokacio].akcio.includes("elixir")) {
        document.getElementById("gamenotifs").innerHTML += `<p class="gamenotifsText">Nyertél egy Szerencse Elixir-t!</p>`;
        player.SzerencseElixirf();
    }
    if (rooms[player.lokacio].akcio.includes("pluszlebeges")) {
        document.getElementById("gamenotifs").innerHTML += `<p class="gamenotifsText">Megkaptad a Lebegés Köpenyét!</p>`;
        player.pluszitem("Lebegés Köpenye")
    }
    if (rooms[player.lokacio].akcio.includes("pluszszobor")) {
        document.getElementById("gamenotifs").innerHTML += `<p class="gamenotifsText">Megkaptad az aranyszbrot!</p>`;
        player.pluszitem("Aranyszobor")
    }
    if (rooms[player.lokacio].akcio.includes("pluszgyuru")) {
        document.getElementById("gamenotifs").innerHTML += `<p class="gamenotifsText">Megkaptad a Ügyesség Gyürüjét!</p>`;
        player.pluszitem("Ügyesség Gyürüje")
    }
    if (rooms[player.lokacio].akcio.includes("pluszarany")) {
        document.getElementById("gamenotifs").innerHTML += `<p class="gamenotifsText">Kaptál egy Arankulcsot!</p>`;
        player.pluszitem("Aranykulcs")
    }
    if (rooms[player.lokacio].akcio.includes("+penz")) {
        player.pluszpenz(rooms[player.lokacio].mennyiseg[0]);
        document.getElementById("gamenotifs").innerHTML += `<p class="gamenotifsText">Kaptál ${rooms[player.lokacio].mennyiseg[0]} Aranyat-t!</p>`;
    }
    if (rooms[player.lokacio].akcio.includes("+kristaly")) {
        player.pluszcrystal(rooms[player.lokacio].targy);
        document.getElementById("gamenotifs").innerHTML += `<p class="gamenotifsText">Mostantól tiéd a(z) ${rooms[player.lokacio].targy} nevű tárgy</p>`;
    }
    if (rooms[player.lokacio].akcio.includes("csatamod")) {
        csatamod = rooms[player.lokacio].ertek;
    }
    if(rooms[player.lokacio].akcio.includes("onharc")){
        harc(csatamod, "te", player.HP, player.Skill);
        csatamod = 0;
    }
    if(rooms[player.lokacio].akcio.includes("harc")){
        if(rooms[player.lokacio].ellenfelek == 1){
            harc(csatamod , rooms[player.lokacio].ellenfel.nev, rooms[player.lokacio].ellenfel.HP, rooms[player.lokacio].ellenfel.ugyesseg);
        }else if (rooms[player.lokacio].ellenfelek == 2){
            harc(csatamod , rooms[player.lokacio].ellenfel.nev, rooms[player.lokacio].ellenfel.HP, rooms[player.lokacio].ellenfel.ugyesseg);
            harc(csatamod , rooms[player.lokacio].ellenfel2.nev, rooms[player.lokacio].ellenfel2.HP, rooms[player.lokacio].ellenfel2.ugyesseg);
        }else if (rooms[player.lokacio].ellenfelek == 3){
            harc(csatamod , rooms[player.lokacio].ellenfel.nev, rooms[player.lokacio].ellenfel.HP, rooms[player.lokacio].ellenfel.ugyesseg);
            harc(csatamod , rooms[player.lokacio].ellenfel2.nev, rooms[player.lokacio].ellenfel2.HP, rooms[player.lokacio].ellenfel2.ugyesseg);
            harc(csatamod , rooms[player.lokacio].ellenfel3.nev, rooms[player.lokacio].ellenfel3.HP, rooms[player.lokacio].ellenfel3.ugyesseg);
        }
        csatamod = 0;
    }
    
    if (rooms[player.lokacio].akcio.includes("gyozelem")){
        Nyert = true
        document.getElementById("mainGame").style.display = "none";
        document.getElementById("bg").style.backgroundImage = 'url("/assets/win.png")';
    }
    if (rooms[player.lokacio].akcio.includes("gameover")) {
        Nyert = false   
        player.gameover()
        gameover();
    }

    if(rooms[player.lokacio].akcio.includes("rollllll")) {
        let a = 0;
        while (true){
            if (kockadobas() > 4){
                break;
            }
            else {
                player.jatekosSebzes(2);
                a+=2;
            }
        }
        if(a>0){
            document.getElementById("gamenotifs").innerHTML += `<p class="gamenotifsText">Vesztettél ${a}HP-t!</p>`;
        }
    }
    if(rooms[player.lokacio].akcio.includes("kisebbnagyonbb")) {
        if(duplakockadobas() > player.Skill) {
            document.getElementById("nextBtn0").style.display = "block";
            document.getElementById("nextBtn1").style.display = "none";
            document.getElementById("nextBtn2").style.display = "none";
            document.getElementById("nextBtn3").style.display = "none";
            document.getElementById("nextBtn4").style.display = "none";
            document.getElementById("nextBtn0").setAttribute("onclick", `nextTile(${rooms[player.lokacio].ugras[0]})`);
            document.getElementById("gamenotifs").innerHTML += `<p class="gamenotifsText">szerencséd volt!</p>`;
        }else{
            document.getElementById("nextBtn0").style.display = "block";
            document.getElementById("nextBtn1").style.display = "none";
            document.getElementById("nextBtn2").style.display = "none";
            document.getElementById("nextBtn3").style.display = "none";
            document.getElementById("nextBtn4").style.display = "none";
            document.getElementById("nextBtn0").setAttribute("onclick", `nextTile(${rooms[player.lokacio].ugras[1]})`);
            document.getElementById("gamenotifs").innerHTML += `<p class="gamenotifsText">nem volt szerencséd!</p>`;
        }
    }
    if(rooms[player.lokacio].akcio.includes("szerencseproba")) {
        if (szerencseproba()) {
            document.getElementById("nextBtn0").setAttribute("onclick", `nextTile(${rooms[player.lokacio].HaVan})`);
            document.getElementById("gamenotifs").innerHTML += `<p class="gamenotifsText">szerencséd volt!</p>`;
        }else{
            document.getElementById("nextBtn0").setAttribute("onclick", `nextTile(${rooms[player.lokacio].ugras[0]})`);
            document.getElementById("gamenotifs").innerHTML += `<p class="gamenotifsText">Nem volt szerencséd!</p>`;
        }
    }
    if(!probaltemar){
        if(rooms[player.lokacio].akcio.includes("gyuruproba")) {
            //igen v nem
            if (szerencseproba()) {
                document.getElementById("nextBtn0").setAttribute("onclick", `nextTile(${rooms[player.lokacio].HaVan})`);
            }else{
                document.getElementById("nextBtn0").setAttribute("onclick", `nextTile(${rooms[player.lokacio].ugras[0]})`);
            }
        }
    }

    if (!fellvettekopenyt) {
        if(rooms[player.lokacio].akcio.includes("kopeny")){
            document.getElementById("nextBtn0").setAttribute("onclick", `nextTile(${rooms[player.lokacio].haszeretnekopenyt})`);
        }
    }

    if(rooms[player.lokacio].akcio.includes("targy")){
        if(player.Items.includes(rooms[player.lokacio].TargyInfo['szukseges'])){
            document.getElementById("nextBtn0").setAttribute("onclick", `nextTile(${rooms[player.lokacio].TargyInfo['HaVan']})`);
            document.getElementById("nextBtn1").setAttribute("onclick", `nextTile(${rooms[player.lokacio].TargyInfo['HaVan']})`);
            document.getElementById("nextBtn1").innerHTML = `<p>Lapozás: ${rooms[player.lokacio].TargyInfo['HaVan']}</p>`;
            document.getElementById("gamenotifs").innerHTML += `<p class="gamenotifsText">Nálad van a tárgy!</p>`;
        }else{
            document.getElementById("gamenotifs").innerHTML += `<p class="gamenotifsText">Nincs nálad a tárgy!</p>`;
            document.getElementById("nextBtn0").setAttribute("onclick", `nextTile(${rooms[player.lokacio].ugras[0]})`);
            document.getElementById("nextBtn1").innerHTML = `<p>Lapozás: ${rooms[player.lokacio].ugras[0]}</p>`;
            document.getElementById("nextBtn1").setAttribute("onclick", `nextTile(${rooms[player.lokacio].ugras[0]})`);
        }
    }

    if(player.lokacio == 77 && !player.Items.includes("Aranyszobor")){
        document.getElementById("nextBtn3").style.display = "none";
    }

    updateStatTXTs();
    updateItems();
}

function updateStatTXTs(){
    document.getElementById("hpNum").innerHTML = player.HP;
    document.getElementById("luckNum").innerHTML = player.Luck;
    document.getElementById("skillNum").innerHTML = player.Skill;
    document.getElementById("coinamt").innerHTML = player.Gold;
}

function updateItems(){
    //items
    for (let i = 0; i < player.Items.length; i++) {
        document.getElementById(`itemInventoryPic${i+1}`).setAttribute("src", `/assets/${player.Items[i]}.png`);
        console.log(`itemInventoryPic${i+1}`+" "+`/assets/${player.Items[i]}.png`)
    }
    for(let i = 0; i < 6; i++) {
        if(player.Items.length < i+1){
            document.getElementById(`itemInventoryPic${i+1}`).setAttribute("src", ``);
        }
    }

    //food
    for (let i = 0; i < player.Food.length; i++) {
        document.getElementById(`foodPic${i+1}`).setAttribute("src", `/assets/${player.Items[i]}.png`);
        console.log(`foodPic${i+1}`+" "+`/assets/${player.Food[i]}.png`)
    }
    for(let i = 0; i < 3; i++) {
        if(player.Food.length < i+1){
            document.getElementById(`foodPic${i+1}`).setAttribute("src", ``);
        }
    }

    //ékkő
    for (let i = 0; i < player.Crystals.length; i++) {
        document.getElementById(`gemstonePic${i+1}`).setAttribute("src", `/assets/${player.Crystals[i]}.png`);
        console.log(`gemstonePic${i+1}`+" "+`/assets/${player.Crystals[i]}.png`)
    }
    for(let i = 0; i < 3; i++) {
        if(player.Crystals.length < i+1){
            document.getElementById(`gemstonePic${i+1}`).setAttribute("src", ``);
        }
    }
    //italok
    for (let i = 0; i < player.Potions.length; i++) {
        document.getElementById(`drinkPic${i+1}`).setAttribute("src", `/assets/${player.Potions[i]}.png`);
        console.log(`drinkPic${i+1}`+" "+`/assets/${player.Potions[i]}.png`)
        if(player.Potions[i]== "luck"){
            document.getElementById(`drinkPic${i+1}`).setAttribute("onclick", "drinkSkill()")
        }else if(player.Potions[i]== "hp"){
            document.getElementById(`drinkPic${i+1}`).setAttribute("onclick", "drinkhp()")
        }else{
            document.getElementById(`drinkPic${i+1}`).setAttribute("onclick", "drinkluck()")
        }
    }
    for(let i = 0; i < 3; i++) {
        if(player.Potions.length < i+1){
            document.getElementById(`drinkPic${i+1}`).setAttribute("src", ``);
        }
    }
}

let whoAttacked = "";

//csatamod, "te", player.HP, player.Skill
function harc(csatamod, név, hp, skill){
    document.getElementById("mainGame").style.display = "none";
    document.getElementById("fight").style.display = "block";
    document.getElementById("bg").style.backgroundImage = 'url("/assets/bgs/bgs/fightscene.png")';
    document.getElementById("enemyPic").setAttribute("src", `/assets/${név}.png`);

    let EllensegAttackSTR = duplakockadobas() + skill;
    let JatekosAttackSTR = duplakockadobas() + player.Skill;

    if (Jatekos.combatblessed){
        JatekosAttackSTR = JatekosAttackSTR + 1
    }
    if (csatamod > 0){
        JatekosAttackSTR = JatekosAttackSTR - csatamod
    }
    if(EllensegAttackSTR < JatekosAttackSTR){
        whoAttacked = "player";
        hp = hp - 2;
        document.getElementById("fightDecider").innerHTML = `Megsebezted az ellenfelet!`;
        if(hp < 1){
            document.getElementById("mainGame").style.display = "block";
            document.getElementById("fight").style.display = "none";
            document.getElementById("bg").style.backgroundImage = 'url("/assets/bg.png")';
            console.log("player win")
            updateItems();
            updateStatTXTs();
            document.getElementById("gamenotifs").innerHTML += `<p class="gamenotifsText">Megnyerted a harcot!</p>`;
        }   
        document.getElementById("luckY").setAttribute("onclick", `szerencseprobas(${csatamod},"${név}",${hp},${skill},"${whoAttacked}")`);
        document.getElementById("luckN").setAttribute("onclick", `harc(${csatamod},"${név}",${hp},${skill})`);
    }else if (EllensegAttackSTR > JatekosAttackSTR){
        whoAttacked = "enemy";
        player.jatekosSebzes(2);
        document.getElementById("fightDecider").innerHTML = `Megsebzett az ellenfél!`;
        if(player.HP < 1){
            //lose fight
            console.log("player lose")
            gameover();
        }   
        document.getElementById("luckY").setAttribute("onclick", `szerencseprobas(${csatamod},"${név}",${hp},${skill},"${whoAttacked}")`);
        document.getElementById("luckN").setAttribute("onclick", `harc(${csatamod},"${név}",${hp},${skill})`);
    }else{
        harc(csatamod, név, hp, skill)
    }

    document.getElementById("yourHp").innerHTML = `HP: ${player.HP}`;
    document.getElementById("enemyHp").innerHTML = `HP: ${hp}`;
}

function szerencseprobas(csatamod, név, hp, skill, whoAttacked){
    if (whoAttacked == "player"){
        if(szerencseproba()){
            hp = hp - 2
        }else{
            hp = hp + 1
        }
    }else{
        if(szerencseproba()){
            player.jatekosHeal(1);
        }else{
            player.jatekosSebzes(2);
            if(player.HP < 1){
                gameover();
            }
        }
    }
    harc(csatamod, név, hp, skill)
}

function gameover(){
    document.getElementById("mainGame").style.display = "none";
    document.getElementById("fight").style.display = "none";
    document.getElementById("bg").style.backgroundImage = 'url("/assets/gamover.png")';
}

function drinkSkill(){
    player.ugyessegitala();
    updateItems();
    updateStatTXTs();
}

function drinkhp(){
    player.hpital();
    updateItems();
    updateStatTXTs();
}

function drinkluck(){
    player.SzerencseItala();
    updateItems();
    updateStatTXTs();
}