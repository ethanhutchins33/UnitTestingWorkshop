using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingWorkshopTwo
{
    public interface IDateTimeFacade
    {
        DateTime UtcNow();
    }

    [ExcludeFromCodeCoverage]
    public class DateTimeFacade : IDateTimeFacade
    {
        public DateTime UtcNow()
        {
            return DateTime.UtcNow;
        }
    }
}
    
