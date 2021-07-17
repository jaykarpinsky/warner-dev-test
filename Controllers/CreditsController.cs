using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using WarnerTestJK.Data;
using WarnerTestJK.Data.DTO;
using WarnerTestJK.Data.Models;
using WarnerTestJK.Data.Repositories.Abstract;

namespace WarnerTestJK.Controllers
{
    /// <summary>
    /// API for getting people and companies the worked on a title
    /// </summary>
    /// 
    [Route("api/[controller]")]
    [ApiController]
    public class CreditsController : ControllerBase
    {
        private readonly IReadOnlyRepository<TitleParticipant> _repo;
        private readonly ILogger<CreditsController> _logger;

        public CreditsController(IReadOnlyRepository<TitleParticipant> repo, ILogger<CreditsController> logger)
        {
            this._repo = repo;
            this._logger = logger;
        }

        /// <summary>
        /// Gets a paged, sorted and filtered list of credits
        /// </summary>
        /// <param name="pageIndex">Zero-based current page index (0 = first page)</param>
        /// <param name="pageSize">The actual size of each page</param>
        /// <param name="sortColumn">The sorting colum name</param>
        /// <param name="sortOrder">The sorting order ("ASC" or "DESC")</param>
        /// <param name="filterColumn">The filtering column name</param>
        /// <param name="filterQuery">The filtering query (value to lookup)</param>
        
        [HttpGet]
        public async Task<ActionResult<ApiResult<CreditDTO>>> GetCredits(int pageIndex,
                                                                         int pageSize,
                                                                         string sortColumn = null,
                                                                         string sortOrder = null,
                                                                         string filterColumn = null,
                                                                         string filterQuery = null)
        {

            return await ApiResult<CreditDTO>.CreateAsync(
                        _repo.List().ProjectToType<CreditDTO>(),
                        pageIndex,
                        pageSize,
                        sortColumn,
                        sortOrder,
                        filterColumn,
                        filterQuery);

        }

        /// <summary>
        /// Gets the credits for the given Title
        /// </summary> 
        // GET: api/credits/GetByTitle/1
        [HttpGet]
        [Route("GetByTitle/{id}")]
        public async Task<ActionResult<ApiResult<CreditDTO>>> GetByTitle(int id)
        {
            return await ApiResult<CreditDTO>.CreateAsync(_repo.List(t => t.TitleId == id, null, "Participant").ProjectToType<CreditDTO>());
        }

    }
}
