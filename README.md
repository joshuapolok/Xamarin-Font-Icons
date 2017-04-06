# Xamarin-Font-Icons

Xamarin forms vector icon label, and tabs. Enables the use of vector based font icons for Xamarin TabbedPage and Label for iOS and Android projects. This solution allows the developer to use any font they desire, but the following fonts have corresponding classes already included in the solution. All you need to do is reference the code and font. 


### Font Resources

The fonts below have already been incorrperated into the solution. If you want to use any of the font icons listed below click the link and install them into the Android, and/or iOS solution. See [iOS Instuctions](#installation), and [Android Instructions](#android-solution) for font install locations.

| Fonts   | Code Key Files    |
| ----- | --------- |
| [Fontawesome](http://fontawesome.io/icons/) | FontAwesomeIconCode.cs   |
| [Foundation](http://foundation.zurb.com/icon-fonts.html) | FoundationIconCode.cs   |
| [Themify](https://themify.me/themify-icons) | ThemifyIconCode.cs   |
| [IconIcons](http://ionicons.com/) | IonIconCode.cs   |


## Installation
This section details how to install the Xamarin Plugin. 

### Nuget Installation
Install Plugin.VectorIcon [Nuget Package](https://www.nuget.org/packages/Xamarin.Plugin.FontIcons/) into the following projects:

* Xamarin.Android
* Xamarin.iOS
* Xamarin (PCL)

At this point your project's should contain the following dll's installed:

| PCL   | Android    | iOS   |
| ----- | --------- | ------ |
| VectorIcon.FormsPlugin.Abstractions.dll| VectorIcon.FormsPlugin.Abstractions.dll   | VectorIcon.FormsPlugin.Abstractions.dll  |
| | VectorIcon.FormsPlugin.Android.dll | VectorIcon.FormsPlugin.iOS.dll |

# iOS Solution
The following section details how to setup the iOS solution to enable font icons. 

## Initializing iOS
Initialize the vector icon renderer's in the AppDelegate.cs file before LoadApplication(new App()); 

### Setup
- Add your font to the info.plist
- Initialize Renderer

### AppDelepage.cs Example
```csharp
public override bool FinishedLaunching(UIApplication app, NSDictionary options)
{
     global::Xamarin.Forms.Forms.Init();
            
     FontIconTab.FormsPlugin.iOS.FontIconTabRenderer.Init(); <---------- Initialize Renderer here
            
     LoadApplication(new App());

     return base.FinishedLaunching(app, options);
}
```
### Font Registration
This section gives an example of the info.plist font registration. You must register your font in order to use it for iOS solutions. 

#### info.plist Example
```xml
<key>UIAppFonts</key>
<array>
  <string>fontawesome.ttf</string>
  <string>foundation-icons.ttf</string>
  <string>ionicons.ttf</string>
  <string>themify.ttf</string>
</array>
```
# Android Solution
The following section details how to setup the Android solution to enable font icons. 
<hr/>
## Initializing Android
Initialize the vector icon renderer's in your MainActivity.cs file before LoadApplication(new App()), and global::Xamarin.Forms.Init(this, bundle); The Android solution takes an extra step compared to the iOS solution. You'll have to set the resource id used for your Tabbar in the MainActivity.cs. The example below shows that my Resource.Id.\<tab> is named "sliding_tabs"

### Set the following in MainActivity.cs
- VectorIconTabRenderer.TabLayoutResourceID = \<resource id of your tab view>
- VectorIconLabelRenderer.Init(); (Only needed if you want to use vector icon text for Xamarin Labels)

### MainActivity Example
```csharp
protected override void OnCreate(Bundle bundle)
{
     TabLayoutResource = Resource.Layout.Tabbar;
     ToolbarResource = Resource.Layout.Toolbar;

     base.OnCreate(bundle);
            
     VectorIconTabRenderer.TabLayoutResourceID = Resource.Id.sliding_tabs;   <------ Set layout used for tabs (ex.android:id="@+id/sliding_tabs")
     VectorIconLabelRenderer.Init();                                         <------ Initialize renderer
            
     global::Xamarin.Forms.Forms.Init(this, bundle);
     LoadApplication(new App());
}
```

### Tabbar.axml Example
This layout is used for my tabbar. You need to set the resource id to the android:id="@+id/sliding_tabs" used in this file. Creating a new Xamarin PCL project will generate this file for you. 

```xml
<?xml version="1.0" encoding="utf-8"?>
<android.support.design.widget.TabLayout xmlns:android="http://schemas.android.com/apk/res/android"
    xmlns:app="http://schemas.android.com/apk/res-auto"
    android:id="@+id/sliding_tabs"
    android:layout_width="match_parent"
    android:layout_height="wrap_content"
    android:background="?attr/colorPrimary"
    android:theme="@style/ThemeOverlay.AppCompat.Dark.ActionBar"
    app:tabIndicatorColor="@android:color/white"
    app:tabGravity="fill"
    app:tabMode="fixed" />
```

### Font Installation

Install fonts into the Assets folder to enable access for Android.

# Xamarin PCL Implementation
This section details how to use the font icons once all packages have been installed. 

## Implementing font Labels
```csharp
// Fontawesome icon
 var _linuxIcon = new VectorIconLabel 
{ 
     Text       = FontAwesomeIconCode.FaLinux, 
     FontFamily = Device.OnPlatform("fontawesome", "fontawesome.ttf", null) 
};
// IonIcon font icon
 var  _windowsIcon = new VectorIconLabel  
 {
     Text       = IonIconCode.TiApple, 
     FontFamily = Device.OnPlatform("ionicons", "ionicons.ttf", null)  
 };
 // Foundation font icon
var _androidIcon = new VectorIconLabel  
{ 
     Text       = FoundationIconCode.FiSocialAndroid,  
     FontFamily = Device.OnPlatform("foundation-icons", "foundation-icons.ttf", null)
};
// Themify font icon 
var _appleIcon = new VectorIconLabel 
{ 
     Text       = ThemifyIconCode.TiApple, 
     FontFamily = Device.OnPlatform("themify", "themify.ttf", null)
};
```

## Implementing Font Icon Tabs
You can use the MainTabPage example for an additional aid if needed. 

```csharp
 public class MainTabPage : VectorIconTabbedPage
    {
        public MainTabPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            SelectedIconColor = Color.White;
            UnselectedIconColor = Color.Gray;
            IconSize = 32;

            Tabs = new List<VectorIconNavigationPage>()
            {
                new VectorIconNavigationPage(new HomePage())
                {
                    TabIcon = FontAwesomeIconCode.FaHome,
                    Title = "HOME",
                    IconFontFamily = Device.OnPlatform("fontawesome", "fontawesome.ttf", null)
                },
                new VectorIconNavigationPage(new AwardsPage())
                {
                    TabIcon = FontAwesomeIconCode.FaTrophy,
                    Title   = "AWARDS"
                },
                new VectorIconNavigationPage(new SettingsPage())
                {
                    TabIcon = FontAwesomeIconCode.FaCog,
                    Title = "SETTINGS"
                }
            };

            foreach (var tab in Tabs)
            {
                Children.Add(tab);
            }
        }
    }
```

## Results
| Android   | iOS   |
| ----- | --------- |
| ![Android Result](https://github.com/joshuapolok/Xamarin-Font-Icons/blob/master/SampleImages/IconLabelsDroid.png) |![iOS Result](https://github.com/joshuapolok/Xamarin-Font-Icons/blob/master/SampleImages/IconLabelsiOS.png) | 
