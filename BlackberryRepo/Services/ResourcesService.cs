using BlackberryRepo.Portable.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;

namespace BlackberryRepo.Services
{
    class ResourcesService:IResourcesService
    {
        public ResourceLoader loader;
 
        public ResourcesService()
        {
            this.loader = new ResourceLoader();
        }

        public string GetString(string key)
        {
            return loader.GetString(key);
        }
    }
}
