using System;
using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Notes.WebApi.Controllers{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : ControllerBase{
        private IMediator? _mediator;

        protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        internal Guid UserId{
            get{
                if (User?.Identity == null || !User.Identity.IsAuthenticated){
                    return Guid.Empty;
                }

                Claim? user = User.FindFirst(ClaimTypes.NameIdentifier);
                return user != null ? Guid.Parse(user.Value) : Guid.Empty;
            }
        }
    }
}