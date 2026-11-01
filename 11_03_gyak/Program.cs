

// ============================================================================
// 1. FELADAT: OSZTÁLYZAT-KALKULÁTOR
// ============================================================================
int pontszam;

do
{
    Console.Write("Kérlek, add meg a dolgozat pontszámát (0-100): ");
    string bemenet1 = Console.ReadLine();

    if (int.TryParse(bemenet1, out pontszam) && pontszam >= 0 && pontszam <= 100)
    {
        break;
    }

    Console.WriteLine("Hiba: Érvénytelen érték! Kérlek, egy 0 és 100 közötti egész számot adj meg.");
    Console.WriteLine();
} while (true);

string jegy;
ConsoleColor szin;

if (pontszam <= 39)
{
    jegy = "elégtelen";
    szin = ConsoleColor.Red;
}
else if (pontszam <= 54)
{
    jegy = "elégséges";
    szin = ConsoleColor.Yellow;
}
else if (pontszam <= 69)
{
    jegy = "közepes";
    szin = ConsoleColor.Yellow;
}
else if (pontszam <= 84)
{
    jegy = "jó";
    szin = ConsoleColor.Yellow;
}
else
{
    jegy = "jeles";
    szin = ConsoleColor.Green;
}

Console.Write("A dolgozatra kapott osztályzatod: ");
Console.ForegroundColor = szin;
Console.Write(jegy);
Console.ResetColor();
Console.WriteLine(".");
Console.WriteLine("\n----------------------------------------\n");


// ============================================================================
// 2. FELADAT: KONCERT / BULI BELÉPŐ
// ============================================================================
int eletkkor;

while (true)
{
    Console.Write("Kérlek, add meg az életkorodat: ");
    string bemenet2 = Console.ReadLine();

    if (int.TryParse(bemenet2, out eletkkor) && eletkkor >= 0)
    {
        break;
    }

    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Hiba: Érvénytelen érték! Kérlek, egy 0-nál nagyobb vagy egyenlő egész számot adj meg.");
    Console.ResetColor();
    Console.WriteLine();
}

bool bemehet = true;

if (eletkkor < 16)
{
    Console.WriteLine("Mivel még nem vagy 16 éves, egyedül nem mehetsz be a buliba.");
    char gomb;
    do
    {
        Console.Write("Van veled felnőtt kísérő? (i/n): ");
        gomb = char.ToLower(Console.ReadKey().KeyChar);
        Console.WriteLine();
    } while (gomb != 'i' && gomb != 'n');

    if (gomb == 'n')
    {
        bemehet = false;
    }
}

Console.WriteLine();
if (bemehet)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Bemehetsz a buliba!");
}
else
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Sajnálom, de nem mehetsz be a buliba.");
}
Console.ResetColor();
Console.WriteLine("\n----------------------------------------\n");


// ============================================================================
// 3. FELADAT: HÉT NAPJA
// ============================================================================
int napSorszam;

// Átalakítottuk ezt is makacs beolvasássá, hogy ne omoljon össze a return miatt!
while (true)
{
    Console.Write("Kérlek, add meg egy nap sorszámát (1-7): ");
    string bemenet3 = Console.ReadLine();

    // Ha JÓ a szám, kilépünk a beolvasásból és megyünk tovább
    if (int.TryParse(bemenet3, out napSorszam) && napSorszam >= 1 && napSorszam <= 7)
    {
        break;
    }

    // Ha ROSSZ a szám, kiírja a hibát és újra kéri
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Hiba: Érvénytelen sorszám! Kérlek, 1 és 7 közötti számot adj meg.");
    Console.ResetColor();
    Console.WriteLine();
}

string napNeve = napSorszam switch
{
    1 => "hétfő",
    2 => "kedd",
    3 => "szerda",
    4 => "csütörtök",
    5 => "péntek",
    6 => "szombat",
    7 => "vasárnap",
    _ => ""
};

bool hetvege = (napSorszam == 6 || napSorszam == 7);

Console.Write($"A megadott nap: ");

if (hetvege)
{
    Console.ForegroundColor = ConsoleColor.Cyan;
}
Console.Write(napNeve);
Console.ResetColor();

string napTipus = hetvege ? "hétvége" : "hétköznap";
Console.WriteLine($", ami egy {napTipus}.");


//4.fel

// Bemenetek bekérése és konvertálása
Console.Write("Kérjük, adja meg a beszállni készülő személyek számát: ");
int szemelyekSzama = int.Parse(Console.ReadLine());

Console.Write("Kérjük, adja meg a beszállók össztömegét (kg): ");
double ossztomeg = double.Parse(Console.ReadLine());

// Határértékek definiálása
const int MaxSzemely = 6;
const double MaxTomeg = 450.0;

// Feltételek ellenőrzése
bool szemelyTullepve = szemelyekSzama > MaxSzemely;
bool tomegTullepve = ossztomeg > MaxTomeg;

// Kiértékelés és mondatszerű kiírás
if (!szemelyTullepve && !tomegTullepve)
{
    Console.WriteLine("A lift biztonságosan elindulhat.");
}
else
{
    Console.WriteLine("A lift nem indulhat el!");

    // A szövegszín átállítása pirosra a hibák kiírásához
    Console.ForegroundColor = ConsoleColor.Red;

    if (szemelyTullepve && tomegTullepve)
    {
        Console.WriteLine("Sérült korlátok: A megengedett személyek száma és a maximális össztömeg is túl lett lépve!");
    }
    else if (szemelyTullepve)
    {
        Console.WriteLine($"Sérült korlát: A beszállni kívánó személyek száma meghaladja a maximumot ({MaxSzemely} fő)!");
    }
    else if (tomegTullepve)
    {
        Console.WriteLine($"Sérült korlát: Az össztömeg meghaladja a maximális teherbírást ({MaxTomeg} kg)!");
    }

    // A konzolszín visszaállítása az alapértelmezettre
    Console.ResetColor();
}

//5. fel


// Bummok számolásához szükséges akkumulátor változó
int bummSzamlalo = 0;

// Ciklus 1-től 100-ig
for (int i = 1; i <= 100; i++)
{
    // Feltétel: osztható 7-tel (i % 7 == 0) VAGY 7-re végződik (i % 10 == 7)
    if (i % 7 == 0 || i % 10 == 7)
    {
        // Szövegszín átállítása pirosra
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("BUMM! ");

        // Szín visszaállítása az alapértelmezettre
        Console.ResetColor();

        // Darabszám növelése
        bummSzamlalo++;
    }
    else
    {
        // Normál szám kiírása fehéren/alapértelmezett színnel
        Console.Write($"{i} ");
    }
}

// Sorválasztás a szebb megjelenésért
Console.WriteLine("\n");

// Végeredmény kiírása
Console.WriteLine($"A játék során összesen {bummSzamlalo} BUMM! hangzott el.");


//6. fel

// A címletek tömbje csökkenő sorrendben – így elkerüljük a bűvös számokat
int[] cimletek = { 20000, 10000, 5000, 2000, 1000 };

int osszeg = 0;
bool sikeresBeolvasas = false;

// Makacs beolvasás do-while ciklussal, amíg nem megfelelő az összeg
do
{
    Console.Write("Kérjük, adja meg a felvenni kívánt összeget (Ft): ");
    string bemenet = Console.ReadLine();

    // Ellenőrizzük, hogy szám-e, és hogy osztható-e 1000-rel
    if (int.TryParse(bemenet, out osszeg) && osszeg > 0 && osszeg % 1000 == 0)
    {
        sikeresBeolvasas = true;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Hiba! Csak 1000-rel osztható pozitív egész számot adhat meg.");
        Console.ResetColor();
    }

} while (!sikeresBeolvasas);

Console.WriteLine("\nA kiadott bankjegyek:");

// Címletek kiszámítása és kiírása
int maradekOsszeg = osszeg;

foreach (int cimlet in cimletek)
{
    // Megnézzük, hányszor van meg az adott címlet a maradék összegben
    int darab = maradekOsszeg / cimlet;

    // Ha az adott címletből ad ki a gép, kiírjuk és csökkentjük a maradékot
    if (darab > 0)
    {
        Console.WriteLine($"- {cimlet,6} Ft-os bankjegy: {darab} db");
        maradekOsszeg %= cimlet; // A maradékot vesszük a következő körre
    }
}


//7.fel

int evszam = 0;
int honap = 0;
bool sikeresEv = false;
bool sikeresHonap = false;

// 1. Makacs évszám bekérés
do
{
    Console.Write("Kérjük, adja meg az évszámot: ");
    if (int.TryParse(Console.ReadLine(), out evszam) && evszam > 0)
    {
        sikeresEv = true;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Hiba! Kérjük, pozitív egész évszámot adjon meg.");
        Console.ResetColor();
    }
} while (!sikeresEv);

// 2. Makacs hónap bekérés
do
{
    Console.Write("Kérjük, adja meg a hónap sorszámát (1-12): ");
    if (int.TryParse(Console.ReadLine(), out honap) && honap >= 1 && honap <= 12)
    {
        sikeresHonap = true;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Hiba! Érvénytelen hónapszám, csak 1 és 12 közötti számot adhat meg.");
        Console.ResetColor();
    }
} while (!sikeresHonap);

// 3. Szökőév-szabály ellenőrzése (C3 alapján)
// Osztható 4-gyel ÉS (nem osztható 100-zal VAGY osztható 400-zal)
bool szokoev = (evszam % 4 == 0) && (evszam % 100 != 0 || evszam % 400 == 0);

// 4. Napok meghatározása modern C# switch-kifejezéssel
int napokSzama = honap switch
{
    1 or 3 or 5 or 7 or 8 or 10 or 12 => 31,
    4 or 6 or 9 or 11 => 30,
    2 => szokoev ? 29 : 28,
    _ => 0 // Ez az ág a korábbi ellenőrzés miatt sosem fut le, de a switch megköveteli
};

// 5. Eredmény kiírása mondatszerűen
Console.WriteLine($"\nA(z) {evszam}. év {honap}. hónapja {napokSzama} napos.");


//8.fel


// Átváltási arányok definiálása konstansként (így elkerüljük a magic number-öket)
const double KmMilesRatio = 0.621;
const double KgLbsRatio = 2.205;

bool fonalatFut = true;

while (fonalatFut)
{
    // Menü kirajzolása
    Console.WriteLine("\n=== MÉRTÉKEGYSÉG-ÁTVÁLTÓ ===");
    Console.WriteLine("1. km -> mérföld");
    Console.WriteLine("2. kg -> font");
    Console.WriteLine("3. °C -> °F");
    Console.WriteLine("4. Kilépés");
    Console.Write("Válasszon menüpontot (1-4): ");

    string valasztas = Console.ReadLine();

    if (valasztas == "4")
    {
        fonalatFut = false;
        Console.WriteLine("Köszönjük, hogy használta a programot! Viszlát!");
        continue;
    }

    if (valasztas != "1" && valasztas != "2" && valasztas != "3")
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Hiba! Érvénytelen menüpont, kérjük válasszon 1 és 4 között.");
        Console.ResetColor();
        continue;
    }

    // Makacs adatbekérés a konvertálandó értékre
    double bemenetiErtek = 0;
    bool sikeresErtek = false;

    do
    {
        Console.Write("Adja meg az átváltandó értéket: ");
        if (double.TryParse(Console.ReadLine(), out bemenetiErtek))
        {
            sikeresErtek = true;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Hiba! Kérjük, érvényes számot adjon meg.");
            Console.ResetColor();
        }
    } while (!sikeresErtek);

    // Átváltások elvégzése és kiírása
    Console.Write("\nEredmény: ");
    Console.ForegroundColor = ConsoleColor.Cyan; // Színes kiemelés az eredménynek

    switch (valasztas)
    {
        case "1":
            double miles = bemenetiErtek * KmMilesRatio;
            Console.WriteLine($"{bemenetiErtek:F2} km = {miles:F2} mérföld");
            break;
        case "2":
            double lbs = bemenetiErtek * KgLbsRatio;
            Console.WriteLine($"{bemenetiErtek:F2} kg = {lbs:F2} font");
            break;
        case "3":
            // °C -> °F képlet: (Celsius * 9/5) + 32
            double fahrenheit = (bemenetiErtek * 9 / 5) + 32;
            Console.WriteLine($"{bemenetiErtek:F2} °C = {fahrenheit:F2} °F");
            break;
    }

    Console.ResetColor(); // Szín visszaállítása a következő menükör előtt
}
//9.fel


// Konstansok a bűvös számok elkerülésére
const int IngyenesPercek = 15;
const int OraDíj = 400;

int erkezesOra = 0, erkezesPerc = 0;
int tavozasOra = 0, tavozasPerc = 0;

// 1. Érkezési idő bekérése
bool sikeresErkezes = false;
do
{
    Console.Write("Kérjük, adja meg az érkezés óráját (0-23): ");
    bool oOk = int.TryParse(Console.ReadLine(), out erkezesOra) && erkezesOra >= 0 && erkezesOra <= 23;

    Console.Write("Kérjük, adja meg az érkezés percét (0-59): ");
    bool pOk = int.TryParse(Console.ReadLine(), out erkezesPerc) && erkezesPerc >= 0 && erkezesPerc <= 59;

    if (oOk && pOk)
    {
        sikeresErkezes = true;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Hiba! Érvénytelen időpont. Próbálja újra!");
        Console.ResetColor();
    }
} while (!sikeresErkezes);

// 2. Távozási idő bekérése (garantáltan az érkezés után)
bool sikeresTavozas = false;
do
{
    Console.Write("Kérjük, adja meg a távozás óráját (0-23): ");
    bool oOk = int.TryParse(Console.ReadLine(), out tavozasOra) && tavozasOra >= 0 && tavozasOra <= 23;

    Console.Write("Kérjük, adja meg a távozás percét (0-59): ");
    bool pOk = int.TryParse(Console.ReadLine(), out tavozasPerc) && tavozasPerc >= 0 && tavozasPerc <= 59;

    if (oOk && pOk)
    {
        // Ellenőrizzük, hogy a távozás valóban az érkezés után van-e
        if (tavozasOra > erkezesOra || (tavozasOra == erkezesOra && tavozasPerc >= erkezesPerc))
        {
            sikeresTavozas = true;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Hiba! A távozás időpontja nem lehet korábbi az érkezésnél!");
            Console.ResetColor();
        }
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Hiba! Érvénytelen időpont. Próbálja újra!");
        Console.ResetColor();
    }
} while (!sikeresTavozas);

// 3. Időtartam kiszámítása percekben
int erkezesPercekben = (erkezesOra * 60) + erkezesPerc;
int tavozasPercekben = (tavozasOra * 60) + tavozasPerc;
int bentToltottPercek = tavozasPercekben - erkezesPercekben;

// Átültetés vissza órára és percre a kiíratáshoz
int elteltOra = bentToltottPercek / 60;
int elteltPerc = bentToltottPercek % 60;

// 4. Parkolási díj számítása
int fizetendoDij = 0;

if (bentToltottPercek > IngyenesPercek)
{
    // Megkezdett órák száma: felfelé kerekítés percek alapján
    // Ha pl. 16 perc -> 16 / 60 = 0, de a maradék miatt +1 óra
    int megkezdettOrak = bentToltottPercek / 60;
    if (bentToltottPercek % 60 > 0)
    {
        megkezdettOrak++;
    }

    fizetendoDij = megkezdettOrak * OraDíj;
}

// 5. Eredmények mondatszerű kiírása
// Az idő formázásánál a :D2 biztosítja, hogy a magányos számok elé is kerüljön nulla (pl. 05)
Console.WriteLine($"\nA parkolóházban töltött idő: {elteltOra:D2}:{elteltPerc:D2}");

Console.Write("A fizetendő parkolási díj: ");
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"{fizetendoDij} Ft");
Console.ResetColor();

//10.fel

int elertPontszam = 0;

Console.WriteLine("=== VILLÁMKVÍZ: C# ALAPOK ===");
Console.WriteLine("Válaszolj a következő 3 kérdésre!\n");

// --- 1. KÉRDÉS (Szám válaszú) ---
Console.WriteLine("1. Kérdés: Hány bájt (byte) memóriát foglal egy standard 'int' típusú változó a C# nyelvben?");
Console.Write("A válaszod (szám): ");

int valasz1 = 0;
// Biztonságos számbeolvasás hibakezeléssel
while (!int.TryParse(Console.ReadLine(), out valasz1))
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.Write("Hiba! Kérjük, egy egész számot írj be: ");
    Console.ResetColor();
}

if (valasz1 == 4)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("HELYES! Az int típus valóban 4 bájtos (32 bites).");
    elertPontszam++;
}
else
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("HIBÁS! A helyes válasz: 4.");
}
Console.ResetColor();
Console.WriteLine();


// --- 2. KÉRDÉS (Szöveges válaszú) ---
Console.WriteLine("2. Kérdés: Melyik kulcsszóval hozhatunk létre módosíthatatlan, állandó értéket (konstanst) a C#-ban?");
Console.Write("A válaszod (szöveg): ");

string valasz2 = Console.ReadLine().Trim().ToLower(); // Kisbetűssé alakítás a pontosságért

if (valasz2 == "const")
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("HELYES! A 'const' kulcsszó szolgál a konstansok definiálására.");
    elertPontszam++;
}
else
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("HIBÁS! A helyes válasz: const.");
}
Console.ResetColor();
Console.WriteLine();


// --- 3. KÉRDÉS (Szöveges/Logikai válaszú) ---
Console.WriteLine("3. Kérdés: Igaz vagy Hamis? A C# nyelvben a '10 / 4' osztás eredménye pontosan 2.5 lesz.");
Console.Write("A válaszod (igaz/hamis): ");

string valasz3 = Console.ReadLine().Trim().ToLower();

if (valasz3 == "hamis")
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("HELYES! Mivel mindkét szám egész (int), egészosztás történik, így az eredmény 2 lesz!");
    elertPontszam++;
}
else
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("HIBÁS! A válasz Hamis, mert az egészosztás levágja a tizedesjegyeket. Pontos eredményhez (10.0 / 4) kellene.");
}
Console.ResetColor();
Console.WriteLine("\n=============================");


// --- KIVÉRTÉKELÉS HÁROM SÁVBAN ---
Console.Write($"A kvíz véget ért! Az elért pontszámod: {elertPontszam} / 3. Értékelés: ");

if (elertPontszam == 3)
{
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("Profi vagy! Hibátlanul ismered a C# alapjait!");
}
else if (elertPontszam == 2 || elertPontszam == 1)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("Nem rossz… de van még mit csiszolni az elméleten.");
}
else // 0 pont esetén
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Olvasd újra a fejezeteket! Szükséged lesz még a gyakorlásra.");
}
Console.ResetColor();
