def optimized_sieve_of_eratosthenes(n):
    if n < 2:
        return []

    is_prime = [True] * (n + 1)
    is_prime[0] = is_prime[1] = False


    for i in range(4, n + 1, 2):
        is_prime[i] = False

    p = 3
    while p * p <= n:
        if is_prime[p]:
            for i in range(p * p, n + 1, 2 * p): 
                is_prime[i] = False
        p += 2 


    prime_numbers = [2] + [p for p in range(3, n + 1, 2) if is_prime[p]]
    return prime_numbers


given_number = 50
prime_list = optimized_sieve_of_eratosthenes(given_number)
print(f"Prime numbers up to {given_number}: {prime_list}")
