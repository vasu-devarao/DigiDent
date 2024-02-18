﻿using DigiDent.InventoryManagement.Domain.Items.ValueObjects;
using DigiDent.Shared.Kernel.Abstractions;
using DigiDent.Shared.Kernel.ValueObjects.Pagination;

namespace DigiDent.InventoryManagement.Domain.Items;

public interface IInventoryItemsRepository
{
    Task<InventoryItem?> GetByIdAsync(
        InventoryItemId id, CancellationToken cancellationToken);
    
    Task<InventoryItem?> GetByNameAsync(
        ItemName name, CancellationToken cancellationToken);
    
    Task<IPaginatedResponse<InventoryItem>> GetAllAsync(
        PaginationDTO pagination, CancellationToken cancellationToken);
    
    Task AddAsync(InventoryItem item, CancellationToken cancellationToken);
    Task UpdateAsync(InventoryItem item, CancellationToken cancellationToken);
}