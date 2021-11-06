using KikiShop.ApplicationCore.Merchants.Command;
using KikiShop.Domain.Merchants;
using KikiShop.Helper.Exceptions;
using KikiShop.Infrastructure.KikiShop.Database.UserIdentity.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace KikiShop.ApplicationCore.Merchants.Handlers
{

    public class RegisterMerchantCommandHandler : CommandHandler<RegisterMerchantCommand, Guid>
    {
        private readonly IKikiShopUnitOfWork _unitOfWork;
        private readonly IMerchantUniquenessChecker _uniquenessChecker;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public RegisterMerchantCommandHandler(
            UserManager<ApplicationUser> userManager,
            IKikiShopUnitOfWork unitOfWork,
            IMerchantUniquenessChecker uniquenessChecker,
            IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _uniquenessChecker = uniquenessChecker;
            _httpContextAccessor = httpContextAccessor;
        }

        public override async Task<Guid> ExecuteCommand(RegisterMerchantCommand command,
            CancellationToken cancellationToken)
        {
            try
            {
                var customer = Merchant.CreateNew(
                    command.Email,
                    command.Name,
                    _uniquenessChecker
                );

                if (customer != null)
                {
                    await _unitOfWork.Merchants
                        .Add(customer, cancellationToken);

                    await CreateUserForCustomer(command);
                    await _unitOfWork.CommitAsync();
                }

                return customer.Id.Value;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<ApplicationUser> CreateUserForCustomer(RegisterMerchantCommand request)
        {
            //Creating Identity user
            var user = new ApplicationUser(_httpContextAccessor)
            {
                UserName = request.Email,
                Email = request.Email
            };

            var userCreated = await _userManager
                .CreateAsync(user, request.Password);

            if (!userCreated.Succeeded)
            {
                foreach (var error in userCreated.Errors)
                {
                    throw new ApplicationDataException(error.Description.ToString());
                }
            }

            //Adding user claims
            await _userManager.AddClaimAsync(user, new Claim("CanRead", "Read"));
            await _userManager.AddClaimAsync(user, new Claim("CanSave", "Save"));
            await _userManager.AddClaimAsync(user, new Claim("CanDelete", "Delete"));

            return user;
        }
    }

}
