using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S01.EFCoreDbFristMySql.Models
{
    public partial class Menu
    {
        [NotMapped]
        public MenuStatusEnum StatusEnum
        {
            get => (MenuStatusEnum)Status;
            set => Status = (int)value;
        }
    }
}
