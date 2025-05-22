using System;

namespace DSACsharp;

public static class ArraysAndHashing
{
  public static int[] TwoSum(int[] nums, int target)
  {
    var dict = new Dictionary<int, int>();

    for (int i = 0; i < nums.Length; i++)
    {
      int targetPair = target - nums[i];
      if (dict.TryGetValue(targetPair, out int index))
        return [index, i];
      dict.Add(nums[i], i);
    }

    return [0, 0];
  }

  public static bool IsAnagram(string s, string t)
  {
    // if (s.Length != t.Length) return false;

    // var seen = new Dictionary<char, int>();
    // foreach (char c in s)
    // {
    //   seen[c] = seen.GetValueOrDefault(c, 0) + 1;
    // }

    // foreach (char c in t)
    // {
    //   if (!seen.TryGetValue(c, out int value) || value == 0) return false;
    //   seen[c] = seen[c] - 1;
    // }

    // return true;

    if (s.Length != t.Length) return false;

    Dictionary<char, int> countS = new Dictionary<char, int>();
    Dictionary<char, int> countT = new Dictionary<char, int>();

    for (int i = 0; i < s.Length; i++) {
        countS[s[i]] = countS.GetValueOrDefault(s[i], 0) + 1;
        countT[t[i]] = countT.GetValueOrDefault(t[i], 0) + 1;
    }

    return countS.Count == countT.Count && !countS.Except(countT).Any();
  }
}
