using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BelgiumCafeteria
{
    internal class Student
    {
        private int id;
        private String fullName;
        private bool isResStudent;
        private int yearsOnCampus;
        private int yearsAtRes;
        private decimal allowance;
        private double avgMark;

        public Student(int id, string fullName, bool isResStudent, int yearsOnCampus, int yearsAtRes, decimal allowance, double avgMark)
        {
            this.Id = id;
            this.FullName = fullName;
            this.IsResStudent = isResStudent;
            this.YearsOnCampus = yearsOnCampus;
            this.YearsAtRes = yearsAtRes;
            this.Allowance = allowance;
            this.AvgMark = avgMark;
        }

        public int Id { get => id; set => id = value; }
        public string FullName { get => fullName; set => fullName = value; }
        public bool IsResStudent { get => isResStudent; set => isResStudent = value; }
        public int YearsOnCampus { get => yearsOnCampus; set => yearsOnCampus = value; }
        public int YearsAtRes { get => yearsAtRes; set => yearsAtRes = value; }
        public decimal Allowance { get => allowance; set => allowance = value; }
        public double AvgMark { get => avgMark; set => avgMark = value; }

        

        public override string ToString()
        {
            return $"ID: {Id}\n, Name: {FullName}\n, Residence: {IsResStudent}\n, Years on Campus: {YearsOnCampus}\n, Years at Residence: {YearsAtRes}\n, Allowance: {Allowance:C}\n, Average: {AvgMark}%\n";
        }
    }
}
