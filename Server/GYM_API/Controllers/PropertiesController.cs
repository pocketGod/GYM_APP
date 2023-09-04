using GYM_LOGICS.Managers;
using GYM_MODELS.DB;
using GYM_MODELS.Settings.Properties;
using Microsoft.AspNetCore.Mvc;

namespace GYM_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PropertiesController : SecureController
    {
        private readonly PropertiesManager _propertiesManager;
        public PropertiesController(PropertiesManager propertiesManager)
        {
            _propertiesManager = propertiesManager;
        }

        [HttpGet]
        [Route("Enums")]
        public ActionResult<List<EnumPropertiesGroupModel>> Enums()
        {
            return Ok(_propertiesManager.GetEnumsProperties());
        }
    }
}
