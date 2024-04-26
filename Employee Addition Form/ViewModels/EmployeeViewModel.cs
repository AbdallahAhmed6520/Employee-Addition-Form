using System;
using System.ComponentModel.DataAnnotations;

namespace Employee_Addition_Form.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name Is Required")]
        [MaxLength(50, ErrorMessage = "Max Length Is 50")]
        [MinLength(5, ErrorMessage = "Min Length Is 5")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please select a job role.")]
        public string JobRole { get; set; }

        [Required(ErrorMessage = "Please select gender.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Please indicate if this is the first appointment.")]
        public bool IsFirstAppointment { get; set; }

        [Required(ErrorMessage = "Please select a start date.")]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters.")]
        public string Notes { get; set; }
    }
}
