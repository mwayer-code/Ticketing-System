public class TicketManager {
    private string file;
    public TicketManager(string file) {
        this.file = file;
    }
   
    public List<Ticket> ReadTickets() {
        List<Ticket> tickets = new List<Ticket>();
        if (File.Exists(file)) {
            StreamReader sr = new StreamReader(file);
            while (!sr.EndOfStream) {
                string ?line = sr.ReadLine();
                string[] arr = line.Split(',');
                tickets.Add(new Ticket(arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6]));
            }
            sr.Close();
        }
        return tickets;
    }
    public void WriteTickets(Ticket t) {
        StreamWriter sw = new StreamWriter(file, true);
        sw.WriteLine(t);
        sw.Close();
    }


}