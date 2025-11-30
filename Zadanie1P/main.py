def wczytaj_liczbe(tekst):
    while True:
        try:
            return float(input(tekst))
        except ValueError:
            print("Błąd: podaj poprawną liczbę!")


def kalkulator():
    a = wczytaj_liczbe("Podaj pierwszą liczbę: ")
    b = wczytaj_liczbe("Podaj drugą liczbę: ")

    op = input("Wybierz operację (+, -, *, /): ")

    match op:
        case "+":
            print("Wynik:", a + b)
        case "-":
            print("Wynik:", a - b)
        case "*":
            print("Wynik:", a * b)
        case "/":
            if b != 0:
                print("Wynik:", a / b)
            else:
                print("Błąd: dzielenie przez zero!")
        case _:
            print("Nieznana operacja.")


def konwerter_temperatur():
    kierunek = input("Wybierz konwersję (C lub F): ").upper()

    match kierunek:
        case "C":
            c = wczytaj_liczbe("Podaj temperaturę w °C: ")
            print(f"{c}°C = {c * 1.8 + 32}°F")

        case "F":
            f = wczytaj_liczbe("Podaj temperaturę w °F: ")
            print(f"{f}°F = {(f - 32) / 1.8}°C")

        case _:
            print("Nieprawidłowy wybór!")


def srednia_ocen():
    while True:
        try:
            n = int(input("Podaj liczbę ocen: "))
            break
        except ValueError:
            print("Błąd: podaj liczbę całkowitą!")

    suma = 0
    for i in range(n):
        ocena = wczytaj_liczbe(f"Podaj ocenę {i + 1}: ")
        suma += ocena

    srednia = suma / n
    print(f"Średnia: {srednia:.2f}")

    if srednia >= 3.0:
        print("Uczeń zdał.")
    else:
        print("Uczeń nie zdał.")


# ---- MENU ----
while True:
    print("\n=== MENU ===")
    print("1. Prosty kalkulator")
    print("2. Konwerter temperatur (C <-> F)")
    print("3. Średnia ocen ucznia")
    print("0. Wyjście")

    wybor = input("Wybierz opcję: ")

    match wybor:
        case "1":
            kalkulator()
        case "2":
            konwerter_temperatur()
        case "3":
            srednia_ocen()
        case "0":
            break
        case _:
            print("Nieprawidłowa opcja!")
