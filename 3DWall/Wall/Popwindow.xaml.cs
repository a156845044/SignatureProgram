using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _3DWall.Wall
{
    /// <summary>
    /// Interaction logic for Popwindow.xaml
    /// </summary>
    public partial class Popwindow : UserControl
    {
        public Popwindow()
        {
            InitializeComponent();
            DataContext = this;
            Loaded += Popwindow_Loaded;
        }

        void Popwindow_Loaded(object sender, RoutedEventArgs e)
        {

            Loaded -= Popwindow_Loaded;
            SetSize();
            Appear();
        }


        private void Appear()//出现
        {
            DoubleAnimation Ani = new DoubleAnimation()
            {
                From = 0,
                To = 1,
                Duration = new Duration(TimeSpan.FromSeconds(.5))
            };



            DoubleAnimation Rni = new DoubleAnimation()
            {
                From = 0,
                To = 720,
                Duration = new Duration(TimeSpan.FromSeconds(.5))

            };
            _scale.BeginAnimation(ScaleTransform.ScaleXProperty, Ani);
            _scale.BeginAnimation(ScaleTransform.ScaleYProperty, Ani);
            _rot.BeginAnimation(RotateTransform.AngleProperty, Rni);
        }
        #region <<属性
        public ImageSource PictureSource
        {
            get { return (ImageSource)GetValue(PictureSourceProperty); }
            set { SetValue(PictureSourceProperty, value); }
        }
        public static readonly DependencyProperty PictureSourceProperty =
            DependencyProperty.Register("PictureSource", typeof(ImageSource), typeof(Popwindow), new UIPropertyMetadata(null));



        public string Introduce;

        public double X
        {
            set { Canvas.SetLeft(this, value); }
            get { return Canvas.GetLeft(this); }
        }
        public double Y
        {
            set { Canvas.SetTop(this, value); }
            get { return Canvas.GetTop(this); }
        }
        #endregion
        private void SetSize()
        {

        }

    }
}
