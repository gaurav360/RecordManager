using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySecureService.Exceptions;
using MySecureService.Models;
using MySecureService.Repository;

namespace MySecureService.Service
{
    public class MyService : IMyService
    {
        private readonly IMyServiceRepository repository;
        
        public MyService(IMyServiceRepository _repository)
        {
            this.repository = _repository;
        }

        public MyRecords FindByRecordId(string recordId)
        {
            var rec = repository.FindByRecordId(recordId);
            if (rec == null)
            {
                throw new RecordNotFoundException(recordId);
            }

            return rec;
        }

        public List<MyRecords> GetMyRecords()
        {
            return repository.GetMyRecords();           
        }

        public bool SaveRecord(MyRecords record)
        {
            return repository.SaveRecord(record);
        }
    }
}
