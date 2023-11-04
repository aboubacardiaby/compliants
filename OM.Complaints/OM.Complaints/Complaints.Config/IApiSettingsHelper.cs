using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complaints.Config
{
    public interface IApiSettingsHelper
    {
        Task<string> GetAccessToken();
        string GetAuthorityUrl();
        string GetScopeUrl();
    }
}
