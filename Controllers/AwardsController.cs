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
    /// API for getting Award data
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    public class AwardsController : ControllerBase
    {
        private readonly IReadOnlyRepository<Award> _repo;
        private readonly ILogger<AwardsController> _logger;

        public AwardsController(IReadOnlyRepository<Award> repo, ILogger<AwardsController> logger)
        {
            this._repo = repo;
            this._logger = logger;
        }

        /// <summary>
        /// Gets a paged, sorted and filtered list of awards
        /// </summary>
        /// <param name="pageIndex">Zero-based current page index (0 = first page)</param>
        /// <param name="pageSize">The actual size of each page</param>
        /// <param name="sortColumn">The sorting colum name</param>
        /// <param name="sortOrder">The sorting order ("ASC" or "DESC")</param>
        /// <param name="filterColumn">The filtering column name</param>
        /// <param name="filterQuery">The filtering query (value to lookup)</param>
        [HttpGet]
        public async Task<ActionResult<ApiResult<AwardDTO>>> GetAwards( int pageIndex,
                                                                        int pageSize,
                                                                        string sortColumn = null,
                                                                        string sortOrder = null,
                                                                        string filterColumn = null,
                                                                        string filterQuery = null)
        {

            return await ApiResult<AwardDTO>.CreateAsync(
                        _repo.List().ProjectToType<AwardDTO>(),
                        pageIndex,
                        pageSize,
                        sortColumn,
                        sortOrder,
                        filterColumn,
                        filterQuery);

        }

        /// <summary>
        /// Gets the awards for the given Title
        /// </summary>
        // GET: api/awards/GetByTitle/1
        [HttpGet]
        [Route("GetByTitle/{id}")]
        public async Task<ActionResult<ApiResult<AwardDTO>>> GetByTitle(int id)
        {
            return await ApiResult<AwardDTO>.CreateAsync( _repo.List(a => a.TitleId == id).ProjectToType<AwardDTO>());
        }

    }
}
