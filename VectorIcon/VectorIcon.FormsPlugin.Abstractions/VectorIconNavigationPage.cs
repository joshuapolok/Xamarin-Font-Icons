using Xamarin.Forms;

namespace VectorIcon.FormsPlugin.Abstractions
{
    /// <summary>
    /// <see cref="NavigationPage"/> with vector <see cref="Page.Icon"/>
    /// </summary>
    /// <author>Joshua Poling</author>
    /// <date>April 2, 2017</date>
    /// <copyright>
    /// </copyright>
    /// <productName>VectorIconNavigationPage.cs</productName>
    /// <history>
    /// Date             Author              Change Reason                      Change Description
    /// ----------------------------------------------------------------------------------------------------------
    /// 
    /// ----------------------------------------------------------------------------------------------------------
    /// </history>
    public class VectorIconNavigationPage : NavigationPage
    {
        /// <summary>
        /// Get/Set tab icon to display
        /// </summary>
        public string TabIcon { get; set; }

        /// <summary>
        /// Get/Set Icon font family
        /// </summary>
        public string IconFontFamily { get; set;}

        /// <summary>
        /// Sets <see cref="NavigationPage"/> root page
        /// </summary>
        /// <param name="root"><see cref="Page"/> to set as root</param>
        public VectorIconNavigationPage(Page root) : base(root) { }
    }
}
