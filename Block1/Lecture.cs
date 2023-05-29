
class Lecture
{
    public string ?Title { get; set; }
    public string ?Lector { get; set; }
    public List<Student> Students { get; set; }
    public List<Reference> LiteratureReferences { get; set; }

    public Lecture(LectureBuilder builder)
    {
        Title = builder.Title;
        Lector = builder.Lector;
        Students = builder.Students;
        LiteratureReferences = builder.LiteratureReferences;
    }
}






