﻿using System.Collections.Generic;

namespace DigitalArchitecture.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ArticleCategory> Articles { get; set; } = new HashSet<ArticleCategory>();
        public bool IsDeleted { get; set; }
    }
}
