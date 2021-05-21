using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Maersk.Sorting.Interface;
using Maersk.Sorting.Model.Enums;
using Maersk.Sorting.Model.Models;
using System.Linq;
using System.Diagnostics;

namespace Maersk.Sorting.Service
{
    public class SortJobProcessorService : ISortJobProcessorService
    {
        private readonly List<SortJob> _Jobs = new List<SortJob>();
        public SortJobProcessorService()
        {
        }

        public async Task<SortJob> EnqueueJob(SortJob job)
        {
            var t = Task.Run(async () => await ProcessTask(job));
            return job;
        }

        private async Task ProcessTask(SortJob job)
        {
            _Jobs.Add(job);
            var stopwatch = Stopwatch.StartNew();
            await Task.Delay(10000); // NOTE: This is just to simulate a more expensive operation
            var output = job.Input.OrderBy(n => n).ToArray();
            var duration = stopwatch.Elapsed;
            foreach (var j in _Jobs.Where(o => o.Id == job.Id))
            {
                j.SetOutPut(output);
                j.SetDuration(duration);
                j.SetStatus(SortJobStatus.Completed);
            }
        }

        public async Task<SortJob[]> GetJobs()
        {
            return await Task.Run(() => _Jobs.ToArray());
        }

        public async Task<SortJob> GetJob(Guid jobId)
        {
            return await Task.Run(() => _Jobs.Where(o => o.Id == jobId).FirstOrDefault());
        }
    }
}
