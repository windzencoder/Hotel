﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    /// <summary>
    /// 新闻实体类
    /// </summary>
    public class News
    {
        public int NewsId { get; set; }
        public string NewsTitle { get; set; }
        public string NewsContents { get; set; }
        public DateTime PublishTime { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
