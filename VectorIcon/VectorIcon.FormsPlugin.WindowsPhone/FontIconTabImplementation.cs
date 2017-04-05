using FontIconTab.FormsPlugin.Abstractions;
using System;
using Xamarin.Forms;
using FontIconTab.FormsPlugin.WindowsPhone;
using Xamarin.Forms.Platform.WinPhone;

[assembly: ExportRenderer(typeof(FontIconTab.FormsPlugin.Abstractions.FontIconTabControl), typeof(FontIconTabRenderer))]
namespace FontIconTab.FormsPlugin.WindowsPhone
{
    /// <summary>
    /// FontIconTab Renderer
    /// </summary>
    public class FontIconTabRenderer // : 
    {
        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public static void Init() { }

       
    }
}
