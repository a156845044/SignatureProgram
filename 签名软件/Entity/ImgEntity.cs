using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 签名软件.Entity
{
    public class ImgEntity
    {
        /// <summary>
        /// 文件创建时间
        /// </summary>
        public DateTime CreationTime
        {
            get;
            set;
        }

        /// <summary>
        /// 文件名称
        /// </summary>
        public string Name
        {
            get;
            set;
        }
    }
}
