using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Reestr.Api.CQRS.Queries
{
    public static class GetItemsQuery
    {
        public record Query() : IRequest<Response>;

        // Handler method
        public class Handler : IRequestHandler<Query, Response>
        {
            // If you want inject any dependency you can use contructor
            // private readonly IDataservice dataservice { get; set; }
            // public Handler(IDataservice dataservice)
            // {
            //      this.dataservice = dataservice;
            // }

            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                // The business logic implements here
                // you can implement the db logic here. for demo purpose i'm returning hard coded value
                return new Response(1, "demo item", "IT001");
            }
        }

        // Response 
        public record Response(int id, string itemName, string itemCode);
    }
}
