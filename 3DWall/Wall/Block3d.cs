using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Shapes;
using _3DTools;
using _3DWall.Utils;

namespace _3DWall.Wall
{
    class Block3d : InteractiveVisual3D
    {
        #region<<构造函数
        public Block3d()
        {


        }
        public Block3d(LocationInfo _loc)//
        {
            _location = _loc;
            init();

        }
        #endregion

        #region<<属性
        /// <summary>
        /// 位置
        /// </summary>
        private LocationInfo _location;
        public LocationInfo Location
        {
            get { return _location; }
            set { _location = value; }
        }


        private MediaInfo _info;
        public MediaInfo InFo
        {
            set
            {
                _info = value;
                MediaItem item=Visual as MediaItem;
                item.IMA.Source=new BitmapImage(new Uri(ExtendUtils.DATA_PATH+_info.Thumb));
            }
            get { return _info; }
        }


        #endregion


        #region<<初始化
        public void init()
        {
            this.Visual = CreateVisual();
            this.Geometry = CreateGeometry3D();
            this.Transform = InitTransform3DGroup();


        }


        #endregion

        #region 私有方法
        /// <summary>
        /// 建立3d模型
        /// </summary>
        /// <returns></returns>
        private MeshGeometry3D CreateGeometry3D()
        {
            MeshGeometry3D geometry = new MeshGeometry3D();
            double x = 2;
            double y = 1.5;

            geometry.Positions = new Point3DCollection();
            geometry.Positions.Add(new Point3D(-x, y, 0));
            geometry.Positions.Add(new Point3D(x, y, 0));
            geometry.Positions.Add(new Point3D(x, -y, 0));
            geometry.Positions.Add(new Point3D(-x, -y, 0));

            geometry.TriangleIndices = new Int32Collection();
            // 内侧
            //geometry.TriangleIndices.Add(0);
            //geometry.TriangleIndices.Add(1);
            //geometry.TriangleIndices.Add(2);
            //geometry.TriangleIndices.Add(0);
            //geometry.TriangleIndices.Add(2);
            //geometry.TriangleIndices.Add(3);

            ////外侧
            geometry.TriangleIndices.Add(0);
            geometry.TriangleIndices.Add(3);
            geometry.TriangleIndices.Add(2);
            geometry.TriangleIndices.Add(0);
            geometry.TriangleIndices.Add(2);
            geometry.TriangleIndices.Add(1);

            geometry.TextureCoordinates = new PointCollection();
            geometry.TextureCoordinates.Add(new Point(1, 0));
            geometry.TextureCoordinates.Add(new Point(0, 0));
            geometry.TextureCoordinates.Add(new Point(0, 1));
            geometry.TextureCoordinates.Add(new Point(1, 1));

            return geometry;

        }

        /// <summary>
        /// 建立Visual
        /// </summary>
        /// <returns></returns>
        private Visual CreateVisual()
        {
            MediaItem _mediaitem = new MediaItem();
            return _mediaitem;
          

        }


        //初始化位置
        private Transform3DGroup InitTransform3DGroup()
        {
            Transform3DGroup group = new Transform3DGroup();
            group.Children.Add(new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 1, 0), _location.Degree)));
            group.Children.Add(new TranslateTransform3D(_location.Point.X, _location.Point.Y, _location.Point.Z));
            group.Children.Add(new ScaleTransform3D());

            return group;
        }
        #endregion
    }

    /// <summary>
    /// 位置类
    ///用于设置小块的位置
    /// </summary>
    public class LocationInfo
    {
        public Point3D Point;
        public double Degree;
        public int Index;
        public LocationInfo(Point3D p, double degree, int index)
        {
            Point = p;
            Degree = degree;
            Index = index;
        }
    }
    /// <summary>
    /// 媒体文件类
    /// 用于定义新的媒体
    /// </summary>
    public class MediaInfo
    {
        /// <summary>
        /// 序号
        /// </summary>
        public string ID { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 资源地址
        /// </summary>
        public string Source { get; set; }
        /// <summary>
        /// 缩略图地址
        /// </summary>
        public string Thumb { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string Desc { get; set; }
    }
}
