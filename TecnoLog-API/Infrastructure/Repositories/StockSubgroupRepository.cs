namespace Infrastructure.Repositories;

using Application.Entities;
using Application.Interfaces.Providers;
using Application.Interfaces.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories.Primitives;

public class StockSubgroupRepository(
    TecnoLogDbContext context, IDateTimeProvider dateTimeProvider
) : BaseRepository<StockSubgroup>(context, dateTimeProvider), IStockSubgroupRepository;