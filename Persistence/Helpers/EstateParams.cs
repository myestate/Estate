using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Helpers
{
    public class EstateParams
    {
        private const int MaxPageSize = 30;
        public int PageNumber { get; set; } = 1;
        private int pageSize = 10;
        public int PageSize
        {
            get { return pageSize; }
            set
            {
                pageSize = (value > MaxPageSize) ? MaxPageSize : value;
            }
        }


        public string Type { get; set; }

        public double MinPrice { get; set; }

        public double MaxPrice { get; set; }

        public double MinSquare { get; set; }

        public double MaxSquare { get; set; }

        public int MinRooms { get; set; }

        public int MaxRooms { get; set; }

        public int MinFloors { get; set; }

        public int MaxFloors { get; set; }

        public string Country { get; set; }

        public string City { get; set; }
    }
}
