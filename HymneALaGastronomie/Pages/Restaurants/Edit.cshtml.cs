﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HymneALaGastronomie.CoreBusiness;
using HymneALaGastronomie.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HymneALaGastronomie.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper )
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int restaurantId)
        {
            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            Restaurant = restaurantData.GetRestaurantById(restaurantId);

            if(Restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            Restaurant = restaurantData.UpdateRestaurant(Restaurant);
            restaurantData.Commit();

            return RedirectToPage("./List");
        }
    }
}