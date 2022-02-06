using AutoMapper;
using LibApp.Data;
using LibApp.Dtos;
using LibApp.Interfaces;
using LibApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using AuthorizeAttribute = Microsoft.AspNetCore.Authorization.AuthorizeAttribute;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace LibApp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Owner,StoreManager")]
    public class CustomersController : ControllerBase
    {
        public CustomersController(ICustomerRepository repository, IMapper mapper)
        {
            this.repository = repository;
            _mapper = mapper;
        }

        // GET /api/customers
        [HttpGet]
        public IActionResult GetCustomers()
        {
            var customers = repository.GetCustomers()
                .ToList()
                .Select(_mapper.Map<Customer, CustomerDto>);

            return Ok(customers);
        }


        // GET /api/customers/{id}
        [HttpGet("{id}", Name ="GetCustomer")]
        public IActionResult GetCustomer(string id)
        {
            var customer = repository.GetCustomerById(id);
            if (customer == null)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }

            return Ok(_mapper.Map<CustomerDto>(customer));
        }

        // POST /api/customers
        [Authorize(Roles = "Owner")]
        [HttpPost]
        public IActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customer = _mapper.Map<Customer>(customerDto);
            customer.Id = Guid.NewGuid().ToString();
            repository.AddCustomer(customer);
            repository.Save();

            customerDto.Id = customer.Id;
        
            return CreatedAtRoute(nameof(GetCustomer), new { id = customerDto.Id }, customerDto);
        }

        // PUT /api/customers/{id}
        [Authorize(Roles = "Owner")]
        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(string id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.BadRequest);
            }

            var customerInDb = repository.GetCustomerById(id);
            if (customerInDb == null)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }

            _mapper.Map(customerDto, customerInDb);

            repository.UpdateCustomer(customerInDb);
            repository.Save();

            return Ok(customerInDb);
        }

        // DELETE /api/customers/{id}
        [Authorize(Roles = "Owner")]
        [HttpDelete("{id}")]
        public void DeleteCustomer(string id)
        {
            var customerInDb = repository.GetCustomerById(id);
            if (customerInDb == null)
            {
                throw new HttpResponseException(System.Net.HttpStatusCode.NotFound);
            }

            repository.DeleteCustomer(id);
            repository.Save();
        }

        private readonly ICustomerRepository repository;
        private readonly IMapper _mapper;
    }
}
