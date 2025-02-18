# Ítélet Labirintusa - Programleírás

**Készítette:** Magyar Márk József, Nagy Levéd Sámuel

## Program Célja
Az Ítélet Labirintusa egy interaktív, történetvezérelt kalandjáték, ahol a játékos egy mágikus labirintusban próbál túlélni és kijutni. A játék véletlenszerű elemeket, statisztika-generálást és harcrendszert tartalmaz.

## Program Funkciói
### 1. Játék indítása
- A játék üdvözli a játékost és megjeleníti az alapsztorit.
- Véletlenszerű kezdő statisztikák generálása:
  - Életerő (HP)
  - Ügyesség
  - Szerencse
  - Pénz (aranytallérok)
- A játékos továbbléphet vagy kiléphet.

### 2. Labirintus bejárása
- A játékos elágazásokhoz ér, ahol döntéseket kell hoznia.
- Találhat tárgyakat, harcolhat ellenfelekkel, vagy csapdákba eshet.

### 3. Harc mechanika
- Kockadobás-alapú harcrendszer.
- A játékos és az ellenfél dob két 6-oldalú kockával.
- Akinek nagyobb az összeg, az támad, és a másik veszít 2 HP-t.

### 4. Szerencsepróba
- A játékos két kockával dob, és összeveti az eredményt a szerencse statisztikájával.
- Siker esetén extra jutalom, kudarc esetén sebzés.

### 5. Nyertes és vesztes helyzetek
- A játék véget ér, ha a játékos meghal (0 HP), kijut, vagy kilép.
- A végén összesítést kap: szerzett arany, tárgyak, legyőzött ellenfelek.

## Működési Elv
### 1. Játék indítása
A program véletlenszerű statisztikákat generál és elindítja a kalandot.

### 2. Játékmenet – Labirintus bejárása
A játékos döntéseket hoz, harcol, tárgyakat szerez, eseményeket él át.

### 3. Harc és események kezelése
Kockadobásos mechanika alapján zajlik a harc és a szerencsepróba.

### 4. Játék vége és statisztika kiírása
Megjelenik a végső eredmény: arany, tárgyak, legyőzött ellenfelek.

## Program Kinézete
### 1. Form1
![image](https://github.com/user-attachments/assets/72606e83-ca9d-4d66-a38e-6220401bd8b0)

### 2. Form2 
![image](https://github.com/user-attachments/assets/e259dea3-91aa-4005-85b3-24c713be58e7)

## A kezdő ital után
  
![image](https://github.com/user-attachments/assets/d01dc5ce-b15b-4992-b923-cdd5224094c2)

## Harc megjelenés

![image](https://github.com/user-attachments/assets/f960e97a-de86-441d-9a15-d3ec13ba22a2)

## Egyedi Icon

![image](https://github.com/user-attachments/assets/b8210a36-5828-4011-97e0-de7c9db43a66)



