using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using System.Xml.Serialization;

namespace ConsoleApp2.models
{
    [Serializable]
    public class Student
    {
        [Index(0)]
        [JsonPropertyName("Imie")]
        [XmlElement(ElementName ="Imie")]
        public string FirstName { get; set; }

        [Index(1)]
        public string LastName { get; set; }

        [Index(2)]
        public string Faculty { get; set; }
        [Index(3)]
        public string StudyMode { get; set; }
        [Index(4)]
        public string Number { get; set; }
        [Index(5)]
        public string Date { get; set; }
        [Index(6)]
        public string Mail { get; set; }
        [Index(7)]
        public string MothersName { get; set; }
        [Index(8)]
        public string FathersName { get; set; }


    }
}
