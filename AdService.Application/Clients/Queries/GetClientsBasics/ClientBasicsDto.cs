using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdService.Application.Clients.Queries.GetClients
{
    public class ClientBasicsDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        //public bool IsBusinessAccount { get; set; }
        public bool IsDeleted { get; set; }
    }
}
