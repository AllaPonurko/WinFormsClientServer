using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WinFormsServer.Entities
{
    public  class Street
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid MyIndexId { get; set; }
        public Street()
        {
            Name = Name;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
