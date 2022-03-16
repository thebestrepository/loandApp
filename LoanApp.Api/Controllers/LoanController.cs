using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LoanApp.CalculationService;
using LoanApp.CalculationService.Interfaces;
using Newtonsoft.Json;
using LoanApp.Api.DTO;

namespace LoanApp.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoanController : ControllerBase
    {
        private readonly ILoanCalculationService _service;
        public LoanController(ILoanCalculationService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetSchedule([FromQuery] LoanDTO loan)
        {
            IEnumerable<MonthlyPaybackDTO> monthlyPaybacks = new List<MonthlyPaybackDTO>();
            try
            {
                monthlyPaybacks = _service.GetMortgageEqualAmountLoanSchedule(loan.Amount, loan.Years).Select(m => new MonthlyPaybackDTO {
                    Interest = m.Interest,
                    PaymentDate = m.PaymentDate,
                    Principal= m.Principal,
                    TotalAmount= m.TotalAmount,
                    UnpaidBalance= m.UnpaidBalance,
                });
            }
            catch (ArgumentOutOfRangeException)
            {
                return BadRequest();
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
            return Ok(monthlyPaybacks);
        }
    }
}
