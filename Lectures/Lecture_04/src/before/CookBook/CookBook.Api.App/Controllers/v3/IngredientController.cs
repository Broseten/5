﻿using System;
using System.Collections.Generic;
using CookBook.Api.BL.Facades;
using CookBook.Common.Models;
using CookBook.Common.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using NSwag.Annotations;

namespace CookBook.Api.App.Controllers.v3
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiVersion("3.0")]
    public class IngredientController : ControllerBase
    {
        private const string ApiOperationBaseName = "Ingredient";
        private readonly IIngredientFacade ingredientFacade;
        private readonly IStringLocalizer<IngredientControllerResources> ingredientControllerLocalizer;

        public IngredientController(
            IIngredientFacade ingredientFacade,
            IStringLocalizer<IngredientControllerResources> ingredientControllerLocalizer)
        {
            this.ingredientFacade = ingredientFacade;
            this.ingredientControllerLocalizer = ingredientControllerLocalizer;
        }

        [HttpGet]
        [OpenApiOperation(ApiOperationBaseName + nameof(GetAll))]
        public ActionResult<List<IngredientListModel>> GetAll()
        {
            return ingredientFacade.GetAll();
        }

        [HttpGet("{id:guid}")]
        [OpenApiOperation(ApiOperationBaseName + nameof(GetById))]
        public ActionResult<IngredientDetailModel> GetById(Guid id)
        {
            var ingredient = ingredientFacade.GetById(id);
            if (ingredient == null)
            {
                return NotFound(ingredientControllerLocalizer[nameof(IngredientControllerResources.GetById_NotFound), id].Value);
            }

            return ingredient;
        }

        [HttpPost]
        [OpenApiOperation(ApiOperationBaseName + nameof(Create))]
        public ActionResult<Guid> Create(IngredientDetailModel ingredient)
        {
            return ingredientFacade.Create(ingredient);
        }

        [HttpPut]
        [OpenApiOperation(ApiOperationBaseName + nameof(Update))]
        public ActionResult<Guid?> Update(IngredientDetailModel ingredient)
        {
            return ingredientFacade.Update(ingredient);
        }

        [HttpPost("upsert")]
        [OpenApiOperation(ApiOperationBaseName + nameof(CreateOrUpdate))]
        public ActionResult<Guid> CreateOrUpdate(IngredientDetailModel ingredient)
        {
            return ingredientFacade.CreateOrUpdate(ingredient);
        }

        [HttpDelete("{id:guid}")]
        [OpenApiOperation(ApiOperationBaseName + nameof(Delete))]
        public IActionResult Delete(Guid id)
        {
            ingredientFacade.Delete(id);
            return Ok();
        }
    }
}
