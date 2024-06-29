def longest_substring_without_repeating_characters(s):
    char_set = set()
    left = 0
    max_length = 0

    for right in range(len(s)):
        while s[right] in char_set:
            char_set.remove(s[left])
            left += 1
        char_set.add(s[right])
        max_length = max(max_length, right - left + 1)
    
    return max_length


input_string = input("Enter input string: ")
result = longest_substring_without_repeating_characters(input_string)
print(f"Length of the longest substring without repeating characters is: {result}")