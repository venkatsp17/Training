def luhn_check(card_number):
    card_number = card_number.replace(" ", "")
    if not card_number.isdigit():
        return False

    total_sum = 0
    reverse_digits = card_number[::-1]

    for i, digit in enumerate(reverse_digits):
        n = int(digit)
        if i % 2 == 1:
            n *= 2
            if n > 9:
                n -= 9
        total_sum += n

    return total_sum % 10 == 0


card_number = "4539 1488 0343 6467"
is_valid = luhn_check(card_number)
print(f"The card number {card_number} is {'valid' if is_valid else 'invalid'}.")
