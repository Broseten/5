﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CookBook.Common.Models;

namespace CookBook.Web.BL.Facades
{
    public class IngredientFacade : FacadeBase<IngredientDetailModel, IngredientListModel>
    {
        private readonly IIngredientApiClient apiClient;

        public IngredientFacade(IIngredientApiClient apiClient)
        {
            this.apiClient = apiClient;
        }

        public async Task<ICollection<IngredientListModel>> GetAllAsync()
        {
            return await apiClient.IngredientGetAsync(apiVersion, culture);
        }

        public async Task<IngredientDetailModel> GetByIdAsync(Guid id)
        {
            return await apiClient.IngredientGetAsync(id, apiVersion, culture);
        }

        public async Task DeleteAsync(Guid id)
        {
            await apiClient.IngredientDeleteAsync(id, apiVersion, culture);
        }

        public async Task SaveAsync(IngredientDetailModel data)
        {
            await apiClient.UpsertAsync(apiVersion, culture, data);
        }
    }
}
