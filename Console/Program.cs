using Api.Protos;
using Grpc.Core;
using Grpc.Net.Client;

var handler = new HttpClientHandler
{
    ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
};

var channel = GrpcChannel.ForAddress("http://localhost:7192");
var client = new PersonService.PersonServiceClient(channel);

using var call = client.ExchangePersons();

var sendTask = Task.Run(async () =>
{
    var persons = new[]
    {
        new Person { Name = "Alice", DateOfBirth = "1990-05-20", Age = 34, Active = true },
        new Person { Name = "Bob", DateOfBirth = "1985-11-15", Age = 39, Active = false },
        new Person { Name = "Charlie", DateOfBirth = "2000-07-10", Age = 24, Active = true }
    };

    foreach (var person in persons)
    {
        Console.WriteLine($"Enviando: {person.Name}, {person.Age} anos");
        await call.RequestStream.WriteAsync(person);
        await Task.Delay(500);
    }

    await call.RequestStream.CompleteAsync();
});

var receiveTask = Task.Run(async () =>
{
    await foreach (var response in call.ResponseStream.ReadAllAsync())
    {
        Console.WriteLine($"Recebido: {response.Name}, {response.Age} anos");
    }
});

await Task.WhenAll(sendTask, receiveTask);