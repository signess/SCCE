using SCCE.ViewModels;
using Xamanimation;
using Xamarin.Forms.Xaml;

namespace SCCE.Views.Tutorial
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page6 : IAnimatedView
    {
        public Page6()
        {
            InitializeComponent();
			this.BindingContext = new Page6ViewModel();
        }


		public void StartAnimation()
		{
			if (Resources["BackgroundColorAnimation"] is ColorAnimation backgroundColorAnimation)
			{
				backgroundColorAnimation.Begin();
			}

			if (Resources["InfoPanelAnimation"] is StoryBoard animation)
			{
				animation.Begin();
			}
		}
	}
}