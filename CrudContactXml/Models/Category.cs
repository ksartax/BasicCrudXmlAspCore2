using System.ComponentModel.DataAnnotations;

namespace CrudContactXml.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Pole Wymagane")]
        public string Titlle { get; set; }
        [Required(ErrorMessage = "Pole Wymagane")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Pole Wymagane")]
        public bool Checked { get; set; }
        [Required(ErrorMessage = "Pole Wymagane")]
        public Group Group { get; set; }

        public void Update(Category category)
        {
            Titlle = category.Titlle;
            Description = category.Description;
            Checked = category.Checked;
            Group = category.Group;
        }
    }
}