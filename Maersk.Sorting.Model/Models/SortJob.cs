using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Maersk.Sorting.Model.Enums;

namespace Maersk.Sorting.Model.Models
{
    public class SortJob
    {
        public SortJob(Guid id, SortJobStatus status, TimeSpan? duration, IReadOnlyCollection<int> input, IReadOnlyCollection<int>? output)
        {
            Id = id;
            Status = status;
            Duration = duration;
            Input = input;
            Output = output;
        }

        public Guid Id { get; }
        public SortJobStatus Status { get; private set; }
        public TimeSpan? Duration { get; private set; }
        public IReadOnlyCollection<int> Input { get; }
        public IReadOnlyCollection<int>? Output { get; private set; }

        public void SetDuration(TimeSpan duration)
        {
            Duration = duration;
        }
        public void SetOutPut(IReadOnlyCollection<int> output)
        {
            Output = output;
        }
        public void SetStatus(SortJobStatus status)
        {
            Status = status;
        }
    }
}