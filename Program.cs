global using System;
global using System.Globalization;
global using System.Runtime.ConstrainedExecution;
global using System.IO;
namespace UniSystem
{
    class Program
    {
        static void Main()
        {
            #region Starting logic code
            List<Faculty> faculties = new List<Faculty>(5);
            Dictionary<string, List<Faculty>> facultiesByField = new Dictionary<string, List<Faculty>>(5);
            Dictionary<string,int> all_faculty_abreviations = new Dictionary<string, int>
            {
                {"IMIT",0},{"CIM",1},{"TA",2},{"UA",3},{"MV",4}
            };

            // StreamReader StudentsFile = new StreamReader("C:\\Users\\chicu\\OneDrive\\Desktop\\students.txt");
            // StreamWriter LoggingFile = new StreamWriter("C:\\Users\\chicu\\OneDrive\\Desktop\\LogCsharp.txt")
            string ?field_choice = string.Empty;
            int iterations = 1;
            int choice2 = 1;
            using(StreamReader StudentsFile = new StreamReader("C:\\Users\\boss\\OneDrive\\Desktop\\students.txt"))
            using(StreamWriter LoggingFile = new StreamWriter("C:\\Users\\boss\\OneDrive\\Desktop\\LogCsharp.txt"))
            #endregion
            {
                while(choice2 != 0)
                {
                    LoggingFile.WriteLine($"State {iterations}");
                    LoggingFile.Flush();
                    int faculty_choice;
                    UtilFuncs.show_menu();
                    int.TryParse(Console.ReadLine(), out choice2);
                    // Console.ReadLine();
                    LoggingSystem.has_changes = false;
                    switch(choice2)
                    {
                        case 1:
                            if(faculties.Count == 0)
                            {
                                faculties.Add(new Faculty("Inginerie meacanica  industriala si transporturi","IMIT","MECHANICAL_ENGINEER"));
                                faculties.Add(new Faculty("Calculatoare informatica si microelectronica","CIM","SOFTWARE_ENGINEERING"));
                                faculties.Add(new Faculty("Inginerie si management in industria alimentara","TA","FOOD_TECHNOLOGY"));
                                faculties.Add(new Faculty("Planificare urbana si regionala","UA","URBANISM_ARCHITECTURE"));
                                faculties.Add(new Faculty("Medicina veterinara",  "MV","VETERINARY_MEDICINE"));
                                facultiesByField["MECHANICAL_ENGINEER"] = new List<Faculty>();
                                facultiesByField["MECHANICAL_ENGINEER"].Add(new Faculty("IMIT"));
                                facultiesByField["SOFTWARE_ENGINEERING"] = new List<Faculty>();
                                facultiesByField["SOFTWARE_ENGINEERING"].Add(new Faculty("CIM"));
                                facultiesByField["FOOD_TECHNOLOGY"] = new List<Faculty>();
                                facultiesByField["FOOD_TECHNOLOGY"] .Add(new Faculty("TA"));
                                facultiesByField["URBANISM_ARCHITECTURE"] = new List<Faculty>();
                                facultiesByField["URBANISM_ARCHITECTURE"] .Add(new Faculty("UA"));
                                facultiesByField["VETERINARY_MEDICINE"] = new List<Faculty>();
                                facultiesByField["VETERINARY_MEDICINE"].Add(new Faculty("MV"));
                                Faculty.nr_of_facs = 5;
                            }
                            faculty_choice = UtilFuncs.get_faculty_choice(faculties);
                            if(faculty_choice == -1)
                                break;
                            faculties[faculty_choice].add_student(StudentsFile,LoggingFile);
                        break;

                        case 2:
                            faculty_choice = UtilFuncs.get_faculty_choice(faculties);
                            if(faculty_choice == -1)
                                break;          
                            faculties[faculty_choice].graduate_student(LoggingFile);
                        break;

                        case 3:
                            faculty_choice = UtilFuncs.get_faculty_choice(faculties);
                            if(faculty_choice == -1)
                                break;
                            faculties[faculty_choice].display_all_enrolled_students(faculties);
                        break;

                        case 4:
                            faculty_choice = UtilFuncs.get_faculty_choice(faculties);
                            if(faculty_choice == -1)
                                break;
                            faculties[faculty_choice].display_all_graduates();
                        break;

                        case 5:
                            faculty_choice = UtilFuncs.get_faculty_choice(faculties);
                            if(faculty_choice == -1)
                                break;
                            faculties[faculty_choice].verify_students_adherence();
                        break;

                        case 6:
                            UtilFuncs.search_student_by_email(faculties,LoggingFile);
                        break;
                        
                        case 7:
                            UtilFuncs.add_faculty(faculties,LoggingFile,facultiesByField,all_faculty_abreviations);
                        break;

                        case 8:
                            UtilFuncs.display_all_faculties(faculties);
                        break;

                        case 9:
                            UtilFuncs.show_all_faculties_belonging_to_a_field(ref facultiesByField);
                        break;

                        case 10:
                            FileManager.load_all_previous_changes(faculties,all_faculty_abreviations,facultiesByField);
                        break;
                        case 0:
                            FileManager.save_all_changes(faculties);
                            StudentsFile.Close();
                            Environment.Exit(0);
                        break;

                        default:
                            Console.WriteLine("Wrong number");
                        break;
                    }   
                    iterations++;
                    if(LoggingSystem.has_changes == false)
                    {
                        LoggingFile.WriteLine("No operation performed");
                        LoggingFile.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine();
                    }
                }
            // StudentsFile.Close();
            // LoggingFile.Close();
            }
           
        }
    }
}


// using System;
// using System.Globalization;
// using System.Runtime.ConstrainedExecution;
// using System.IO;
// // using System.Runtime.Intrinsics.Arm;
// #pragma warning disable CS0219
// #pragma warning disable CS8604
// #pragma warning disable CS8600
// // #pragma warning disable CS8603
// namespace UniSystem
// {
//     class Program
//     {
//         class Faculty : Students
//         {
//             public string faculty_name{get; set;} = string.Empty;
//             public string faclt_abreviation{get; set;} = string.Empty;
//             public string study_field{get; set;} = string.Empty;
//             public override string ToString() => faculty_name;
//             public List<Students> students = new List<Students>();
//             public static int nr_of_facs;
//             public Faculty(string fac_name_abrv)
//             {
//                 faculty_name = fac_name_abrv;
//             }
//             public Faculty( string p_faculty_name, string p_faclt_abreviation, string p_study_field)
//             {
//                 faculty_name = p_faculty_name;
//                 faclt_abreviation = p_faclt_abreviation;
//                 study_field = p_study_field;
//             }
//             // Functie add_student start
//             public void add_student(StreamReader StudentFile,StreamWriter LoggingFile)
//             {
//                 students.Add(CreateStudent(StudentFile,LoggingFile));
//             }
//             // Functie add_student finish


//             // Functie graduate_student start
//             public void graduate_student(StreamWriter logging_file)
//             {
//                 Console.WriteLine("Write student's email:");
//                 string ?studentsEmail = Console.ReadLine();

//                 foreach (var student in students)
//                 {
//                     if (student.Email == studentsEmail)
//                     {
//                         student.StudyYear += 1;
//                         LoggingSystem.LogGraduation(logging_file,student.Email,student.StudyYear);
//                         return;
//                     }
//                 }

//                 LoggingSystem.LogErrorGraduation(logging_file, studentsEmail);
//             }
//             // Functie graduate_student finish


//             // Functie display_all_enrolled_students start
//             public void display_all_enrolled_students(List<Faculty> faculties)
//             {
//                 if(students.Count == 0)
//                 {
//                     Console.WriteLine("There are no students.");
//                     return;
//                 }
//                 foreach(var AStudent in students)
//                 {
//                     if (AStudent.StudyYear < 4) // Similar to checking if the student is not graduated
//                     {
//                         Console.Write($"{AStudent.FirstName} {AStudent.LastName} is year {AStudent.StudyYear} ");
//                         Console.WriteLine($"Email: {AStudent.Email}, Date of birth: {AStudent.DateOfBirth}");
//                     }
//                 }
//             }
//             // Functie display_all_enrolled_students finish


//             // Functie display_all_graduates start
//             public void display_all_graduates()
//             {
//                 foreach(var i in students)
//                 {
//                     if(i.StudyYear >= 4)
//                     {
//                         Console.WriteLine($"Student {i.FirstName} {i.LastName} has graduated");
//                     }
//                 }
//             }
//             // Functie display_all_graduates finish
//             // Functie verify_students_adherence start
//             public void verify_students_adherence()
//             {
//                 Console.WriteLine("Enter student's email");
//                 string ?email = Console.ReadLine();

//                 foreach (var student in students)
//                 {
//                     if (student.Email == email)
//                     {
//                         Console.Write($"Student: {student.FirstName} {student.LastName} - year {student.StudyYear}");
//                         Console.WriteLine($" belongs to {faclt_abreviation}");
//                         return;
//                     }
//                 }
//                 Console.WriteLine("Such student doesn't exist here");
//             }
//             // Functie verify_students_adherence FINISH
//         }
    
//         class Students
//         {
//             public string ?FirstName { get; set; }
//             public string ?LastName { get; set; }
//             public string ?Email { get; set; }
//             public string ?EnrollmentDate { get; set; }
//             public string ?DateOfBirth { get; set; }
//             public int StudyYear { get; set; }
//             // public string GetName() => FirstName;
//             public Students(string a,string b,string c, string d,string e,int f)
//             {
//                 FirstName = a;
//                 LastName = b;
//                 Email = c;
//                 EnrollmentDate = d;
//                 DateOfBirth = e;
//                 StudyYear = f;
//             }
//             public Students()
//             {

//             }

//             // Functie CreateStudent start
//             public Students CreateStudent(StreamReader StudentsFile,StreamWriter LoggingFile)
//             {
//                 Students NewStudent = new Students();
//                 string ?line = StudentsFile.ReadLine(); // ? = poate avea si valoarea null

//                 if (line != null)
//                 {
//                     // Separarea elementelor pe baza separatorului (virgulă, în acest caz)
//                     string[] parts = line.Split(',');
                    
//                     NewStudent.FirstName = parts[0];
//                     NewStudent.LastName = parts[1];
//                     NewStudent.Email = parts[2];
//                     NewStudent.EnrollmentDate = parts[3];
//                     NewStudent.DateOfBirth = parts[4];
//                 }
                
//                 // LoggingFile.WriteLine($"Student '{NewStudent.FirstName} {NewStudent.LastName}' added");
//                 // LoggingFile.WriteLine();
//                 // LoggingSystem.has_changes = true;
//                 LoggingSystem.LogStudent(LoggingFile,NewStudent);
//                 NewStudent.StudyYear  = 1;
//                 return NewStudent;
//             }
//             // Functie CreateStudent finish

//         }

//         ////////////
//         abstract class Operation_logger
//         {
//                 public abstract void log(StreamWriter logging_file, string message);
//         };

//         class Console_logger : Operation_logger
//         { 
//             public override void log(StreamWriter logging_file, string message)
//             {
//                 Console.WriteLine("Console Logger");
//                 Console.WriteLine(message);
//                 logging_file.WriteLine(message);
//             }
//         };

//         class File_logger : Operation_logger
//         {
//             public override void log(StreamWriter logging_file, string message)
//             {
//                 Console.WriteLine("File Logger");
//                 logging_file.WriteLine(message);
//             }
//         };
//         //////////////////////////
//         class FileManager
//         {
//             public static void save_all_changes(List<Faculty> faculties)
//             {
//                 string facultiesFilePath = @"c:\Users\chicu\OneDrive\Desktop\WriteFacC#.txt";
//                 string studentsFilePath = @"c:\Users\chicu\OneDrive\Desktop\stud_wit_abrv_c#.txt";

//                 try
//                 {
//                     using (StreamWriter facultiesFile = new StreamWriter(facultiesFilePath))
//                     using (StreamWriter studentsFile = new StreamWriter(studentsFilePath))
//                     {
//                         foreach (var faculty in faculties)
//                         {
//                             facultiesFile.WriteLine($"{faculty.faculty_name},{faculty.faclt_abreviation},{faculty.study_field}");

//                             foreach (var student in faculty.students)
//                             {
//                                 studentsFile.WriteLine($"{student.FirstName},{student.LastName},{student.Email}," +
//                                                     $"{student.EnrollmentDate},{student.DateOfBirth},{student.StudyYear}," +
//                                                     $"{faculty.faclt_abreviation}");
//                             }
//                         }
//                     }
//                 }
//                 catch (Exception ex)
//                 {
//                     Console.WriteLine("Eroare la scrierea fișierelor: " + ex.Message);
//                 }
//             }
            

//             public static void load_all_previous_changes(List<Faculty> faculties,
//             Dictionary<string,int> all_faculty_abreviations,Dictionary<string, List<Faculty>> facultiesByField)
//             {
//                 // StreamReader FacultiesFile;
//                 // StreamReader StudentsFile;
//                 using(StreamReader FacultiesFile = new StreamReader(@"C:\Users\chicu\OneDrive\Desktop\WriteFacC#.txt") )
//                 {
//                     int i = 0;
//                     string line1;
//                     while((line1 = FacultiesFile.ReadLine()) != null)
//                     {
//                         string[] parts = line1.Split(',');
//                         if(parts.Length >= 3)
//                         {
//                             string FacName = parts[0];
//                             string FacAbrv = parts[1];
//                             string FacField = parts[2];

//                             all_faculty_abreviations[FacAbrv] = i;
//                             faculties.Add(new Faculty(FacName,FacAbrv,FacField));
//                             i++;
//                             facultiesByField[FacField] = new List<Faculty>();
//                             facultiesByField[FacField].Add(new Faculty(FacAbrv));
//                         }
//                     }
//                 }
//                     using(StreamReader StudentsFile = new StreamReader(@"C:\Users\chicu\OneDrive\Desktop\stud_wit_abrv_c#.txt"))
//                     {
//                         string line1;
//                         while((line1 = StudentsFile.ReadLine()) != null)
//                         {
//                             string[] parts = line1.Split(',');
//                             if(parts.Length >= 7)
//                             {
//                                 string FirstName = parts[0];
//                                 string LastName = parts[1];
//                                 string Email = parts[2];
//                                 string enrollmentDate  = parts[3];
//                                 string dateOfBirth  = parts[4];
//                                 int studyYear  = int.Parse(parts[5]);
//                                 string facultyAbbrv  = parts[6];

//                                 if(all_faculty_abreviations.ContainsKey(facultyAbbrv))
//                                 {
//                                     int fac_index = all_faculty_abreviations[facultyAbbrv];
//                                     faculties[fac_index].students.Add(new Students(FirstName,LastName,Email,
//                                     enrollmentDate,dateOfBirth,studyYear));
//                                 }
//                             }
//                         }
//                     }
//             }

//         }
//         class LoggingSystem 
//         {
//             public static Operation_logger ?logger; 
//             public static bool has_changes = false;
//             public static void LogStudent(StreamWriter loggingFile, Students student)
//             {
//                 string message = $"Enrolled student: {student.FirstName} {student.LastName}";
//                 ExecuteLogging(loggingFile, message);
//             }

//             public static void LogFaculty(StreamWriter loggingFile, Faculty faculty)
//             {
//                 string message = $"Faculty {faculty.faculty_name} added to field: {faculty.study_field}";
//                 ExecuteLogging(loggingFile, message);
//             }

//             public static void LogGraduation(StreamWriter loggingFile, string email, int yearStudy)
//             {
//                 string message = $"Student with email {email} is now year {yearStudy}";
//                 ExecuteLogging(loggingFile, message);
//             }

//             public static void LogErrorGraduation(StreamWriter loggingFile, string email)
//             {
//                 string message = $"Error: Student with email {email} could not graduate";
//                 ExecuteLogging(loggingFile, message);
//             }

//             public static void LogErrorSearchingStudent(StreamWriter loggingFile, string email)
//             {
//                 string message = $"Error: Student with email {email} wasn't found";
//                 ExecuteLogging(loggingFile, message);
//             }

//             public static void LogFoundStudent(StreamWriter loggingFile, string email)
//             {
//                 string message = $"Found student with email {email}";
//                 ExecuteLogging(loggingFile, message);
//             }

//             private static Operation_logger choose_logger()
//             {
//                 Console.WriteLine("Choose logger:");
//                 Console.WriteLine("1. File logger");
//                 Console.WriteLine("2. Console logger");

//                 int choice;

//                 while(!int.TryParse(Console.ReadLine(),out choice) ||(choice != 1 && choice != 2))
//                 {
//                     Console.WriteLine("Wrong input. Try again");
//                 }
//                 return choice == 1 ? new File_logger() : new Console_logger();
//             }

//             private static void ExecuteLogging(StreamWriter LoggingFile, string message)
//             {
//                 LoggingSystem.has_changes = true;
//                 logger = choose_logger();
//                 LoggingFile.WriteLine();
//                 logger.log(LoggingFile,message);
//                 LoggingFile.WriteLine();
//                 logger = null;
//             }

//         }
        
    
//         //STRING INTERPOLATION
//         static void Main()
//         {
//             List<Faculty> faculties = new List<Faculty>(5);
//             Dictionary<string, List<Faculty>> facultiesByField = new Dictionary<string, List<Faculty>>(5);
//             Dictionary<string,int> all_faculty_abreviations = new Dictionary<string, int>
//             {
//                 {"IMIT",0},{"CIM",1},{"TA",2},{"UA",3},{"MV",4}
//             };

//             // StreamReader StudentsFile = new StreamReader("C:\\Users\\chicu\\OneDrive\\Desktop\\students.txt");
//             // StreamWriter LoggingFile = new StreamWriter("C:\\Users\\chicu\\OneDrive\\Desktop\\LogCsharp.txt")
//             string ?field_choice = string.Empty;
//             int iterations = 1;
//             int choice2 = 1;
//             using(StreamReader StudentsFile = new StreamReader("C:\\Users\\chicu\\OneDrive\\Desktop\\students.txt"))
//             using(StreamWriter LoggingFile = new StreamWriter("C:\\Users\\chicu\\OneDrive\\Desktop\\LogCsharp.txt"))
//             {
//                 while(choice2 != 0)
//                 {
//                     LoggingFile.WriteLine($"State {iterations}");
//                     LoggingFile.Flush();
//                     int faculty_choice;
//                     show_menu();
//                     int.TryParse(Console.ReadLine(), out choice2);
//                     // Console.ReadLine();
//                     LoggingSystem.has_changes = false;
//                     switch(choice2)
//                     {
//                         case 1:
//                             if(faculties.Count == 0)
//                             {
//                                 faculties.Add(new Faculty("Inginerie meacanica  industriala si transporturi","IMIT","MECHANICAL_ENGINEER"));
//                                 faculties.Add(new Faculty("Calculatoare informatica si microelectronica","CIM","SOFTWARE_ENGINEERING"));
//                                 faculties.Add(new Faculty("Inginerie si management in industria alimentara","TA","FOOD_TECHNOLOGY"));
//                                 faculties.Add(new Faculty("Planificare urbana si regionala","UA","URBANISM_ARCHITECTURE"));
//                                 faculties.Add(new Faculty("Medicina veterinara",  "MV","VETERINARY_MEDICINE"));
//                                 facultiesByField["MECHANICAL_ENGINEER"] = new List<Faculty>();
//                                 facultiesByField["MECHANICAL_ENGINEER"].Add(new Faculty("IMIT"));
//                                 facultiesByField["SOFTWARE_ENGINEERING"] = new List<Faculty>();
//                                 facultiesByField["SOFTWARE_ENGINEERING"].Add(new Faculty("CIM"));
//                                 facultiesByField["FOOD_TECHNOLOGY"] = new List<Faculty>();
//                                 facultiesByField["FOOD_TECHNOLOGY"] .Add(new Faculty("TA"));
//                                 facultiesByField["URBANISM_ARCHITECTURE"] = new List<Faculty>();
//                                 facultiesByField["URBANISM_ARCHITECTURE"] .Add(new Faculty("UA"));
//                                 facultiesByField["VETERINARY_MEDICINE"] = new List<Faculty>();
//                                 facultiesByField["VETERINARY_MEDICINE"].Add(new Faculty("MV"));
//                                 Faculty.nr_of_facs = 5;
//                             }
//                             faculty_choice = get_faculty_choice(faculties);
//                             if(faculty_choice == -1)
//                                 break;
//                             faculties[faculty_choice].add_student(StudentsFile,LoggingFile);
//                         break;

//                         case 2:
//                             faculty_choice = get_faculty_choice(faculties);
//                             if(faculty_choice == -1)
//                                 break;          
//                             faculties[faculty_choice].graduate_student(LoggingFile);
//                         break;

//                         case 3:
//                             faculty_choice = get_faculty_choice(faculties);
//                             if(faculty_choice == -1)
//                                 break;
//                             faculties[faculty_choice].display_all_enrolled_students(faculties);
//                         break;

//                         case 4:
//                             faculty_choice = get_faculty_choice(faculties);
//                             if(faculty_choice == -1)
//                                 break;
//                             faculties[faculty_choice].display_all_graduates();
//                         break;

//                         case 5:
//                             faculty_choice = get_faculty_choice(faculties);
//                             if(faculty_choice == -1)
//                                 break;
//                             faculties[faculty_choice].verify_students_adherence();
//                         break;

//                         case 6:
//                             search_student_by_email(faculties,LoggingFile);
//                         break;
                        
//                         case 7:
//                             add_faculty(faculties,LoggingFile,facultiesByField,all_faculty_abreviations);
//                         break;

//                         case 8:
//                             display_all_faculties(faculties);
//                         break;

//                         case 9:
//                             show_all_faculties_belonging_to_a_field(ref facultiesByField);
//                         break;

//                         case 10:
//                             FileManager.load_all_previous_changes(faculties,all_faculty_abreviations,facultiesByField);
//                         break;
//                         case 0:
//                             FileManager.save_all_changes(faculties);
//                             StudentsFile.Close();
//                             Environment.Exit(0);
//                         break;

//                         default:
//                             Console.WriteLine("Wrong number");
//                         break;
//                     }   
//                     iterations++;
//                     if(LoggingSystem.has_changes == false)
//                     {
//                         LoggingFile.WriteLine("No operation performed");
//                         LoggingFile.WriteLine();
//                         Console.WriteLine();
//                         Console.WriteLine();
//                     }
//                 }
//             // StudentsFile.Close();
//             // LoggingFile.Close();
//             }
           
//         }
//         // Functie show_menu start
//         public static void  show_menu()
//         {
//             Console.WriteLine("Choose one option:");
//             Console.WriteLine("1.Add a student to a faculty");
//             Console.WriteLine("2.Graduate a student from a faculty");
//             Console.WriteLine("3.Display all enrolled students");
//             Console.WriteLine("4.Display graduates");
//             Console.WriteLine("5.Verify belonging of a student");
//             Console.WriteLine("6.Search a student by email");
//             Console.WriteLine("7.Add a faculty");
//             Console.WriteLine("8.Display all faculties");
//             Console.WriteLine("9.Display all faculties belonging to a field");
//             Console.WriteLine("10.Load all previous changes");  
//             Console.WriteLine("0.Exit");
//         }
//         // Functie add_student finish


//         // Functie get_faculty_choice start
//         static int get_faculty_choice(List<Faculty> faculties)
//         {
//             if (faculties.Count == 0)
//             {
//                 Console.WriteLine("There are no faculties");
//                 return -1;
//             }

//             int facultyChoice;

//             while (true)
//             {
//                 Console.WriteLine("Choose a faculty:");
//                 display_all_faculties(faculties);
//                 if (int.TryParse(Console.ReadLine(), out facultyChoice) && facultyChoice > 0 && facultyChoice <= faculties.Count)
//                     return facultyChoice - 1; // Return index (0-based)

//                 Console.WriteLine("Invalid choice. Please try again.");
//             }
//         }
//         // Functie get_faculty_choice finish

//         // Functie display_all_faculties start
//         static void display_all_faculties(List<Faculty> faculties)
//         {
//             if (faculties.Count == 0)
//             {
//                 Console.WriteLine("There are no faculties");
//                 return;
//             }

//             Console.WriteLine("All the faculties are:");
//             int i = 0;

//             foreach (var facultyList in faculties)
//             {
//                 Console.WriteLine($"{i + 1}. {facultyList.faculty_name}");
//                 i++;
//             }
//         }
//         // Functie display_all_faculties finish


//         // Functie search_student_by_email start
//         static void search_student_by_email(List<Faculty> faculties, StreamWriter loggingFile)
//         {
//             if (faculties.Count == 0)
//             {
//                 Console.WriteLine("There are no faculties");
//                 return;
//             }

//             Console.WriteLine("Enter student's email");
//             string ?emailToSearch = Console.ReadLine();

//             foreach (var faculty in faculties)
//             {
//                 foreach (var student in faculty.students)
//                 {
//                     if (student.Email == emailToSearch)
//                     {
//                         Console.WriteLine($"Student with email '{emailToSearch}' stands in faculty '{faculty.faculty_name }'");
//                         LoggingSystem.LogFoundStudent(loggingFile, emailToSearch);
//                         return;
//                     }
//                 }
//             }

//             LoggingSystem.LogErrorSearchingStudent(loggingFile, emailToSearch);
//             Console.WriteLine($"Student with email '{emailToSearch}' was not found");
//         }
//         // Functie search_student_by_email finish


//                                 //Functie start
//         public static string GetStudyField()
//         {
//             int field;
//             string ?studField;

//             while (true)
//             {
//                 Console.WriteLine("Choose a field:");
//                 Console.WriteLine("1. MECHANICAL_ENGINEER");
//                 Console.WriteLine("2. SOFTWARE_ENGINEERING");
//                 Console.WriteLine("3. FOOD_TECHNOLOGY");
//                 Console.WriteLine("4. URBANISM_ARCHITECTURE");
//                 Console.WriteLine("5. VETERINARY_MEDICINE");

//                 if (int.TryParse(Console.ReadLine(), out field))
//                 {
//                     switch (field)
//                     {
//                         case 1:
//                             studField = "MECHANICAL_ENGINEER";
//                             break;
//                         case 2:
//                             studField = "SOFTWARE_ENGINEERING";
//                             break;
//                         case 3:
//                             studField = "FOOD_TECHNOLOGY";
//                             break;
//                         case 4:
//                             studField = "URBANISM_ARCHITECTURE";
//                             break;
//                         case 5:
//                             studField = "VETERINARY_MEDICINE";
//                             break;
//                         default:
//                             Console.WriteLine("Invalid selection. Please try again.");
//                             continue;
//                     }
//                     break;
//                 }
//                 else
//                 {
//                     Console.WriteLine("Invalid input. Please enter a number.");
//                 }
//             }

//             return studField;
//         }
//                                         //Functie finish


//                     //Functie start
//         static void add_faculty(List<Faculty> faculties,StreamWriter LoggingFile,Dictionary<string, List<Faculty>> facultiesByField,Dictionary<string,int> all_faculty_abreviations)
//         {
//             string ?faculty_name;
//             string ?faculty_abrv;
//             string ?studField;
//             studField = GetStudyField();
//             Console.WriteLine("Enter faculty's name: ");
//             faculty_name = Console.ReadLine();
//             Console.WriteLine("Enter faculty's abreviation: ");
//             faculty_abrv = Console.ReadLine();
//             if(all_faculty_abreviations.ContainsKey(faculty_abrv))
//             {
//                 Console.WriteLine($"Faculty {faculty_name} exists");
//                 return;
//             }
//             Faculty faculty = new Faculty(faculty_name,faculty_abrv,studField);
//             faculties.Add(faculty);
//             if (!facultiesByField.ContainsKey(studField))
//             {
//                 facultiesByField[studField] = new List<Faculty>();
//             }
//             Faculty.nr_of_facs++;
//             all_faculty_abreviations[faculty_abrv] = Faculty.nr_of_facs;
//             facultiesByField[studField].Add(faculty);
//             LoggingSystem.LogFaculty(LoggingFile,faculty);
//         }
//                 //Functie finish

//         //Functie start        
//         static void show_all_faculties_belonging_to_a_field(ref Dictionary<string, List<Faculty>> facultiesByField)
//         {
//             string field = GetStudyField();
//             var faculties_by_field =  facultiesByField.TryGetValue(field, out var faculties) ? faculties : new List<Faculty>();
//             Console.WriteLine($"Faculties in field: '{field}' are: ");
//             int i = 1;
//             foreach (var faculty in faculties_by_field)
//             {
//                 Console.WriteLine($"{i++}. {faculty}");
//             }
//         }
//             //Functie finish          
//     }
// }



