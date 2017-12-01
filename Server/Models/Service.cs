using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspCoreServer.Models
{
    public class Service
    {
        public int ServiceId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string IsActive { get; set; }
        public string DateCreated { get; set; }

        //Setting Default value
        public Service()
        {
            DateCreated = DateTime.Now.ToString();
        }
    }
}
