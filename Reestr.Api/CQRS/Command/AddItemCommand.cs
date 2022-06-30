using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Reestr.Api.CQRS.Command
{
    public class AddItemCommand
    {
        public record Command(string name, string itemCode) : IRequest<int>;

        public class Handler : IRequestHandler<Command, int>
        {
            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                // you can implement the db logic here. for demo purpose
                // i'm returning hard coded value
                return 0;
            }
        }
    }
}
