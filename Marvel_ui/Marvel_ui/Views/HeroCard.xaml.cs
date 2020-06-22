using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Marvel_ui.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HeroCard : ContentView
    {
        public HeroCard()
        {
            InitializeComponent();
        }

        public Image MainImage  
        {
            get 
            {
                return HeroImage;
            }
            
        }
    }
}