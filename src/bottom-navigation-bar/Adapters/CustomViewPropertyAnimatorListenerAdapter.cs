using System;
using Android.Views;
using Android.Graphics;
using Android.Animation;

namespace BottomNavigationBar.Adapters
{
    internal class CustomViewPropertyAnimatorListenerAdapter : Animator.IAnimatorListener
	{
        private readonly View _backgroundView;
        private readonly View _bgOverlay;
        private readonly Color _newColor;

		public IntPtr Handle
		{
			get
			{
				return IntPtr.Zero;
			}
		}

		public CustomViewPropertyAnimatorListenerAdapter(View backgroundView, int newColor, View bgOverlay)
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

		public void OnAnimationCancel(Animator animation)
		{
            OnCancel();
		}

		public void OnAnimationRepeat(Animator animation)
		{
		}

		public void OnAnimationStart(Animator animation)
		{
		}

		public void Dispose()
		{
			OnCancel();
		}

		public void OnAnimationEnd(Animator animation)
		{
            OnCancel();
		}
	}
}

