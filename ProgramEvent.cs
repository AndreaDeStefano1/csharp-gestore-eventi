// See https://aka.ms/new-console-template for more information
class ProgramEvent
{
    string title;
    List<Event> events;

    
    public string Title { get =>  title ; set => title = value; }
    public List<Event> Events { get => events;  }

    public ProgramEvent(string title)
    {
        Title = title;
        events = new List<Event>();
        
    }



    public void AddEvent(Event e)
    {
        Events.Add(e);  
    }

    public List<Event> ListedEvents(string date)
    {
        List<Event> listedEvents = new List<Event>();

        foreach (Event e in Events)
        {
            if(e.Date.ToString("d") == date)
            {
                listedEvents.Add(e);
            }
        }

        return listedEvents;
    }

    public static void PrintList(List<Event> eList)
    {
        foreach (Event e in eList)
        {
            Console.WriteLine(e.ToString()); 
        }
    }

    public int EventCount()
    {
        return Events.Count;
    }

    public void EmptyList()
    {
        Events.Clear();
    }

    public string PrintProgram()
    {
        string program = "";
        int count = 1;

        program = Title + ": \n" ;
        foreach (Event e in Events)
        {
            program += count + " - " + e.ToString() + "\n";
            count++;
        }

        return program;
    }
 
}