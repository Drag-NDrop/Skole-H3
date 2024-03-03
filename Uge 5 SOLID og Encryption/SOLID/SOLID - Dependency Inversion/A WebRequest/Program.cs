
namespace A_WebRequest
{
    internal class Program
    {

        // HttpClient lifecycle management best practices:
        // https://learn.microsoft.com/dotnet/fundamentals/networking/http/httpclient-guidelines#recommended-use
        private static HttpClient sharedClient = new()
        {
            //BaseAddress = new Uri("https://jsonplaceholder.typicode.com"),
        };

        static async Task Main(string[] args)
        {
            IOutput chosenOutputMethod; // Prepare a variable to hold the chosen implementation of IOutput

            Console.WriteLine("En webside - Del 1+2");
            Console.WriteLine("Please select an output method. 1: Console, 2: File");
            string output = Console.ReadLine();
  
            // Let the user decide which implementation of IOutput to pass to WebRequester
            switch(output)
            {
                case "1":
                    chosenOutputMethod = new OutputConsole();
                    break;
                case "2":
                    Console.WriteLine("Please enter a file path. Default: \"C:\\Temp\\output.txt\"");
                    string path = Console.ReadLine();
                    if (string.IsNullOrEmpty(path)) // If the user doesn't enter a path, use the default
                    {
                        path = "C:\\Temp\\output.txt";
                    }
                    chosenOutputMethod = new OutputFile(path);
                    break;
                default:
                    chosenOutputMethod = new OutputConsole();
                    break;
            }

            HttpClient sharedClient = new HttpClient(); // HttpClient is intended to be instantiated once per application, rather than per-use.
            WebRequester requester = new WebRequester(sharedClient, chosenOutputMethod); // Dependency Injection x2

            Console.WriteLine("Please enter a URL. Default: \"https://minip.dk\"");
            string url = Console.ReadLine();
            if (string.IsNullOrEmpty(url))
            {
                url = "https://minip.dk";
            }
            
            requester.SetBaseAddress(url); // Configure the base address of the shared client
            await requester.GetAsync("/");
        }
    }
}
