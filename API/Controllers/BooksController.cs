using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataAccessLayer;
using DataAccessLayer.Interfaces;
using Entities.Dto;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IRepository<Book> _repository;
        private readonly IMapper _mapper;

        public BooksController(IRepository<Book> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var books = await _repository.GetAllAsync();
            var bookDtos = _mapper.Map<List<BookDto>>(books);

            return Ok(bookDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int? id)
        {
            if (id == null)
                return BadRequest();

            var book = await _repository.GetAsync(id.Value);
            if (book == null)
                return NotFound("Bele book yoxdur");

            var bookDto = _mapper.Map<BookDto>(book);

            return Ok(bookDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] BookDto bookDto)
        {
            try
            {
                if (bookDto == null)
                    return BadRequest();

                var book = _mapper.Map<Book>(bookDto);

                using (var fileStream = new FileStream("C://test.jpg", FileMode.CreateNew))
                {
                    await bookDto.Photo.CopyToAsync(fileStream);
                }
                if (!await _repository.CreateAsync(book))
                    return BadRequest();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int? id, [FromBody] BookDto bookDto)
        {
            try
            {
                if (id == null)
                    return BadRequest("The id is null. ");

                if (bookDto == null)
                    return BadRequest("The book is null. ");

                if (id != bookDto.Id)
                    return BadRequest("Conflicted id. ");

                var dbBook = await _repository.GetAsync(id.Value);
                if (dbBook == null)
                    return BadRequest("The entity isn't exist. ");

                var book = _mapper.Map<Book>(bookDto);

                await _repository.UpdateAsync(book);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int? id)
        {
            try
            {
                if (id == null)
                    return BadRequest();

                var book = await _repository.GetAsync(id.Value);
                if (book == null)
                    return BadRequest();

                await _repository.DeleteAsync(book);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
