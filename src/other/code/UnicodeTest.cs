using System;
using System.Text;
using System.Text.RegularExpressions;

namespace UnicodeTest
{
  public class UnicodeTest
  {
    public static void Main()
    {
      string strings = "国‌";
      Console.WriteLine("\nEncoded bytes:{0}", String2Unicode(strings));
      Console.WriteLine();
    }

    public static string String2Unicode(string source)
    {
      byte[] bytes = Encoding.Unicode.GetBytes(source);
      StringBuilder stringBuilder = new StringBuilder();
      for (int i = 0; i < bytes.Length; i += 2)
      {
        stringBuilder.AppendFormat("\\u{0}{1}", bytes[i + 1].ToString("x").PadLeft(2, '0'), bytes[i].ToString("x").PadLeft(2, '0'));
      }
      return stringBuilder.ToString();
    }

    public static string Unicode2String(string source)
    {
      return new Regex(@"\\u([0-9A-F]{4})", RegexOptions.IgnoreCase | RegexOptions.Compiled).Replace(
                   source, x => string.Empty + Convert.ToChar(Convert.ToUInt16(x.Result("$1"), 16)));
    }
  }
}