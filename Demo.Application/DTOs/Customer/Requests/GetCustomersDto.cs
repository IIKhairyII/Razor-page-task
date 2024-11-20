using Demo.Application.DTOs.Customer.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.DTOs.Customer.Requests
{
    public class GetCustomersDto : IRequest<ICollection<CustomerDto>>
    {
    }
}
