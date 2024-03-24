public abstract class Ticket {
    public string TicketID { get; set; }
    public string Summary { get; set; }
    public string Status { get; set; }
    public string Priority { get; set; }
    public string Submitter { get; set; }
    public string Assigned { get; set; }
    public string Watching { get; set; }
    public Ticket(string ticketID, string summary, string status, string priority, string submitter, string assigned, string watching) {
        TicketID = ticketID;
        Summary = summary;
        Status = status;
        Priority = priority;
        Submitter = submitter;
        Assigned = assigned;
        Watching = watching;
    }
    public abstract override string ToString();

}

public class BugDefect : Ticket {
    public string Severity { get; set; }
    public BugDefect(string ticketID, string summary, string status, string priority, string submitter, string assigned, string watching, string severity) : base(ticketID, summary, status, priority, submitter, assigned, watching) {
        Severity = severity;
    }
    public override string ToString() {
        return TicketID + "," + Summary + "," + Status + "," + Priority + "," + Submitter + "," + Assigned + "," + Watching + "," + Severity;
    }
}

public class Enhancement : Ticket {
    public string Software { get; set; }
    public double Cost { get; set; }
    public string Reason { get; set; }
    public double Estimate { get; set; }
    public Enhancement(string ticketID, string summary, string status, string priority, string submitter, string assigned, string watching, string software, double cost, string reason, double estimate) : base(ticketID, summary, status, priority, submitter, assigned, watching) {
        Software = software;
        Cost = cost;
        Reason = reason;
        Estimate = estimate;
    }
    public override string ToString() {
        return TicketID + "," + Summary + "," + Status + "," + Priority + "," + Submitter + "," + Assigned + "," + Watching + "," + Software + "," + Cost + "," + Reason + "," + Estimate;
    }
}

public class Task : Ticket {
    public string ProjectName { get; set; }
    public string DueDate { get; set; }
    public Task(string ticketID, string summary, string status, string priority, string submitter, string assigned, string watching, string projectName, string dueDate) : base(ticketID, summary, status, priority, submitter, assigned, watching) {
        ProjectName = projectName;
        DueDate = dueDate;
    }
    public override string ToString() {
        return TicketID + "," + Summary + "," + Status + "," + Priority + "," + Submitter + "," + Assigned + "," + Watching + "," + ProjectName + "," + DueDate;
    }
}