using Microsoft.AspNetCore.Http;
using StudentInformationSystem.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInformationSystem.Interfaces
{
    
        public class ImageWriter : IImageWriter
    {
            public async Task<string> UploadImage(IFormFile file, string path)
            {
                if (CheckIfImageFile(file))
                {
                    return await WriteFile(file, path);
                }

                return "Invalid image file";
            }

            /// <summary>
            /// Method to check if file is image file
            /// </summary>
            /// <param name="file"></param>
            /// <returns></returns>
            private bool CheckIfImageFile(IFormFile file)
            {
                byte[] fileBytes;
                using (var ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    fileBytes = ms.ToArray();
                }

                return ImageWriterHelper.GetImageFormat(fileBytes) != ImageWriterHelper.ImageFormat.unknown;
            }

            /// <summary>
            /// Method to write file onto the disk
            /// </summary>
            /// <param name="file"></param>
            /// <returns></returns>
            public async Task<string> WriteFile(IFormFile file,string path)
            {
                string fileName;
                try
                {
                    var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                // fileName = Guid.NewGuid().ToString() + extension; //Create a new Name 
                fileName = file.FileName ;
                var imagepath = path + "\\uploads";

                if (!Directory.Exists(imagepath))
                {
                    Directory.CreateDirectory(imagepath);
                }
                //for the file due to security reasons.
                

                    using (var bits = new FileStream(imagepath + "\\" + fileName, FileMode.Create))
                    {
                        await file.CopyToAsync(bits);
                    }
                }
                catch (Exception e)
                {
                    return e.Message;
                }

                return fileName;
            }
        
    }
}
