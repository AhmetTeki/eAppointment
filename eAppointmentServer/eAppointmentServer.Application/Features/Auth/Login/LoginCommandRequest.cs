using MediatR;
using TS.Result;

namespace eAppointmentServer.Application.Features.Auth.Login;

public record LoginCommandRequest(string UserNameOrEmail, string Password): IRequest<Result<LoginCommandResponse>>;


