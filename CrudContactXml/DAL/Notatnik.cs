using CrudContactXml.Models;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace CrudContactXml.DAL
{
    public class Notatnik
    {
        private readonly string Path;
        public List<Category> Category { get; set; }

        public Notatnik(IHostingEnvironment hostingEnvironment)
        {
            Path = hostingEnvironment.WebRootPath + "\\notatnik.xml";
            this.Load();
        }

        public Notatnik Load()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Category>));

            try
            {
                using (Stream fileStream = new FileStream(Path, FileMode.OpenOrCreate))
                {
                    Category = (List<Category>)serializer.Deserialize(fileStream);
                }
            }
            catch
            {
                Category = new List<Category>();
            }

            return this;
        }

        public Notatnik Write()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Category>));

            using (Stream fileStream = new FileStream(Path, FileMode.Create))
            {
                serializer.Serialize(fileStream, Category);
            }

            return this;
        }
    }
}
