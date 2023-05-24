using System;
using System.IO;

namespace CSVFileSearch
{
    class SearchProgram
    {
        static void Main(string[] args)
        {
            // Checking if command line arguments are provided correctly
            if (args.Length != 3)
            {
                Console.WriteLine("\nWrong arguments entered!!\n\n ------ Utilization------\n node search.js <file_path> <column_number> <search_key>");
                return;
            }

            string filePath = args[0];
            int colunmNumber = Convert.ToInt32(args[1]);
            string searchKey = args[2];

            try
            {
               
                using (StreamReader reader = new StreamReader(filePath))
                {
                    string row;
                    // Read the CSV file
                    while ((row = reader.ReadLine()) != null)
                    {
                        string[] columns = row.Split(',');
                        
                         Console.WriteLine("------Search Result-----");

                        // Search for matching records
                        if (columns.Length > colunmNumber && columns[colunmNumber].Trim().Equals(searchKey))
                        {
                            Console.WriteLine(row);// Output matching records 
                            return;
                        }
                    }
                }

                Console.WriteLine("No records matching the search critera were found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("-----Error------");
                Console.WriteLine("An error has been encountered: " + ex.Message);
            }
        }
    }
}
