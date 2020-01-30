using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentInformationSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInformationSystem.Handler
{
    public interface IImageHandler
    {
        Task<IActionResult> UploadImage(IFormFile file);
    }

    public class ImageHandler : IImageHandler
    {
        private readonly IImageWriter _imageWriter;
        public static IWebHostEnvironment _environment;
        public ImageHandler(IImageWriter imageWriter, IWebHostEnvironment environment)
        {
            _imageWriter = imageWriter;
            _environment = environment;
        }

        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            var result = await _imageWriter.UploadImage(file,_environment.ContentRootPath);
            return new ObjectResult(result);
        }
    }
}
