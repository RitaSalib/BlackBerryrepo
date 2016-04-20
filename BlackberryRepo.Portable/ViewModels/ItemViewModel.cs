using BlackberryRepo.Portable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackberryRepo.Portable.ViewModels
{
    public class ItemViewModel
    {
        public RepoItem Repo{get; set;}
        public ItemViewModel(RepoItem repo)
        {
            this.Repo = repo;
        }
    }
}
