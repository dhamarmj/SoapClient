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
            Console.WriteLine("Hello World!");


            AcademicoWebServiceClient academicoWebServiceClient = new AcademicoWebServiceClient();

            var a = showStudentsAsync(academicoWebServiceClient);
            Task.WaitAll(a);
            var b = consultAsignatura(academicoWebServiceClient);
            Task.WaitAll(b);
            var c = consultaProfesor(academicoWebServiceClient);
            Task.WaitAll(c);


            Console.ReadKey();
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
