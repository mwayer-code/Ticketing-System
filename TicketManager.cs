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
                string line = sr.ReadLine();
                string[] arr = line.Split(',');
                Ticket ticket;
                if (arr.Length == 8) {
                    ticket = new BugDefect(arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6], arr[7]);
                } else if (arr.Length == 11) {
                    ticket = new Enhancement(arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6], arr[7], double.Parse(arr[8]), arr[9], double.Parse(arr[10]));
                } else if (arr.Length == 9){
                    ticket = new Task(arr[0], arr[1], arr[2], arr[3], arr[4], arr[5], arr[6], arr[7], arr[8]);
                } else {
                    throw new Exception("Invalid line");
                }
                tickets.Add(ticket);
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