using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BlogScript.WebApi.Enums;
using BlogScript.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogScript.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public async Task<UploadModel> UploadFileAsync(IFormFile file, string contentType, UploadType uploadType)
        {
            UploadModel uploadModel = new UploadModel();
            if(file != null)
            {
                if(file.ContentType != contentType)
                {
                    uploadModel.ErrorMessage = "Uygunsuz dosya uzantısı!";
                    uploadModel.UploadState = UploadState.Error;
                    return uploadModel;
                }
                else
                {
                    var newName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Posts/" + newName);
                    var stream = new FileStream(path, FileMode.Create);
                    await file.CopyToAsync(stream);

                    uploadModel.NewName = newName;
                    uploadModel.UploadState = UploadState.Success;
                    return uploadModel;
                }
            }
            uploadModel.ErrorMessage = "Dosya bulunamadı!";
            uploadModel.UploadState = UploadState.NotExist;
            return uploadModel;
        }
    }
}