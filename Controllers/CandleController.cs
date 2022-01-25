using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Waxy.Models.Entities;
using Waxy.Models.Entities.DTOs;
using Waxy.Repositories.CandleRepository;

namespace Waxy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CandleController : ControllerBase
    {
        private readonly ICandleRepository _repository;
    
        public CandleController(ICandleRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCandles()
        {
            var candles = await _repository.GetAllCandlesAsync();

            var candlesToReturn = new List<CandleDTO>();

            foreach (var candle in candles)
            {
                candlesToReturn.Add(new CandleDTO(candle));
            }

            return Ok(candlesToReturn);
        }

        [HttpGet("filtered")]
        public async Task<IActionResult> GetCreatorByFullName()
        {
            var candles = await _repository.GetCandlesOrderedByPrice();

            var candlesToReturn = new List<CandleDTO>();

            foreach (var candle in candles)
            {
                candlesToReturn.Add(new CandleDTO(candle));
            }

            return Ok(candlesToReturn);
        }

        [HttpGet("scent-number")]
        public async Task<IActionResult> GetNrOfScents()
        {
            var candles = await _repository.GetAllCandlesAsync();

            var candlesToReturn = new List<CandleDTO>();

            foreach (var candle in candles)
            {
                candlesToReturn.Add(new CandleDTO(candle));
            }
            var orderdedCandles = candlesToReturn.GroupBy(
                c => c.Scent,
                (key, i) => new { CandleScent = key, CandleCount = i.ToList().Count  }) ;

           return Ok(orderdedCandles);
       }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandle(int id)
        {
            var candle = await _repository.GetByIdAsync(id);

            if (candle == null)
            {
                return NotFound("Candle does not exist.");
            }

            _repository.Delete(candle);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCandle([FromBody] CreateCandleDTO dto)
        {
            Candle newCandle = new Candle();

            newCandle.Price = dto.Price;
            newCandle.Scent = dto.Scent;
            newCandle.ContainerId = dto.ContainerId;

            _repository.Create(newCandle);

            await _repository.SaveAsync();

            return Ok(new CandleDTO(newCandle));

        }

        [HttpPut("{id}/price+{price}")]
        public async Task<IActionResult> UpdateCandlePrice(int id, double price)
        {

            var updatedCandle = await _repository.GetByIdAsync(id);
            updatedCandle.Price = updatedCandle.Price + price;

            _repository.Update(updatedCandle);

            await _repository.SaveAsync();

            return Ok(new CandleDTO(updatedCandle));

        }

    }
}
