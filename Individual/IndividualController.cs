using Microsoft.AspNetCore.Mvc;
using SubscriptionManager.Individual.Interfaces;
using TheUltimateStrictLibrary.Models;

namespace SubscriptionManager.Individual;

[Route("api/[controller]")]
[ApiController]
public class IndividualController : ControllerBase
{
    private readonly IIndividualService _individualService;
    private readonly Logger<IndividualController> _logger;

    public IndividualController(IIndividualService individualService)
    {
        _individualService = individualService;
      
    }
    
    [HttpGet]
    public IEnumerable<Person> GetIndividuals()
    {
        return _individualService.GetIndividuals().Result;
    }
}