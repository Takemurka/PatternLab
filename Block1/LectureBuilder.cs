class LectureBuilder
{
    public string? Title { get; set; }
    public string? Lector { get; set; }
    public List<Student> Students { get; set; }
    public List<Reference> LiteratureReferences { get; set; }

    public LectureBuilder()
    {
        Students = new List<Student>();
        LiteratureReferences = new List<Reference>();
    }

    public LectureBuilder SetTitle(string title)
    {
        Title = title;
        return this;
    }

    public LectureBuilder SetLector(string lector)
    {
        Lector = lector;
        return this;
    }

    public LectureBuilder AddStudent(string firstName, string lastName)
    {
        Students.Add(new Student (firstName,lastName));
        return this;
    }

    public LectureBuilder AddLiteratureReference(string location, int page)
    {
        LiteratureReferences.Add(new Reference { Location = location, Page = page });
        return this;
    }

    public Lecture Build()
    {
        return new Lecture(this);
    }
}