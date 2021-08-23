using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProAgil.WebAPI.Model;
using ProAgil.WebAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace ProAgil.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public readonly DataContext _context ;
       
        public WeatherForecastController(DataContext context)
        {
            _context = context;
            
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try{

                var results = await _context.Eventos.ToListAsync();
                return Ok(results);
            
            }catch(System.Exception){

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }
            
          
        }

         [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            
            try{

                var results = await _context.Eventos.FirstOrDefaultAsync(x => x.EventoId == id);
                return Ok(results);
            
            }catch(System.Exception){

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco Dados Falhou");
            }
            
        }

    }
}
