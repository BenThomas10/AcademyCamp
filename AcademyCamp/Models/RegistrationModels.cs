using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyCamp.Models
{
    public class Registrant
    {
        
        [Key]
        [Display(Name = "Registrant Id")]
        public int Id { get; set; }
        [Required]
        public virtual string Event { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public virtual string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public virtual string LastName { get; set; }
        [Required]
        [EmailAddress]
        public virtual string Email { get; set; }
        [Required]
        [Range(5,110)]
        public virtual int Age { get; set; }
        [Required]
        public virtual string Gender { get; set; }
        [Display(Name = "T-Size")]
        public virtual string Tsize { get; set; }
        public virtual string Workshop { get; set; }
        [Display(Name = "Submission Date")]
        public virtual string SubmitDate { get; set; }
        [Display(Name = "Submitter Id")]
        public virtual string SubmitterId { get; set; }
       

    }

    public class Unit
    {
        [Key]
        public virtual int UnitId { get; set; }
        [Required]
        [Display(Name = "Unit Name")]
        public virtual string UnitName { get; set; }
    }

    public class Workshop
    {   
        [Key]
        public virtual int WorkshopId { get; set; }
        [ForeignKey("Event")]
        [Display(Name = "Event Name")]
        public virtual int EventId { get; set; }
        [Required]
        [Display(Name = "Workshop Name")]
        public virtual string WorkshopName { get; set; }
        public virtual Event Event { get; set; }
    }

    public class Event
    {
        [Key]
        [Required]
        public virtual int EventId { get; set; }
        [Required]
        [Display(Name = "Event Name")]
        public virtual string Name { get; set; }
        public virtual string Address { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Start Date")]
        public virtual string StartDate { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "End Date")]
        public virtual string EndDate { get; set; }
        public List<Workshop> Workshops { get; set; }
    }
}

