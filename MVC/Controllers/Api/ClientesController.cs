using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using MVC.Dtos;
using MVC.Models;

namespace MVC.Controllers.Api
{
    public class ClientesController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public ClientesController()
        {
            _context = new ApplicationDbContext();
        }


        // GET /api/clientes
        public IHttpActionResult GetClientes()
        {
            var clientesQuery = _context.Clientes;
            
            var clienteDtos = clientesQuery.ToList().Select(Mapper.Map<Cliente, ClienteDto>);

            return Ok(clienteDtos);
        }

        // GET /api/clientes/{id}
        public IHttpActionResult GetCliente(int id)
        {
            var cliente = _context.Clientes.SingleOrDefault(c => c.Id == id);

            if (cliente == null)
                return NotFound();

            return Ok(Mapper.Map<Cliente, ClienteDto>(cliente));
        }

        // POST /api/clientes
        [HttpPost]
        public IHttpActionResult CreateCliente(ClienteDto clienteDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var cliente = Mapper.Map<ClienteDto, Cliente>(clienteDto);

            _context.Clientes.Add(cliente);
            _context.SaveChanges();

            clienteDto.Id = cliente.Id;

            return Created(new Uri(Request.RequestUri + "/" + cliente.Id), clienteDto);
        }
        
        // PUT /api/clientes/{id}
        [HttpPut]
        public IHttpActionResult UpdateCliente(int id, ClienteDto clienteDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var clienteInDb = _context.Clientes.SingleOrDefault(c => c.Id == id);

            if (clienteInDb == null)
                return NotFound();

            Mapper.Map(clienteDto, clienteInDb);

            _context.SaveChanges();

            return Ok();
        }
        
        // DELETE /api/clientes/{id}
        [HttpDelete]
        public IHttpActionResult DeleteCliente(int id)
        {
            var clienteInDb = _context.Clientes.SingleOrDefault(c => c.Id == id);

            if (clienteInDb == null)
                return NotFound();

            _context.Clientes.Remove(clienteInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}