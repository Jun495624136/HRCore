using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using IBLL;
namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryCriterionApiController : ControllerBase
    {
        public readonly ISalary_standard_BLL ssbll;
        public SalaryCriterionApiController(ISalary_standard_BLL ssbll)
        {
            this.ssbll = ssbll;
        }
        [HttpPost]
        public async Task<int> Salary_standard_Add([FromForm]Salary_standard_Model salary_Standard_)
        {
            int result =await ssbll.Salary_standard_Add(salary_Standard_);
            return result;
        }
    }
}