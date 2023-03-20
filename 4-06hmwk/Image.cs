using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_06hmwk
{
    public class Image
    {
        public int Id { get; set; }
        public string ImageSource { get; set; }
        public int Likes { get; set; }
        public string Title { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
