using System;

namespace Tp2AAT
{
    public class Producto
    {
        public string Nombre { get; set; }
        private float Costo { get; set; }
        public float PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int Cantidad { get; set; }

        public Producto(string nombre, float costo, int stock) {
            
            if (string.IsNullOrWhiteSpace(nombre)) {
                Console.WriteLine("Agreguele nombre al producto");
                return; 
            }
            
            if (costo <= 0) {
                Console.WriteLine("El costo debe ser positivo");
                return;
            }

            if (stock < 0) {
                Console.WriteLine("El stock no puede ser negativo");
                return;
            }
            
            Nombre = nombre;
            Costo = costo;
            PrecioVenta = costo + (costo * 0.3f);
            Stock = stock;
            Cantidad = 0;
        }

        public void ReducirStock(int cantidad) {
            if (cantidad > Stock) {
                Console.WriteLine("No hay stock");
            } else {
            Stock -= cantidad;
            }
        }
    }
}

