using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _3DWall.Utils
{
    public class ExtendUtils // 扩展类
    {
        #region << 主窗体句柄
        //public static Window WHD = Application.Current.MainWindow;
        //public static WallUserControl WHD = Application.Current.MainWindow;
        //public static Window WHD = WindowsFormsApplication1;
        #endregion 

        #region << 主屏幕宽
        //public static double SCREEN_WIDTH = SystemParameters.PrimaryScreenWidth;
        //public static double SCREEN_WIDTH = SystemParameters.PrimaryScreenWidth;
        #endregion

        #region << 主屏幕高
        //public static double SCREEN_HEIGHT = SystemParameters.PrimaryScreenHeight;
        //public static double SCREEN_HEIGHT = SystemParameters.PrimaryScreenHeight;
        #endregion

        #region << 执行程序根目录
        public static string EXECUTE_PATH = Directory.GetCurrentDirectory() + @"\";
        #endregion

        #region<<Xml文件夹
        public static String XML_PATH = EXECUTE_PATH + @"Xml\"; 
        #endregion

        #region<<资源文件夹
        public static string DATA_PATH = EXECUTE_PATH + @"VisitImage\";
        #endregion

        #region<<背景图片
        public static string BACKGROUND_IMG = DATA_PATH + "bg.jpg";        
        #endregion

    }
}
