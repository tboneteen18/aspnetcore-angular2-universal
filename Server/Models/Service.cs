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
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }

        //Setting Default value
        public Service()
        {
            DateCreated = DateTime.Now;
        }
    }
}
