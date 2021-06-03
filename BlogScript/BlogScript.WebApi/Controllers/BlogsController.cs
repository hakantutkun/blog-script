using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogScript.Business.Abstract;
using BlogScript.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogScript.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogsController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<IActionResult> GetAll()
        {
            return Ok(await _blogService.GetAllSortedByPostedTimeAsync());
        }

        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _blogService.FindByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create(Blog blog)
        {
            await _blogService.AddAsync(blog);
            return Created("", blog);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Blog blog)
        {
            if(id != blog.Id)
            {
                return BadRequest("Invalid ID");
            }
            await _blogService.UpdateAsync(blog);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _blogService.RemoveAsync(new Blog { Id = id });
            return NoContent();
        }
    }
}