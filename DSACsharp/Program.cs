using DSACsharp;

// Console.WriteLine(string.Join(", ", ArraysAndHashing.TwoSum([3, 6, 1, 8], 11)));
Console.WriteLine(ArraysAndHashing.IsAnagram("anagram", "nagagram"));
Console.WriteLine(string.Join(", ", ArraysAndHashing.TopKFrequent([1, 1, 1, 2, 2, 3], 2)));
var encodedStr = ArraysAndHashing.Encode(["neet", "33", "code"]);
Console.WriteLine(encodedStr);
Console.WriteLine(string.Join(", ", ArraysAndHashing.Decode(encodedStr)));
Console.WriteLine(string.Join(", ", ArraysAndHashing.ProductExceptSelf([1, 2, 3, 4])));