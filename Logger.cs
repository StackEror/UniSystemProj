abstract class Operation_logger
{
        public abstract void log(StreamWriter logging_file, string message);
};

class Console_logger : Operation_logger
{ 
    public override void log(StreamWriter logging_file, string message)
    {
        Console.WriteLine("Console Logger");
        Console.WriteLine(message);
        logging_file.WriteLine(message);
    }
};

class File_logger : Operation_logger
{
    public override void log(StreamWriter logging_file, string message)
    {
        Console.WriteLine("File Logger");
        logging_file.WriteLine(message);
    }
};