using System;
using System.Collections.Generic;
using System.Text;

using Xamarin.Forms;

namespace BetterNotes.CustomControls
{
    public class CustomEditor:Editor
    {
        public static BindableProperty CornerRadius = BindableProperty.Create("CornerRadius", typeof(string), typeof(CustomEditor), "0,0,0,0");

        public int[] CornerRadii
        {
            get 
            {
                var radii = (string)GetValue(CornerRadius);
                List<int> result = new List<int>();
                try
                {
                    var radistring = radii.Split(',');
                    foreach (var rad in radistring)
                    {
                        result.Add(int.Parse(rad.Trim()));
                    }
                    return result.ToArray();
                }
                catch (Exception e)
                {
                    return new int[] { 40, 40, 40, 40 };
                }
            }

            set => SetValue(CornerRadius, value);
        }

        public static BindableProperty Background = BindableProperty.Create("Background", typeof(string), typeof(CustomEditor));

        public Color BackGroundColor
        {
            get
            {
                var color = (string)GetValue(Background);
                if (color.Contains("#"))
                {
                    return Color.FromHex(color);
                }
                return Color.White;              
            }
            set
            {
                SetValue(Background, value);
            }
        }

        public static BindableProperty EndColorProperty = BindableProperty.Create("EndColor", typeof(string), typeof(CustomEditor), null);

        public Color EndColor
        {
            get
            {
                var color = (string)GetValue(EndColorProperty);
                if (color.Contains("#"))
                {
                    return Color.FromHex(color);
                }
                return Color.White;
            }
            set
            {
                SetValue(EndColorProperty, value);
            }
        }
    }
}
