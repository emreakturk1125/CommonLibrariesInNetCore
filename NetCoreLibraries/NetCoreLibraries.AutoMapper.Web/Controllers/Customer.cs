using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetCoreLibraries.AutoMapper.Web.DTOs;
using NetCoreLibraries.AutoMapper.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreLibraries.AutoMapper.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   public class CustomerController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public CustomerController(AppDbContext context,IMapper mapper)   // Entity yerine Dto modelleri üzerinden yapmak gerekir. Örnek olsn diye entity üzerinden yaptık
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("MappingExample")]
        public  ActionResult MappingExample()
        {

            Customer customer = new Customer
            {
                Id = 1,
                Name = "emreee",
                Email = "er@hotmail.com",
                Age = 23,
                CreditCard = new CreditCard { Number = "1234579",ValidDate=DateTime.Now}
            };

            return Ok(_mapper.Map<CustomerDto>(customer));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerDto>>> GetCustomers()
        {
            var customerList  = await _context.Customers.ToListAsync();

            var cusList2 = _mapper.Map<List<CustomerDtoT>>(customerList);

            return _mapper.Map<List<CustomerDto>>(customerList);
        }
         
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }
         
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
         
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
             
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }
         
        [HttpDelete("{id}")]
        public async Task<ActionResult<Customer>> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return customer;
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }

       
    }
}
