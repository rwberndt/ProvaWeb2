using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProvaWeb2_RicardoWehmuth.Models
{
    public class BaseEntity
    {
        public BaseEntity()
        {

        }
        public int Id { get; set; }
    }
}
