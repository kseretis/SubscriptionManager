using IndividualClient;
using TheUltimateStrictLibrary.DataTypes;
using TheUltimateStrictLibrary.Models;

namespace SubscriptionManager.Extensions;

public static class GrpcExtensions
{
    public static Person ToPerson(this GetAllIndividualsResponse.Types.Individual individual)
    {
        return new Person()
        {
            Id = new Guid(individual.Id),
            FirstName = new Name(individual.FirstName),
            LastName = new Name(individual.LastName)
        };
    }
}