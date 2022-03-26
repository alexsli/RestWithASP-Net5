using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWihtASPNETUdemy.Model;
using RestWihtASPNETUdemy.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWihtASPNETUdemy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {

        private readonly ILogger<PersonController> _logger;
        private IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {

            _logger = logger;
            _personService = personService;
        }

        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_personService.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _personService.FindById(id);
            if (person == null) return NotFound();
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person )
        {

            if (person == null) return BadRequest();
            return Ok(_personService.Create(person));
        }
  
        [HttpPut]
        public IActionResult Put([FromBody] Person person )
        {

            if (person == null) return BadRequest();
            return Ok(_personService.Update(person));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _personService.Delete(id);
           // if (person == null) return NotFound();
            return NoContent();
        }


        private bool IsNumeric(string strNumber)
        {
            double Number;
            bool isNumber = double.TryParse(strNumber,
                System.Globalization.NumberStyles.Any, 
                System.Globalization.NumberFormatInfo.InvariantInfo, 
                out Number);
            return isNumber;
            //throw new NotImplementedException();
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            return 0;
        }

    }
}
