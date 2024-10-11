using Microsoft.AspNetCore.Mvc;

namespace dms_webapi.Controllers;

[ApiController]
[Route("/api/{userId}/[controller]")]
public class DirectoriesController : ControllerBase
{
    [HttpGet]
    public Task<List<Entities.Directory>> GetUserDirectories(string userId)
    {
        return null;
    }
}