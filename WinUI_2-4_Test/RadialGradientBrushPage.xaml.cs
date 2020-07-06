using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
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
    public sealed partial class RadialGradientBrushPage : Page
    {
        public RadialGradientBrushPage()
        {
            this.InitializeComponent();
            Loaded += OnPageLoaded;
        }

        private void OnPageLoaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            MappingModeComboBox.SelectionChanged += OnMappingModeChanged;
            SpreadMethodComboBox.SelectionChanged += OnSpreadMethodChanged;
            InitializeSliders();
        }

        private void OnSpreadMethodChanged(object sender, SelectionChangedEventArgs e)
        {
            RadialGradientBrushExample.SpreadMethod = Enum.Parse<GradientSpreadMethod>(SpreadMethodComboBox.SelectedValue.ToString());
        }

        private void OnMappingModeChanged(object sender, SelectionChangedEventArgs e)
        {
            RadialGradientBrushExample.MappingMode = Enum.Parse<BrushMappingMode>(MappingModeComboBox.SelectedValue.ToString());
            InitializeSliders();
        }

        private void InitializeSliders()
        {
            var rectSize = Rect.ActualSize.ToSize();
            if (RadialGradientBrushExample.MappingMode == BrushMappingMode.Absolute)
            {
                CenterXSlider.Maximum = RadiusXSlider.Maximum = OriginXSlider.Maximum = rectSize.Width;
                CenterYSlider.Maximum = RadiusYSlider.Maximum = OriginYSlider.Maximum = rectSize.Width;
                CenterXSlider.Value = RadiusXSlider.Value = OriginXSlider.Value = rectSize.Width / 2;
                CenterYSlider.Value = RadiusYSlider.Value = OriginYSlider.Value = rectSize.Width / 2;
                CenterXSlider.StepFrequency = RadiusXSlider.StepFrequency = OriginXSlider.StepFrequency = rectSize.Width / 50;
                CenterYSlider.StepFrequency = RadiusYSlider.StepFrequency = OriginYSlider.StepFrequency = rectSize.Height / 50;
            }
            else
            {
                CenterXSlider.Maximum = RadiusXSlider.Maximum = OriginXSlider.Maximum = 1.0;
                CenterYSlider.Maximum = RadiusYSlider.Maximum = OriginYSlider.Maximum = 1.0;
                CenterXSlider.Value = RadiusXSlider.Value = OriginXSlider.Value = 0.5;
                CenterYSlider.Value = RadiusYSlider.Value = OriginYSlider.Value = 0.5;
                CenterXSlider.StepFrequency = RadiusXSlider.StepFrequency = OriginXSlider.StepFrequency = 0.02;
                CenterYSlider.StepFrequency = RadiusYSlider.StepFrequency = OriginYSlider.StepFrequency = 0.02;
            }
        }

        private void OnSliderValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            RadialGradientBrushExample.Center = new Point(CenterXSlider.Value, CenterYSlider.Value);
            RadialGradientBrushExample.RadiusX = RadiusXSlider.Value;
            RadialGradientBrushExample.RadiusY = RadiusYSlider.Value;
            RadialGradientBrushExample.GradientOrigin = new Point(OriginXSlider.Value, OriginYSlider.Value);
        }
    }
}
