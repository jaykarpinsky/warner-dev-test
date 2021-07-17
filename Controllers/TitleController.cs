using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WarnerTestJK.Data;
using WarnerTestJK.Data.DTO;
using WarnerTestJK.Data.Models;
using WarnerTestJK.Data.Repositories.Abstract;

namespace WarnerTestJK.Controllers
{
    /// <summary>
    /// API for getting the title data from the datastore
    /// </summary>
    /// 
    [Route("api/[controller]")]
    [ApiController]
    public class TitleController : ControllerBase
    {
        private readonly IReadOnlyRepository<Title> _repo;
        private readonly ILogger<TitleController> _logger;

        public TitleController(IReadOnlyRepository<Title> repo, ILogger<TitleController> logger)
        {
            this._repo = repo;
            this._logger = logger;
        }

        /// <summary>
        /// Gets a specific Title
        /// </summary> 

        // GET: api/Artists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TitleDTO>> GetTitle(int id)
        {
            var title = await _repo.GetByIdAsync(id);

            if (title == null)
            {
                return NotFound();
            }

            return title.Adapt<TitleDTO>();
        }

        /// <summary>
        /// Gets a paged, sorted and filtered list of Titles
        /// </summary>
        /// <param name="pageIndex">Zero-based current page index (0 = first page)</param>
        /// <param name="pageSize">The actual size of each page</param>
        /// <param name="sortColumn">The sorting colum name</param>
        /// <param name="sortOrder">The sorting order ("ASC" or "DESC")</param>
        /// <param name="filterColumn">The filtering column name</param>
        /// <param name="filterQuery">The filtering query (value to lookup)</param>

        [HttpGet]
        public async Task<ActionResult<ApiResult<TitleDTO>>> GetTitles(  int pageIndex,
                                                                        int pageSize,
                                                                        string sortColumn = null,
                                                                        string sortOrder = null,
                                                                        string filterColumn = null,
                                                                        string filterQuery = null)
        {
            //adding a more complex filter than what in the API Result
            //so we can search on any name or language (OtherName table)
            //and handling if the filter is still null
            Expression<Func<Title, bool>> otherNameFilter = null;

            if (filterQuery != null)
            {
                var queryFilter = filterQuery;
                otherNameFilter = (t => t.TitleName.Contains(queryFilter) || t.OtherNames.Any(o => o.TitleName.Contains(queryFilter)));
                filterColumn = null;
                filterQuery = null;
            }

            return await ApiResult<TitleDTO>.CreateAsync(
                        _repo.List(otherNameFilter).ProjectToType<TitleDTO>(),
                        pageIndex,
                        pageSize,
                        sortColumn,
                        sortOrder,
                        filterColumn,
                        filterQuery);
        }


    }
}
