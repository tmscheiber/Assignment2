﻿using SportsStore.Models;
namespace SportsStore.Models.ViewModels
{
    public class CartIndexViewModel
    {
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        public int NewProductID { get; set; }
    }// end class




}// end namespace