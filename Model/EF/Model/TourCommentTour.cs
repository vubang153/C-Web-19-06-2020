using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.EF.Model
{
    public class TourCommentTour
    {
        public long id { get; set; }

        public long tour_id { get; set; }
        public string tour_name { set; get; }
        public int status { get; set; }
        public string comment_content { get; set; }

    }
}
