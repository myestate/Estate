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


        public string Type { get; set; } = "All";

        public string Country { get; set; } = "All";

        public string City { get; set; } = "All";

        public string Street { get; set; } = "All";

        public int OwnerId { get; set; } = -1;

        public double MinPrice { get; set; } = 0;

        public double MaxPrice { get; set; } = 5000000;

        public double MinSquare { get; set; } = 0;

        public double MaxSquare { get; set; } = 1000;

        public int MinRooms { get; set; } = 1;

        public int MaxRooms { get; set; } = 10;

        public int MinFloors { get; set; } = 1;

        public int MaxFloors { get; set; } = 50;

    }
}
