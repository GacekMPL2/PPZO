def read_number(text):
    while True:
        try:
            return float(input(text))
        except ValueError:
            print("Błąd: podaj poprawną liczbę!")


def calculator():
    a = read_number("Podaj pierwszą liczbę: ")
    b = read_number("Podaj drugą liczbę: ")

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


def temperature_converter():
    direction = input("Wybierz konwersję (C lub F): ").upper()

    match direction:
        case "C":
            c = read_number("Podaj temperaturę w °C: ")
            print(f"{c}°C = {c * 1.8 + 32}°F")

        case "F":
            f = read_number("Podaj temperaturę w °F: ")
            print(f"{f}°F = {(f - 32) / 1.8}°C")

        case _:
            print("Nieprawidłowy wybór!")


def grades_average():
    while True:
        try:
            n = int(input("Podaj liczbę ocen: "))
            break
        except ValueError:
            print("Błąd: podaj liczbę całkowitą!")

    suma = 0
    for i in range(n):
        grade = read_number(f"Podaj ocenę {i + 1}: ")
        suma += grade

    average = suma / n
    print(f"Średnia: {average:.2f}")

    if average >= 3.0:
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

    choice = input("Wybierz opcję: ")

    match choice:
        case "1":
            calculator()
        case "2":
            temperature_converter()
        case "3":
            grades_average()
        case "0":
            break
        case _:
            print("Nieprawidłowa opcja!")
