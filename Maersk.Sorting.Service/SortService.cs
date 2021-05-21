using System;
using System.Threading.Tasks;
using Maersk.Sorting.Interface;
using Maersk.Sorting.Model.Enums;
using Maersk.Sorting.Model.Models;

namespace Maersk.Sorting.Service
{
    public class SortService : ISortService
    {
        private readonly ISortJobProcessorService _sortJobProcessorService;
        public SortService(ISortJobProcessorService sortJobProcessorService)
        {
            _sortJobProcessorService = sortJobProcessorService;
        }

        public async Task<SortJob> EnqueueJob(int[] values)
        {

            var job = new SortJob(
                id: Guid.NewGuid(),
                status: SortJobStatus.Pending,
                duration: null,
                input: values,
                output: null
            );
            return await _sortJobProcessorService.EnqueueJob(job);
        }

        public async Task<SortJob> GetJob(Guid jobId)
        {
            return await _sortJobProcessorService.GetJob(jobId);
        }

        public async Task<SortJob[]> GetJobs()
        {
            return await _sortJobProcessorService.GetJobs();
        }
    }
}
