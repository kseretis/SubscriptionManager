using TheUltimateStrictLibrary.Models;

namespace SubscriptionManager.Endpoints.Individual;

public interface IIndividualRepository
{
    Task<IEnumerable<Person>> GetIndividuals();
}