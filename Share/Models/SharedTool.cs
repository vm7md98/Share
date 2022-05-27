using System.ComponentModel.DataAnnotations;

namespace Share.Models
{
    public class SharedTool
    {
        [Required(ErrorMessage = "الاسم يجب ان يكون موجودا")]
        public String Name { get; set; }

        public String Description { get; set; }

        [Required(ErrorMessage = "لابد من ادخال قيمة")]
        public int? Quantity { get; set; }

        public SharedTool()
        {

        }

        public SharedTool(String Name, String Description, int? Quantity)
        {
            this.Name = Name;
            this.Description = Description;
            this.Quantity = Quantity;
        }
    }
}
