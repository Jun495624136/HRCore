using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IBLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Newtonsoft.Json;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigpublicCharController : ControllerBase
    {
        private readonly IConfig_public_charBLL config_;
        public ConfigpublicCharController(IConfig_public_charBLL config_)
        {
            this.config_ = config_;
        }

        [HttpGet]

        public async Task<IActionResult> ConfigPublicCharSelect()
        {
            List<Config_public_char_Model> list = await config_.GetConfigPublicCharSelect();
            return Content(JsonConvert.SerializeObject(list));
        }

        [HttpDelete]
        //[Route("{id}")]
        public async Task<int> ConfigPublicCharDel([FromQuery]int Pid)
        {
            int result = await config_.GetConfigPublicCharDel(Pid);
            return result;
        }
    }
}