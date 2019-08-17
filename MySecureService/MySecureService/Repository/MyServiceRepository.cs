using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySecureService.Models;

namespace MySecureService.Repository
{
    public class MyServiceRepository : IMyServiceRepository
    {
        private readonly IMyServiceContext context;

        public MyServiceRepository(IMyServiceContext _context)
        {
            context = _context;
        }

        public List<MyRecords> GetMyRecords()
        {
            return context.MyRecords.ToList();
        }

        public MyRecords FindByRecordId(string recordId)
        {
            return context.MyRecords.FirstOrDefault(x => x.RecordId.Equals(recordId));
        }

        public bool SaveRecord(MyRecords record)
        {
           context.MyRecords.Add(record);
            context.SaveChanges();
            return true;
        }
    }
}
