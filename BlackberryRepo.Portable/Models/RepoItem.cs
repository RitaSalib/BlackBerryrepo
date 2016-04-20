using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackberryRepo.Portable.Models
{
    public class RepoItem
    {

        public int id
        {get; set;}
        public string name { get; set; }
        public string description { get; set; }
        public string language { get; set; }
        public string html_url { get; set; } 
            
    }
}
