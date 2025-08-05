#region Typy całkowite 
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

#region Typy zmiennoprzecinkowe 
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

#region Typy tekstowe 
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

#region Typ logiczny 
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

#region  Pętla for  – przykład z dniami tygodnia
// ================= Pętla for – schemat działania =====================
// Element         | Przykład                                        | Opis
// --------------- | ------------------------------------------------ | --------------------------------------------
// Tablica         | string[] dayOfWeeks = new string[7];            | tworzymy tablicę na 7 dni tygodnia
// Inicjalizacja   | int i = 0                                        | początek pętli, zmienna sterująca
// Warunek         | i < dayOfWeeks.Length                            | pętla trwa, dopóki indeks mieści się w tablicy
// Zmiana          | i++                                              | po każdej iteracji zwiększamy indeks
// Iteracja        | Console.WriteLine(dayOfWeeks[i]);               | wypisujemy bieżący dzień tygodnia
// ====================================================================

//string[] dayOfWeeks = new string[7];
//dayOfWeeks[0] = "poniedziałek";
//dayOfWeeks[1] = "wtorek";
//dayOfWeeks[2] = "środa";
//dayOfWeeks[3] = "czwartek";
//dayOfWeeks[4] = "piątek";
//dayOfWeeks[5] = "sobota";
//dayOfWeeks[6] = "niedziela";

//for (int i = 0; i < dayOfWeeks.Length; i++)
//{
//Console.WriteLine(dayOfWeeks[i]);
//}
#endregion

#region  Pętla for  – przykład z List<string>
// =================== Pętla for – schemat działania =====================
// Element         | Przykład                                      | Opis
// --------------- | ---------------------------------------------- | --------------------------------------------
// Lista           | List<string> dayOfWeeks = new List<string>(); | tworzymy listę zamiast tablicy
// Dodawanie       | dayOfWeeks.Add("poniedziałek");               | dodajemy kolejne dni tygodnia
// Inicjalizacja   | int i = 0                                     | początek pętli, zmienna sterująca
// Warunek         | i < dayOfWeeks.Count                          | pętla trwa, dopóki indeks mieści się w liście
// Zmiana          | i++                                           | po każdej iteracji zwiększamy indeks
// Iteracja        | Console.WriteLine(dayOfWeeks[i]);            | wypisujemy bieżący dzień tygodnia
// =======================================================================

//List<string> dayOfWeeks = new List<string>();
//dayOfWeeks.Add("poniedziałek");
//dayOfWeeks.Add("wtorek");
//dayOfWeeks.Add("środa");
//dayOfWeeks.Add("czwartek");
//dayOfWeeks.Add("piątek");
//dayOfWeeks.Add("sobota");
//dayOfWeeks.Add("niedziela");

//for (int i = 0; i < dayOfWeeks.Count; i++)
//{
//Console.WriteLine(dayOfWeeks[i]);
//}
#endregion

#region  Pętla foreach  – przykład z List<string>
// ================= Pętla foreach – schemat działania ==================
// Element         | Przykład                                      | Opis
// --------------- | ---------------------------------------------- | --------------------------------------------
// Lista           | List<string> dayOfWeeks = new List<string>(); | lista z dniami tygodnia
// Dodawanie       | dayOfWeeks.Add("poniedziałek");               | dodajemy kolejne dni do listy
// Iteracja        | foreach (string day in dayOfWeeks)            | przechodzimy przez każdy element
// Działanie       | Console.WriteLine(day);                       | wypisujemy dzień tygodnia
//
// 📝 UWAGA: Można też użyć `foreach (var day in dayOfWeeks)`.
// Obie wersje są poprawne — kompilator wie, że typem elementów jest `string`.
// - `string`: jawnie podajesz typ — jest to bardziej czytelne dla początkujących.
// - `var`: skrócona składnia — przydatna gdy typ jest oczywisty.
// Wybór zależy od stylu kodowania — z technicznego punktu widzenia obie działają identycznie.
// =====================================================================

//List<string> dayOfWeeks = new List<string>();
//dayOfWeeks.Add("poniedziałek");
//dayOfWeeks.Add("wtorek");
//dayOfWeeks.Add("środa");
//dayOfWeeks.Add("czwartek");
//dayOfWeeks.Add("piątek");
//dayOfWeeks.Add("sobota");
//dayOfWeeks.Add("niedziela");

//foreach (string day in dayOfWeeks)
//{
//Console.WriteLine(day);
//}
#endregion
#region  Liczenie wystąpień cyfr – wersja z pętlą for
// =================== Liczenie wystąpień cyfr ========================
// Liczba           | int number = 4566;                           | liczba, którą analizujemy
// Konwersja        | string text = number.ToString();             | zamieniamy na tekst (ciąg cyfr)
// Słownik          | Dictionary<char, int> wystapienia            | przechowuje liczbę wystąpień każdej cyfry
// Iteracja         | for (int i = 0; i < text.Length; i++)        | przechodzimy po każdej cyfrze tekstu
// Działanie        | jeśli cyfra istnieje → zwiększ wartość       | w przeciwnym wypadku dodaj ją z wartością 1
// Wyświetlenie     | foreach → wypisz wynik                       | pokazujemy ile razy wystąpiła każda cyfra
// ====================================================================

// text = number.ToString();
//Dictionary<char, int> wystapienia = new Dictionary<char, int>();

//for (int i = 0; i < text.Length; i++)
//{
//char cyfra = text[i];
//if (wystapienia.ContainsKey(cyfra))
//wystapienia[cyfra]++;
//else
//wystapienia[cyfra] = 1;
//}

//foreach (var wpis in wystapienia)
//{
//Console.WriteLine($"Cyfra {wpis.Key} występuje {wpis.Value} razy");
//}
#endregion
