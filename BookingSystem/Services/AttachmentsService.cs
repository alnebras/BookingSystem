using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookingSystem.Services
{
    public class AttachmentsService
    {
        private readonly IHostingEnvironment _hostEnvironment;
        public AttachmentsService(IHostingEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }
        private Task<string> Upload(string file, Guid name)
        {

            var filePath = "";

            try
            {

                var home = Path.Combine(_hostEnvironment.WebRootPath, @"images/attachments");
                var wwwroot = "https://localhost:5001/";
                if (_hostEnvironment.IsDevelopment())
                {
                    wwwroot = "https://localhost:5001/";
                }
                const string extenstion = ".jpeg";
                var fileName = "licence" + name + extenstion;
                var path = Path.Combine(wwwroot, @"images/attachments");
                filePath = Path.Combine(path, fileName);
                var filePathAbsolute = Path.Combine(home, fileName);

                //Check if directory exist
                if (!System.IO.Directory.Exists(home))
                {
                    System.IO.Directory.CreateDirectory(home); //Create directory if it doesn't exist
                }

                var imageBytes = Convert.FromBase64String(file);
                File.WriteAllBytes(filePathAbsolute, imageBytes);

            }
            catch (Exception ex)
            {

                throw;
            }


            return Task.FromResult(filePath);
        }

    }
}
