using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using Persistance;

namespace Application.Activities
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Category { get; set; }
            public DateTime? Date { get; set; }
            public string City { get; set; }
            public string Venue { get; set; }      
        }
        
           public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Title).NotEmpty();
                RuleFor(x => x.Description).NotEmpty();
                RuleFor(x => x.Category).NotEmpty();
                RuleFor(x => x.Date).NotEmpty();
                RuleFor(x => x.City).NotEmpty();
                RuleFor(x => x.Venue).NotEmpty();
            }
        }
        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            public Handler(DataContext context)
            {
                        _context = context;
            }
        
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                        //handler logic
               var activities = await _context.Activities.FindAsync(request.Id);
               if(activities == null)
                 throw new Exception("Content not found");
                 
                activities.Title = request.Title ?? activities.Title;
                activities.Description = request.Description ?? activities.Description;
                activities.Category = request.Category ?? activities.Category;
                activities.Date = request.Date ?? activities.Date;
                activities.City = request.City ?? activities.City;
                activities.Venue = request.Venue ?? activities.Venue;

                var success =await _context.SaveChangesAsync() > 0;
                if(success) return Unit.Value;
        
                throw new Exception("Problem saving to database");
                  
            }


        }
    }
}