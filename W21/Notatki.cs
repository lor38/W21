#region Typy całkowite C#
// =================== Typy całkowite  C# ===================
// Typ      | Zakres wartości                                      | Rozmiar | Znak
// -------- | ----------------------------------------------------- | ------- | ----
// byte     | 0 do 255                                              | 8-bit   | bez znaku
// sbyte    | -128 do 127                                           | 8-bit   | ze znakiem
// short    | -32 768 do 32 767                                     | 16-bit  | ze znakiem
// ushort   | 0 do 65 535                                           | 16-bit  | bez znaku
// int      | -2 147 483 648 do 2 147 483 647                       | 32-bit  | ze znakiem
// uint     | 0 do 4 294 967 295                                    | 32-bit  | bez znaku
// long     | -9 223 372 036 854 775 808 do 9 223 372 036 854 775 807 | 64-bit | ze znakiem
// ulong    | 0 do 18 446 744 073 709 551 615                       | 64-bit  | bez znaku
// ==================================================================
//
// Najczęściej używany typ to int, ale warto wybierać bardziej
// optymalny typ zależnie od zakresu danych i kontekstu użycia.
#endregion

#region Typy zmiennoprzecinkowe C#
// ================= Typy zmiennoprzecinkowe  C# =================
// Typ     | Zakres wartości                         | Rozmiar | Precyzja   | Użycie
// ------- | ---------------------------------------- | ------- | ---------- | -------------------------------
// float   | ±1.5 × 10^−45 do ±3.4 × 10^38            | 32-bit  | ~7 cyfr    | do grafiki, prostych obliczeń
// double  | ±5.0 × 10^−324 do ±1.7 × 10^308          | 64-bit  | ~15-16 cyfr| domyślny typ dla ułamków
// decimal | ±1.0 × 10^−28 do ±7.9 × 10^28            | 128-bit | ~28-29 cyfr| precyzyjne finanse i waluty
// =======================================================================
//
// 📌 Wskazówka:
// - `float` i `double` używają binarnej reprezentacji, mogą zaokrąglać liczby.
// - `decimal` używa dziesiętnej reprezentacji — świetny do finansów, ale wolniejszy.
// - Dla większości obliczeń używa się `double`.
// - Warto dodawać litery typu: 3.14f (float), 3.14m (decimal)
#endregion

#region Typy tekstowe C#
// ================== Typy tekstowe C# ===================
// Typ      | Opis                                              | Przykład użycia
// -------- | -------------------------------------------------- | -------------------------------
// char     | Pojedynczy znak Unicode                           | char znak = 'A';
// string   | Sekwencja znaków (łańcuch tekstowy)              | string imie = "Robert";
// =================================================================
//
// 📌 Wskazówki:
// - `char` służy do przechowywania **jednego** znaku i jest otaczany apostrofami ('A').
// - `string` służy do przechowywania tekstu — od jednego znaku do bardzo długich zdań.
// - Można używać tzw. interpolacji: $"Witaj, {imie}".
// - C# posiada bogaty zestaw metod do pracy ze stringami: .Length, .ToUpper(), .Contains(), itd.
#endregion

#region Typ logiczny C#
// ================== Typ logiczny  C# ===================
// Typ    | Zakres wartości | Przykład użycia
// ------ | ---------------- | --------------------------------
// bool   | true / false     | bool czyAktywny = true;
// ===============================================================
//
// 📌 Wskazówki:
// - `bool` służy do przechowywania logicznych decyzji, np. czy użytkownik jest zalogowany.
// - Idealny do instrukcji warunkowych: if (czyAktywny) { ... }
// - Wartości można negować: !czyAktywny oznacza "nieaktywny".
#endregion

#region Operatory relacyjne
// =============== Operatory relacyjne ===============
// Operator | Opis                     | Przykład
// -------- | ------------------------ | --------------------------
// ==       | równość                  | a == b
// !=       | nierówność               | a != b
// >        | większy niż              | a > b
// <        | mniejszy niż             | a < b
// >=       | większy lub równy        | a >= b
// <=       | mniejszy lub równy       | a <= b
//
// 📌 Przykład:
// int wiek = 20;
// if (wiek >= 18)
// {
//     Console.WriteLine("Pełnoletni");
// }
#endregion

#region Operatory logiczne
// =============== Operatory logiczne ===============
// Operator | Opis                      | Przykład
// -------- | ------------------------- | --------------------------------
// &&       | i (AND)                   | a > 0 && b < 10
// ||       | lub (OR)                  | a == 0 || b == 5
// !        | zaprzeczenie (NOT)        | !(a == b)
//
// 📌 Przykład:
// bool czyZalogowany = true;
// bool czyAdmin = false;
//
// if (czyZalogowany && !czyAdmin)
// {
//     Console.WriteLine("Witaj użytkowniku!");
// }
#endregion

#region Instrukcja if...else
// ================= Instrukcja if...else ========================
// Pozwala wykonać różny kod w zależności od spełnienia warunku.
//
// Podstawowa składnia:
// if (warunek)
// {
//     // Kod wykonywany, gdy warunek jest TRUE
// }
// else
// {
//     // Kod wykonywany, gdy warunek jest FALSE
// }
//
// 📌 Przykład:
// int godzina = 14;
// if (godzina < 12)
// {
//     Console.WriteLine("Dzień dobry!");
// }
// else
// {
//     Console.WriteLine("Dobry wieczór!");
// }
//
// Rozszerzenie: if...else if...else
//
// if (warunek1)
// {
//     // kod jeśli warunek1
// }
// else if (warunek2)
// {
//     // kod jeśli warunek2
// }
// else
// {
//     // kod jeśli żaden z warunków nie jest spełniony
// }
//
// 📣 Wskazówki:
// - Warunek musi zwracać wartość logiczną (bool): np. x > y, a == b, !aktywny
// - Można używać operatorów logicznych: && (i), || (lub), ! (nie)
// - Ułatwia sterowanie logiką programu w zależności od danych
#endregion
