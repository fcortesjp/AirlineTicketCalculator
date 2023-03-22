using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirlineTicketCalculator
{
    class Program
    {
        public struct valores
        {
            public string passangerName;
            public int passangerAge;
            public char passangerType;
            public char airlineCompany;
            public char season;
            public double baseTicketPrice;
        }

        public static valores obtenerValores()
        {
            valores values = new valores();
            //Capture nombre solo si es valido pasajero valido
            while (true)
            {
                Console.Write("Ingrese Nombre de Pasajero: ");
                values.passangerName = Console.ReadLine();

                // revise si el nombre esta en blanco
                if (string.IsNullOrWhiteSpace(values.passangerName))
                {
                    //si es asi, indique mensaje de error
                    Console.WriteLine("El nombre del pasajero no puede estar en blanco");
                    //regrese al inicio del loop
                    continue;
                }

                //  revise si el nombre es un numero o tiene digitos
                if (values.passangerName.Any(char.IsDigit))
                {
                    //si es asi indique mensaje de error
                    Console.WriteLine("el nombre no puede contener digitos");
                    //regrese al incio del loop
                    continue;
                }

                // si no hay problemas con la captura salga del loop
                break;
            }
            //Console.WriteLine("passangerName: " + passangerName);

            //Capture Edad de Pasajero
            while (true)
            {
                Console.Write("Ingrese Edad de Pasajero: ");
                string passangerAgeStr = Console.ReadLine();

                // revise si el precio esta en blanco o nulo
                if (string.IsNullOrWhiteSpace(passangerAgeStr))
                {
                    //si es asi, indique mensaje de error
                    Console.WriteLine("La edad no puede estar en blanco o ser nulo");
                    //regrese al inicio del loop
                    continue;
                }
                // revise si el precio puede ser un numero double
                values.passangerAge = 0;
                bool canBeInt = int.TryParse(passangerAgeStr, out values.passangerAge);
                if (canBeInt == false)
                {
                    //si es asi, indique mensaje de error
                    Console.WriteLine("El dato ingresado no es valido");
                    //regrese al inicio del loop
                    continue;
                }

                // si no hay problemas con la captura salga del loop
                break;
            }
            //Console.WriteLine("passangerAge: " + passangerAge);

            //Capture tipo de pasajero solo si es valido
            while (true)
            {
                Console.Write("Ingrese 'e' si estudiante o 'p' particular: ");
                string passangerTypeStr = Console.ReadLine();

                // revise si el tipo de pasajero esta en blanco
                if (string.IsNullOrWhiteSpace(passangerTypeStr))
                {
                    //si es asi, indique mensaje de error
                    Console.WriteLine("El Tipo de pasajero no puede estar en blanco");
                    //regrese al inicio del loop
                    continue;
                }
                // revise si el tipo de pasajero no es ni e ni p
                values.passangerType = passangerTypeStr.ToCharArray()[0];
                if (values.passangerType != 'e' && values.passangerType != 'p')
                {
                    //si es asi, indique mensaje de error
                    Console.WriteLine("ingrese 'e' o 'p'");
                    //regrese al inicio del loop
                    continue;
                }

                // si no hay problemas con la captura salga del loop
                break;
            }
            //Console.WriteLine("passangerType: " + passangerType);

            //Capture aerolinea
            while (true)
            {
                Console.Write("Ingrese la Aerolinea: 'a' si 'ALAS' o 'v' si 'VOLAR': ");
                string airlineCompanyStr = Console.ReadLine();

                // revise si el aerolinea esta en blanco
                if (string.IsNullOrWhiteSpace(airlineCompanyStr))
                {
                    //si es asi, indique mensaje de error
                    Console.WriteLine("La Aerolinea no puede estar en blanco");
                    //regrese al inicio del loop
                    continue;
                }
                // revise si el tipo de pasajero no es ni e ni p
                values.airlineCompany = airlineCompanyStr.ToCharArray()[0];
                if (values.airlineCompany != 'a' && values.airlineCompany != 'v')
                {
                    //si es asi, indique mensaje de error
                    Console.WriteLine("ingrese 'a' o 'v'");
                    //regrese al inicio del loop
                    continue;
                }

                // si no hay problemas con la captura salga del loop
                break;
            }
            //Console.WriteLine("airlineCompany: " + airlineCompany);

            //Capture Temporada
            while (true)
            {
                Console.Write("Ingrese Temporada: 'a' si 'Alta' o 'b' si 'Baja': ");
                string seasonStr = Console.ReadLine();

                // revise si el temporada esta en blanco
                if (string.IsNullOrWhiteSpace(seasonStr))
                {
                    //si es asi, indique mensaje de error
                    Console.WriteLine("La Temporada no puede estar en blanco");
                    //regrese al inicio del loop
                    continue;
                }
                // revise si la temporada no es ni a ni b
                values.season = seasonStr.ToCharArray()[0];
                if (values.season != 'a' && values.season != 'b')
                {
                    //si es asi, indique mensaje de error
                    Console.WriteLine("ingrese 'a' o 'b'");
                    //regrese al inicio del loop
                    continue;
                }

                // si no hay problemas con la captura salga del loop
                break;
            }
            //Console.WriteLine("season: " + season);


            //Capture Precio base de ticket
            while (true)
            {
                Console.Write("Ingrese valor ticket: ");
                string baseTicketPriceStr = Console.ReadLine();

                // revise si el precio esta en blanco o nulo
                if (string.IsNullOrWhiteSpace(baseTicketPriceStr))
                {
                    //si es asi, indique mensaje de error
                    Console.WriteLine("El valor del ticket no estar en blanco o ser nulo");
                    //regrese al inicio del loop
                    continue;
                }
                // revise si el precio puede ser un numero double
                values.baseTicketPrice = 0.0;
                bool canBeDouble = double.TryParse(baseTicketPriceStr, out values.baseTicketPrice);
                if (canBeDouble == false)
                {
                    //si es asi, indique mensaje de error
                    Console.WriteLine("El dato ingresado no es valido");
                    //regrese al inicio del loop
                    continue;
                }

                // si no hay problemas con la captura salga del loop
                break;
            }
            //Console.WriteLine("baseTicketPrice: " + baseTicketPrice);
            return values;
        }

        public static double calcularValorFinalTicket(double baseTicketPrice, char season, char airlineCompany, int passangerAge, char passangerType) 
        {

            //variables requeridas para el calculo del precio final de ticket
            double airlineDiscountAddition = 0;
            double ageDiscount = 0;
            double overSixty = 0;
            double studentDiscount = 0;

            switch (season)
            {
                case 'a':
                    switch (airlineCompany)
                    {
                        case 'a':
                            airlineDiscountAddition = baseTicketPrice * 0.3;
                            if (passangerAge < 18)
                            {
                                ageDiscount = -(baseTicketPrice * 0.5);
                            }
                            break;
                        case 'v':
                            airlineDiscountAddition = baseTicketPrice * 0.2;
                            if (passangerAge < 18)
                            {
                                ageDiscount = -(baseTicketPrice * 0.5);
                            }
                            else if (passangerAge > 60)
                            {
                                overSixty = 10000;
                            }
                            break;
                    }
                    break;
                case 'b':
                    switch (airlineCompany)
                    {
                        case 'v':
                            if (passangerAge < 18)
                            {
                                ageDiscount = -(baseTicketPrice * 0.5);
                            }
                            else if (passangerAge > 60)
                            {
                                overSixty = 10000;
                            }
                            break;
                        case 'a':
                            if (passangerAge < 18)
                            {
                                ageDiscount = -(baseTicketPrice * 0.5);
                            }
                            else if (passangerType == 'e')
                            {
                                studentDiscount = -(baseTicketPrice * 0.1);
                            }
                            break;
                    }
                    break;
            }
            double finalTicketPrice = baseTicketPrice + airlineDiscountAddition + ageDiscount + overSixty + studentDiscount;
            return finalTicketPrice;
        }

        static void Main(string[] args)
        {
            //obtener los valores del usuario
            var values =  obtenerValores();

            //obtener el valor final del ticket
            double finalTicketPrice = calcularValorFinalTicket(values.baseTicketPrice, values.season, values.airlineCompany, values.passangerAge, values.passangerType);
            
            //Muestre nombre pasajero y Tarifa final
            Console.WriteLine("Para el pasajero: " + values.passangerName);
            Console.WriteLine("la tarifa final es: " + finalTicketPrice);
            Console.WriteLine("Presione enter para finalizar...");
            Console.ReadLine();
       
        }
    }
             
}
