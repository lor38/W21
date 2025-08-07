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

#region  Programowanie obiektowe — wyjaśnienie na przykładzie klasy użytkownika

// ====================================================================
//  Klasa — fundament obiektowości
// Klasa to wzorzec, który opisuje, jak ma wyglądać obiekt.
// Można ją porównać do projektu domu — zawiera informacje o tym,
// co obiekt „ma” (dane) i co „robi” (funkcje).
// Na podstawie klasy można tworzyć wiele obiektów,
// każdy z własnymi wartościami.
//
// ====================================================================
//  Konstruktor — sposób tworzenia obiektu
// Konstruktor to specjalna część klasy, która uruchamia się automatycznie
// przy tworzeniu obiektu. Dzięki niemu można od razu ustawić dane początkowe,
// np. nazwę użytkownika czy hasło.
// To jak wypełnienie formularza przy zakładaniu konta.
//
// ====================================================================
//  Modyfikatory dostępu — kontrola widoczności
// W programowaniu obiektowym ważne jest, by nie wszystko było dostępne dla każdego.
// Dlatego stosuje się modyfikatory:
//
// - Prywatne elementy są ukryte i dostępne tylko wewnątrz klasy.
// - Publiczne elementy są widoczne i dostępne z zewnątrz.
//
// To pozwala chronić dane i ograniczyć ryzyko przypadkowych zmian.
//
// ====================================================================
//  Pola i właściwości — przechowywanie danych
// Pole to miejsce, gdzie przechowywane są dane obiektu,
// np. lista punktów użytkownika.
// Właściwości to bardziej elegancki sposób udostępniania tych danych —
// pozwalają na kontrolę, czy i jak można je odczytać lub zmieniać.
//
// ====================================================================
//  Hermetyzacja — bezpieczeństwo danych
// Hermetyzacja polega na ukrywaniu danych wewnątrz klasy
// i udostępnianiu ich tylko przez specjalne metody.
// Dzięki temu dane są bezpieczne, a dostęp do nich jest kontrolowany.
// Przykładowo: zamiast pozwalać każdemu zmieniać listę punktów,
// klasa udostępnia metodę, która dodaje punkt w określony sposób.
//
// ====================================================================
//  Static — elementy wspólne dla wszystkich
// Elementy statyczne nie należą do konkretnego obiektu, lecz do całej klasy.
// Można z nich korzystać bez tworzenia obiektu.
// Są przydatne, gdy coś jest wspólne dla wszystkich,
// np. funkcje matematyczne czy licznik użytkowników.
//
// ====================================================================
//  Poprawność i czytelność
// Dobrze zaprojektowana klasa powinna być:
//
// - Spójna — wszystkie elementy powinny ze sobą współgrać.
// - Czytelna — łatwa do zrozumienia przez innych programistów.
// - Bezpieczna — dane powinny być chronione przed przypadkowymi zmianami.
//
// ====================================================================

#endregion

#region Testowanie oprogramowania — wyjaśnienie na przykładzie testów jednostkowych

// ====================================================================
//  Testy — strażnicy jakości kodu
// Testy to fragmenty kodu, które sprawdzają, czy inne fragmenty działają poprawnie.
// Dzięki nim można szybko wykryć błędy i upewnić się, że zmiany nie psują istniejącej logiki.
// To jak kontrola jakości w fabryce — zanim produkt trafi do klienta, musi przejść test.
//
// ====================================================================
//  Testy jednostkowe — mikroskop dla kodu
// Test jednostkowy sprawdza jedną, konkretną funkcję lub metodę.
// Jest szybki, precyzyjny i łatwy do uruchomienia.
// Przykład: sprawdzenie, czy metoda `DodajPunkt()` faktycznie zwiększa liczbę punktów.
//
// ====================================================================
//  Framework testowy — zestaw narzędzi
// Do pisania testów używa się specjalnych bibliotek, np.:
// - NUnit (dla C#)
// - xUnit
// - MSTest
// Framework udostępnia metody takie jak `Assert.AreEqual`, które porównują oczekiwany wynik z rzeczywistym.
//
// ====================================================================
//  Asercje — oczekiwania vs rzeczywistość
// Asercja to instrukcja, która mówi: „Spodziewam się, że wynik będzie taki”.
// Jeśli wynik jest inny — test się nie powiedzie.
// Przykład:
//     Assert.AreEqual(5, Dodaj(2, 3)); // oczekujemy, że 2 + 3 = 5
//
// ====================================================================
//  Izolacja — test bez zakłóceń
// Dobry test powinien działać niezależnie od innych.
// Nie powinien polegać na danych z zewnątrz ani wpływać na inne testy.
// To jak testowanie jednej części maszyny bez uruchamiania całej fabryki.
//
// ====================================================================
//  Automatyzacja — testy na autopilocie
// Testy można uruchamiać automatycznie przy każdej zmianie kodu.
// Dzięki temu programista od razu widzi, czy coś się zepsuło.
// Narzędzia takie jak GitHub Actions, Jenkins czy Azure DevOps wspierają ten proces.
//
// ====================================================================
//  Dobry test — cechy
// Test powinien być:
// - Jasny — łatwy do zrozumienia.
// - Powtarzalny — zawsze daje ten sam wynik.
// - Szybki — nie powinien spowalniać pracy.
// - Trafny — sprawdza konkretną rzecz, a nie wszystko naraz.
//
// ====================================================================

#endregion

#region Typy wartościowe i referencyjne — wyjaśnienie na przykładzie 

// ====================================================================
//  Czym są typy wartościowe?
// Typ wartościowy przechowuje dane bezpośrednio w zmiennej.
// Kopiowanie takiej zmiennej oznacza, że tworzymy niezależną kopię danych.
// Przykłady: int, bool, double, enum, struct
//
// Działa jak kopia dokumentu — zmiana kopii nie wpływa na oryginał.
//
// ====================================================================
//  Czym są typy referencyjne?
// Typ referencyjny przechowuje adres do danych w pamięci (referencję).
// Kopiując taką zmienną, kopiujemy adres, więc różne zmienne wskazują na ten sam obiekt.
// Przykłady: string, array, class, List<>, Dictionary<>
//
// Działa jak współdzielony dokument online — zmiany widzi każdy, kto ma dostęp.
//
// ====================================================================
//  Główne różnice
//
// - Typy wartościowe znajdują się w pamięci typu stos (stack).
// - Typy referencyjne znajdują się w stercie (heap), a ich adresy — na stosie.
//
// - Wartość → niezależna kopia.
// - Referencja → wspólna zawartość.
//
// ====================================================================
//  Przykład: typ wartościowy
//     int a = 5;
//     int b = a;
//     b = 10;
//     // a nadal = 5, bo b to niezależna kopia
//
// ====================================================================
//  Przykład: typ referencyjny
//     var list1 = new List<int> { 1, 2, 3 };
//     var list2 = list1;
//     list2.Add(4);
//     // list1 także zawiera 4, bo obie zmienne wskazują na ten sam obiekt
//
// ====================================================================
//  Specjalny przypadek: string
// Typ string to **typ referencyjny**, ale zachowuje się jak typ wartościowy,
// ponieważ jest niemutowalny (nie można go zmienić).
// Każda modyfikacja tworzy nowy obiekt w pamięci.
//
// ====================================================================

#endregion

#region przekazywanie argumentów — wyjaśnienie na przykładzie ref i out
// ====================================================================
//  ref vs out — przekazywanie argumentów przez referencję
// W C# oba służą do przekazywania danych do metody tak, aby można je było modyfikować.
// - `ref`: zmienna musi być wcześniej zainicjalizowana. Metoda może ją zmieniać.
// - `out`: zmienna może być niezainicjalizowana, ale musi dostać wartość w metodzie.
// Są używane np. przy zwracaniu wielu wyników bez tworzenia klasy pomocniczej.
//
// Przykład:
//     void Zmien(ref int a) { a = 10; }
//     void Wypelnij(out int b) { b = 20; }
//
// ====================================================================
//  Model danych — struktura informacji w systemie
// Model danych to klasa lub struktura, która opisuje dane, np. użytkownika, głos, punkt.
// Przykład modelu:
//     class Votatnik
//     {
//         public string Imie;
//         public int Punkty;
//     }
// Model danych służy do przechowywania informacji i przekazywania ich między warstwami systemu.
//
// ====================================================================
//  Interpolacja stringów — wygodne składanie tekstu
// Zamiast używać konkatenacji (`+`), interpolacja pozwala wstawić wartości do tekstu:
//     string name = "Robert";
//     string info = $"Witaj, {name}"; // wynik: Witaj, Robert
// Ułatwia tworzenie komunikatów, zapytań SQL, logów i opisu obiektów.
//
// ====================================================================
//  Max / Min „na piechotę” — bez użycia LINQ
// Czasem trzeba obliczyć wartość maksymalną lub minimalną ręcznie.
// Przykład:
//     float max = float.MinValue;
//     foreach (var x in liczby)
//         max = Math.Max(max, x);
// Jest to przydatne, gdy nie można użyć `Max()` lub trzeba sprawdzić warunki specjalne.
//
// ====================================================================
//  Przekazywanie parametrów — jak działa mechanizm w metodach
// W C# domyślnie przekazywane są:
// - Typy wartościowe: przez kopię (int, float) — metoda widzi kopię wartości.
// - Typy referencyjne: przez referencję (klasa, lista) — metoda może zmieniać oryginał.
// Można też używać `ref`, `out`, lub `in` by kontrolować sposób przekazywania.
// To kluczowe dla optymalizacji i bezpieczeństwa danych.
//
// ====================================================================

#endregion

#region Walidacja Rzutowanie  Parsowanie Sprawdzanie typu Zaokrąglanie
// ====================================================================
//  Walidacja danych — sprawdzanie poprawności wejścia
// Walidacja to proces sprawdzania, czy dane są zgodne z oczekiwanym formatem.
// Chroni przed błędami i nieprawidłowymi wartościami.
// Przykład:
//     if (ocena < 0 || ocena > 100)
//         throw new ArgumentOutOfRangeException("Ocena musi być od 0 do 100");
// Można też zwracać komunikaty błędów zamiast rzucać wyjątki.
//
// ====================================================================
//  Rzutowanie — wymuszenie zmiany typu
// Rzutowanie pozwala zmienić typ zmiennej, np. z float na int.
// Przykład:
//     float f = 3.7f;
//     int i = (int)f; // wynik: 3 (obcięcie części dziesiętnej)
// Uwaga: rzutowanie nie zaokrągla — tylko obcina.
//
// ====================================================================
//  Parsowanie i konwertowanie — zmiana stringa na liczbę
// Parsowanie to próba konwersji tekstu na typ liczbowy.
// Przykład:
//     string s = "42";
//     int i = int.Parse(s); // może rzucić wyjątek
// Bezpieczniejsza wersja:
//     if (int.TryParse(s, out int i))
//         Console.WriteLine($"Liczba: {i}");
// TryParse nie rzuca wyjątku — zwraca true/false.
//
// ====================================================================
//  Sprawdzanie typu — czy string da się przekonwertować
// Można sprawdzić, czy tekst jest poprawną liczbą:
//     bool isInt = int.TryParse("123", out _);
//     bool isFloat = float.TryParse("3.14", out _);
// Znak `_` oznacza, że nie interesuje nas wynik — tylko czy się udało.
//
// ====================================================================
//  Zaokrąglanie — jak zmienić float na int z zaokrągleniem
// Aby zaokrąglić wartość do najbliższej liczby całkowitej:
//     float f = 3.6f;
//     int i = (int)Math.Round(f); // wynik: 4
// Domyślnie używane jest „bankers rounding” (np. 2.5 → 2, 3.5 → 4).
// Aby zawsze zaokrąglać .5 w górę:
//     int i = (int)Math.Round(f, MidpointRounding.AwayFromZero);
//
// ====================================================================

#endregion
