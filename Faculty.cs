#pragma warning disable CS8604
class Faculty : Students
{
    public string faculty_name{get; set;} = string.Empty;
    public string faclt_abreviation{get; set;} = string.Empty;
    public string study_field{get; set;} = string.Empty;
    public override string ToString() => faculty_name;
    public List<Students> students = new List<Students>();
    public static int nr_of_facs;
    public Faculty(string fac_name_abrv)
    {
        faculty_name = fac_name_abrv;
    }
    public Faculty( string p_faculty_name, string p_faclt_abreviation, string p_study_field)
    {
        faculty_name = p_faculty_name;
        faclt_abreviation = p_faclt_abreviation;
        study_field = p_study_field;
    }
    // Functie add_student start
    public void add_student(StreamReader StudentFile,StreamWriter LoggingFile)
    {
        students.Add(CreateStudent(StudentFile,LoggingFile));
    }
    // Functie add_student finish


    // Functie graduate_student start
    public void graduate_student(StreamWriter logging_file)
    {
        Console.WriteLine("Write student's email:");
        string ?studentsEmail = Console.ReadLine();

        foreach (var student in students)
        {
            if (student.Email == studentsEmail)
            {
                student.StudyYear += 1;
                LoggingSystem.LogGraduation(logging_file,student.Email,student.StudyYear);
                return;
            }
        }

        LoggingSystem.LogErrorGraduation(logging_file, studentsEmail);
    }
    // Functie graduate_student finish


    // Functie display_all_enrolled_students start
    public void display_all_enrolled_students(List<Faculty> faculties)
    {
        if(students.Count == 0)
        {
            Console.WriteLine("There are no students.");
            return;
        }
        foreach(var AStudent in students)
        {
            if (AStudent.StudyYear < 4) // Similar to checking if the student is not graduated
            {
                Console.Write($"{AStudent.FirstName} {AStudent.LastName} is year {AStudent.StudyYear} ");
                Console.WriteLine($"Email: {AStudent.Email}, Date of birth: {AStudent.DateOfBirth}");
            }
        }
    }
    // Functie display_all_enrolled_students finish


    // Functie display_all_graduates start
    public void display_all_graduates()
    {
        foreach(var i in students)
        {
            if(i.StudyYear >= 4)
            {
                Console.WriteLine($"Student {i.FirstName} {i.LastName} has graduated");
            }
        }
    }
    // Functie display_all_graduates finish
    // Functie verify_students_adherence start
    public void verify_students_adherence()
    {
        Console.WriteLine("Enter student's email");
        string ?email = Console.ReadLine();

        foreach (var student in students)
        {
            if (student.Email == email)
            {
                Console.Write($"Student: {student.FirstName} {student.LastName} - year {student.StudyYear}");
                Console.WriteLine($" belongs to {faclt_abreviation}");
                return;
            }
        }
        Console.WriteLine("Such student doesn't exist here");
    }
    // Functie verify_students_adherence FINISH
}