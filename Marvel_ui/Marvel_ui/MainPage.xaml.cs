using Marvel_ui.ViewModels;
using Marvel_ui.Views;
using PanCardView;
using PanCardView.EventArgs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Marvel_ui
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = new HeroCardsViewModel();
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MainCardView.UserInteracted += MainCardView_User_Interacted;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MainCardView.UserInteracted -= MainCardView_User_Interacted;
        }

        private void MainCardView_User_Interacted(CardsView view, UserInteractedEventArgs args)
        {
            var card = MainCardView.CurrentView as HeroCard;
            
            if (args.Status == PanCardView.Enums.UserInteractionStatus.Running)
            {
                //work out what percent the swipe is at
                var percentFromCenter = Math.Abs(args.Diff / this.Width);

                var opacity = (1 - (percentFromCenter)) * 1.5;

                if (opacity > 1)
                {
                    opacity = 1;
                }

                MainCardView.CurrentView.Opacity = opacity;

                //do the scaling on the main card during swipe
                var scale = (1 - (percentFromCenter) * 1.5);
                card.MainImage.Scale = scale;
                var imageBaseMargin = -150;
                var movementFactor = 50;

                var translation = imageBaseMargin + (movementFactor * percentFromCenter);
                card.MainImage.TranslationY = translation;

                //adjust opacity of image
                var imageOpacity = Math.Abs(opacity * 1.5);
                card.MainImage.Opacity = imageOpacity;

                var nextCard = MainCardView.CurrentBackViews.First() as HeroCard;
                //Adjust opacity of the back image
                nextCard.MainImage.Opacity = percentFromCenter * 1.5;
                nextCard.MainImage.Scale = percentFromCenter * 1.5;

                //scale up the back image

            }

            if (args.Status == PanCardView.Enums.UserInteractionStatus.Ended ||
                args.Status == PanCardView.Enums.UserInteractionStatus.Ending)
            {
                card.Opacity = 1;
                card.MainImage.Scale = 1;
                card.MainImage.TranslationY = -150;
            }
        }

        
    }
}
