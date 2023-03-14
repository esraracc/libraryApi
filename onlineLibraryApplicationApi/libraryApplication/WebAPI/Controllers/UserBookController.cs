using Application.Features.UserActionsOnTheBookRepository.Commands.BookStatusUpdateCommand;
using Application.Features.UserActionsOnTheBookRepository.Commands.CreateUserBook;
using Application.Features.UserActionsOnTheBookRepository.Dtos;
using Application.Features.UserActionsOnTheBookRepository.Queries.GetListUserBookQuery;
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
    public class UserBookController : BaseController
    {
        [Route("GetListAll")]
        [HttpGet]
        public async Task<ActionResult> GetList()
        {
            List<UserActionsOnTheBook> result = await Mediator.Send(new GetListUserBookQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserBookCommand createUserBookCommand)
        {
            CreatedUserBookDto result = await Mediator.Send(createUserBookCommand);
            return Created("", result);
        }

        [Route("BookStatusUpdate")]
        [HttpPut]
        public async Task<IActionResult> BookStatusUpdate([FromBody] UpdateUserBookStatusCommand updateUserBookStatusCommand)
        {
            UpdatedBookStatusDto result = await Mediator.Send(updateUserBookStatusCommand);
            return Ok(result);
        }
    }
}
