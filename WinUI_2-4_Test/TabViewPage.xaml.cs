using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WinUI_2_4_Test
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TabViewPage : Page
    {
        public TabViewPage()
        {
            this.InitializeComponent();
        }

        private void TabWidthBehaviorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string widthModeString = (e.AddedItems[0] as ComboBoxItem).Content.ToString();
            TabViewWidthMode widthMode = TabViewWidthMode.Equal;
            switch (widthModeString)
            {
                case "Equal":
                    widthMode = TabViewWidthMode.Equal;
                    break;
                case "SizeToContent":
                    widthMode = TabViewWidthMode.SizeToContent;
                    break;
                case "Compact":
                    widthMode = TabViewWidthMode.Compact;
                    break;
            }
            TabView3.TabWidthMode = widthMode;
        }

        private void TabCloseButtonOverlayModeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string overlayModeString = (e.AddedItems[0] as ComboBoxItem).Content.ToString();
            TabViewCloseButtonOverlayMode overlayMode = TabViewCloseButtonOverlayMode.Auto;
            switch (overlayModeString)
            {
                case "Auto":
                    overlayMode = TabViewCloseButtonOverlayMode.Auto;
                    break;
                case "OnHover":
                    overlayMode = TabViewCloseButtonOverlayMode.OnPointerOver;
                    break;
                case "Always":
                    overlayMode = TabViewCloseButtonOverlayMode.Always;
                    break;
            }
            TabView4.CloseButtonOverlayMode = overlayMode;
        }
    }
}
