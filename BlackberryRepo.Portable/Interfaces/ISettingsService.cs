using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackberryRepo.Portable.Interfaces
{
    public interface ISettingsService
    {
        void Initialize();
        void OnSettingsPaneCommandsRequested(object sender, object args);
    }
}
