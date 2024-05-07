﻿using ASP_test_project.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using taxCalculator;

namespace ASP_test_project.Controllers
{
    [Route("api/demo")]
    [ApiController]
    public class DemoAPIController : ControllerBase
    {
        private readonly ApiDemoDbContext apiDemoDbContext;

        private ApiDemoDbContext _apiDemoDbContext;
        public DemoAPIController(ApiDemoDbContext apiDemoDbContext)
        {
            _apiDemoDbContext = apiDemoDbContext;
        }
        [HttpPost]
        [Route("calculate-tax")]
        public IActionResult CalculateTax([FromBody] TaxCalculationRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid request data.");
            }

             float taxAmount = TaxCalculator.Calculate(request.Salary, request.Income, request.Dependent);
            return Ok(new { TaxAmount = taxAmount });
        }




        //Bài 3
        [HttpGet]
        [Route("get-users-list")]
        public async Task<IActionResult> GetAsync()
        {
            var users = await _apiDemoDbContext.Users.ToListAsync();
            return Ok(users);
        }
        [HttpGet]
        [Route("get-user-by-id/{UserId}")]
        public async Task<IActionResult> GetUserByIdAsync(int UserId)
        {
            var user = await _apiDemoDbContext.Users.FindAsync(UserId);
            return Ok(user);
        }

        [HttpPost]
        [Route("create-user")]
        public async Task<IActionResult> PostAsync(Users user)
        {
            _apiDemoDbContext.Users.Add(user);
            await _apiDemoDbContext.SaveChangesAsync();
            return Created($"/get-user-by-id/{user.UserId}", user);
        }

        [HttpPut]
        [Route("update-user")]
        public async Task<IActionResult> PutAsync(Users userToUpdate)
        {
            _apiDemoDbContext.Users.Update(userToUpdate);
            await _apiDemoDbContext.SaveChangesAsync();
            return NoContent();
        }

        [Route("delete-user/{UserId}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int UserId)
        {
            var userToDelete = await _apiDemoDbContext.Users.FindAsync(UserId);
            if (userToDelete == null)
            {
                return NotFound();
            }
            _apiDemoDbContext.Users.Remove(userToDelete);
            await _apiDemoDbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
    