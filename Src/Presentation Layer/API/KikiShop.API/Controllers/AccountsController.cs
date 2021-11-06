using AutoMapper;
using KikiShop.ApplicationCore.Merchants.Command;
using KikiShop.Helper.Dto.Request;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace KikiShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : BaseController
    {
        private readonly IMapper _mapper;
        public AccountsController(
           IMediator mediator,
           IMapper mapper)
           : base(mediator)
        {
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost, Route("register-merchant")]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] CreateMerchantRequest request)
        {
            var command = _mapper.Map<RegisterMerchantCommand>(request);
            return await Response(command);
        }
    }
}
