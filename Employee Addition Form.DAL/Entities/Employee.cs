using System;

namespace Employee_Addition_Form.DAL.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string JobRole { get; set; }
        public string Gender { get; set; }
        public bool IsFirstAppointment { get; set; }
        public DateTime StartDate { get; set; }
        public string Notes { get; set; }
    }
}
