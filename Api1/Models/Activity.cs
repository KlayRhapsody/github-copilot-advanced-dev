using System;
using System.Collections.Generic;

namespace Api1.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ExhibitionDate { get; set; }
        public DateTime SaleStartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Description { get; set; }
        public List<Session> Sessions { get; set; }
    }
}
