﻿namespace Application.Interfaces.Services.Domain;

using Application.Entities;
using Application.Enums;
using Application.Interfaces.Services.Domain.Primitives;
using Application.Models.Entities;
using Application.Models.Responses.StockItem;

public interface IStockItemService : IBaseService<StockItem, StockItemDto>
{
    Task<PaginatedStockItemResponse> GetPaginatedStockItemsAsync(
        int page,
        int size,
        string? search = null,
        EStockGroup? stockGroup = null,
        EStockItemStatus? status = null
    );
}