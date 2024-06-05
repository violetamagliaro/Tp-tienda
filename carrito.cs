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
                Console.WriteLine("----------------------------");
                foreach (var productoC in productosCarrito) {
                    Console.WriteLine($"Nombre: {productoC.producto.Nombre}\nPrecio de venta: {productoC.producto.PrecioVenta}\nCantidad: {productoC.producto.Cantidad}");
                    Console.WriteLine("----------------------------");
                }
              }
        }
    
        public void AgregarProducto(Producto producto, int cantidad) {
            if (producto == null) {
                Console.WriteLine("El producto no puede ser nulo.");
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

            var productoExistente = productosCarrito.Find(p => p.producto.Nombre.Equals(producto.Nombre, StringComparison.OrdinalIgnoreCase));

            if (productoExistente != default) {
                productoExistente.cantidad += cantidad;
            } else {
                productosCarrito.Add((producto, cantidad));
            }

            producto.Cantidad += cantidad;
            producto.Stock -= cantidad;
            

            Console.WriteLine($"\nProducto '{producto.Nombre}' agregado al carrito ({cantidad} unidades).");
        }

        
        public void EliminarProducto(string nombreProducto) {
            if(productosCarrito.Count == 0){
                Console.WriteLine("El carrito esta vacio, no hay productos para eliminar.");
                return;
            }
            productosCarrito.RemoveAll(i => i.producto.Nombre.Equals(nombreProducto, StringComparison.OrdinalIgnoreCase));
        }
            
        public float CalcularSubtotal() {
            float subtotal = 0;
            foreach (var productoC in productosCarrito) {
                subtotal += productoC.producto.PrecioVenta * productoC.producto.Cantidad;
            }
        return subtotal;
        }
    }
}