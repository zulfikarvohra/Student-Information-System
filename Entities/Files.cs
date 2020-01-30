using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInformationSystem.Entities
{
    public class Files : BaseEntity
    {
       
        public System.Int64 Id { get; set; }

        public string FileName { get; set; }
        public string FileSize { get; set; }

        [ForeignKey("StudentId")]
        public long StudentId { get; set; }
        
        public StudentMaster Student { get; set; }
    }
}
