using System;
using System.Collections.Generic;
using System.Text;

namespace PointOfSale.Domain.Enums
{
    public enum ResponseResultType
    {
        Success,
        NotFound,
        AlreadyExists,
        NoChanges,
        ValidationError
    }
}
