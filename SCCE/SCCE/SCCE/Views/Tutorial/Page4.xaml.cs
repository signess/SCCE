﻿using Xamanimation;

namespace SCCE.Views.Tutorial
{
    public partial class Page4 : IAnimatedView
    {
        public Page4()
        {
            InitializeComponent();
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