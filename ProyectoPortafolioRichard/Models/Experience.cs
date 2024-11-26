namespace ProyectoPortafolioRichard.Models
{
    public class Experience
    {
        public int Id { get; set; }
        public required string Puesto { get; set; }
        public required string Empresa { get; set; }
        public required string Descripcion { get; set; }
        public required string Periodo { get; set; }
    }
}
