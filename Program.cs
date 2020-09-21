using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Xml;
using System.Drawing;
using System.Text;



namespace API_Endpoint
{
    class Program
    {
        public static void Main()
        {
            var client = new HttpClient(); 
            
            WebRequest request = WebRequest.Create(
              "http://www.esbl.ee/opendata/?etH%5Beesnimi%5D=on&etH%5Bperenimi%5D=on&etH%5Btekst%5D=on&"+
              "synd_min=&synd_max=&surm_min=&surm_max=&sugu=0&sport_id=0&org_id=0&etH%5Bommedaliomanik%5D=on&ommedaliomanik=on&etH%5Bomosalenud%5D=on&omosalenud=on&eok_tk=0&eok_ek=0&type=&submit=OK"
              );
          
           
            WebResponse response = request.GetResponse();
            
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);

           string responseXML = "";
            using (Stream dataStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(dataStream);
                responseXML = reader.ReadToEnd();
            }
            var xml = new XmlDocument();
            xml.LoadXml(responseXML);
           XmlNodeList FirstNames =  xml.GetElementsByTagName("eesnimi");
           XmlNodeList LastNames =  xml.GetElementsByTagName("perenimi");
           XmlNodeList Teksts =  xml.GetElementsByTagName("tekst");
           XmlNodeList OlympicMedals = xml.GetElementsByTagName("ommedaliomanik");
           XmlNodeList Participated  = xml.GetElementsByTagName("omosalenud");
           XmlNodeList PersonId  = xml.GetElementsByTagName("per_id");

            Console.WriteLine("Enter first name");
            string FirstName = Console.ReadLine();
            Console.WriteLine("Enter last name");
            string LastName = Console.ReadLine();

            Console.WriteLine("----");
         
            for(int i = 0; i < FirstNames.Count; i++)
            {
                if(FirstNames[i].InnerText == FirstName && LastNames[i].InnerText == LastName)
                {
                    Console.WriteLine("First name: "+FirstNames[i].InnerText);
                    Console.WriteLine("Last name: "+LastNames[i].InnerText);
                    Console.WriteLine(Teksts[i].InnerText);
                    Console.WriteLine("Olympic medals: "+OlympicMedals[i].InnerText);
                    Console.WriteLine("Participated in the Olympics: " + Participated[i].InnerText);
                    Console.WriteLine("Picture link: http://www.esbl.ee/admin/photo/"+PersonId[i].InnerText
                     + ".jpg" );
                }
            }
            response.Close();
        }


    //     private const string BLACK = "@";
    //     private const string CHARCOAL = "#";
    //     private const string DARKGRAY = "8";
    //     private const string MEDIUMGRAY = "&";
    //     private const string MEDIUM = "o";
    //     private const string GRAY = ":";
    //     private const string SLATEGRAY = "*";
    //     private const string LIGHTGRAY = ".";
    //     private const string WHITE = " ";
    //     public static string GrayscaleImageToASCII(Image img)
    //         {
    //             StringBuilder html = new StringBuilder();
    //             Bitmap bmp = null;

    //             try
    //             {
    //                 // Create a bitmap from the image

    //                 bmp = new Bitmap(img);

    //                 // The text will be enclosed in a paragraph tag with the class

    //                 // ascii_art so that we can apply CSS styles to it.

    //                 html.Append("&lt;br/&rt;");

    //                 // Loop through each pixel in the bitmap

    //                 for (int y = 0; y < bmp.Height; y++)
    //                 {
    //                     for (int x = 0; x < bmp.Width; x++)
    //                     {
    //                         // Get the color of the current pixel

    //                         Color col = bmp.GetPixel(x, y);

    //                         // To convert to grayscale, the easiest method is to add

    //                         // the R+G+B colors and divide by three to get the gray

    //                         // scaled color.

    //                         col = Color.FromArgb((col.R + col.G + col.B) / 3,
    //                             (col.R + col.G + col.B) / 3,
    //                             (col.R + col.G + col.B) / 3);

    //                         // Get the R(ed) value from the grayscale color,

    //                         // parse to an int. Will be between 0-255.

    //                         int rValue = int.Parse(col.R.ToString());

    //                         // Append the "color" using various darknesses of ASCII

    //                         // character.

    //                         html.Append(getGrayShade(rValue));

    //                         // If we're at the width, insert a line break

    //                         if (x == bmp.Width - 1)
    //                             html.Append("&lt;br/&rt");
    //                     }
    //                 }

    //                 // Close the paragraph tag, and return the html string.

    //                 html.Append("&lt;/p&rt;");

    //                 return html.ToString();
    //             }
    //             catch (Exception exc)
    //             {
    //                 return exc.ToString();
    //             }
    //             finally
    //             {
    //                 bmp.Dispose();
    //             }
    //         }

    //         private static string getGrayShade(int redValue)
    //         {
    //             string asciival = " ";

    //             if (redValue >= 230)
    //             {
    //                 asciival = WHITE;
    //             }
    //             else if (redValue >= 200)
    //             {
    //                 asciival = LIGHTGRAY;
    //             }
    //             else if (redValue >= 180)
    //             {
    //                 asciival = SLATEGRAY;
    //             }
    //             else if (redValue >= 160)
    //             {
    //                 asciival = GRAY;
    //             }
    //             else if (redValue >= 130)
    //             {
    //                 asciival = MEDIUM;
    //             }
    //             else if (redValue >= 100)
    //             {
    //                 asciival = MEDIUMGRAY;
    //             }
    //             else if (redValue >= 70)
    //             {
    //                 asciival = DARKGRAY;
    //             }
    //             else if (redValue >= 50)
    //             {
    //                 asciival = CHARCOAL;
    //             }
    //             else
    //             {
    //                 asciival = BLACK;
    //             }

    //             return asciival;
    //         }
      }
}
