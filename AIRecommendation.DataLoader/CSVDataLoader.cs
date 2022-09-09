using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Configuration;

namespace AIRecommendation.DataLoader
{
    public class CSVDataLoader : IDataLoader
    {
        public ILog Logger = new FileLogger();

        void ReadRatings(BookDetails details)
        {
            StreamReader sr;
            sr = new StreamReader(ConfigurationManager.AppSettings["Ratings"]);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                string[] vals = line.Split(';');
		try
		{
		     if (vals[0] != "\"User-ID\"")
                     {
                    	details.Ratings.Add(new BookUserRating() { UserID = int.Parse(vals[0].Trim('"')), ISBN = vals[1].Trim('"'), Rating = byte.Parse(vals[2].Trim('"')) });
                     }
                
		}
		catch (Exception)
                {
                    //Logger.Log(line);
                }
            }
        }

        void ReadBooks(BookDetails details)
        {
            StreamReader sr;
            sr = new StreamReader(ConfigurationManager.AppSettings["Books"]);
            while (!sr.EndOfStream)
            {

                string line = sr.ReadLine();
                string[] vals = line.Split(new string[] { ";\"" }, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    if (vals[0] != "\"ISBN\"")
                    {

                        details.Books.Add(new Book() { ISBN = vals[0].Trim('"'), BookTitle = vals[1].Trim('"'), BookAuthor = vals[2].Trim('"'), YearOfPublication = short.Parse(vals[3].Trim('"')), Publisher = vals[4].Trim('"'), ImgUrlSmall = vals[5].Trim('"'), ImgUrlMedium = vals[6].Trim('"'), ImgUrlLarge = vals[7].Trim('"') });
                    }
                }
                catch (Exception)
                {
                    //Logger.Log(line);
                }
            }
        }

        void ReadUsers(BookDetails details)
        {
            StreamReader sr;
            sr = new StreamReader(ConfigurationManager.AppSettings["Users"]);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();

                string[] vals = line.Split(new string[] { "\";" }, StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    if (vals[0] != "\"User-ID\"")
                    {
                        details.Users.Add(new User() { UserID = int.Parse(vals[0].Trim('"')), Age = vals[2] != "NULL" ? byte.Parse(vals[2].Trim('"')) : (byte)0, City = vals[1].Split(',')[0].Trim('"'), State = vals[1].Split(',')[1].Trim('"', ' '), Country = vals[1].Split(',')[2].Trim('"', ' ') });

                    }
                }
                catch (Exception)
                {
                    //Logger.Log(line);
                }
            }
        }
        public BookDetails Load()
        {
            BookDetails details = new BookDetails();
            Parallel.Invoke(()=> { ReadBooks(details); },()=> { ReadUsers(details); },()=> { ReadRatings(details); });
            return details;
        }
    }
}
