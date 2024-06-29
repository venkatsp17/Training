
footballers = [
    ("Lionel Messi", 30),
    ("Cristiano Ronaldo", 25),
    ("Robert Lewandowski", 35),
    ("Kylian Mbappe", 28),
    ("Erling Haaland", 27),
    ("Harry Kane", 23),
    ("Karim Benzema", 24),
    ("Romelu Lukaku", 20),
    ("Neymar Jr", 22),
    ("Luis Suarez", 19),
    ("Zlatan Ibrahimovic", 18),
    ("Lautaro Martinez", 17),
    ("Gerard Moreno", 21),
    ("Ciro Immobile", 15),
    ("Jamie Vardy", 16)
]


sorted_footballers = sorted(footballers, key=lambda x: x[1], reverse=True)


top_10_footballers = sorted_footballers[:10]

print("Top 10 footballers:")
for rank, (name, score) in enumerate(top_10_footballers, start=1):
    print(f"{rank}. {name} - {score} goals")
