using System;
using System.Threading.Tasks;
using Maersk.Sorting.Model.Models;

namespace Maersk.Sorting.Interface
{
    public interface ISortJobProcessorService
    {
        Task<SortJob> EnqueueJob(SortJob job);
        Task<SortJob[]> GetJobs();
        Task<SortJob> GetJob(Guid jobId);
    }
}
