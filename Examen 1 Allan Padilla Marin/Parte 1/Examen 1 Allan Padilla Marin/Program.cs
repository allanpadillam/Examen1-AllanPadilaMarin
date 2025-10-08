const int MAX_PRODUCTOS = 10;
const int MAX_TRANSACCIONES = 50;

string[] productos = {
    "Café negro", "Gallo pinto", "Casado con pollo", "Casado con carne",
    "Jugo natural", "Refresco gaseoso", "Empanada de queso",
    "Empanada de frijol", "Sandwich de jamon", "Ensalada de frutas"
};

int[,] transacciones = new int[MAX_TRANSACCIONES, 3]; // [producto, cantidad, estado]
int contador = 0;
int opcion;

do
{
    opcion = Menu();
    switch (opcion)
    {
        case 1:
            MostrarCatalogo(productos);
            break;

        case 2:
            MostrarCatalogo(productos);
            Console.Write("\nIngrese el índice del producto: ");
            int indice = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese la cantidad: ");
            int cantidad = int.Parse(Console.ReadLine());
            RegistrarPedido(transacciones, ref contador, indice, cantidad, 1);
            Console.WriteLine("Pedido registrado correctamente.\n");
            break;

        case 3:
            MostrarTransacciones(productos, transacciones, contador);
            break;

        case 4:
            MostrarTransacciones(productos, transacciones, contador);
            Console.Write("\nIngrese el número de transacción a modificar: ");
            int num = int.Parse(Console.ReadLine());
            Console.Write("Ingrese el nuevo estado (0=Cancelado, 1=Activo, 2=Finalizado): ");
            int nuevoEstado = int.Parse(Console.ReadLine());
            CambiarEstado(transacciones, contador, num, nuevoEstado);
            break;

        case 5:
            Console.WriteLine("Saliendo del sistema...");
            break;

        default:
            Console.WriteLine("Opción inválida.");
            break;
    }

} while (opcion != 5);

// FUNCIONES 

int Menu()
{
    Console.WriteLine("\n------------------ SODA AsoHispa -------------------");
    Console.WriteLine("1. Mostrar catálogo de productos");
    Console.WriteLine("2. Registrar pedido");
    Console.WriteLine("3. Ver pedidos registrados");
    Console.WriteLine("4. Cambiar estado de pedido");
    Console.WriteLine("5. Salir");
    Console.Write("Seleccione una opción: ");
    return int.Parse(Console.ReadLine());
}

void MostrarCatalogo(string[] productos)
{
    Console.WriteLine("\n--------------- Catálogo de Productos --------------------");
    for (int i = 0; i < MAX_PRODUCTOS; i++)
    {
        Console.WriteLine($"{i}. {productos[i]}");
    }
}

void RegistrarPedido(int[,] matriz, ref int contador, int indiceProducto, int cantidad, int estado)
{
    matriz[contador, 0] = indiceProducto;
    matriz[contador, 1] = cantidad;
    matriz[contador, 2] = estado;
    contador++;
}

void MostrarTransacciones(string[] productos, int[,] matriz, int contador)
{
    Console.WriteLine("\n-------------- Transacciones registradas -------------");
    for (int i = 0; i < contador; i++)
    {
        string estado = matriz[i, 2] switch
        {
            0 => "Cancelado",
            1 => "Activo",
            2 => "Finalizado",
            _ => "Desconocido"
        };

        Console.WriteLine($"{i}. Producto: {productos[matriz[i, 0]]} | Cantidad: {matriz[i, 1]} | Estado: {estado}");
    }
}

void CambiarEstado(int[,] matriz, int contador, int numTransaccion, int nuevoEstado)
{
    if (numTransaccion >= 0 && numTransaccion < contador)
    {
        matriz[numTransaccion, 2] = nuevoEstado;
        Console.WriteLine("Estado actualizado correctamente.\n");
    }
    else
    {
        Console.WriteLine("Número de transacción inválido.\n");
    }
}
