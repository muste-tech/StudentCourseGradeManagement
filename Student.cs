using System;
using System.Linq;
using System.Collections.Generic;
namespace Mustakim
{
    public class Student
    {
        public int StuentId{get;set;}
        public string Name{get;set;}
        public List<CourseGrade>Grades{get;set;}=new List<CourseGrade>();
        
    }
}