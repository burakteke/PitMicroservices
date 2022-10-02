using FreeCourses.Services.Order.Application.Dtos;
using FreeCourses.Shared.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCourses.Services.Order.Application.Queries
{
    public class GetOrdersByUserIdQuery: IRequest<Response<List<OrderDto>>> //Requeste dönecek olan response'ı belirttik. Buradaki Response class'ı bizim shareddaki class herhangi bi kütüphaneden çekmiyoruz.
    {
        public string UserId { get; set; } //Query için gelecek olan parametreyi tanımladık
    }
}
