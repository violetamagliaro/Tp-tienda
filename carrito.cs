using System;
using System.Collections.Generic;

namespace Tp2AAT
{
    class Carrito 
    {
        private List<(Producto producto, int cantidad)> productosCarrito;
    
        public Carrito() {
            productosCarrito = new List<(Producto,int)>();
        }
    
        public void VaciarCarrito() {
            productosCarrito.Clear();
            Console.WriteLine("El carrito se ha vaciado.");
        }
        
        public void MostrarCarrito() {
            if (productosCarrito.Count == 0) {
                Console.WriteLine("El carrito está vacío.");
            } else {
                Console.WriteLine("\nProductos en el carrito:");
                Console.WriteLine("-------------------------------");
                foreach (var productoC in productosCarrito) {
                    Console.WriteLine($"Nombre: {productoC.producto.Nombre}\nPrecio de venta: {productoC.producto.PrecioVenta:C}\nCantidad: {productoC.cantidad}");
                    Console.WriteLine("-------------------------------");
                }
            }
        }
    
        public void AgregarProducto(Tienda tienda, string nombreProducto, int cantidad) {
            Producto producto = tienda.BuscarProductoPorNombre(nombreProducto);

            if (producto == null) {
                Console.WriteLine("El producto no se encuentra en la tienda.");
                return;
            }

            if (cantidad <= 0) {
                Console.WriteLine("La cantidad debe ser mayor que cero.", nameof(cantidad));
                return;
            }

            if (producto.Stock < cantidad) {
                Console.WriteLine($"\nNo hay suficiente stock disponible para agregar al carrito ({producto.Stock} disponibles).");
                return;
            }

            int indice = productosCarrito.FindIndex(p => p.producto.Nombre.Equals(producto.Nombre, StringComparison.OrdinalIgnoreCase));

            if (indice != -1) {
                productosCarrito[indice] = (producto, productosCarrito[indice].cantidad + cantidad);
            } else {
                productosCarrito.Add((producto, cantidad));
            }

            producto.Stock -= cantidad;

            Console.WriteLine($"\nProducto '{producto.Nombre}' agregado al carrito ({cantidad} unidades).");
        }
        
        public int isEmptyCarrito(){
            if(productosCarrito.Count == 0){
                return 0;
            } else {
                return 1;
            }     
        }

        public void EliminarProducto(string nombreProducto) {
            productosCarrito.RemoveAll(i => i.producto.Nombre.Equals(nombreProducto, StringComparison.OrdinalIgnoreCase));
        }

        public float CalcularSubtotal() {
            float subtotal = 0;
            Console.WriteLine("\nCalculando subtotal...\n");

            if (productosCarrito.Count == 0) {
                Console.WriteLine("\nEl carrito está vacío.");
                return subtotal;
            }

            foreach (var productoC in productosCarrito) {
                Console.WriteLine($"Nombre: {productoC.producto.Nombre}\nPrecio de venta: {productoC.producto.PrecioVenta:C}\nCantidad: {productoC.cantidad}");
                Console.WriteLine("-------------------------------");
                subtotal += productoC.producto.PrecioVenta * productoC.cantidad;  
            }
            Console.WriteLine($"Subtotal calculado: {subtotal:C}");
            return subtotal;
        }

    
    }
}
