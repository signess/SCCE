using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SCCE.Views.Tutorial
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TutorialPage : ContentPage
    {
        private readonly View[] _views;
        public TutorialPage()
        {
            InitializeComponent();
            _views = new View[]
            {
                new Page2(),
                new Page3(),
                new Page4(),
                new Page5(),
                new Page6()
            };

            Carousel.ItemsSource = _views;
        }

        private void OnCarouselPositionSelected(object sender, CarouselView.FormsPlugin.Abstractions.PositionSelectedEventArgs e)
        {
            var currentView = _views[e.NewValue];

            if (currentView is IAnimatedView animatedView)
            {
                animatedView.StartAnimation();
            }
        }
    }
}