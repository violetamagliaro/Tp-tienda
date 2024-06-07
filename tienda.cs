using System;
using System.Collections.Generic;

namespace Tp2AAT
{
    public class Tienda
    {
        public List<Producto> productos { get; private set; }
        public float DineroEnCaja { get; private set; }

        public Tienda() {
            productos = new List<Producto>();
            DineroEnCaja = 0.0f;
        }


        public void MostrarProductos() {
            Console.WriteLine("\nProductos en la tienda: ");
            Console.WriteLine("-------------------------------");
            foreach (Producto prod in productos) {
                if(prod.Stock==0){
                    Console.WriteLine($"Nombre: {prod.Nombre}\nPrecio de venta: {prod.PrecioVenta:C}\nNo hay stock");  
                    Console.WriteLine("-------------------------------");
                } else {
                    Console.WriteLine($"Nombre: {prod.Nombre}\nPrecio de venta: {prod.PrecioVenta:C}\nStock: {prod.Stock}");
                    Console.WriteLine("-------------------------------");
                }
            }
        }

        public void AgregarProducto(Producto producto_tienda, int cantidad) {
            if (producto_tienda == null) {
                Console.WriteLine("El producto no puede ser nulo");
                return;
            }
            
            if (cantidad <= 0) {
                Console.WriteLine("La cantidad debe ser mayor a cero");
                return;
            } 

            var productoExistente = productos.Find(p => p.Nombre.Equals(producto_tienda.Nombre, StringComparison.OrdinalIgnoreCase));
    
            if (productoExistente != null) {
                productoExistente.Stock += cantidad;
                productoExistente.PrecioVenta = producto_tienda.PrecioVenta;
                Console.WriteLine($"\nSe han agregado {cantidad} unidades del producto '{producto_tienda.Nombre}'.");
            } else {
                producto_tienda.Stock = cantidad; 
                productos.Add(producto_tienda);
                Console.WriteLine($"\nSe ha agregado el producto '{producto_tienda.Nombre}' con un stock de {cantidad} unidades.");
            }
        }
    
        public void EliminarProducto(string nombreProducto) {
            productos.RemoveAll(p => p.Nombre.Equals(nombreProducto, StringComparison.OrdinalIgnoreCase));
        }

        public Producto BuscarProductoPorNombre(string nombre)
        {
            return productos.Find(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        }
        

        public float Cobrar(float totalCompra) {
            Console.Write("Ingrese la cantidad de dinero con la que va a pagar: ");
            float dineroCliente = float.Parse(Console.ReadLine());

            if (dineroCliente < totalCompra) {
                Console.WriteLine("Dinero insuficiente para completar la compra.");   
                return 0;
            } else {
                DineroEnCaja += totalCompra;
                float vuelto = dineroCliente - totalCompra;
                Console.WriteLine($"Su vuelto es: {vuelto:C}");
                Console.WriteLine($"Dinero en caja: {DineroEnCaja:C}");
                return vuelto;
            } 
        }

    }
}