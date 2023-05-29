

public class NotAnsweredSelection : IStudentStrategy
{
    public Student SelectStudent(List<Student> students)
    {
        var notAnsweredStudents = students.Where(student => !student.HasAnswered).ToList();

        if (notAnsweredStudents.Count > 0)
        {
            int index = new Random().Next(notAnsweredStudents.Count);
            return notAnsweredStudents[index];
        }

        return null; // Return null if no student has not answered
    }
}