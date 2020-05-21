using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace CRM.WPF
{
    /// <summary>
    /// Animation helpers for <see cref="StoryBoard"/>
    /// </summary>
    public static class StoryBoardHelpers
    {
        /// <summary>
        /// Add a slide and animation to the storyboard
        /// </summary>
        /// <param name="storyBoard">storyboard to add the animation to</param>
        /// <param name="seconds"> the time animation will take</param>
        /// <param name="offset">The distance to the right to start from</param>
        /// <param name="decelerationRatio">The rate of deceleration</param>
        public static void AddSlideFromRight(this Storyboard storyBoard, float seconds, double offset, float decelerationRatio = 0.9f)
        {
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(offset, 0, -offset, 0),
                To = new Thickness(0),
                DecelerationRatio = decelerationRatio
            };

            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            storyBoard.Children.Add(animation);
        }

        /// <summary>
        /// Add a fade in  to the storyboard
        /// </summary>
        /// <param name="storyBoard">storyboard to add the animation to</param>
        /// <param name="seconds"> the time animation will take</param>
        public static void AddFadeIn(this Storyboard storyBoard, float seconds)
        {
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 0,
                To = 1
            };

            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));
            storyBoard.Children.Add(animation);
        }


        /// <summary>
        /// Add a slide to left and animation to the storyboard
        /// </summary>
        /// <param name="storyBoard">storyboard to add the animation to</param>
        /// <param name="seconds"> the time animation will take</param>
        /// <param name="offset">The distance to the right to start from</param>
        /// <param name="decelerationRatio">The rate of deceleration</param>
         public static void AddSlideToLeft(this Storyboard storyBoard, float seconds, double offset, float decelerationRatio = 0.9f)
        {
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0),
                To = new Thickness(-offset, 0, offset, 0),
                DecelerationRatio = decelerationRatio
            };

            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            storyBoard.Children.Add(animation);
        }

        /// <summary>
        /// Add a fade out  to the storyboard
        /// </summary>
        /// <param name="storyBoard">storyboard to add the animation to</param>
        /// <param name="seconds"> the time animation will take</param>
        public static void AddFadeOut(this Storyboard storyBoard, float seconds)
        {
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = 1,
                To = 0
            };

            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));
            storyBoard.Children.Add(animation);
        }
    }
}
