class LoggingSystem 
{
    public static Operation_logger ?logger; 
    public static bool has_changes = false;
    public static void LogStudent(StreamWriter loggingFile, Students student)
    {
        string message = $"Enrolled student: {student.FirstName} {student.LastName}";
        ExecuteLogging(loggingFile, message);
    }

    public static void LogFaculty(StreamWriter loggingFile, Faculty faculty)
    {
        string message = $"Faculty {faculty.faculty_name} added to field: {faculty.study_field}";
        ExecuteLogging(loggingFile, message);
    }

    public static void LogGraduation(StreamWriter loggingFile, string email, int yearStudy)
    {
        string message = $"Student with email {email} is now year {yearStudy}";
        ExecuteLogging(loggingFile, message);
    }

    public static void LogErrorGraduation(StreamWriter loggingFile, string email)
    {
        string message = $"Error: Student with email {email} could not graduate";
        ExecuteLogging(loggingFile, message);
    }

    public static void LogErrorSearchingStudent(StreamWriter loggingFile, string email)
    {
        string message = $"Error: Student with email {email} wasn't found";
        ExecuteLogging(loggingFile, message);
    }

    public static void LogFoundStudent(StreamWriter loggingFile, string email)
    {
        string message = $"Found student with email {email}";
        ExecuteLogging(loggingFile, message);
    }

    private static Operation_logger choose_logger()
    {
        Console.WriteLine("Choose logger:");
        Console.WriteLine("1. File logger");
        Console.WriteLine("2. Console logger");

        int choice;

        while(!int.TryParse(Console.ReadLine(),out choice) ||(choice != 1 && choice != 2))
        {
            Console.WriteLine("Wrong input. Try again");
        }
        return choice == 1 ? new File_logger() : new Console_logger();
    }

    private static void ExecuteLogging(StreamWriter LoggingFile, string message)
    {
        LoggingSystem.has_changes = true;
        logger = choose_logger();
        LoggingFile.WriteLine();
        logger.log(LoggingFile,message);
        LoggingFile.WriteLine();
        logger = null;
    }

}