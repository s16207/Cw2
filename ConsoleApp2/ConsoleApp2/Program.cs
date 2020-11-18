using System;

using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using System.Collections;
using System.Xml.Linq;
using System.Data;
using CsvHelper;
using System.Globalization;
using ConsoleApp2.models;
using System.Linq;
using System.Text.Json;


namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Zapewnienie ustawien domyslnych
            string defaultCSV = "data.csv";
            string defaultResult = "result.xml";
            string defaultDataType = "xml";
            string sourceFile;
            string exportFile;

            sourceFile = ((args[0] == null) || (args[0] == "")) ? defaultCSV : args[0];
            exportFile = ((args[1] == null) || (args[1] == "")) ? defaultResult : args[1];
            string formatDanych = ((args[2] == null) || (args[2] == "")) ? defaultDataType : args[2];

            //Wczytanie


            using (StreamReader reader = new StreamReader(sourceFile))
            using (CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                //Console.WriteLine(reader + "*****");
                //Console.WriteLine(csv + "*****");

                Student student = new Student();

                    csv.Configuration.HasHeaderRecord = false;
                    csv.Configuration.MissingFieldFound = null;

                    List<Student> fatRecords = csv.GetRecords<Student>().ToList();

                    Console.WriteLine(fatRecords.Count);

                //Usuniecie duplikatow - Distinct nie dziala
                //fatRecords.Select(x => x.Number).Distinct();
                //Console.WriteLine(fatRecords.Count);

                //Usuniecie duplikatow 
                HashSet<Student> hashset = new HashSet<Student>(); 
                foreach (Student record in fatRecords)
                {
                    hashset.Add(record);
                }

                List<Student> records = new List<Student>();
                foreach (Student item in hashset)
                {
                    records.Add(item);
                }

                Console.WriteLine(records.Count);

                //Do XML
                FileStream writer = new FileStream(exportFile, FileMode.Create);
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Student>), new XmlRootAttribute("uczelnia"));
                    serializer.Serialize(writer, records);
                    writer.Close();

                    //Do JSON
                    string jsonString = JsonSerializer.Serialize(records);
                    File.WriteAllText("data.json", jsonString);

                }
        }
    }
}
