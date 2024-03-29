string choice;
do
{
    Console.WriteLine("1. Read data from ticket file.");
    Console.WriteLine("2. Create ticket file from data");
    Console.WriteLine("3. Search for a ticket");
    Console.WriteLine("4. Exit");

    choice = Console.ReadLine();

    if (choice == "1")
    {
      Console.WriteLine("Select file to read (1: Bugs/Defects, 2: Enhancements, 3: Tasks): ");
      string ticketType = Console.ReadLine();
      string fileName;
        switch (ticketType)
        {
            case "1":
                fileName = "ticket.csv";
                break;
            case "2":
                fileName = "Enhancements.csv";
                break;
            case "3":
                fileName = "Tasks.csv";
                break;
            default:
                Console.WriteLine("Invalid choice.");
                continue;
        }
        TicketManager manager = new TicketManager(fileName);
        List<Ticket> tickets = manager.ReadTickets();
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

            Console.WriteLine("Enter ticket type (1: Bug/Defect, 2: Enhancement, 3: Task): ");
            string type = Console.ReadLine();

            Ticket t;
            TicketManager manager;
            
            switch (type)
            {
                case "1":
                    Console.WriteLine("Enter ticket Severity: ");
                    string severity = Console.ReadLine();
                    t = new BugDefect(ticketID, summary, status, priority, submitter, assigned, watching, severity);
                    manager = new TicketManager("ticket.csv");
                    manager.WriteTickets(t);
                    break;
                case "2":
                    Console.WriteLine("Enter ticket Software: ");
                    string software = Console.ReadLine();
                    Console.WriteLine("Enter ticket Cost: ");
                    double cost = double.Parse(Console.ReadLine());
                    Console.WriteLine("Enter ticket Reason: ");
                    string reason = Console.ReadLine();
                    Console.WriteLine("Enter ticket Estimate: ");
                    double estimate = double.Parse(Console.ReadLine());
                    t = new Enhancement(ticketID, summary, status, priority, submitter, assigned, watching, software, cost, reason, estimate);
                    manager = new TicketManager("Enhancements.csv");
                    manager.WriteTickets(t);
                    break;
                case "3":
                    Console.WriteLine("Enter ticket Project Name: ");
                    string projectName = Console.ReadLine();
                    Console.WriteLine("Enter ticket Due Date: ");
                    string dueDate = Console.ReadLine();
                    t = new Task(ticketID, summary, status, priority, submitter, assigned, watching, projectName, dueDate);
                    manager = new TicketManager("Tasks.csv");
                    manager.WriteTickets(t);
                    break;
                
            }
        }

    }
    else if (choice == "3")
    {
        Console.WriteLine("Enter search term: ");
        string searchTerm = Console.ReadLine();

        TicketManager bugManager = new TicketManager("ticket.csv");
        TicketManager enhancementManager = new TicketManager("Enhancements.csv");
        TicketManager taskManager = new TicketManager("Tasks.csv");

        List<Ticket> tickets = bugManager.ReadTickets()
            .Concat(enhancementManager.ReadTickets())
            .Concat(taskManager.ReadTickets())
            .ToList();

        var results = tickets.Where(t => t.Status.Contains(searchTerm) || t.Priority.Contains(searchTerm) || t.Submitter.Contains(searchTerm)).ToList();

        Console.WriteLine($"Found {results.Count} tickets matching '{searchTerm}':");
        foreach (Ticket t in results)
        {
            Console.WriteLine(t);
        }        
    }
} while (choice != "4");