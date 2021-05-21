using System;
using System.Threading.Tasks;
using Maersk.Sorting.Model.Models;

namespace Maersk.Sorting.Interface
{
    public interface ISortService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        Task<SortJob> EnqueueJob(int[] values);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<SortJob[]> GetJobs();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        Task<SortJob> GetJob(Guid jobId);
    }
}
