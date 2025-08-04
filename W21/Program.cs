// ===============================================
// Zadanie: Analiza danych osobowych z if...else
// ===============================================
string imie = "Ewa";
string plec = "kobieta"; // Możliwe: "kobieta" lub "mężczyzna"
int wiek = 30;

if (plec == "kobieta" && wiek < 30)
{
    Console.WriteLine("Kobieta poniżej 30 lat");
}
else if (imie == "Ewa" && wiek == 30)
{
    Console.WriteLine("Ewa, lat 30");
}
else if (plec == "mężczyzna" && wiek < 18)
{
    Console.WriteLine("Niepełnoletni mężczyzna");
}
// (4): jeśli żaden warunek nie został spełniony — brak komunikatu
