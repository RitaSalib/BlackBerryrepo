using BlackberryRepo.Portable.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackberryRepo.Portable.Interfaces
{
    public interface IGlobalizationService
    {
        void SetCulture(Language language);
        Language GetCurrentLanguage();
    }
}
