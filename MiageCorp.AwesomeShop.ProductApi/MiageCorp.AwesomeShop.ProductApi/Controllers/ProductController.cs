using MiageCorp.AwesomeShop.ProductApi.Models;
using MiageCorp.AwesomeShop.ProductApi.Services;
using MiageCorp.AwesomeShop.ProductApi.Services.Exception;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace MiageCorp.AwesomeShop.ProductApi.Controllers;
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private IProductService ProductService { get; set; }

    public ProductController(IProductService productService)
    {
        ProductService = productService;
    }
    
    // GET api/<ProductController>/5
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<ProductDTO> Get(string id)
    {
        try
        {
            return Ok(ProductService.Get(id));
        }
        catch (NotFoundException e)
        {
            return NotFound();
        }
        
    }
    
    // GET api/<ProductController>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<IEnumerable<ProductDTO>> Get()
    {
        return Ok(ProductService.GetAll());
    }
    
    // POST api/<ProductController>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<ProductDTO> Post([FromBody] ProductDTO product)
    {
        try
        {
            return CreatedAtAction(nameof(Get), new { id = product.Id }, ProductService.Add(product));
            
        }
        catch (AlreadyExistsException e)
        {
            return BadRequest(e.Message);
        }
    }
    
    // PUT api/<ProductController>/5
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<ProductDTO> Put(string id, [FromBody] ProductDTO product)
    {
        try
        {
            return Ok(ProductService.Update(id, product));
        }
        catch (NotFoundException e)
        {
            return NotFound();
        }catch (AlreadyExistsException e)
        {
            return BadRequest(e.Message);
        }
    }
    
    // DELETE api/<ProductController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<ProductDTO> Delete(string id)
    {
        try
        {
            ProductService.Delete(id);
            return Ok();
        }
        catch (NotFoundException e)
        {
            return NotFound();
        }
    }
}