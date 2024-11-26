namespace ProyectoPortafolioRichard.Models
{
    public class Project
    {
        public int Id { get; set; }
        public required string Titulo { get; set; }
        public required string Descripcion { get; set; }
        public required string ImagenUrl { get; set; }
        public required string LinkDemo { get; set; }
    }
}
