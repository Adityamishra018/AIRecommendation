using System.Configuration;
using System.IO;

namespace AIRecommendation.DataLoader
{
    public class FileLogger : ILog
    {
        public string Path { get; set; } = ConfigurationManager.AppSettings["Logs"];
        public void Log(string message)
        {
            using (StreamWriter sr = new StreamWriter(Path, true))
            {
                sr.WriteLine(message);
            }
        }
    }
}
