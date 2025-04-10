using Microsoft.AspNetCore.Mvc;
using SubscriptionManager.Database;
using TheUltimateStrictLibrary.Models;

namespace SubscriptionManager.Endpoints.Individual;

[Route("api/[controller]")]
[ApiController]
public class IndividualController : ControllerBase
{
    private readonly AppDbContext _dbContext;
    private readonly IIndividualRepository _individualService;
    private readonly Logger<IndividualController> _logger;

    public IndividualController(IIndividualRepository individualService, AppDbContext context, Logger<IndividualController> logger)
    {
        _individualService = individualService;
        _dbContext = context;
        _logger = logger;
    }

    //[HttpGet]
    //public ActionResult<IEnumerable<Individual>> GetIndividuals()
    //{
    //    return _individualService.GetIndividuals().Result;
    //}
}