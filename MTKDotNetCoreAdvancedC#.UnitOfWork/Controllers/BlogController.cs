﻿using Microsoft.AspNetCore.Mvc;
using MTKDotNetCoreAdvancedC_.Shared;
using MTKDotNetCoreAdvancedC_.UnitOfWork.Persistance;

namespace MTKDotNetCoreAdvancedC_.UnitOfWork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        internal readonly IUnitOfWork _unitOfWork;

        public BlogController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public async Task<IActionResult> GetBlogsAsync(int pageNo, int pageSize, CancellationToken cs)
        {
            var query = _unitOfWork.BlogRepository.Query().Paginate(pageNo, pageSize);
            var lst = await query.ToListAsync(cs);

            return Ok(lst);
        }
    }
}
