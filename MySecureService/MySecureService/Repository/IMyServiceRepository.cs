using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySecureService.Models;

namespace MySecureService.Repository
{
    public interface IMyServiceRepository
    {        
        List<MyRecords> GetMyRecords();
        MyRecords FindByRecordId(string recordId);
        bool SaveRecord(MyRecords record);
    }
}
