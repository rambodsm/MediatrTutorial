namespace MediatrTutorial.Controllers;

[SwaggerTag("Manage Customer")]
public sealed class Customers : ApiControllerBase
{
    [HttpPost]
    [SwaggerOperation("Create a customer")]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Successful!")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid data")]
    [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Invalid data")]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand request)
    {
        await Mediator.Send(request);

        return NoContent();
    }

    [HttpDelete("{id}")]
    [SwaggerOperation("Delete a customer")]
    [SwaggerResponse(StatusCodes.Status204NoContent, "Successful!")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid data")]
    [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Invalid data")]
    public async Task<IActionResult> DeleteCustomer([FromRoute] string id)
    {
        var request = new DeleteCustomerCommand
        {
            Id = id
        };

        await Mediator.Send(request);

        return NoContent();
    }

    [HttpGet("{id}")]
    [SwaggerOperation("Retrieve a customer by id")]
    [SwaggerResponse(StatusCodes.Status200OK, "Successful!")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid data")]
    [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Invalid data")]
    public async Task<IActionResult> GetCustomerById([FromRoute] string id)
    {
        var request = new GetCustomerByIdQuery
        {
            Id = id
        };

        var response = await Mediator.Send(request);

        return Ok(response);
    }

    [HttpGet]
    [SwaggerOperation("Retrieve customers with pagination")]
    [SwaggerResponse(StatusCodes.Status200OK, "Successful!")]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid data")]
    [SwaggerResponse(StatusCodes.Status422UnprocessableEntity, "Invalid data")]
    public async Task<IActionResult> GetCustomersWithPaginationQuery([FromQuery] int page = 1,
        [FromQuery] int pageSize = 10)
    {
        var request = new GetCustomersWithPaginationQuery
        {
            Page = page,
            PageSize = pageSize
        };

        var response = await Mediator.Send(request);

        return Ok(response);
    }
}