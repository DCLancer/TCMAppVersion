using System;
namespace GetAppVersions.Models
{
    public class AppVersionInfo
    {
        public AppVersionInfo()
        {
        }

        public int Id{
            get;
            set;
        }

        /// <summary>
        /// 商店名称
        /// </summary>
        /// <value>The name of the store.</value>
        public string StoreName{
            get;
            set;
        }

        /// <summary>
        /// app的链接地址
        /// </summary>
        /// <value>The URL.</value>
        public string Url
        {
            get;
            set;
        }

        /// <summary>
        /// 版本号
        /// </summary>
        /// <value>The version.</value>
        public string Version{
            get;
            set;
        }

        /// <summary>
        /// 更新时间
        /// </summary>
        /// <value>The update date.</value>
        public string UpdateDate{
            get;
            set;
        }

        /// <summary>
        /// 用来匹配的字符串
        /// </summary>
        /// <value>The pattern.</value>
        public string Pattern{
            get;
            set;
        }

    }
}
