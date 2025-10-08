using System;

class Program
{
    static void Main()
    {

        string[] catalogo = { "A", "B", "C", "D", "E"};
        double[] precios = { 10.0, 15.0, 20.0, 25.0, 30.0 };
        int[,] registros = new int[50, 3];
        int contador = 0;
        int opcion = 0;
        do
        {
            Console.WriteLine("\n1. Registrar evento");
            Console.WriteLine("2. Mostrar registros");
            Console.WriteLine("3. Calcular total");
            Console.WriteLine("4. Salir");

            Console.Write("Seleccione una opción: ");
            opcion = Convert.ToInt32(Console.ReadLine());  // <-- lectura de opción

            switch (opcion)
            {
                case 1: RegistrarEvento(registros, catalogo, precios, ref contador); break;
                case 2: MostrarRegistros(registros, catalogo, contador); break;
                case 3: CalcularTotal(registros, precios, contador); break;
                case 4: Console.WriteLine("Saliendo del programa..."); break;
                default: Console.WriteLine("Opción inválida, intente de nuevo."); break;
            }

        } while (opcion != 4);  // <-- salir cuando la opción sea 4
    }
    static void CalcularTotal(int[,] matriz, double[] precios, int contador)
    {
        double total = 0;

        for (int i = 0; i < contador; i++)
        {
            int pos = matriz[i, 0];          // posición del ítem en el vector catalogo/precios
            int cantidad = matriz[i, 1];     // cantidad registrada
            total += cantidad * precios[pos]; // cálculo: cantidad * precio del item
        }

        Console.WriteLine("Total de todos los eventos: $" + total);
    }

    static void RegistrarEvento(int[,] matriz, string[] catalogo, double[] precios, ref int contador) //se agrega ref para pasar por referencia
    {
    string codigo;
    Console.Write("Ingrese codigo (ej: A, B, C...): ");
    codigo = Console.ReadLine();

    int pos = -1;
    for (int i = 0; i < catalogo.Length; i++) //se cambia < por <= para recorrer todo el arreglo
        {
    
        if (catalogo[i] == codigo)
            {               //Se arregla identacion
                pos = i;
                break; //se anade break para salir del ciclo una vez encontrado
            }


         }   

    if (pos ==-1) //se agrega ==
        Console.WriteLine("Codigo no encontrado");
    else
    {
        Console.Write("Cantidad: "); // se borra dolbe Console.Write("Cantidad: ");
        double cantidad = Convert.ToDouble(Console.ReadLine());
        matriz[contador, 0] = pos;
        matriz[contador, 1] = (int)cantidad;
        matriz[contador, 2] = 1;
        contador++;
        }
    }

                
        static void MostrarRegistros(int[,] matriz, string[] catalogo, int contador)
        {
            for (int i = 0; i < contador; i++)
            {
            Console.WriteLine("Item: " + catalogo[matriz[i, 0]] + //se cambia solo muestra el código del item, no la cantidad ni el campo “registrado”
                              ", Cantidad: " + matriz[i, 1] +
                              ", Registrado: " + matriz[i, 2]);

        }
    }
}