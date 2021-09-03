using System;
using System.ComponentModel.DataAnnotations;

namespace Business.Models
{
    public abstract class Entity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
