def is_prime(num):
    if num <= 1:
        return False
    if num == 2:
        return True  
    if num % 2 == 0:
        return False
    for i in range(3, int(num**0.5) + 1, 2):
        if num % i == 0:
            return False
    return True

def average_of_primes(numbers):
    prime_numbers = [num for num in numbers if is_prime(num)]
    if not prime_numbers:
        return None 
    average = sum(prime_numbers) / len(prime_numbers)
    return average

numbers = [4, 7, 12, 9, 5, 23, 14, 8, 11, 6]
result = average_of_primes(numbers)
print(f"Average of prime numbers: {result}")
