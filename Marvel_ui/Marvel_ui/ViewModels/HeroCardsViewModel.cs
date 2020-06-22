using Marvel_ui.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Marvel_ui.ViewModels
{
    public class HeroCardsViewModel
    {
        public ObservableCollection<Hero> Heroes { get; set; }

        public HeroCardsViewModel()
        {
            Heroes = new ObservableCollection<Hero>
            {
                new Hero()
                {
                    HeroName = "Spider Man",
                    RealName = "Peter Parker",
                    Image = "spiderman.png",
                    HeroColor = "#C51925"

                },
                new Hero()
                {
                    HeroName = "Iron Man",
                    RealName = "Tony Stark",
                    Image = "ironman.png",
                    HeroColor = "#DF8E04"

                }
            };
            
        }
    }
}
