#pragma warning disable CS8600
class FileManager
{
    public static void save_all_changes(List<Faculty> faculties)
    {
        string facultiesFilePath = @"c:\Users\boss\OneDrive\Desktop\WriteFacC#.txt";
        string studentsFilePath = @"c:\Users\boss\OneDrive\Desktop\stud_wit_abrv_c#.txt";

        try
        {
            using (StreamWriter facultiesFile = new StreamWriter(facultiesFilePath))
            using (StreamWriter studentsFile = new StreamWriter(studentsFilePath))
            {
                foreach (var faculty in faculties)
                {
                    facultiesFile.WriteLine($"{faculty.faculty_name},{faculty.faclt_abreviation},{faculty.study_field}");

                    foreach (var student in faculty.students)
                    {
                        studentsFile.WriteLine($"{student.FirstName},{student.LastName},{student.Email}," +
                                            $"{student.EnrollmentDate},{student.DateOfBirth},{student.StudyYear}," +
                                            $"{faculty.faclt_abreviation}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Eroare la scrierea fișierelor: " + ex.Message);
        }
    }
    

    public static void load_all_previous_changes(List<Faculty> faculties,
    Dictionary<string,int> all_faculty_abreviations,Dictionary<string, List<Faculty>> facultiesByField)
    {
        // StreamReader FacultiesFile;
        // StreamReader StudentsFile;
        using(StreamReader FacultiesFile = new StreamReader(@"C:\Users\boss\OneDrive\Desktop\WriteFacC#.txt") )
        {
            int i = 0;
            string line1;
            while((line1 = FacultiesFile.ReadLine()) != null)
            {
                string[] parts = line1.Split(',');
                if(parts.Length >= 3)
                {
                    string FacName = parts[0];
                    string FacAbrv = parts[1];
                    string FacField = parts[2];

                    all_faculty_abreviations[FacAbrv] = i;
                    faculties.Add(new Faculty(FacName,FacAbrv,FacField));
                    i++;
                    facultiesByField[FacField] = new List<Faculty>();
                    facultiesByField[FacField].Add(new Faculty(FacAbrv));
                }
            }
        }
            using(StreamReader StudentsFile = new StreamReader(@"C:\Users\boss\OneDrive\Desktop\stud_wit_abrv_c#.txt"))
            {
                string line1;
                while((line1 = StudentsFile.ReadLine()) != null)
                {
                    string[] parts = line1.Split(',');
                    if(parts.Length >= 7)
                    {
                        string FirstName = parts[0];
                        string LastName = parts[1];
                        string Email = parts[2];
                        string enrollmentDate  = parts[3];
                        string dateOfBirth  = parts[4];
                        int studyYear  = int.Parse(parts[5]);
                        string facultyAbbrv  = parts[6];

                        if(all_faculty_abreviations.ContainsKey(facultyAbbrv))
                        {
                            int fac_index = all_faculty_abreviations[facultyAbbrv];
                            faculties[fac_index].students.Add(new Students(FirstName,LastName,Email,
                            enrollmentDate,dateOfBirth,studyYear));
                        }
                    }
                }
            }
    }

}