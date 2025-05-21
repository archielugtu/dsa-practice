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
}
