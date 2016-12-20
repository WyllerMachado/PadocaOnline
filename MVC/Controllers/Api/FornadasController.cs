using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using MVC.Dtos;
using MVC.Models;

namespace MVC.Controllers.Api
{
    public class FornadasController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public FornadasController()
        {
            _context = new ApplicationDbContext();
        }
        
        // GET /api/fornadas
        public IHttpActionResult GetFornadas()
        {
            var ultimaFornada = _context.Fornadas.OrderByDescending(p => p.Id).First();

            var fornadaDto = Mapper.Map<Fornada, FornadaDto>(ultimaFornada);

            fornadaDto.Futura = ultimaFornada.DataHora > DateTime.Now;
            
            return Ok(fornadaDto);
        }
    }
}
