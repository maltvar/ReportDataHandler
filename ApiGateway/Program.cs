using ApiGateway.Clients;
using ApiGateway.Common.Extensions;
using ApiGateway.Common.Helpers;
using ApiGateway.Models.GrpcRequests;
using ApiGateway.Validators;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureGrpcClients(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/next-month-day", async (IGrpcService service,
    int ? year, int? month, int? day, int nextMonthDay, bool adjust = true) =>
{
    //TODO: Create some kind of wrap like Result<T>
    InputValidator.ValidateDate(year, month, day);
    InputValidator.ValidateNextMonthDay(nextMonthDay);

    DateTime date = DateComposer.ComposeDate(year, month, day);
    long epochTime = EpochConverter.ConvertToEpoch(date); // use epoch if time of day does not matter

    long answer = await service.ReadDate(new ReadDateGrpcRequest(nextMonthDay, epochTime, adjust));
    DateTime resultDate = EpochConverter.ConvertToDate(answer);
    return resultDate.ToString("O");
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();