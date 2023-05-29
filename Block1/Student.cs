public class Student
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public bool HasAnswered { get; set; }

    public Student(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
    public Student(string firstName, string lastName, bool hasAnswered)
    {
        FirstName = firstName;
        LastName = lastName;
        HasAnswered = hasAnswered;
    }
}