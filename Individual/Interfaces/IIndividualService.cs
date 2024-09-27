using TheUltimateStrictLibrary.Models;

namespace SubscriptionManager.Individual.Interfaces;

public interface IIndividualService
{
    Task<IEnumerable<Person>> GetIndividuals();
}