using Microsoft.AspNetCore.Mvc;
using NasaApolo.Data;
using NasaApolo.Models.Entities;
using NasaApolo.Models.JsonObjects;
using NasaApolo.Client;
using NasaApolo.Models.Services;

namespace NasaApolo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NasaImageController : ControllerBase
    {
        private NasaTestContext _db;

        public NasaImageController(NasaTestContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IEnumerable<NasaImage> Get() => _db.NasaImages.ToList();


    }
}
