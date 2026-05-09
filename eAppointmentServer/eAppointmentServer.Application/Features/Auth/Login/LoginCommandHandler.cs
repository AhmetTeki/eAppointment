using eAppointmentServer.Application.Services;
using eAppointmentServer.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TS.Result;

namespace eAppointmentServer.Application.Features.Auth.Login;

internal sealed class LoginCommandHandler(UserManager<AppUser> _userManager, IJwtProvider _jwtProvider)
    : IRequestHandler<LoginCommandRequest, Result<LoginCommandResponse>>
{
    public async Task<Result<LoginCommandResponse>> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
    {
        var appUser = await _userManager.Users.FirstOrDefaultAsync(p => p.UserName == request.UserNameOrEmail || p.Email == request.UserNameOrEmail,
            cancellationToken);

        if (appUser is null)
        {
            return Result<LoginCommandResponse>.Failure("User not found");
        }

        bool isPasswordCorrect = await _userManager.CheckPasswordAsync(appUser, request.Password);

        if (!isPasswordCorrect)
        {
            return Result<LoginCommandResponse>.Failure("Password is incorrect");
        }

        string token = _jwtProvider.CreateToken(appUser);
        return Result<LoginCommandResponse>.Succeed(new(token));
    }
}