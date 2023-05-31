using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructure.Services.Statuses
{
    public enum RepositoryStatus
    {
        NullEntity,
        Success,
        DatabaseError,
        BookNotExist,
        TableIsEmpty
    }
}
