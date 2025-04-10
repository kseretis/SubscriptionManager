using Grpc.Net.Client;
using IndividualClient;
using SubscriptionManager.Extensions;
using TheUltimateStrictLibrary.Models;

namespace SubscriptionManager.Endpoints.Individual;

public class IndividualService : IIndividualRepository
{
    private const string IndividualServiceAddress = "http://localhost:5036";
    private readonly Individuals.IndividualsClient _client;

    public IndividualService()
    {
        using var channel = GrpcChannel.ForAddress(IndividualServiceAddress);
        _client = new Individuals.IndividualsClient(channel);
    }

    public async Task<IEnumerable<Person>> GetIndividuals()
    {
        var repsonse = await _client.GetIndividualsAsync(new GetAllIndividualsRequest());

        return repsonse.Individuals.Select(i => i.ToPerson());
    }
}
