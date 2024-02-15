using Microsoft.EntityFrameworkCore;
using Cars_api.Contexts;
using Cars_api.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
namespace Cars_api.Controllers;

public static class CarStatEndpoints
{
    public static void MapCarStatEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/CarStat").WithTags(nameof(CarStat));

        group.MapGet("/", async (CarsContext db) =>
        {
            return await db.CarStats.ToListAsync();
        })
        .WithName("GetAllCarStats")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<CarStat>, NotFound>> (int id, CarsContext db) =>
        {
            return await db.CarStats.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is CarStat model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetCarStatById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int id, CarStat carStat, CarsContext db) =>
        {
            var affected = await db.CarStats
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Rank, carStat.Rank)
                    .SetProperty(m => m.Model, carStat.Model)
                    .SetProperty(m => m.Quantity, carStat.Quantity)
                    .SetProperty(m => m.ChangeQuantityPercent, carStat.ChangeQuantityPercent)
                  //  .SetProperty(m => m.Id, carStat.Id)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateCarStat")
        .WithOpenApi();

        group.MapPost("/", async (CarStat carStat, CarsContext db) =>
        {
            db.CarStats.Add(carStat);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/CarStat/{carStat.Id}",carStat);
        })
        .WithName("CreateCarStat")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int id, CarsContext db) =>
        {
            var affected = await db.CarStats
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteCarStat")
        .WithOpenApi();
    }
}
