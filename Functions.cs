using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;


public class Functions
{
  private static readonly string Characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
  private static readonly Random Random = new Random();

  public static string generate_random_string(int length)
  {
    char[] chArray = new char[length];
    for (int index1 = 0; index1 < length; ++index1)
    {
      int index2 = Functions.Random.Next(Functions.Characters.Length);
      chArray[index1] = Functions.Characters[index2];
    }
    return new string(chArray);
  }

  public static string RandomizeCase(string input)
  {
    char[] chArray = new char[input.Length];
    for (int index = 0; index < input.Length; ++index)
    {
      char c = input[index];
      if (char.IsLetter(c))
      {
        bool flag = Functions.Random.Next(2) == 0;
        chArray[index] = flag ? char.ToUpper(c) : char.ToLower(c);
      }
      else
        chArray[index] = c;
    }
    return new string(chArray);
  }

  public static byte[] XorEncryptDecrypt(byte[] data, byte[] key)
  {
    byte[] numArray = new byte[data.Length];
    for (int index = 0; index < data.Length; ++index)
      numArray[index] = (byte) ((uint) data[index] ^ (uint) key[index % key.Length]);
    return numArray;
  }

  public static string Choose_File()
  {
    OpenFileDialog openFileDialog = new OpenFileDialog();
    openFileDialog.Filter = "Executable files (*.exe)|*.exe";
    openFileDialog.Title = "Select an EXE file";
    openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    if (openFileDialog.ShowDialog() != DialogResult.OK)
      return (string) null;
    string fileName = openFileDialog.FileName;
    return openFileDialog.FileName;
  }

  public static bool IsDotNetAssembly(string filePath)
  {
    try
    {
      AssemblyName.GetAssemblyName(filePath);
      return true;
    }
    catch (BadImageFormatException ex)
    {
      return false;
    }
    catch
    {
      return false;
    }
  }

  public static string EncryptBytes(byte[] inputBytes, int key)
  {
    return Convert.ToBase64String(((IEnumerable<byte>) inputBytes).Select<byte, byte>((Func<byte, byte>) (b => (byte) ((uint) b ^ (uint) key))).ToArray<byte>());
  }

  public static int GenerateRandomKey() => new Random().Next(0, 256);
}
