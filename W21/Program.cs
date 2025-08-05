//Zadanie : Policz wystąpienia cyfr w liczbie 4566

int number = 4566;
string text = number.ToString();
Dictionary<char, int> wystapienia = new Dictionary<char, int>();

for (int i = 0; i < text.Length; i++)
{
    char cyfra = text[i];
    if (wystapienia.ContainsKey(cyfra))
        wystapienia[cyfra]++;
    else
        wystapienia[cyfra] = 1;
}

foreach (var wpis in wystapienia)
{
    Console.WriteLine($"Cyfra {wpis.Key} występuje {wpis.Value} razy");
}