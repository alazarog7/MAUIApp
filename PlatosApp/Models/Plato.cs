namespace PlatosApp.Models
{
    public class Plato
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public string Ingredientes { get; set; } = string.Empty;
    }

    public static class PlatoExtension
    {
        public static AddOrModifyPlato ToAddOrModifyPlato(this Plato plato)
        {
            return new AddOrModifyPlato
            {
                Nombre = plato.Nombre,
                Precio = plato.Precio,
                Ingredientes = plato.Ingredientes
            };
        }
    }
}
