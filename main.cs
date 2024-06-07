using System;

namespace Tp2AAT
{
    class Program
    {
        public static void Main() {
            Tienda tienda = new Tienda();
            Carrito carrito = new Carrito();
            
            while (true) {
                Console.WriteLine("\nMenú:");
                Console.WriteLine("1. Mostrar productos de la tienda");
                Console.WriteLine("2. Agregar producto en la tienda");
                Console.WriteLine("3. Eliminar producto en la tienda");
                Console.WriteLine("4. Agregar producto al carrito");
                Console.WriteLine("5. Ver productos en el carrito");
                Console.WriteLine("6. Eliminar producto del carrito");
                Console.WriteLine("7. Cobrar compra");
                Console.WriteLine("8. Mostrar dinero en caja");
                Console.WriteLine("9. Salir");
                Console.Write("\nElija una opcion: ");
                string opcion = Console.ReadLine();
    
                switch (opcion) {
                    case "1":
                        tienda.MostrarProductos();
                        break;
    
                    case "2":
                        Console.Write("\nIngrese el nombre del producto: ");
                        string nombre = Console.ReadLine();
                        Console.Write("\nIngrese el costo del producto: ");
                        float costo = float.Parse(Console.ReadLine());
                        Console.Write("\nIngrese el stock del producto: ");
                        int stock = int.Parse(Console.ReadLine());   
                         
                        Producto producto = new Producto(nombre, costo, stock);
                        tienda.AgregarProducto(producto,stock);                                     
                        break;
    
                    case "3":
                        Console.Write("\nIngrese el nombre del producto a eliminar: ");
                        string nombreEliminar = Console.ReadLine(); 
                        tienda.EliminarProducto(nombreEliminar);
                        carrito.EliminarProducto(nombreEliminar);
                        break;
                  
                    case "4":
                        tienda.MostrarProductos();
                        Console.Write("\nNombre del producto a agregar al carrito: ");
                        string nombreProd = Console.ReadLine();
                        Producto productoSeleccionado = tienda.BuscarProductoPorNombre(nombreProd);
                        
                        if (productoSeleccionado != null) {
                            Console.Write("\nIngrese la cantidad a agregar: ");
                            int cantidad = int.Parse(Console.ReadLine());
                            carrito.AgregarProducto(tienda, nombreProd, cantidad); 
                        } else {
                            Console.WriteLine("\nProducto no válido.");
                        }
                        break;
    
                    case "5":
                        carrito.MostrarCarrito();
                        break;
    
                    case "6":
                        Console.Write("\nIngrese el nombre del producto que desea eliminar del carrito: ");
                        string nombreEliminarCarrito = Console.ReadLine();
                        carrito.EliminarProducto(nombreEliminarCarrito);
                        break;
    
                    case "7":
                        float subtotal = carrito.CalcularSubtotal();
                        float vuelto = tienda.Cobrar(subtotal);
                        if (vuelto > 0) {
                            carrito.VaciarCarrito();
                        }
                        break;
    
                    case "8":
                        float dinero = tienda.Dinero();
                        Console.WriteLine($"\nDinero en caja: ${dinero:F2}");
                        break;
    
                    case "9":
                        Console.WriteLine("\nSaliendo del programa.");
                        return;
    
                    default:
                        Console.WriteLine("\nOpción no válida, por favor intente de nuevo.");
                        break;
                }
            }
        }  
    }
}
