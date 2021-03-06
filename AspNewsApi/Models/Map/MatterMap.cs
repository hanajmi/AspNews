﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNewsApi.Models.Map
{
    public class MatterMap
    {
        public string TopTitle { get; set; }
        public string Title { get; set; }
        public string Lead { get; set; }
        public string Body { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}