def permute(data, i, length, result):
    if i == length:
        result.append(''.join(data))
    else:
        for j in range(i, length):
            data[i], data[j] = data[j], data[i]
            permute(data, i + 1, length, result)
            data[i], data[j] = data[j], data[i]

def find_permutations(s):
    result = []
    permute(list(s), 0, len(s), result)
    return result


ini_str = "venkat"
permutations = find_permutations(ini_str)
print("Permutations of the string are:", permutations)

