using BL;
using DataLayer;
using DTO;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace AirportConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddScoped<MainDbContext>();
            services.AddScoped<IAirportRep, AirportRep>();
            services.AddScoped<IFlightRep, FlightRep>();
            services.AddScoped<IDelayReasonRep, DelayReasonRep>();
            services.AddScoped<IPassangerRep, PassangerRep>();
            services.AddScoped<IPlaceRep, PlaceRep>();
            services.AddScoped<IPlaneRep, PlaneRep>();
            services.AddScoped<ITicketRep, TicketRep>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddSingleton<IAirportService, AirportService>();
            services.AddSingleton<IFlightService, FlightService>();
            services.AddSingleton<IPlaneService, PlaneService>();
            services.AddSingleton<IDealyService, DelayService>();

            var sp = services.BuildServiceProvider();
            StartPage();
            int end = 0;
            Console.WriteLine("Оберіть функцію: ");
            Console.WriteLine("1 - Показати аеропорти: ");
            Console.WriteLine("2 - Додати рейс ");
            Console.WriteLine("3 - Закінчити роботу ");
            int chosen = ReadKey();
            Flight fl = new Flight {
                tickets = new List<Ticket>(), 
            };
            switch (chosen)
            {
                case 1:
                    ShowAirports(sp.GetService<IAirportService>());
                    fl = ChooseAirports(sp.GetService<IFlightService>(), sp.GetService<IAirportService>());
                    break;

                case 2:
                    Console.WriteLine("Введіть дату вильоту (в форматі YYYY-MM-DDTHH:MM:SS): ");
                    string chosenstr = Console.ReadLine();
                    Console.WriteLine("Введіть назву ");
                    string name = Console.ReadLine();
                    fl = SetUpPlane(fl, sp.GetService<IPlaneService>(), sp.GetService<IFlightService>());
                    fl = new Flight{ 
                        
                        number = name,
                        plane = fl.plane,
                        delayReasons = new List<DelayReason>(),
                        tickets = fl.tickets,
                        flightDate = DateTime.Parse(chosenstr),
                        ticketsPurchaseEnd = DateTime.Parse(chosenstr),
                    };
                    sp.GetService<IFlightService>().AddFlight(fl);
                    break;

                case 3:
                    return;

                default:
                    PrintError();
                    break;
            }

            end = 0;
            while (end == 0)
            {
                if (fl.plane != null)
                {
                    Console.WriteLine("Літак: ");
                    Console.WriteLine(fl.plane.name);
                }

                Console.WriteLine("Дата закінчення покупки квитків: ");
                Console.WriteLine(fl.ticketsPurchaseEnd);

                if (fl.delayReasons.Count != 0)
                {
                    Console.WriteLine("Причини затримки ");
                    DateTime date = fl.flightDate;
                    foreach (DelayReason dr in fl.delayReasons) {
                        Console.WriteLine(dr.name);
                        date += dr.delay;
                    }
                    Console.WriteLine("Дата вильоту ");
                    Console.WriteLine(date);
                }
                else
                {
                    Console.WriteLine("Дата вильоту ");
                    Console.WriteLine(fl.flightDate);
                }
                ShowMenu();
                if ((chosen = ReadKey()) == 0)
                {
                    PrintError();
                    break;
                }
                switch (chosen)
                {
                    case 1:
                        ShowPassangers(fl, sp.GetService<IFlightService>());
                        break;

                    case 2:
                        ShowTickets(fl);
                        break;

                    case 3:
                        SetTicketsEndTime(fl, sp.GetService<IFlightService>());
                        break;

                    case 4:
                        SetDelay(fl, sp.GetService<IDealyService>(), sp.GetService<IFlightService>());
                        break;

                    case 5:
                        end = 1;
                        break;

                    default:
                        PrintError();
                        break;
                }
            }
        }
        

        private static Flight ChooseAirports(IFlightService fserv, IAirportService aserv) 
        {
            int chosen;
            while ((chosen = ReadKey()) == 0)
            {
                PrintError();
                ShowAirports(aserv);
            }
            ShowFlights(chosen, aserv);
            while ((chosen = ReadKey()) == 0)
            {
                PrintError();
                ShowFlights(chosen, aserv);
            }
            Flight fl = fserv.Get(chosen);
            return fl;
        }
                
        private static void ShowMenu() 
        {
            Console.WriteLine("Оберіть функцію: ");
            Console.WriteLine("1 - Показати пасажирів: ");
            Console.WriteLine("2 - Показати квитки ");
            Console.WriteLine("3 - Вказати час закінчення продажу квитків ");
            Console.WriteLine("4 - Вказати затримку");
            Console.WriteLine("5 - Закінчити роботу");
        }
        private static void ShowAirports(IAirportService aserv) 
        {
            Console.WriteLine("Оберіть аеропорт: ");
            foreach(Airport a in aserv.GetAll()) 
            {
                Console.WriteLine(a.id + " " + a.name);
            }
        }

        private static void ShowFlights(int chosen, IAirportService aserv) 
        {
            Console.WriteLine("Оберіть рейс: ");
            foreach (Flight a in aserv.GetFlights(chosen))
            {
                Console.WriteLine(a.id + " " + a.number);
            }
        }

        private static void ShowPassangers(Flight fl, IFlightService fserv) 
        {
            Console.WriteLine("Список пасажирів: ");
            /*foreach (Passanger a in fserv.GetPasangers(fl))
            {
                Console.WriteLine(a.name + " " + a.surname);
            }*/
        }

        private static void ShowTickets(Flight fl) 
        {
            Console.WriteLine("Список місць: ");
            foreach (Ticket a in fl.tickets)
            {
                Console.WriteLine(a.id + " " + a.place.number);
            }
        }

        private static void SetTicketsEndTime(Flight fl, IFlightService fserv) 
        {
            Console.WriteLine("Введіть дату закінчення можливості покупки квитків (в форматі YYYY-MM-DDTHH:MM:SS): ");
            string chosen = Console.ReadLine();
            //fserv.ChangeTicketsPurchaseEndTime(fl, DateTime.Parse(chosen));
        }

        private static void SetDelay(Flight fl, IDealyService dserv, IFlightService fs) 
        {
            Console.WriteLine("Затримки: ");
            foreach (DelayReason p in dserv.GetAll())
            {
                Console.WriteLine(p.id + " " + p.name);
            }
            int chosen = ReadKey();
           // fs.SetDelay(fl, chosen);
        }

        private static Flight SetUpPlane(Flight fl, IPlaneService pserv, IFlightService fserv)
        {
            Console.WriteLine("Оберіть літак: ");
            Console.WriteLine("Список літаків: ");
            foreach (Plane p in pserv.GetAll())
            {
                Console.WriteLine(p.id + " " + p.name);
            }
            int chosen = ReadKey();
            fl = fserv.SetUpPlane(fl, chosen);
            return fl;
        }


        private static int ReadKey() 
        {
            string num = Console.ReadLine();
            int result;
            if (Int32.TryParse(num, out result)) 
            {
                return result;
            }
            return 0;
        }

        private static void StartPage() 
        {
            Console.WriteLine("Добрий день!");
        }

        private static void PrintError() 
        {
            Console.WriteLine("Введено некоректні дані");
            Console.WriteLine("Спробуйте ще раз: ");
        }
    }
}
