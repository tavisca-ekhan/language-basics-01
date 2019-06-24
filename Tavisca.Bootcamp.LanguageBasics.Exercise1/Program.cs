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
      var components = equation.Split('=');
      var digits = components[0].Split('*');

      int rhsResult;
      var rhs = int.TryParse(components[1], out rhsResult);

      int firstDigitResult;
      var firstDigit = int.TryParse(digits[0], out firstDigitResult);

      int secondDigitResult;
      var secondDigit = int.TryParse(digits[1], out secondDigitResult);

      if (components[0].Contains('?'))
      {
        var result = digits[0].Contains('?') ? ((rhsResult / secondDigitResult).ToString()) : ((rhsResult / firstDigitResult).ToString());

        if (digits[0].Contains('?'))
        {
          if (digits[0].Length == result.Length)
          {
            var digitsC = digits[0].ToCharArray();
            var resultC = result.ToCharArray();
            for (var index = 0; index < result.Length; index++)
            {
              if (digitsC[index] != resultC[index])
              {
                int returnResult;
                var temp = int.TryParse(resultC[index].ToString(), out returnResult);
                return returnResult;
              }

            }
          }
          return -1;
        }
        else
        {
          if ((rhsResult % firstDigitResult) != 0)
            return -1;
          if (digits[1].Length == result.Length)
          {
            var digitsC = digits[1].ToCharArray();
            var resultC = result.ToCharArray();
            for (var index = 0; index < result.Length; index++)
            {
              if (digitsC[index] != resultC[index])
              {
                int returnResult;
                var temp = int.TryParse(resultC[index].ToString(), out returnResult);
                return returnResult;
              }

            }
          }
          return -1;
        }

      }
      else
      {
        var index = components[1].IndexOf('?');
        var result = 1;
        foreach (var digit in digits)
        {
          int tempInt;
          var tempBool = int.TryParse(digit, out tempInt);
          result *= tempInt;
        }
        var strResult = result.ToString().ToCharArray();
        int intResult;
        bool finalResult = int.TryParse(strResult[index].ToString(), out intResult);
        return intResult;
      }
    }
  }
}
