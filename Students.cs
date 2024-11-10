class Students
{
    public string ?FirstName { get; set; }
    public string ?LastName { get; set; }
    public string ?Email { get; set; }
    public string ?EnrollmentDate { get; set; }
    public string ?DateOfBirth { get; set; }
    public int StudyYear { get; set; }
    // public string GetName() => FirstName;
    public Students(string a,string b,string c, string d,string e,int f)
    {
        FirstName = a;
        LastName = b;
        Email = c;
        EnrollmentDate = d;
        DateOfBirth = e;
        StudyYear = f;
    }
    public Students()
    {

    }

    // Functie CreateStudent start
    public Students CreateStudent(StreamReader StudentsFile,StreamWriter LoggingFile)
    {
        Students NewStudent = new Students();
        string ?line = StudentsFile.ReadLine(); // ? = poate avea si valoarea null

        if (line != null)
        {
            // Separarea elementelor pe baza separatorului (virgulă, în acest caz)
            string[] parts = line.Split(',');
            
            NewStudent.FirstName = parts[0];
            NewStudent.LastName = parts[1];
            NewStudent.Email = parts[2];
            NewStudent.EnrollmentDate = parts[3];
            NewStudent.DateOfBirth = parts[4];
        }
        
        // LoggingFile.WriteLine($"Student '{NewStudent.FirstName} {NewStudent.LastName}' added");
        // LoggingFile.WriteLine();
        // LoggingSystem.has_changes = true;
        LoggingSystem.LogStudent(LoggingFile,NewStudent);
        NewStudent.StudyYear  = 1;
        return NewStudent;
    }
    // Functie CreateStudent finish

}