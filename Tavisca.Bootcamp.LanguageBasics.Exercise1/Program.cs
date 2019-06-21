using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
  class Program
  {
    static void Main(string[] args)
    {
      Test("42*47=1?74", 9);
      Test("4?*47=1974", 2);
      Test("42*?7=1974", 4);
      Test("42*?47=1974", -1);
      Test("2*12?=247", -1);
      Console.ReadKey(true);
    }

    private static void Test(string args, int expected)
    {
      var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
      Console.WriteLine($"{args} : {result}");
    }

    public static int FindDigit(string equation)
    {
      var comp = equation.Split('=');
      var digits = comp[0].Split('*');
      if (comp[0].Contains('?'))
      {
        var result = digits[0].Contains('?') ? ((int.Parse(comp[1]) / int.Parse(digits[1])).ToString()) : ((int.Parse(comp[1]) / int.Parse(digits[0])).ToString());

        if (digits[0].Contains('?'))
        {
          if (digits[0].Length == result.Length)
          {
            var digitsC = digits[0].ToCharArray();
            var resultC = result.ToCharArray();
            for (var i = 0; i < result.Length; i++)
            {
              if (digitsC[i] != resultC[i])
                return int.Parse(resultC[i].ToString());
            }
          }
          return -1;
        }
        else
        {
          if ((int.Parse(comp[1]) % int.Parse(digits[0])) != 0)
            return -1;
          if (digits[1].Length == result.Length)
          {
            var digitsC = digits[1].ToCharArray();
            var resultC = result.ToCharArray();
            for (var i = 0; i < result.Length; i++)
            {
              if (digitsC[i] != resultC[i])
                return int.Parse(resultC[i].ToString());
            }
          }
          return -1;
        }

      }
      else
      {
        var index = comp[1].IndexOf('?');
        var result = 1;
        foreach (var digit in digits)
        {
          result *= int.Parse(digit);
        }
        var strResult = result.ToString().ToCharArray();
        return int.Parse(strResult[index].ToString());
      }
    }
  }
}
