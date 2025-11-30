using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\n=== MENU ===");
            Console.WriteLine("1. Prosty kalkulator");
            Console.WriteLine("2. Konwerter temperatur (C <-> F)");
            Console.WriteLine("3. Średnia ocen ucznia");
            Console.WriteLine("0. Wyjście");
            Console.Write("Wybierz opcję: ");

            string wybor = Console.ReadLine();

            switch (wybor)
            {
                case "1":
                    Calculator();
                    break;
                case "2":
                    TemperatureConverter();
                    break;
                case "3":
                    GradesAverage();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Nieprawidłowy wybór!");
                    break;
            }
        }
    }

    // --- Funkcja pomocnicza do wczytywania liczby ---
    static double ReadDouble(string komunikat)
    {
        double liczba;
        while (true)
        {
            Console.Write(komunikat);
            if (double.TryParse(Console.ReadLine(), out liczba))
                return liczba;

            Console.WriteLine("Błąd: podaj poprawną liczbę!");
        }
    }

    static int ReadInt(string komunikat)
    {
        int liczba;
        while (true)
        {
            Console.Write(komunikat);
            if (int.TryParse(Console.ReadLine(), out liczba))
                return liczba;

            Console.WriteLine("Błąd: podaj poprawną liczbę całkowitą!");
        }
    }

    // --- Zadanie 1 ---
    static void Calculator()
    {
        double a = ReadDouble("Podaj pierwszą liczbę: ");
        double b = ReadDouble("Podaj drugą liczbę: ");

        Console.Write("Wybierz operację (+, -, *, /): ");
        string op = Console.ReadLine();

        switch (op)
        {
            case "+":
                Console.WriteLine("Wynik: " + (a + b));
                break;

            case "-":
                Console.WriteLine("Wynik: " + (a - b));
                break;

            case "*":
                Console.WriteLine("Wynik: " + (a * b));
                break;

            case "/":
                if (b != 0)
                    Console.WriteLine("Wynik: " + (a / b));
                else
                    Console.WriteLine("Błąd: dzielenie przez zero!");
                break;

            default:
                Console.WriteLine("Nieznana operacja!");
                break;
        }
    }

    // --- Zadanie 2 ---
    static void TemperatureConverter()
    {
        Console.Write("Wybierz konwersję (C lub F): ");
        string kierunek = Console.ReadLine().ToUpper();

        switch (kierunek)
        {
            case "C":
                double c = ReadDouble("Podaj temperaturę w °C: ");
                Console.WriteLine($"{c}°C = {c * 1.8 + 32}°F");
                break;

            case "F":
                double f = ReadDouble("Podaj temperaturę w °F: ");
                Console.WriteLine($"{f}°F = {(f - 32) / 1.8}°C");
                break;

            default:
                Console.WriteLine("Nieprawidłowy wybór!");
                break;
        }
    }

    // --- Zadanie 3 ---
    static void GradesAverage()
    {
        int n = ReadInt("Podaj liczbę ocen: ");

        double suma = 0;
        for (int i = 1; i <= n; i++)
        {
            double ocena = ReadDouble($"Podaj ocenę {i}: ");
            suma += ocena;
        }

        double srednia = suma / n;
        Console.WriteLine($"Średnia: {srednia:F2}");
        if (srednia >= 3.0)
            Console.WriteLine("Uczeń zdał.");
        else
            Console.WriteLine("Uczeń nie zdał.");
    }
}
