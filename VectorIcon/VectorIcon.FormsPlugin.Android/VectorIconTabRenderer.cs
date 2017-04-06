using System;
using Xamarin.Forms;
using VectorIcon.FormsPlugin.Android;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;
using System.ComponentModel;
using Android.Support.Design.Widget;
using VectorIcon.FormsPlugin.Abstractions;

[assembly: ExportRenderer(typeof(VectorIconTabbedPage), typeof(VectorIconTabRenderer))]
namespace VectorIcon.FormsPlugin.Android
{
    /// <summary>
    /// Renders <see cref="TabLayout.Tab.Icon"/>
    /// </summary>
    /// <author>Joshua Poling</author>
    /// <date>April 2, 2017</date>
    /// <copyright>
    /// </copyright>
    /// <productName>VectorIconTabRenderer.cs</productName>
    /// <history>
    /// Date             Author              Change Reason                      Change Description
    /// ----------------------------------------------------------------------------------------------------------
    /// 
    /// ----------------------------------------------------------------------------------------------------------
    /// </history>
    public class VectorIconTabRenderer : TabbedPageRenderer
    {
        private static TabLayout _tbLayout;

        /// <summary>
        /// <see cref="Resource"/> used for <see cref="TabLayout"/>
        /// </summary>
        public static int TabLayoutResourceID { get; set; }

        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public static void Init() { }

        /// <summary>
        /// Called on first binding of <see cref="VectorIconTabbedPage"/>. Sets <see cref="Android"/> View to 
        /// use for <see cref="TabLayout"/>, and sets <see cref="TabLayout.TabTextColors"/>
        /// </summary>
        /// <param name="e"></param>
        protected override void OnElementChanged(ElementChangedEventArgs<TabbedPage> e)
        {
            base.OnElementChanged(e);

            _tbLayout = FindViewById<TabLayout>(TabLayoutResourceID);

            var element = Element as VectorIconTabbedPage;

            _tbLayout.SetTabTextColors(element.UnselectedIconColor.ToAndroid(), element.SelectedIconColor.ToAndroid());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <author>Joshua Poling</author>
        /// <date>April 1, 2017</date>
        /// <exception cref="NullReferenceException" ></exception>
        /// <history>
        /// Date             Author              Change Reason                      Change Description
        /// ----------------------------------------------------------------------------------------------------------
        /// 
        /// ----------------------------------------------------------------------------------------------------------
        /// </history>
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            var element = Element as VectorIconTabbedPage;
            var tabs = element.Tabs;

            //changed cast from MainPage to TabbedPage to allow use on multiple tabbed pages: Joshua Poling - 3/19/2017
            var mainPage = ((TabbedPage)sender);

            Page currentPage = mainPage.CurrentPage;
            int currentPageNavigationIndex = mainPage.Children.IndexOf(currentPage);

            int selectedTab = _tbLayout.GetTabAt(currentPageNavigationIndex).Position;

            tabs.ForEach(tab =>
            {
                if (tabs.IndexOf(tab) == selectedTab)
                {
                    _tbLayout.GetTabAt(tabs.IndexOf(tab))
                             .SetIcon(new FontDrawable(Context, tab.TabIcon.ToString(), element.SelectedIconColor.ToAndroid(), element.IconSize, tab.IconFontFamily));
                }
                else
                {
                    _tbLayout.GetTabAt(tabs.IndexOf(tab))
                             .SetIcon(new FontDrawable(Context, tab.TabIcon.ToString(), element.UnselectedIconColor.ToAndroid(), element.IconSize, tab.IconFontFamily));
                }
            });
        }
    }
}