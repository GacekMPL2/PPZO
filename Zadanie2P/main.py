import random

class Card:
    def __init__(self, rank, suit):
        self.rank = rank
        self.suit = suit

    def value(self):
        if self.rank.isdigit():
            return int(self.rank)
        if self.rank == "A":
            return 11
        return 10

    def __str__(self):
        if self.suit in "♥♦":
            color = "\033[31m"
        else:
            color = "\033[30m"
        reset = "\033[0m"
        return f"{color}{self.rank}{self.suit}{reset}"

class Deck:
    def __init__(self):
        suits = ["♠", "♥", "♦", "♣"]
        ranks = ["A","2","3","4","5","6","7","8","9","10","J","Q","K"]
        self.cards = [Card(r, s) for s in suits for r in ranks]
        random.shuffle(self.cards)

    def draw(self):
        return self.cards.pop()

class Hand:
    def __init__(self):
        self.cards = []

    def add(self, card):
        self.cards.append(card)

    def value(self):
        total = 0
        aces = 0
        for c in self.cards:
            total += c.value()
            if c.rank == "A":
                aces += 1
        while total > 21 and aces > 0:
            total -= 10
            aces -= 1
        return total

    def __str__(self):
        return " ".join(str(c) for c in self.cards) + f" (wartość: {self.value()})"

class Player:
    def __init__(self):
        self.hand = Hand()

class Dealer:
    def __init__(self):
        self.hand = Hand()

print("=== PROSTY BLACKJACK ===")

deck = Deck()
player = Player()
dealer = Dealer()

player.hand.add(deck.draw())
player.hand.add(deck.draw())
dealer.hand.add(deck.draw())
dealer.hand.add(deck.draw())

print("\nTwoje karty:")
print(player.hand)

print("\nKarta krupiera:")
print(dealer.hand.cards[0], "[X]")

while True:
    move = input("\nHit czy Stand (h/s)? ").lower()
    if move == "h":
        player.hand.add(deck.draw())
        print("Twoje karty:")
        print(player.hand)
        if player.hand.value() > 21:
            print("Przegrałeś.")
            exit()
    else:
        break

print("\nKarty krupiera:")
print(dealer.hand)

while dealer.hand.value() < 17:
    dealer.hand.add(deck.draw())
    print("Krupier dobiera...")
    print(dealer.hand)

p = player.hand.value()
d = dealer.hand.value()

print("\n=== WYNIK ===")
print("Twoje punkty:", p)
print("Punkty krupiera:", d)

if d > 21 or p > d:
    print("Wygrałeś!")
elif p == d:
    print("Remis!")
else:
    print("Przegrałeś!")
