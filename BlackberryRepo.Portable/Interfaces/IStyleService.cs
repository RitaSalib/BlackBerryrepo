using BlackberryRepo.Portable.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackberryRepo.Portable.Interfaces
{
    public interface IStyleService
    {
       void SetStyle(Theme theme);
        //Theme GetCurrentStyle();
    }
}
