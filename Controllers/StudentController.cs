using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StudentInformationSystem.Data;
using StudentInformationSystem.Entities;
using StudentInformationSystem.Handler;
using StudentInformationSystem.Interfaces;

namespace StudentInformationSystem.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/student")]
    [Authorize]
    public class StudentController : MyBaseController<StudentMaster, StudentRepository>
    {
        private readonly ILogger<StudentController> _logger;
        private readonly StudentRepository _repository;
        private readonly IImageHandler _imageHandler;
       
        public StudentController(ILogger<StudentController> logger, StudentRepository repository, IImageHandler imageHandler) : base(repository)
        {
            _logger = logger;
            _repository = repository;
            _imageHandler = imageHandler;
           // _environment = environment;
        }

        [Route("~/api/student/searchbyname/{name}")]
        [HttpGet ]
        public async Task<IEnumerable<StudentMaster>> GetByName(string name)
        {
            return await  _repository.SearchByName(name);
        }
        [Route("~/api/student/getall")]
        [HttpGet]
        public async Task<IEnumerable<StudentMaster>> GetAll()
        {
            return await _repository.GetAll();
        }


        /// <summary>
        /// Uplaods an image to the server.
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("~/api/student/uploadFile/{studentId}")]
        public async Task<IActionResult> UploadFile(long studentId, IFormFile file)
        {
            StudentMaster student = _repository.Get(studentId).Result;
            if(student != null)
            {
                Files sfile = new Files();
                sfile.FileName = file.FileName;
                sfile.FileSize = file.Length.ToString();
                sfile.StudentId = studentId;
                student.Files.Add(sfile);
               await _repository.Update(student);
                return await _imageHandler.UploadImage(file);
            }
            return NoContent();

        }

        [HttpGet]
        [Route("~/api/student/fileUrl/{fileName}")]
        public IActionResult GetFileUrl(string fileName)
        {
            var extension = fileName.Split('.')[fileName.Split('.').Length - 1];
            try
            {
                var image = System.IO.File.OpenRead("uploads/" + fileName);
                return File(image, "image/" + extension);
            }
            catch (System.IO.FileNotFoundException ex)
            {

                return NotFound() ;
            }
           
        }

    }
  
}



   