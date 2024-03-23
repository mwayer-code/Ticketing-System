string choice;
do
{
    Console.WriteLine("1. Read data from ticket file.");
    Console.WriteLine("2. Create ticket file from data");
    Console.WriteLine("3. Exit");

    choice = Console.ReadLine();

    if (choice == "1")
    {
       TicketManager tm = new TicketManager("ticket.csv");
         List<Ticket> tickets = tm.ReadTickets();
            foreach (Ticket t in tickets)
            {
                Console.WriteLine(t);
            }
    }
    else if (choice == "2")
    {
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

            TicketManager manager = new TicketManager("ticket.csv");
            Ticket t = new Ticket(ticketID, summary, status, priority, submitter, assigned, watching);
            manager.WriteTickets(t);
        }

    }
} while (choice == "1" || choice == "2");