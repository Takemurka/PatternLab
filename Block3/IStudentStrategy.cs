using System;
using System.Collections.Generic;

public interface IStudentStrategy
{
    Student SelectStudent(List<Student> students);
}