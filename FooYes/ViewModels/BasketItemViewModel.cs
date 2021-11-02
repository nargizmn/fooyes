using FooYes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FooYes.ViewModels
{
    public class BasketItemViewModel
    {
        public Meal Meal { get; set; }
        public int Count { get; set; }
        public Size Size { get; set; }
    }
}
