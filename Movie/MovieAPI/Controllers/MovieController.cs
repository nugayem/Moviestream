using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MovieAPI.Controllers
{ 
    public class MovieController : BaseApiController
    {
        private readonly IMovieRepository _movieService;
        private readonly IMapper _mapper;

        public MovieController(IMovieRepository movieService, IMapper mapper)
        {
            this._movieService = movieService;
            this._mapper = mapper;
        }
        
        //[HttpGet("{id}")]
        //public async Task<ActionResult<OrderToReturnDto>> GetOrderByIdForUser(int id)
        //{
        //    var email =  HttpContext.User.RetrieveEmailFromPrincipal();

        //    var order= await _orderService.GetOrderByIdAsync(id,email);

        //    if(order==null) return NotFound(new ApiResponse(404));            

        //    return _mapper.Map<Order,OrderToReturnDto>(order);

        //} 
        
    }
}