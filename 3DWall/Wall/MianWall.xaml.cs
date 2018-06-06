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
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using _3DWall.Utils;

namespace _3DWall.Wall
{
    /// <summary>
    /// Interaction logic for MianWall.xaml
    /// </summary>
    public partial class MianWall : UserControl
    {
        public MianWall()
        {
            InitializeComponent();
            Loaded += MianWall_Loaded;
            SetSize();
        }

        void MianWall_Loaded(object sender, RoutedEventArgs e)
        { 
            Loaded -= MianWall_Loaded;
            CreatWall();
            AddMouseEvent();
            LoadMedia();
        }

        void CompositionTarget_Rendering(object sender, EventArgs e)//
        {
            if (_offsetX > 2)
                MoveCamera(.75);
            else if (_offsetX < -2)
                MoveCamera(-.75);
        }

        #region 鼠标操作
        private Point Start;
        private Point _prePoint; //鼠标点
        private double _offsetX = 5d; //位移量

        void AddMouseEvent()
        {
            _3dgrid.MouseLeftButtonDown += MianWall_MouseLeftButtonDown;
          
          
 
        }
        /// <summary>
        /// 点中
        /// </summary>
        /// <typeparam name="T">类型</typeparam>                                                          
        /// <param name="point">触激点</param>
        /// <returns></returns>
        public T HitObject<T>(Point point) where T : DependencyObject
        {
            PointHitTestParameters pointparams = new PointHitTestParameters(point);
            HitTestResult hRresult = VisualTreeHelper.HitTest(this, point);
            if (null != hRresult)
            {
                if (hRresult.VisualHit.GetType() == typeof(T))
                {
                    return hRresult.VisualHit as T;
                }

            } return null;
        }
        void WHD_MouseMove(object sender, MouseEventArgs e)
        {
            Point p = e.GetPosition(this);
            _offsetX = _prePoint.X - p.X;
            MoveCamera(_offsetX);
            _prePoint = p;
            
        }
        Block3d _block3d;
        void WHD_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)//鼠标立起来
        {
            //ExtendUtils.WHD.MouseLeftButtonUp -= WHD_MouseLeftButtonUp;
            //ExtendUtils.WHD.MouseMove -= WHD_MouseMove;

            this.MouseLeftButtonUp -= WHD_MouseLeftButtonUp;
            this.MouseMove -= WHD_MouseMove;

           _3dgrid.MouseLeftButtonDown += MianWall_MouseLeftButtonDown;
            for (int  i = -3;  i < 4;  i++)
            {
                if (e.GetPosition(this).X == Start.X)
                {
                    _block3d = HitObject<Block3d>(e.GetPosition(this));
                    if (_block3d != null)
                    {
                        if (ItemClick != null)
                        {
                            ItemClick(this, new ItemclickEventArg() { MEDIA=_block3d.InFo});
                        }
                    }
                    break;
                }
            }
            CompositionTarget.Rendering -= CompositionTarget_Rendering;
            CompositionTarget.Rendering += CompositionTarget_Rendering;
 
        }

   
        

        void MianWall_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)//鼠标按下
        {

            _offsetX = 0d;
            _3dgrid.MouseLeftButtonDown -= MianWall_MouseLeftButtonDown;
            //ExtendUtils.WHD.MouseMove += WHD_MouseMove;
            //ExtendUtils.WHD.MouseLeftButtonUp += WHD_MouseLeftButtonUp;

            this.MouseMove += WHD_MouseMove;
            this.MouseLeftButtonUp += WHD_MouseLeftButtonUp;

            Start = e.GetPosition(this);
            _prePoint = e.GetPosition(this);
           
        }

        #endregion

        /// <summary>
        /// 设置尺寸
        /// </summary>
        private void SetSize()
        {
            //this.Width = ExtendUtils.SCREEN_WIDTH;
            //this.Height = ExtendUtils.SCREEN_HEIGHT;
            _camera.FieldOfView =36d ;
          
        }

        /// <summary>
        /// 移动镜头
        /// </summary>
        /// <param name="deltaX">偏移量</param>
        private void MoveCamera(double deltaX)
        {
            _camRotation.Angle += deltaX * .0588;
        }

        List<Block3d> _BlockList = new List<Block3d>();
        private static int MESH_COUNT = 87;  //块个数
        private  void CreatWall()//创建墙体
        {
            double radianIncrement = -.217; // mesh 位置分配增量（度）
            double startDegrees = -270;  //环形起始度数
            double startRadians = DegreesToRadians(startDegrees); //度数转换为弧度
            double radians = startRadians;  // 弧度
            double radius = 20; //半径
            double height = 15;  //最底层块高度
            Block3d block3d ;
            LocationInfo loacation;
            for (int  i = 0;  i < MESH_COUNT;  i++)//
            {
                Point3D p = CalculateRingPoint(radians, radius, height);
                double degrees = -1 * (RadiansToDegrees(radians) - startDegrees);
                loacation = new LocationInfo(p, degrees, i);
                block3d = new Block3d(loacation);
                _BlockList.Add(block3d);
                _viewport3d.Children.Add(block3d);
                radians += radianIncrement;
                if ((i + 1) % 29 == 0)
                {  
                    radians = startRadians;
                    height += 3.5;
                   
                }
            }

 
        }

        private void LoadMedia()//载入数据
        {
             XmlParse _xmlparse = new XmlParse(ExtendUtils.XML_PATH + "text1.xml");
            for (int i = 0; i < _BlockList.Count; i++)
            {

                _BlockList[i].InFo = _xmlparse.Mlist[i % _xmlparse.Mlist.Count];
               
                
            }
 
        }
        #region<<弧形墙算法

        //弧度转换为度
        private double RadiansToDegrees(double radians)
        {
            return radians * 57.2957795;
        }

        //度转换为弧度
        private double DegreesToRadians(double degrees)
        {
            return degrees / 57.2957795;
        }

        private Point3D CalculateRingPoint(double radians, double radius, double height)//计算小块位置
        {
            double x = Math.Cos(radians) * radius;
            double y = Math.Sin(radians) * radius;
            return new Point3D(x, height, y); 
        }
       
        
        #endregion


        #region<<事件

        public class ItemclickEventArg:EventArgs
        {
            public MediaInfo MEDIA;
        }

        public delegate void ItemClickeventHandler(object sender, ItemclickEventArg e);

        public event ItemClickeventHandler ItemClick;
        #endregion
    }
}
