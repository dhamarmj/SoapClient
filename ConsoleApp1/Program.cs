using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ServiceReference1;

namespace ConsoleApp1
{
    class Program
    {
        public static void Main(string[] args)
        {
            
            AcademicoWebServiceClient academicoWebServiceClient = new AcademicoWebServiceClient();
            string menuid = "0";
            while (menuid != "4")
            {
                Console.WriteLine("Soap Client in C#!");
                Console.WriteLine("1- Listar Estudiantes");
                Console.WriteLine("2- Buscar Asignatura");
                Console.WriteLine("3- Buscar Profesor");
                Console.WriteLine("4- Salir");
                menuid = Console.ReadLine();
                if ( menuid == "1")
                {
                    var a = showStudentsAsync(academicoWebServiceClient);
                    Task.WaitAll(a);
                }
        
                else if(menuid == "2")
                {
                    var b = consultAsignatura(academicoWebServiceClient);
                    Task.WaitAll(b);
                }
                    
                else if (menuid == "3")
                {
                    var c = consultaProfesor(academicoWebServiceClient);
                    Task.WaitAll(c);
                }
            }


            Environment.Exit(0);
        }

        private static async System.Threading.Tasks.Task showStudentsAsync(AcademicoWebServiceClient academicoWebServiceClient)
        {
            var s = await academicoWebServiceClient.getAllEstudianteAsync();
            foreach (var item in s.@return)
            {
                Console.WriteLine(item.nombre + " " + item.matricula);
            }
        }

        private static async System.Threading.Tasks.Task consultAsignatura(AcademicoWebServiceClient academicoWebServiceClient)
        {
            Console.WriteLine(" ");
            Console.Write("Inserte el id de la asignatura: ");
            String id = Console.ReadLine();

            var s = await academicoWebServiceClient.getAsignaturaAsync(Convert.ToInt32(id));
            Console.Write("Asignatura: ");
            Console.WriteLine(s.@return.nombre + " profesor: " + s.@return.profesor.nombre + " grupo: " + s.@return.grupo);
        }

        private static async System.Threading.Tasks.Task consultaProfesor(AcademicoWebServiceClient academicoWebServiceClient)
        {
            Console.WriteLine(" ");
            Console.Write("Inserte el id del profesor: ");
            String id = Console.ReadLine();
            var s = await academicoWebServiceClient.getProfesorAsync(id);
            Console.Write("Profesor: ");
            Console.WriteLine(s.@return.nombre + " cedula: " + s.@return.cedula);
        }



    }
}
