using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Xamarin.Forms;
using BetterNotes.CustomControls;
using BetterNotes.Droid.Renderers;

using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;

[assembly:ExportRenderer(typeof(CustomEditor), typeof(CustomEditorRenderer))]
namespace BetterNotes.Droid.Renderers
{
    public class CustomEditorRenderer: EditorRenderer
    {
        public CustomEditorRenderer(Context context) : base (context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                var myControl = e.NewElement as CustomEditor;
                var radii = myControl.CornerRadii;
                var shape = new GradientDrawable(GradientDrawable.Orientation.TopBottom, new int[]
                {
                    myControl.BackGroundColor.ToAndroid(),
                    myControl.EndColor == null ? myControl.BackGroundColor.ToAndroid() : myControl.EndColor.ToAndroid()
                });

                var radiuses = new float[8];

                for (int i = 0; i < radii.Length; i++)
                {
                    radiuses[i] = radii[i];
                    radiuses[i + 1] = radii[i];
                }
                ////
                ///
                //
                shape.SetCornerRadii(radiuses);

                Control.Background = shape;
                Control.SetHintTextColor(Color.Transparent.ToAndroid());
            }
        }
    }
}