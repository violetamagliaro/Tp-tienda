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
            int c = 1;
            Console.WriteLine("\nProductos en la tienda: ");
            Console.WriteLine("----------------------------");
            foreach (Producto prod in productos) {
                if(prod.Stock==0){
                    Console.WriteLine($"{c}.\nNombre: {prod.Nombre}, Precio de venta: {prod.PrecioVenta} No hay stock\n");  
                    Console.WriteLine("----------------------------");
                } else {
                    Console.WriteLine($"{c}.\nNombre: {prod.Nombre}\nPrecio de venta: {prod.PrecioVenta}\nStock: {prod.Stock}");
                    Console.WriteLine("----------------------------");
                }
                c++;
            }
        }

        public void AgregarProducto(Producto producto_tienda, int cantidad) {
            if (producto_tienda == null) {
                Console.WriteLine("El producto no puede ser nulo");
            } else {
                if (cantidad <= 0) {
                    Console.WriteLine("La cantidad debe ser mayor a cero");
                } else {
                    productos.Add(producto_tienda);
                }
            }
        }
    
        public void EliminarProducto(string nombreProducto) {
            productos.RemoveAll(p => p.Nombre.Equals(nombreProducto, StringComparison.OrdinalIgnoreCase));
        }
        
        public Producto SeleccionarProducto(int indice) {
            if (indice < 1 || indice > productos.Count) {
                return null;
            }
            return productos[indice - 1];
        }

        public float Cobrar(float totalCompra, float dineroCliente) {
            if (dineroCliente < totalCompra) {
                Console.WriteLine("Dinero insuficiente para completar la compra.");
                return -1;
            } 
            DineroEnCaja += totalCompra;
            return dineroCliente - totalCompra; 
        }
    }
}