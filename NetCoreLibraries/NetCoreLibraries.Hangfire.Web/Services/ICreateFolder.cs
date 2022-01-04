using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLibraries.Hangfire.Web.Services
{
    public interface ICreateFolder
    {
        void CreateFile(string message);
    }
}
