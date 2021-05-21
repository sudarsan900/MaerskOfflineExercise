using System;
using System.Threading.Tasks;
using Maersk.Sorting.Interface;
using Maersk.Sorting.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace Maersk.Sorting.Api.Controllers
{
    [Route("sort")]
    public class SortController : ControllerBase
    {
        private readonly ISortService _sortService;
        public SortController(ISortService sortService)
        {
            _sortService = sortService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(SortJob), 200)]
        public async Task<ActionResult<SortJob>> EnqueueJob(int[] values)
        {
            var response = await _sortService.EnqueueJob(values);
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(SortJob[]), 200)]
        public async Task<ActionResult<SortJob[]>> GetJobs()
        {
            var response = await _sortService.GetJobs();
            return Ok(response);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        [HttpGet("{jobId}")]
        [ProducesResponseType(typeof(SortJob), 200)]
        public async Task<ActionResult<SortJob>> GetJob(Guid jobId)
        {
            var response = await _sortService.GetJob(jobId);
            return Ok(response);
        }
    }
}