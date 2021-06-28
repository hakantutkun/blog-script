using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BlogScript.Business.Abstract;
using BlogScript.DTOs.DTOs.BlogDTOs;
using BlogScript.Entities.Concrete;
using BlogScript.WebApi.Enums;
using BlogScript.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogScript.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : BaseController
    {
        private readonly IBlogService _blogService;
        private readonly IMapper _mapper;

        public BlogsController(IBlogService blogService, IMapper mapper)
        {
            _blogService = blogService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(_mapper.Map<List<BlogListDto>>(await _blogService.GetAllSortedByPostedTimeAsync()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(_mapper.Map<BlogListDto>(await _blogService.FindByIdAsync(id)));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromForm]BlogAddModel blogAddModel)
        {
            var uploadModel = await UploadFileAsync(blogAddModel.Image, "image/jpeg", UploadType.Create);

            if(uploadModel.UploadState == UploadState.Success)
            {
                blogAddModel.ImagePath = uploadModel.NewName;
                await _blogService.AddAsync(_mapper.Map<Blog>(blogAddModel));
                return Created("", blogAddModel);
            }
            else if (uploadModel.UploadState == UploadState.NotExist)
            {
                await _blogService.AddAsync(_mapper.Map<Blog>(blogAddModel));
                return Created("", blogAddModel);
            }
            else
            {
                return BadRequest(uploadModel.ErrorMessage);
            }
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, [FromForm]BlogUpdateModel blogUpdateModel)
        {
            if(id != blogUpdateModel.Id)
            {
                return BadRequest("Invalid ID");
            }

            var uploadModel = await UploadFileAsync(blogUpdateModel.Image, "image/jpeg",UploadType.Update);

            if (blogUpdateModel.Image != null)
            {
                if(blogUpdateModel.Image.ContentType != "image/jpeg")
                {
                    return BadRequest("Uygunsuz dosya uzantısı");
                }

                if (uploadModel.UploadState == UploadState.Success)
                {
                    var updatedBlog = await _blogService.FindByIdAsync(blogUpdateModel.Id);
                    updatedBlog.ShortDescription = blogUpdateModel.ShortDescription;
                    updatedBlog.Title = blogUpdateModel.Title;
                    updatedBlog.Description = blogUpdateModel.Description;
                    // if upload state is success then delete existing image in order to prevent file excess
                    System.IO.File.Delete(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Posts/" + updatedBlog.ImagePath));
                    updatedBlog.ImagePath = uploadModel.NewName;
                    await _blogService.UpdateAsync(updatedBlog);
                    return NoContent();
                }
                else if (uploadModel.UploadState == UploadState.NotExist)
                {
                    var updatedBlog = await _blogService.FindByIdAsync(blogUpdateModel.Id);
                    updatedBlog.ShortDescription = blogUpdateModel.ShortDescription;
                    updatedBlog.Title = blogUpdateModel.Title;
                    updatedBlog.Description = blogUpdateModel.Description;
                    await _blogService.UpdateAsync(updatedBlog);
                    return NoContent();
                }
                else
                {
                    return BadRequest(uploadModel.ErrorMessage);
                }
            }
            await _blogService.UpdateAsync(_mapper.Map<Blog>(blogUpdateModel));
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await _blogService.RemoveAsync(new Blog { Id = id });
            return NoContent();
        }
    }
}