using Microsoft.UI.Input;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace CanvasDataBinding
{
    public sealed partial class CustomRectangle : UserControl, INotifyPropertyChanged
    {

        private double x_pos = 10;
        private double custom_width = 20;
        private string side = "none";

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged( string name )
        {
            PropertyChanged?.Invoke( this, new PropertyChangedEventArgs( name ) );
        }

        public double X_Pos
        {
            get { return x_pos; }
            set
            {
                x_pos = value;
                NotifyPropertyChanged( "X_Pos" );
            }
        }

        public double CustomWidth
        {
            get { return custom_width; }
            set
            {
                custom_width = value;
                NotifyPropertyChanged( "CustomWidth" );
            }
        }

        public CustomRectangle( )
        {
            this.InitializeComponent( );
            this.PointerPressed += CustomRectangle_PointerPressed;
            this.PointerMoved += CustomRectangle_PointerMoved;
            this.PointerReleased += CustomRectangle_PointerReleased;
        }

        private PointerPoint start;

        private void CustomRectangle_PointerPressed( object sender, PointerRoutedEventArgs e )
        {
            start = e.GetCurrentPoint( this );

            if ( start.Position.X < ( this.custom_width - start.Position.X ) )
            {
                side = "left";
            }
            else
            {
                side = "right";
            }

            this.CapturePointer( e.Pointer );
        }

        private void CustomRectangle_PointerMoved( object sender, PointerRoutedEventArgs e )
        {
            if ( this.PointerCaptures == null )
            {
                return;
            }

            var captures = this.PointerCaptures.Where( i => i.PointerId == e.Pointer.PointerId );
            if ( captures.Count( ) == 0 )
            {
                return;
            }

            if ( side.Equals( "none" ) )
            {
                return;
            }

            PointerPoint current_point = e.GetCurrentPoint( this );
            var dx = current_point.Position.X - this.start.Position.X;

            if ( side.Equals( "left" ) )
            {
                this.X_Pos += dx;

                // Uncomment to use SetValue instead, which works but very jerky
                //var left = ( double )this.GetValue( Canvas.LeftProperty );
                //this.SetValue( Canvas.LeftProperty, left + dx );

            }
            else
            {
                this.CustomWidth += dx;
            }

            start = current_point;
        }

        private void CustomRectangle_PointerReleased( object sender, PointerRoutedEventArgs e )
        {
            this.ReleasePointerCaptures( );
        }
    }
}
