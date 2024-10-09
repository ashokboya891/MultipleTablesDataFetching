using System.ComponentModel.DataAnnotations;

namespace MultipleTablesData
{
    public class Location
    {
        [Key]
        public int LocationId { set; get; }
        public string LocationName { set; get; }
    }
}
