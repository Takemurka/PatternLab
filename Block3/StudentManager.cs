

public class StudentManager
{
    private List<Student> students;
    private IStudentStrategy selectionStrategy;

    public StudentManager(List<Student> students, IStudentStrategy selectionStrategy)
    {
        this.students = students;
        this.selectionStrategy = selectionStrategy;
    }

    public Student SelectStudent()
    {
        return selectionStrategy.SelectStudent(students);
    }
}