using Application.Errors;
using Application.Interfaces;
using Application.Validators;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Persistance;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.User
{
    public class Register
    {
        public class Command : IRequest<User>
        {
            public string DisplayName { get; set; }
            public string Username { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
        }
        public class QueryValidator : AbstractValidator<Command>
        {
            public QueryValidator()
            {
                RuleFor(x => x.Email).NotEmpty().EmailAddress();
                RuleFor(x => x.Password).Password();
                RuleFor(x => x.DisplayName).NotEmpty();
                RuleFor(x => x.Username).NotEmpty();
            }
        }
        public class Handler : IRequestHandler<Command, User>
        {
            private readonly DataContext _context;
            private readonly UserManager<AppUser> _userManager;
            private readonly SignInManager<AppUser> _signInManager;
            private readonly IJwtGenerator _jwtGenerator;

            public Handler(DataContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IJwtGenerator jwtGenerator)
            {
                _context = context;
                _userManager = userManager;
                _signInManager = signInManager;
                _jwtGenerator = jwtGenerator;
            }

            public async Task<User> Handle(Command request, CancellationToken cancellationToken)
            {
               if(await _context.Users.Where(x=>x.Email == request.Email).AnyAsync())
                throw new RestException(System.Net.HttpStatusCode.BadRequest, new { Email = "Email already exist"});
                if (await _context.Users.Where(x => x.UserName == request.Username).AnyAsync())
                    throw new RestException(System.Net.HttpStatusCode.BadRequest, new { UserName = "UserName already exist" });

                var user = new AppUser
                {
                    DisplayName = request.DisplayName,
                    UserName = request.Username,
                    Email = request.Email,

                };
                var result = await _userManager.CreateAsync(user, request.Password);
                if (result.Succeeded)
                {
                    return new User
                    {
                        DisplayName = request.DisplayName,
                        Username = request.Username,
                        Token = _jwtGenerator.CreateToken(user),
                        Image = null
                    };
                }
                throw new Exception("Problem creating user");
            }
        }
    }
}
