using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dto
{
    public class BookDto
    {
        
        public int Id { get; set; }
        public string Name { get; set; }

        public string Category { get; set; }
        public IFormFile Photo { get; set; }
    }
}
