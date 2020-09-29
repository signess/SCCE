using Xamanimation;

namespace SCCE.Views.Tutorial
{
    public partial class Page2 : IAnimatedView
    {
        public Page2()
        {
            InitializeComponent();
        }

        public void StartAnimation()
        {
            if (Resources["InfoPanelAnimation"] is StoryBoard animation)
            {
                animation.Begin();
            }
        }
    }
}