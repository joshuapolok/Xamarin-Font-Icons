using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace VectorIcon.FormsPlugin.Abstractions
{
    /// <summary>
    /// <see cref="TabbedPage"/> with list of <see cref="VectorIconNavigationPage"/>
    /// </summary>
    /// <author>Joshua Poling</author>
    /// <date>April 2, 2017</date>
    /// <copyright>
    /// </copyright>
    /// <productName>VectorIconTabbedPage.cs</productName>
    /// <history>
    /// Date             Author              Change Reason                      Change Description
    /// ----------------------------------------------------------------------------------------------------------
    /// 
    /// ----------------------------------------------------------------------------------------------------------
    /// </history>
    public class VectorIconTabbedPage : TabbedPage
    {
        public static readonly BindableProperty TabsProperty = BindableProperty.Create("Tabs", typeof(List<VectorIconNavigationPage>), typeof(VectorIconTabbedPage), new List<VectorIconNavigationPage>());
        public static readonly BindableProperty SelectedIconColorProperty = BindableProperty.Create("SelectedIconColor", typeof(Color), typeof(VectorIconTabbedPage), Color.Accent);
        public static readonly BindableProperty UnselectedIconColorColorProperty = BindableProperty.Create("UnselectedIconColor", typeof(Color), typeof(VectorIconTabbedPage), Color.Default);
        public static readonly BindableProperty IconSizeProperty = BindableProperty.Create("IconSize", typeof(int), typeof(VectorIconTabbedPage), 0);
        
        /// <summary>
        /// List of <see cref="NavigationPage"/> to use as root pages of tabs
        /// </summary>
        public List<VectorIconNavigationPage> Tabs {
            get {
                return (List<VectorIconNavigationPage>)GetValue(TabsProperty);
            }
            set {
                SetValue(TabsProperty, value);
            }
        }

        /// <summary>
        /// Get/Set the <see cref="VectorIconNavigationPage.TabIcon"/> <see cref="Color"/> for selected tab
        /// </summary>
        public Color SelectedIconColor {
            get {
                return (Color)GetValue(SelectedIconColorProperty);
            }
            set {
                SetValue(SelectedIconColorProperty, value);
            }
        }

        /// <summary>
        /// Get/Set the <see cref="VectorIconNavigationPage.TabIcon"/> <see cref="Color"/> for inactive tab
        /// </summary>
        public Color UnselectedIconColor {
            get {
                return (Color)GetValue(UnselectedIconColorColorProperty);
            }
            set {
                SetValue(UnselectedIconColorColorProperty, value);
            }
        }

        /// <summary>
        /// Get/Set the size of the iOS icon. 
        /// <para>Width and Height are proportional.</para>
        /// </summary>
        public int IconSize {
            get {
                return (int)GetValue(IconSizeProperty);
            }
            set {
                SetValue(IconSizeProperty, value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public VectorIconTabbedPage() { }
    }
}
