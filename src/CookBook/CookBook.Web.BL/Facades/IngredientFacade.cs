﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using CookBook.Common.Models;
using CookBook.Web.BL.Options;
using CookBook.Web.DAL.Repositories;
using Microsoft.Extensions.Options;

namespace CookBook.Web.BL.Facades
{
    public class IngredientFacade : FacadeBase<IngredientDetailModel, IngredientListModel>
    {
        private readonly IIngredientApiClient apiClient;

        public IngredientFacade(
            IIngredientApiClient apiClient,
            IngredientRepository ingredientRepository,
            IMapper mapper,
            IOptions<LocalDbOptions> localDbOptions)
            : base(ingredientRepository, mapper, localDbOptions)
        {
            this.apiClient = apiClient;
        }

        public override async Task<List<IngredientListModel>> GetAllAsync()
        {
            var ingredientsAll = await base.GetAllAsync();

            var ingredientsFromApi = await apiClient.IngredientGetAsync(apiVersion, culture);
            ingredientsAll.AddRange(ingredientsFromApi);

            return ingredientsAll;
        }

        public override async Task<IngredientDetailModel> GetByIdAsync(Guid id)
        {
            return await apiClient.IngredientGetAsync(id, apiVersion, culture);
        }

        protected override async Task<Guid> SaveToApiAsync(IngredientDetailModel data)
        {
            return await apiClient.UpsertAsync(apiVersion, culture, data);
        }

        public override async Task DeleteAsync(Guid id)
        {
            await apiClient.IngredientDeleteAsync(id, apiVersion, culture);
        }
    }
}
