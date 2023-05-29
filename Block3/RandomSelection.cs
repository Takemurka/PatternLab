

public class RandomSelection : IStudentStrategy
{
    private Random random;

    public RandomSelection()
    {
        random = new Random();
    }

    public Student SelectStudent(List<Student> students)
    {
        int index = random.Next(students.Count);
        return students[index];
    }
}