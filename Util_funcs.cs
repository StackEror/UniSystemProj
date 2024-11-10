#pragma warning disable CS8604
namespace UniSystem
{
    class UtilFuncs
    {
        // Functie show_menu start      
        public static void  show_menu()
        {
            Console.WriteLine("Choose one option:");
            Console.WriteLine("1.Add a student to a faculty");
            Console.WriteLine("2.Graduate a student from a faculty");
            Console.WriteLine("3.Display all enrolled students");
            Console.WriteLine("4.Display graduates");
            Console.WriteLine("5.Verify belonging of a student");
            Console.WriteLine("6.Search a student by email");
            Console.WriteLine("7.Add a faculty");
            Console.WriteLine("8.Display all faculties");
            Console.WriteLine("9.Display all faculties belonging to a field");
            Console.WriteLine("10.Load all previous changes");  
            Console.WriteLine("0.Exit");
        }
        // Functie show_menu finish


        // Functie get_faculty_choice start
        public static int get_faculty_choice(List<Faculty> faculties)
        {
            if (faculties.Count == 0)
            {
                Console.WriteLine("There are no faculties");
                return -1;
            }

            int facultyChoice;

            while (true)
            {
                Console.WriteLine("Choose a faculty:");
                display_all_faculties(faculties);
                if (int.TryParse(Console.ReadLine(), out facultyChoice) && facultyChoice > 0 && facultyChoice <= faculties.Count)
                    return facultyChoice - 1; // Return index (0-based)

                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
        // Functie get_faculty_choice finish

        // Functie display_all_faculties start
        public static void display_all_faculties(List<Faculty> faculties)
        {
            if (faculties.Count == 0)
            {
                Console.WriteLine("There are no faculties");
                return;
            }

            Console.WriteLine("All the faculties are:");
            int i = 0;

            foreach (var facultyList in faculties)
            {
                Console.WriteLine($"{i + 1}. {facultyList.faculty_name}");
                i++;
            }
        }
        // Functie display_all_faculties finish


        // Functie search_student_by_email start
        public static void search_student_by_email(List<Faculty> faculties, StreamWriter loggingFile)
        {
            if (faculties.Count == 0)
            {
                Console.WriteLine("There are no faculties");
                return;
            }

            Console.WriteLine("Enter student's email");
            string ?emailToSearch = Console.ReadLine();

            foreach (var faculty in faculties)
            {
                foreach (var student in faculty.students)
                {
                    if (student.Email == emailToSearch)
                    {
                        Console.WriteLine($"Student with email '{emailToSearch}' stands in faculty '{faculty.faculty_name }'");
                        LoggingSystem.LogFoundStudent(loggingFile, emailToSearch);
                        return;
                    }
                }
            }

            LoggingSystem.LogErrorSearchingStudent(loggingFile, emailToSearch);
            Console.WriteLine($"Student with email '{emailToSearch}' was not found");
        }
        // Functie search_student_by_email finish


            //Functie start
        public static string GetStudyField()
        {
            int field;
            string ?studField;

            while (true)
            {
                Console.WriteLine("Choose a field:");
                Console.WriteLine("1. MECHANICAL_ENGINEER");
                Console.WriteLine("2. SOFTWARE_ENGINEERING");
                Console.WriteLine("3. FOOD_TECHNOLOGY");
                Console.WriteLine("4. URBANISM_ARCHITECTURE");
                Console.WriteLine("5. VETERINARY_MEDICINE");

                if (int.TryParse(Console.ReadLine(), out field))
                {
                    switch (field)
                    {
                        case 1:
                            studField = "MECHANICAL_ENGINEER";
                            break;
                        case 2:
                            studField = "SOFTWARE_ENGINEERING";
                            break;
                        case 3:
                            studField = "FOOD_TECHNOLOGY";
                            break;
                        case 4:
                            studField = "URBANISM_ARCHITECTURE";
                            break;
                        case 5:
                            studField = "VETERINARY_MEDICINE";
                            break;
                        default:
                            Console.WriteLine("Invalid selection. Please try again.");
                            continue;
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }
            }

            return studField;
        }
            //Functie finish


            //Functie start
        public static void add_faculty(List<Faculty> faculties,StreamWriter LoggingFile,Dictionary<string, List<Faculty>> facultiesByField,Dictionary<string,int> all_faculty_abreviations)
        {
            string ?faculty_name;
            string ?faculty_abrv;
            string ?studField;
            studField = GetStudyField();
            Console.WriteLine("Enter faculty's name: ");
            faculty_name = Console.ReadLine();
            Console.WriteLine("Enter faculty's abreviation: ");
            faculty_abrv = Console.ReadLine();
            if(all_faculty_abreviations.ContainsKey(faculty_abrv))
            {
                Console.WriteLine($"Faculty {faculty_name} exists");
                return;
            }
            Faculty faculty = new Faculty(faculty_name,faculty_abrv,studField);
            faculties.Add(faculty);
            if (!facultiesByField.ContainsKey(studField))
            {
                facultiesByField[studField] = new List<Faculty>();
            }
            Faculty.nr_of_facs++;
            all_faculty_abreviations[faculty_abrv] = Faculty.nr_of_facs;
            facultiesByField[studField].Add(faculty);
            LoggingSystem.LogFaculty(LoggingFile,faculty);
        }
        //Functie finish

        //Functie start        
        public static void show_all_faculties_belonging_to_a_field(ref Dictionary<string, List<Faculty>> facultiesByField)
        {
            string field = GetStudyField();
            var faculties_by_field =  facultiesByField.TryGetValue(field, out var faculties) ? faculties : new List<Faculty>();
            Console.WriteLine($"Faculties in field: '{field}' are: ");
            int i = 1;
            foreach (var faculty in faculties_by_field)
            {
                Console.WriteLine($"{i++}. {faculty}");
            }
        }
            //Functie finish 
    }
}