using Xamanimation;

namespace SCCE.Views.Tutorial
{
    public partial class Page3 : IAnimatedView
    {
        public Page3()
        {
            InitializeComponent();
        }

        public void StartAnimation()
        {
            if (Resources["BackgroundColorAnimation"] is ColorAnimation backgroundColorAnimation)
            {
                backgroundColorAnimation.Begin();
            }

            if (Resources["InfoPanelAnimation"] is StoryBoard infoPanelAnimation)
            {
                infoPanelAnimation.Begin();
            }
        }
    }
}