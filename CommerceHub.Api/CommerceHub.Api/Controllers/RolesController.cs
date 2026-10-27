using CommerceHub.Api.Data;
using CommerceHub.Api.DTOs;
using CommerceHub.Api.DTOs.Roles;
using CommerceHub.Api.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CommerceHub.Api.Controllers;
[ApiController]
[Route("api/[controller]")]
public class RolesController(ApplicationDbContext context)
    : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> Create(CreateRoleRequestDto request)
    {
        var normalName = request.Name.Trim().ToUpper();
        if (await context.Roles.AnyAsync(r => r.Name == normalName))
        {
            return BadRequest("این نام قبلا به ثبت رسیده است");
        }
        var role = new Role
        {
            Name = request.Name,
            DisplayName = request.DisplayName
        };

        context.Roles.Add(role);
        await context.SaveChangesAsync();

        return Created($"api/roles/{role.Id}", new
        {
            Id = role.Id
        });

    }

    [HttpPut]
    public async Task<ActionResult> Update(UpdateRoleRequestDto request)
    {





    }





}
