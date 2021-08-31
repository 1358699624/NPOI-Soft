using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace YY_Model
{
   public  class PageClass
    {
        /// <summary>
        /// 分页第几页
        /// </summary>
        [Description("分页第几页")]
        public int page { get; set; }

        /// <summary>
        /// 每页count
        /// </summary>
        [Description("每页count")]
        public int limit { get; set; }

        /// <summary>
        /// strname
        /// </summary>
        [Description("strname")]
        public string strname { get; set; }

        public  List<UserInfo> userInfos { get; set; }



    }
}
