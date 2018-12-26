using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YNABKwikTripToCSV
{
    class Program
    {
        static void Main(string[] args)
        {
        }

        public void RemoveColumnByIndex(string path, int index)
        {
            List<string> lines = new List<string>();
            using (StreamReader reader = new StreamReader(path))
            {
                var line = reader.ReadLine();
                List<string> values = new List<string>();
                while (line != null)
                {
                    values.Clear();
                    var cols = line.Split(',');
                    for (int i = 0; i < cols.Length; i++)
                    {
                        if (i != index)
                            values.Add(cols[i]);
                    }
                    var newLine = string.Join(",", values);
                    lines.Add(newLine);
                    line = reader.ReadLine();
                }
            }

            using (StreamWriter writer = new StreamWriter(path, false))
            {
                foreach (var line in lines)
                {
                    writer.WriteLine(line);
                }
            }

        }
    }
}
