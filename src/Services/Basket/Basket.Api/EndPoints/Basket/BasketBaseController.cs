using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.EndPoints.Basket
{
    [Route("api/basket/[controller]/[Action]")]
    [ApiController]
    public class BasketBaseController : ControllerBase
    {
    }
}
