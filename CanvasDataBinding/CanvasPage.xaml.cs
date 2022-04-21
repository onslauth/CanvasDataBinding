using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace CanvasDataBinding
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CanvasPage : Page
    {
        public CanvasPage( )
        {
            this.InitializeComponent( );
            this.Loaded += CanvasPage_Loaded;
        }

        private void CanvasPage_Loaded( object sender, RoutedEventArgs e )
        {
            CustomRectangle c = new CustomRectangle( );
            c.CustomWidth = 50;
            this.MainCanvas.Children.Add( c );
        }
    }
}
