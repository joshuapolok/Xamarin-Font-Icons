using VectorIcon.FormsPlugin.Abstractions;
using UIKit;
using CoreGraphics;
using Xamarin.Forms;
using VectorIcon.FormsPlugin.iOS;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(VectorIconTabbedPage), typeof(VectorIconTabRenderer))]
namespace VectorIcon.FormsPlugin.iOS
{
    /// <summary>
    /// Renders <see cref="UITabBar.SelectedItem"/> and <see cref="UITabBar.BackgroundImage"/>
    /// </summary>
    /// <author>Joshua Poling</author>
    /// <date>April 2, 2017</date>
    /// <productName>VectorIconRenderer.cs</productName>
    /// <history>
    /// Date             Author              Change Reason                      Change Description
    /// ----------------------------------------------------------------------------------------------------------
    /// 4/6/2017    Joshua Poling       Bug with icon color     Added function to set set UITabBar appearance
    /// ----------------------------------------------------------------------------------------------------------
    /// 4/6/2017    Joshua Poling       Not descriptive         Changed class name from implementation to renderer
    /// ----------------------------------------------------------------------------------------------------------
    /// </history>
    public class VectorIconTabRenderer : TabbedRenderer
    {
        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        new public static void Init() { }

        /// <summary>
        /// Called on initial creation of <see cref="VectorIconTabbedPage"/>
        /// </summary>
        /// <param name="e"></param>
        /// <author>Joshua Poling</author>
        /// <date>April 6, 2017</date>
        /// <history>
        /// Date             Author              Change Reason                      Change Description
        /// ----------------------------------------------------------------------------------------------------------
        /// 
        /// ----------------------------------------------------------------------------------------------------------
        /// </history>
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            var element = Element as VectorIconTabbedPage;

            if (element.SelectedIconColor != null)
            {
                UITabBar.Appearance.SelectedImageTintColor = element.SelectedIconColor.ToUIColor();

            }
            else if (element.UnselectedIconColor != null)
            {
                UITabBar.Appearance.TintColor = element.UnselectedIconColor.ToUIColor();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="animated"></param>
        /// <author>Joshua Poling</author>
        /// <date>April 2, 2017</date>
        /// <history>
        /// Date             Author              Change Reason                      Change Description
        /// ----------------------------------------------------------------------------------------------------------
        /// 
        /// ----------------------------------------------------------------------------------------------------------
        /// </history>
        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            var list = TabBar.Items;
            var element = Element as VectorIconTabbedPage;

            for(int n = 0; n <= element.Tabs.Count - 1; n++)
            {
                var currentTab = element.Tabs[n];
                var iconSize = new CGSize(element.IconSize, element.IconSize);

                TabBar.Items[n].SelectedImage = ImageHelper.ImageFromFont(currentTab.TabIcon, element.SelectedIconColor.ToUIColor(),   iconSize, currentTab.IconFontFamily);
                TabBar.Items[n].Image         = ImageHelper.ImageFromFont(currentTab.TabIcon, element.UnselectedIconColor.ToUIColor(), iconSize, currentTab.IconFontFamily);
            }
        }
    }
}
