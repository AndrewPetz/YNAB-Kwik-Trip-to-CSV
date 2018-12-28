using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace YNABKwikTripToCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            // check for transactions.csv file in same directory
            if(TransactionsFileExists(out string filepath))
            {
                // if there's a file, ask if they'd like to use it
                Console.WriteLine("Found a transactions file: " + filepath);
                Console.WriteLine("Would you like to use that file? (Y/N)");
                string response = Console.ReadLine();
                if(string.Equals(response, "Y", StringComparison.OrdinalIgnoreCase))
                {

                } else if(string.Equals(response, "N", StringComparison.OrdinalIgnoreCase))
                {

                } else
                {

                }
            }
            else
            {
                // if there isn't a file, ask for a filepath
            }
            
            // double-check if the csv is valid
            // if it is, do the logic to rearrange it and save it to the same place
        }

        private static bool TransactionsFileExists(out string filepath)
        {
            bool rVal = false;
            string currentDir = Directory.GetCurrentDirectory();
            string[] filesInDirectory = Directory.GetFiles(currentDir);
            filepath = currentDir + "\\transactions.csv";

            rVal = filesInDirectory.ToList().Contains(filepath, StringComparer.OrdinalIgnoreCase);

            return rVal;
        }

        // transaction date => date
        // payee => Kwik Trip
        // memo => blank (feature idea: dollar amount threshold for setting memo to gas)
        // transaction total => outflow
        //  if the total is a negative number, put it in the inflow column

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
