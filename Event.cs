// See https://aka.ms/new-console-template for more information
class Event
{
    private string title;
    private DateTime date;
    private int maxCapacity;
    private int bookedSeats;

    public string Title 
    {   get => title; 
        set 
        { 
            if (value == "") 
            { 
                title = "Il titolo non può essere vuoto";
            }
            else
            {
                title = value;  
            }
        }
    }
    public DateTime Date {
        get => date; 
        set
        {
            if (value < DateTime.Now)
            {
                throw new Exception("La data non può essere precedente alla data odierna");
            }else
            {
                date = value;
            }
        } 
    }
    public int MaxCapacity 
    {
        get => maxCapacity;

        private set
        {
            
            if (value < 0)
            {
                throw new Exception("La capacità massima dell'evento non può essere minore di 0");
            }
            else
            {
                maxCapacity = value;
            }
            
        }
    }
    public int BookedSeats { get;  }

    public Event(string title, DateTime date, int maxCapacity)
    {
        Title = title;
        try
        {
            Date = date;
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
        MaxCapacity = maxCapacity;
        BookedSeats = 0;
    }

    public void BookSeats(int n)
    {
        if (Date < DateTime.Now)
        {
            throw new Exception("L'evento è già passato");
        }

        if ( n > MaxCapacity - BookedSeats )
        {
            throw new Exception();
        }
        else
        {
            this.bookedSeats += n;
        }
    }

    public void CancelBooking( int n )
    {
        if (Date < DateTime.Now)
        {
            throw new Exception("L'evento è già passato");
        }

        if (n < BookedSeats)
        {
            throw new Exception("Il numero di posti che vuoi disdire è superiore a quello dei posti prenotati");
        }
        else
        {
            this.bookedSeats -= n;
        }
    }


















}