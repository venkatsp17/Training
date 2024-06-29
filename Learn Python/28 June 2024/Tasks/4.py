import random

def generate_secret_number():
    digits = list(range(10))
    random.shuffle(digits)
    return ''.join(str(digits[i]) for i in range(4))

def get_bulls_and_cows(secret, guess):
    bulls = sum(1 for s, g in zip(secret, guess) if s == g)
    cows = sum(1 for g in guess if g in secret) - bulls
    return bulls, cows

def play_game():
    secret_number = generate_secret_number()
    attempts = 0
    
    print("Welcome to the Cow and Bull game!")
    print("I have generated a 4-digit secret number with all unique digits.")
    print("Try to guess it, and I'll tell you how many bulls and cows you get in each guess.")
    print("Bulls: Number is correct and at right position")
    print("Cows: Number is correct and at weong position")
    
    while True:
        guess = input("Enter your 4-digit guess: ")
        
        if len(guess) != 4 or not guess.isdigit() or len(set(guess)) != 4:
            print("Invalid guess. Please enter a 4-digit number with all unique digits.")
            continue
        
        attempts += 1
        bulls, cows = get_bulls_and_cows(secret_number, guess)
        
        print(f"{bulls} Bulls, {cows} Cows")
        
        if bulls == 4:
            print(f"Congratulations! You guessed the number {secret_number} in {attempts} attempts.")
            break


play_game()
