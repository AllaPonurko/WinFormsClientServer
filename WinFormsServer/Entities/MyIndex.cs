using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WinFormsServer.Entities
{
    public class MyIndex
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public int Index { get; set; }
        public MyIndex()
        {
            Index = Index;
            GetStreets = new List<Street>();
        }
        public List <Street> GetStreets { get; set; }
        public override string ToString()
        {
            return Index.ToString();
        }

    }
}
