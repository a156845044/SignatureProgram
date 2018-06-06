using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using _3DWall.Wall;
using System.IO;

namespace _3DWall.Utils
{
   public  class XmlParse
    {
       public XmlParse(string _xmlpath)
       {
           XmlPath = _xmlpath;
           Readxml();
 
       }
       private string XmlPath;
       private List<MediaInfo> _mlist;
       public List<MediaInfo> Mlist
       {
           set { _mlist = value; }
           get { return _mlist; }
       }
       private void Readxml()//解析xml
       {
           MediaInfo media;
           _mlist = new List<MediaInfo>();
           var files = Directory.GetFiles(ExtendUtils.DATA_PATH , "*.jpg");
           foreach (var file in files)
           {
               if (file.Substring(file.LastIndexOf(@"\") + 1, file.Length - file.LastIndexOf(@"\") - 1) != "bg.jpg")
               {
                   media = new MediaInfo();
                   media.ID = "1";

                   media.Title = "2";

                   media.Source = "3";

                   media.Thumb = file.Substring(file.LastIndexOf(@"\") + 1, file.Length - file.LastIndexOf(@"\") - 1);

                   media.Desc = "4";
                   _mlist.Add(media);
                   //dr相关文件.Rows.Add();
                   //dr相关文件.Rows[dr相关文件.Rows.Count - 1][0] = file.Substring(file.LastIndexOf(@"\") + 1, file.Length - file.LastIndexOf(@"\") - 1);
                   //dr相关文件.Rows[dr相关文件.Rows.Count - 1][1] = Application.StartupPath + @"\pdf";
               }
           }
           #region ReadXML
           //if (XmlPath != null)
           //{
           //    XmlReader _xr = XmlReader.Create(XmlPath);
           //    MediaInfo media;
           //    _mlist = new List<MediaInfo>();
           //    while (_xr.Read())
           //    {
           //        switch (_xr.NodeType)
           //        {
           //            case XmlNodeType.Element:
           //                if (_xr.Name == "Item")
           //                {
           //                    media = new MediaInfo();

           //                    for (int i = 0; i < _xr.AttributeCount; i++)
           //                    {
           //                        _xr.MoveToAttribute(i);

           //                        switch (_xr.Name)
           //                        {
           //                            case "ID":
           //                                media.ID = _xr.Value;
           //                                break;
           //                            case "Title":
           //                                media.Title = _xr.Value;
           //                                break;
           //                            case "Source":
           //                                media.Source = _xr.Value;
           //                                break;
           //                            case "Thumb":
           //                                media.Thumb = _xr.Value;
           //                                break;
           //                            case "Desc":
           //                                media.Desc = _xr.Value;
           //                                break;
           //                        }

           //                    }
           //                    _mlist.Add(media);
           //                }
           //                break;
                          
           //        }
           //    }
           //    _xr.Close();
           //}

           #endregion


       }

       

    }
}
