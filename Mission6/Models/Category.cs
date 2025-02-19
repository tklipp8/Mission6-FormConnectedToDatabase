using System.ComponentModel.DataAnnotations;

namespace Mission6.Models
{
    //This is the category class that we use to get the category to come in
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}