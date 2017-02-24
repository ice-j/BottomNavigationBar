using System;
using Android.Animation;
using Android.Views;
using Android.Graphics;

namespace BottomNavigationBar.Adapters
{
    internal class CustomAnimatorListenerAdapter : AnimatorListenerAdapter
    {
        private readonly View _backgroundView;
        private readonly View _bgOverlay;
        private readonly Color _newColor;

        public CustomAnimatorListenerAdapter(View backgroundView, int newColor, View bgOverlay)
        {
            _backgroundView = backgroundView;
            _newColor = new Color(newColor);
            _bgOverlay = bgOverlay;
        }

        private void OnCancel()
        {
            _backgroundView.SetBackgroundColor(_newColor);
            _bgOverlay.Visibility = ViewStates.Invisible;
			_bgOverlay.Alpha = 1;
        }

        public override void OnAnimationEnd(Animator animation)
        {
            OnCancel();
        }

        public override void OnAnimationCancel(Animator animation)
        {
            OnCancel();
        }
    }
}

