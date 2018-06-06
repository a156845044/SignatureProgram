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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _3DWall.Wall
{
    /// <summary>
    /// Interaction logic for MediaItem.xaml
    /// </summary>
    public partial class MediaItem : UserControl
    {
        public MediaItem()
        {
            InitializeComponent();
            Loaded += MediaItem_Loaded;
        }

        void MediaItem_Loaded(object sender, RoutedEventArgs e)//设置部分
        {
            Loaded -= MediaItem_Loaded;
            if (media != null)
            {
                _ima.Source = new BitmapImage(new Uri(media.Source, UriKind.Absolute));
            }

        }
        public MediaInfo media;
        public Image IMA 
        {
            get { return _ima; }
        }
    }
}
