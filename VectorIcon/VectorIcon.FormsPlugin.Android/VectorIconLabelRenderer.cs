using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Graphics;
using System;
using Android.Util;
using VectorIcon.FormsPlugin.Abstractions;
using VectorIcon.FormsPlugin.Android;

[assembly: ExportRenderer(typeof(VectorIconLabel), typeof(VectorIconLabelRenderer))]
namespace VectorIcon.FormsPlugin.Android
{
    /// <summary>
    /// Custom renderer for display's vector font for <see cref="Label.Text"/>
    /// </summary>
    /// <author>Joshua Poling</author>
    /// <date>April 4, 2017</date>
    /// <productName>VectorIconLabelRenderer.cs</productName>
    /// <history>
    /// Date             Author              Change Reason                      Change Description
    /// ----------------------------------------------------------------------------------------------------------
    /// 
    /// ----------------------------------------------------------------------------------------------------------
    /// </history>
    public class VectorIconLabelRenderer : LabelRenderer
    {

        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        /// <author>Joshua Poling</author>
        /// <date>April 4, 2017</date>
        /// <history>
        /// Date             Author              Change Reason                      Change Description
        /// ----------------------------------------------------------------------------------------------------------
        /// 
        /// ----------------------------------------------------------------------------------------------------------
        /// </history>
        public static void Init() { }

        /// <summary>
        /// Sets <see cref="Label.FontFamily"/>
        /// </summary>
        /// <param name="e"></param>
        /// <author>Joshua Poling</author>
        /// <date>April 4, 2017</date>
        /// <history>
        /// Date             Author              Change Reason                      Change Description
        /// ----------------------------------------------------------------------------------------------------------
        /// 
        /// ----------------------------------------------------------------------------------------------------------
        /// </history>
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            try
            {
                var font = Typeface.CreateFromAsset(Forms.Context.ApplicationContext.Assets, e.NewElement.FontFamily);
                Control.Typeface = font;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.InnerException);
                Log.Error(typeof(VectorIconLabelRenderer).AssemblyQualifiedName, $"Error setting font for {e.NewElement}");
            }
        }
    }
}