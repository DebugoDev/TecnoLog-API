namespace Infrastructure.Repositories;

using Application.Entities;
using Application.Interfaces.Providers;
using Application.Interfaces.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories.Primitives;

public class StockDepartmentRepository(
    TecnoLogDbContext context, IDateTimeProvider dateTimeProvider
) : BaseRepository<StockDepartment>(context, dateTimeProvider), IStockDepartmentRepository;