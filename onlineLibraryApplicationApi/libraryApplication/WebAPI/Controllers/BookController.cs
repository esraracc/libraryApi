using Application.Features.Books.Commands.CreateBook;
using Application.Features.Books.Dtos;
using Application.Features.Books.Models;
using Application.Features.Books.Queries.GetByIdBook;
using Application.Features.Books.Queries.GetListBook;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : BaseController
    {
        [Route("GetListAll")]
        [HttpGet]
        public async Task<ActionResult> GetList()
        {
            List<Book> result = await Mediator.Send(new GetListBookQuery());
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdBookQuery getByIdBookQuery)
        {
            BookGetByIdDto bookGetByIdDto = await Mediator.Send(getByIdBookQuery);
            return Ok(bookGetByIdDto);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBookCommand createBookCommand)
        {
            CreatedBookDto result = await Mediator.Send(createBookCommand);
            return Created("", result);
        }
    }
}
