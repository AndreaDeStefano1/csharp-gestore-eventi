using System.Runtime.CompilerServices;





static void PrintMenu()
{
    Console.WriteLine("(1) - Aggiungi Evento");
    Console.WriteLine("(2) - Esci");
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
        #region AggiungiEvento
        case 1:
            Console.Clear();
            string nome = "";
            DateTime data = Convert.ToDateTime("01/01/0001");
            do
            {
                try
                {
                    nome = getUserString("Nome Evento: ");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            } while (nome == "");

            do
            {
                try
                {
                    data = Convert.ToDateTime(getUserString("Data evento: "));
                    if (data < DateTime.Now)
                    {
                        data = Convert.ToDateTime("01/01/0001");
                        throw new Exception("La data non può essere precedente alla data odierna. Riprova");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            } while (data.ToString("d") == "01/01/0001");

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
        #endregion


        default:
            exit = true;
            break;
    }
}






// TEST MILESTONE 3

//Console.WriteLine("");
//ProgramEvent newProgram = new ProgramEvent("Giochi d'autunno");

//newProgram.AddEvent(new Event("Rockstar", new DateTime(2023, 3, 1, 7, 0, 0), 150));

//newProgram.AddEvent(new Event("Barbablù", new DateTime(2023, 3, 11, 7, 0, 0), 150));
//List<Event> list = newProgram.ListedEvents("01/03/2023");
//Console.WriteLine("2\n");
//ProgramEvent.PrintList(list);

//Console.WriteLine("3\n");
//ProgramEvent.PrintList(newProgram.Events);
//Console.WriteLine("4\n");
//Console.WriteLine(newProgram.EventCount());
//Console.WriteLine("5\n");

//Console.WriteLine(newProgram.PrintProgram());

//newProgram.EmptyList();
//Console.WriteLine("6");

//Console.WriteLine(newProgram.EventCount());
