using FullStackApp.Application.Users.Commands.CreateUser;
using FullStackApp.Application.Users.Commands.LoginUser;
using FullStackApp.Application.Users.Commands.RegisterUser;
using FullStackApp.Application.Users.Commands.UpdateUser;
using FullStackApp.Application.Users.Queries.GetAllUsers;
using FullStackApp.Application.Users.Commands.DeleteUser;
using FullStackApp.Application.Users.Queries.GetUserById;

using FullStackApp.Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FullStackApp.API.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterUserCommand command)
    {
        var userId = await _mediator.Send(command);
        return Ok(userId);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserCommand command)
    {
        var token = await _mediator.Send(command);
        return Ok(token);
    }

    // CREATE
    [HttpPost]
    public async Task<IActionResult> Create(CreateUserCommand command)
        => Ok(await _mediator.Send(command));

    // READ ALL
    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _mediator.Send(new GetAllUsersQuery()));

    // READ BY ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
        => Ok(await _mediator.Send(new GetUserByIdQuery(id)));

    // UPDATE
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateUserCommand command)
    {
        if (id != command.Id) return BadRequest();
        await _mediator.Send(command);
        return NoContent();
    }

    // DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteUserCommand(id));
        return NoContent();
    }
}

