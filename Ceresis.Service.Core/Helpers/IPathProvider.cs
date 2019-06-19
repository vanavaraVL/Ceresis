using System;
using System.Collections.Generic;
using System.Text;

namespace Ceresis.Service.Core.Helpers
{
    public interface IPathProvider
    {
        string MapPath(string path);

        string MapPathContent(string path);
    }
}
