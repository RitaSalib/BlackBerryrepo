﻿using BlackberryRepo.Portable.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackberryRepo.Portable.Interfaces
{
    public interface INavigationService
    {
        void NavigateTo(ApplicationSection section);
        void NavigateTo(object parameter);
    }
}
