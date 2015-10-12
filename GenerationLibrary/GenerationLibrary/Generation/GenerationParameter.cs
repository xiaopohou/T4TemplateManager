using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
namespace Codenesium.GenerationLibrary.Generation
{
    public class GenerationParameter
    {
        public string Name { get; set; }
        public string DataType { get; set; }
        public string NumericPrecision { get; set; }
        public string Mode { get; set; }
        public string MaxLength { get; set; }
        public string MappedDatabaseFieldName { get; set; }
        public string MappedDatabaseFieldType { get; set; }
        public string BOObjectType { get; set; }
        public string IsBoolean { get; set; }

        public static List<GenerationParameter> ParseParameters(XElement xml)           
        {

  
            List<GenerationParameter> response = (from fi in xml.Element("root").Element("children").Elements("fields").Elements("children").Elements("field")
                                                  select new GenerationParameter
                                                  {
                                                      Name = (from f in fi.Elements("children").Elements("attribute")
                                                              where f.Attribute("name").Value == "Name"
                                                              select f.Attribute("value").Value).FirstOrDefault(),
                                                      DataType = (from f in fi.Elements("children").Elements("attribute")
                                                                  where f.Attribute("name").Value == "DataType"
                                                                  select f.Attribute("value").Value).FirstOrDefault(),
                                                      NumericPrecision = (from f in fi.Elements("children").Elements("attribute")
                                                                          where f.Attribute("name").Value == "NumericPrecision"
                                                                          select f.Attribute("value").Value).FirstOrDefault(),
                                                      Mode = (from f in fi.Elements("children").Elements("attribute")
                                                              where f.Attribute("name").Value == "Mode"
                                                              select f.Attribute("value").Value).FirstOrDefault(),
                                                      MaxLength = (from f in fi.Elements("children").Elements("attribute")
                                                                   where f.Attribute("name").Value == "MaxLength"
                                                                   select f.Attribute("value").Value).FirstOrDefault(),
                                                      MappedDatabaseFieldName = (from f in fi.Elements("children").Elements("attribute")
                                                                                 where f.Attribute("name").Value == "MappedDatabaseFieldName"
                                                                                 select f.Attribute("value").Value).FirstOrDefault(),
                                                      MappedDatabaseFieldType = (from f in fi.Elements("children").Elements("attribute")
                                                                                 where f.Attribute("name").Value == "MappedDatabaseFieldType"
                                                                                 select f.Attribute("value").Value).FirstOrDefault(),
                                                      BOObjectType = (from f in fi.Elements("children").Elements("attribute")
                                                                      where f.Attribute("name").Value == "BOObjectType"
                                                                      select f.Attribute("value").Value).FirstOrDefault(),
                                                      IsBoolean = (from f in fi.Elements("children").Elements("attribute")
                                                                   where f.Attribute("name").Value == "IsBoolean"
                                                                   select f.Attribute("value").Value).FirstOrDefault()

                                                  }).ToList();

            return response;
        }
    }
}
