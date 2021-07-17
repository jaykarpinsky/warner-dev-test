using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using WarnerTestJK.Data.DTO;
using WarnerTestJK.Data.Models;
using WarnerTestJK.Data.Repositories.Abstract;

namespace WarnerTestJK.Controllers
{
    /// <summary>
    /// API for getting various descriptions (Storylines) for a title
    /// </summary>
    /// 
    [Route("api/[controller]")]
    [ApiController]
    public class StorylineController : ControllerBase
    {
        private readonly IReadOnlyRepository<StoryLine> _repo;
        private readonly ILogger<StorylineController> _logger;

        public StorylineController(IReadOnlyRepository<StoryLine> repo, ILogger<StorylineController> logger)
        {
            this._repo = repo;
            this._logger = logger;
        }

        /// <summary>
        /// Gets internal desciption (Storyline) for a title
        /// </summary>
        /// <param name="pageIndex">Zero-based current page index (0 = first page)</param>
        // GET: api/storyline/GetByTitle/1
        [HttpGet]
        [Route("GetByTitle/{id}")]
        public async Task<ActionResult<StoryLineDTO>> GetByTitle(int id)
        {
            var storyLine = await _repo.ListAsync(s => s.TitleId == id && s.Type == "Turner Internal");
            if (storyLine == null)
            {
                return NotFound();
            }

            return storyLine.FirstOrDefault().Adapt<StoryLineDTO>();
        }
    }
}
