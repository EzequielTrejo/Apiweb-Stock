using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiStock.Data;
using ApiStock.Data.Entities;
using Microsoft.EntityFrameworkCore.Internal;

namespace ApiStock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApiContext _context;

        public StockController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Stock>> Get()
        {
            return _context.ControlVentas.Include(p => p).ToList();
        }
        // GET: api/Pais/5
        [HttpGet("{id}", Name = "ObtenerProductoPorId")]
        public ActionResult<Stock> Get(int id)
        {
            var stock = _context.ControlVentas.FirstOrDefault(p => p.ID == id);
            if (stock == null)
            {
                return NotFound();
            }
            return stock;
        }

        [HttpPost]
        public ActionResult<Stock> Post([FromBody] Stock stock)
        {
            _context.ControlVentas.Add(stock);
            _context.SaveChanges();
            return new CreatedAtRouteResult("ObtenerProductoporid", new { id = stock.ID }, stock);
        }
        [HttpPut("{id}")]
        public ActionResult<Stock> Put(int id, [FromBody] Stock stock)
        {
            if (id != stock.ID)
            {
                return BadRequest();
            }
            _context.Entry(stock).State = EntityState.Modified;
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult<Stock> Delete(int id)
        {
            try
            {
                var stock = _context.ControlVentas.FirstOrDefault(p => p.ID == id);
                if (stock == null)
                {
                    return NotFound();
                }
                _context.ControlVentas.Remove(stock);
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
                throw;
            }
        }
    }
}
