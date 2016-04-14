
using System.ComponentModel.DataAnnotations;

namespace UsedCar.ViewModels
{
    public class BaseModel<T>
    {
        [Key]
        public T ID { get; set; }

    }
}
