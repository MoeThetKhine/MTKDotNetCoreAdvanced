using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MTKDotNetCoreAdvancedC_.Utils.Enum
{
    public enum EnumHttpStatusCode
    {
        None,
        Success = 200,
        BadRequest = 400,
        Conflict = 409,
        NotFound = 404,
        InternalServerError = 500
    }
}
