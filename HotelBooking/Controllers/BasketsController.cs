//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using AutoMapper;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using HotelBooking.Contracts;
//using HotelBooking.Data;
//using HotelBooking.Models.Basket;

//namespace HotelBooking.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class BasketsController : ControllerBase
//    {
//        private readonly IBasketRepository _basketRepository;
//        private readonly IMapper _mapper;

//        public BasketsController(IBasketRepository basketRepository, IMapper mapper)
//        {
//            this._basketRepository = basketRepository;
//            this._mapper = mapper;
//        }

//        [HttpGet]
//        [Route("GetAll")]
//        public async Task<ActionResult<IEnumerable<BasketDto>>> GetBasket()
//        {
//            var products = await _basketRepository.GetBasketsAsync();

//            var result = _mapper.Map<List<GetBasketDto>>(products);

//            return Ok(result);
//        }

//        [HttpPut]
//        [Route("UpdateBasket")]
//        public async Task<IActionResult> PutBasket(UpdateBasketDto updateBasketDto)
//        {
//            if(updateBasketDto.Quantity <= 0)
//            {
//                return BadRequest("რაოდენობა არ შეიძლება იყოს 0-ზე ნაკლები");
//            }

//            var basket = await _basketRepository.GetBasketWithProductId(updateBasketDto.ProductId);
//            if (basket == null)
//            {
//                return NotFound();
//            }

//            _mapper.Map(updateBasketDto, basket);


//            try
//            {
//                await _basketRepository.UpdateAsync(basket);
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!await BasketExists(basket.Id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        [HttpPost]
//        [Route("AddToBasket")]
//        public async Task<ActionResult<Basket>> PostBasket(BasketPostDto basketPostDto)
//        {
//            var basket = _mapper.Map<Basket>(basketPostDto);
//            await _basketRepository.AddAsync(basket);

//            return CreatedAtAction("GetBasket", new { id = basket.Id }, basket);
//        }

//        //// DELETE: api/Baskets/5
//        [HttpDelete]
//        [Route("DeleteProduct/{id}")]
//        public async Task<IActionResult> DeleteBasket(int id)
//        {
//            var basket = await _basketRepository.GetBasketWithProductId(id);

//            if (basket == null)
//            {
//                return NotFound();
//            }

//            await _basketRepository.DeleteProductFromBasket(basket);

//            return NoContent();
//        }

//        private Task<bool> BasketExists(int id)
//        {
//            return _basketRepository.Exists(id);
//        }
//    }
//}
