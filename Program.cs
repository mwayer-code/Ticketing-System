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
       TicketManager tm = new TicketManager("ticket.txt");
         List<Ticket> tickets = tm.ReadTickets();
            foreach (Ticket t in tickets)
            {
                Console.WriteLine(t);
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