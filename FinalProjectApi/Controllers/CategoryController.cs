using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.CQRS.Category.Command.AddCategory;
using Application.CQRS.Category.Command.DeleteCategory;
using Application.CQRS.Category.Query.GetAllCategory;
using Application.CQRS.Category.Query.GetParentCategories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinalProjectApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ISender _mediator;

        public CategoryController(ISender mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(string name, string description, string? parentCategory)
        {
            var command = new AddCategoryCommand(name, description, parentCategory);
            var response = await _mediator.Send(command);
            if (response.Status)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }
        [HttpDelete("{categoryId:guid}")]
        public async Task<IActionResult> DeleteCategory([FromRoute] Guid categoryId)
        {
            var command = new DeleteCategoryCommand(categoryId);
            await _mediator.Send(command);
            return Ok();
        }
        [HttpGet("categories")]
        public async Task<IActionResult> GetCategories()
        {
            var query = new GetAllCategoryQuery();
            var response = await _mediator.Send(query);
            if (response.Status) return Ok(response);
            return BadRequest(response);
        }
        [HttpGet("parentcategories")]
        public async Task<IActionResult> GetParentCategories()
        {
            var query = new GetParentCategoryQuery();
            var response = await _mediator.Send(query);
            if (response.Status) return Ok(response);
            return BadRequest(response);
        }
    }
}