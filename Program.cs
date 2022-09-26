// See https://aka.ms/new-console-template for more information








static void PrintMenu()
{
    Console.WriteLine("(1)- Aggiungi Evento");
    Console.WriteLine("()-");
    Console.WriteLine("()-");
    Console.WriteLine("()-");
    Console.WriteLine("()-");
}

static string getUserString(string message)
{

    Console.WriteLine(message);
    return Console.ReadLine();
}
bool exit = false;
while (!exit)
{
    PrintMenu();
    int choice = Convert.ToInt32(Console.ReadLine());

    switch (choice)
    {
        case 1:
            Console.Clear();
            string nome = getUserString("Nome Evento: ");
            DateTime data = Convert.ToDateTime(getUserString("Data evento: "));
            int posti = Convert.ToInt32(getUserString("Posti disponibili: "));
            Event newE = new Event(nome, data, posti);
            bool flag = true;
            while (flag)
            {
                string choice2 = getUserString("Vuoi aggiungere posti prenotati(1)? O rimuoverli (2)? Oppure tornare al Menu(3) ");
                switch (choice2)
                {
                    case "1":
                        bool addError = false;
                        do
                        {
                            try
                            {
                                newE.BookSeatsPlus(Convert.ToInt32(getUserString("Quanti posti vuoi riservare?")));
                                addError = false;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                                addError = true;

                            }
                        } while (addError);

                        Console.WriteLine(newE.ToString());
                        newE.PrintDisponibility();
                        break;

                    case "2":
                        bool removeError = false;
                        do
                        {
                            try
                            {
                                newE.BookSeatsMinus(Convert.ToInt32(getUserString("Quanti posti vuoi disdire?")));
                                removeError = false;
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                                removeError = true;

                            }
                        } while (removeError);

                        Console.WriteLine(newE.ToString());
                        newE.PrintDisponibility();
                        break;

                    default:
                        flag = false;
                        break;
                }
            }
            break;
            
        default:
            exit = true;
            break;
    }
}
