﻿//----------------------------------------------------------------------- 
// <copyright file="RecipeRepository.cs" company="Copacetic Software"> 
// Copyright (c) Copacetic Software.  
// <author>Philip Pittle</author> 
// <date>Wednesday, June 25, 2014 7:00:33 PM</date> 
// Licensed under the Apache License, Version 2.0,
// you may not use this file except in compliance with this License.
//  
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an 'AS IS' BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright> 
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using CopaceticSoftware.pMixins.Mvc.Models;
using JetBrains.Annotations;

namespace CopaceticSoftware.pMixins.Mvc.BAL
{
    public class RecipeRepository
    {
        #region Hard Coded Recipes

        private readonly IEnumerable<Recipe> _recipes = new[]
        {
            new Recipe
            {
                Id="Basic-Mixin",
                Name = "Basic Mixin",
                Intro = "Welcome to the Basic Mixin!"
            }
        };

        #endregion

        public IEnumerable<Recipe> GetAllRecipes()
        {
            return _recipes;
        }

        [CanBeNull]
        public Recipe GetRecipeById(string id)
        {
            return _recipes.FirstOrDefault(x => x.Id.Equals(id, StringComparison.InvariantCulture));
        }
    }
}
