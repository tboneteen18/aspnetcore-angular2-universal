using System;

namespace AspCoreServer.Models
{
    public class Client
    {
        public int ClientId { get; set; }
        public int PrimaryContactId { get; set; }
        public DateTime DateCreated { get; set; }
        public int PrimaryUserId { get; set; }
    }
}
