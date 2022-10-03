﻿using ADP.Factory;
using Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADP.Controllers
{
    public class GenericController<TEntity,TViewModel> : Controller where TEntity : BaseEntity,new() where TViewModel : class
    {
        private readonly IGenericFactory<TEntity> _genericFactory;
        public GenericController(IGenericFactory<TEntity> genericFactory)
        {
            _genericFactory = genericFactory;
        }

        [HttpPost]
        public async Task<IActionResult> Insert(TViewModel model) 
        {
            await _genericFactory.Insert(model);
            return Ok(new { message = string.Format("{0} added",nameof(TEntity)) });
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, TViewModel model) 
        {
            await _genericFactory.Update(id, model);
            return Ok(new { message = string.Format("{0} added", nameof(TEntity)) });
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _genericFactory.Delete(id);
            return Ok(new { message = string.Format("{0} Deleted Successfully", nameof(TEntity)) });
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id) 
        {
            var data = await _genericFactory.DetailsById<TViewModel>(id);
            return Ok(new { message = string.Format("{0} Fetch Details Successfully", nameof(TEntity)), result = data });
        }

        [HttpGet]
        public async Task<IActionResult> List() 
        {
            var list = await _genericFactory.Get<TViewModel>();
            return Ok(new { message = string.Format("{0} List Fetched Successfully", nameof(TEntity)), result = list });
        }
    }
}
