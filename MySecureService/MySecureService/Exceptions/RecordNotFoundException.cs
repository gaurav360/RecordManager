using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySecureService.Exceptions
{
    public class RecordNotFoundException:ApplicationException
    {
        public RecordNotFoundException() { }
        public RecordNotFoundException(string recordId) :base($"Record with this id {recordId} does not exist") { }
    }
}
