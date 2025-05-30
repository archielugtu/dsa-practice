using System;
using System.Text;

namespace DSACsharp;

public static class ArraysAndHashing
{
  public static bool ContainsDuplicates(int[] nums)
  {
    if (nums.Length < 2) return false;

    var seen = new HashSet<int>();
    foreach (var num in nums)
    {
      if (seen.Contains(num))
        return true;
      seen.Add(num);
    }
    return false;
  }

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

    for (int i = 0; i < s.Length; i++)
    {
      countS[s[i]] = countS.GetValueOrDefault(s[i], 0) + 1;
      countT[t[i]] = countT.GetValueOrDefault(t[i], 0) + 1;
    }

    return !countS.Except(countT).Any();
  }

  public static List<List<string>> GroupAnagrams(string[] strs)
  {
    var anagrams = new Dictionary<string, List<string>>();
    foreach (var str in strs)
    {
      var keyArray = new int[26];
      foreach (var c in str)
        keyArray[c - 'a']++;
      var key = string.Join(",", keyArray);

      if (!anagrams.ContainsKey(key))
        anagrams[key] = new List<string>();

      anagrams[key].Add(str);
    }
    return anagrams.Values.ToList();
  }

  public static int[] TopKFrequent(int[] nums, int k)
  {
    var seen = new Dictionary<int, int>();
    foreach (var n in nums)
      seen[n] = seen.GetValueOrDefault(n, 0) + 1;

    var freq = new List<int>[nums.Length + 1];
    foreach (var (num, occurence) in seen)
    {
      if (freq[occurence] == null)
        freq[occurence] = new List<int>();
      freq[occurence].Add(num);
    }

    int[] res = new int[k];
    int index = 0;
    for (int i = freq.Length - 1; i >= 0; i--)
    {
      var freqArr = freq[i];
      if (freqArr != null)
      {
        foreach (var num in freqArr)
        {
          res[index++] = num;
          if (index == k) return res;
        }
      }
    }
    return res;
  }

  public static string Encode(IList<string> strs)
  {
    var res = new StringBuilder();
    foreach (var str in strs)
      res.Append($"{str.Length}#{str}");
    return res.ToString();
  }

  public static List<string> Decode(string s)
  {
    var res = new List<string>();
    int i = 0;
    while (i < s.Length)
    {
      int j = i;
      while (s[j] != '#')
        j++;

      var length = int.Parse(s.Substring(i, j - i));
      res.Add(s.Substring(j + 1, length));
      i = j + 1 + length;
    }
    return res;
  }

  public static int[] ProductExceptSelf(int[] nums)
  {
    /**
      1, 2, 3, 4
      prefix = 1, 1, 6, 24
      postfix = 24, 12, 4, 1
    */
    var n = nums.Length;
    var prefix = new int[nums.Length];
    var postfix = new int[nums.Length];
    var res = new int[nums.Length];

    prefix[0] = 1;
    postfix[n - 1] = 1;
    for (int i = 1; i < nums.Length; i++)
      prefix[i] = nums[i - 1] * prefix[i - 1];

    for (int i = nums.Length - 2; i >= 0; i--)
      postfix[i] = nums[i + 1] * postfix[i + 1];

    for (int i = 0; i < nums.Length; i++)
      res[i] = prefix[i] * postfix[i];

    return res;
  }

  public static bool ValidSudoku(char[][] board)
  {
    /**
      [["5","3",".",".","7",".",".",".","."]
      ,["6",".",".","1","9","5",".",".","."]
      ,[".","9","8",".",".",".",".","6","."]
      ,["8",".",".",".","6",".",".",".","3"]
      ,["4",".",".","8",".","3",".",".","1"]
      ,["7",".",".",".","2",".",".",".","6"]
      ,[".","6",".",".",".",".","2","8","."]
      ,[".",".",".","4","1","9",".",".","5"]
      ,[".",".",".",".","8",".",".","7","9"]]
    */
    var rows = new HashSet<char>[9];
    var cols = new HashSet<char>[9];
    var boxes = new HashSet<char>[9];

    for (int i = 0; i < 9; i++)
    {
      rows[i] = [];
      cols[i] = [];
      boxes[i] = [];
    }

    for (int r = 0; r < board.Length; r++)
    {
      for (int c = 0; c < board[r].Length; c++)
      {
        var elem = board[r][c];
        if (elem == '.') continue;

        if (!rows[r].Add(elem) ||
            !cols[c].Add(elem)) return false;

        var box = (3 * (r / 3)) + (c / 3);
        if (!boxes[box].Add(elem)) return false;
      }
    }
    return true;
  }

  public static char[][] ConvertStringArrayToCharArray(string[][] stringBoard)
  {
    int rows = stringBoard.Length;
    int cols = stringBoard[0].Length;
    char[][] charBoard = new char[rows][];

    for (int i = 0; i < rows; i++)
    {
      charBoard[i] = new char[cols];
      for (int j = 0; j < cols; j++)
      {
        // Assuming each string is a single character like "5" or "."
        charBoard[i][j] = stringBoard[i][j][0];
      }
    }

    return charBoard;
  }

  public static int LongestConsecutive(int[] nums)
  {
    var seen = new HashSet<int>(nums);
    int longest = 0;
    foreach (int n in nums)
    {
      //if starting num of consecutive
      if (!seen.Contains(n - 1))
      {
        int length = 1;
        while (seen.Contains(n + length))
          length++;

        longest = int.Max(longest, length);
      }
    }

    return longest;
  }
}
