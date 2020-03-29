using System.Collections.Generic;
using System.IO;

namespace Infiniminer
{
    public class DatafileLoader
    {
        Dictionary<string, string> dataDict = new Dictionary<string, string>();
        public Dictionary<string, string> Data
        {
            get { return dataDict; }
        }

        public DatafileLoader(string filename)
        {
            try
            {
                FileStream file = new FileStream(filename, FileMode.Open, FileAccess.Read);
                StreamReader sr = new StreamReader(file);

                string line = sr.ReadLine();
                while (line != null)
                {
                    string[] args = line.Split("=".ToCharArray());
                    if (args.Length == 2 && line[0] != '#')
                    {
                        Data[args[0].Trim()] = args[1].Trim();
                    }
                    line = sr.ReadLine();
                }

                sr.Close();
                file.Close();
            }
            catch { }
        }
    }
}
