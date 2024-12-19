using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Category:BaseEntity
    {
        [Required]
        public string Titel { get; set; }
        [Required]
        public string slug { get; set; } 
        public string MetaTag { get; set; }
        public string MetaDescription { get; set; }

        #region Relations
        public ICollection<Post> Posts { get; set; }
        #endregion
    }
}
