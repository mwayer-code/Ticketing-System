string file = "ticket.txt";
string choice;
do
{
    Console.WriteLine("1. Read data from ticket file.");
    Console.WriteLine("2. Create ticket file from data");
    Console.WriteLine("3. Exit");

    choice = Console.ReadLine();

    if (choice == "1")
    {
        if (File.Exists(file))
        {
            StreamReader sr = new StreamReader(file);
            while (!sr.EndOfStream){
                string line = sr.ReadLine();

                string[] arr = line.Split(',');

                Console.WriteLine("TicketID: {0}, Summary: {1}, Status: {2}, Priority: {3}, Submitter: {4}, Assigned: {5}, Watching: {6}", arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6]);
            }
            sr.Close();
        }
    }
    else if (choice == "2")
    {
        StreamWriter sw = new StreamWriter(file);
        for (int i = 0; i < 1; i++)
        {
            Console.WriteLine("Create a new Ticket File (Y/N)?");
            string resp = Console.ReadLine().ToUpper();

            if (resp != "Y") { break; }

            Console.WriteLine("Enter ticket ID: ");
            string ticketID = Console.ReadLine();
            Console.WriteLine("Enter ticket Summary: ");
            string summary = Console.ReadLine();
            Console.WriteLine("Enter ticket Status: ");
            string status = Console.ReadLine();
            Console.WriteLine("Enter ticket Priority: ");
            string priority = Console.ReadLine();
            Console.WriteLine("Enter ticket Submitter: ");
            string submitter = Console.ReadLine();
            Console.WriteLine("Enter ticket Assigned: ");
            string assigned = Console.ReadLine();
            Console.WriteLine("Enter ticket Watching: ");
            string watching = Console.ReadLine();

            sw.WriteLine("{0},{1},{2},{3},{4},{5},{6}", ticketID, summary, status, priority, submitter, assigned, watching);
        }
        sw.Close();   
    }
} while (choice == "1" || choice == "2");