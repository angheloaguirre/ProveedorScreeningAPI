using System.ComponentModel.DataAnnotations;

namespace ProveedorScreeningAPI.Models
{
    public class Proveedor
    {
        // NOT NULL: El ID siempre es necesario y se autoincrementa
        [Key]
        public int Id { get; set; }

        // NOT NULL: Razón social es fundamental
        [StringLength(200)]  // Limitar el tamaño del texto
        public required string RazonSocial { get; set; }

        [StringLength(200)]  // Nombre comercial es opcional, pero limitamos el tamaño
        public string? NombreComercial { get; set; }

        // NOT NULL: Identificación tributaria es esencial
        [StringLength(11)]  // 11 dígitos para la identificación tributaria
        public required string IdentificacionTributaria { get; set; }

        [StringLength(15)]  // Longitud estándar para un número de teléfono
        public string? Telefono { get; set; }

        //[EmailAddress]  // Validación para correo electrónico
        public string? Correo { get; set; }

        //[Url]  // Validación para una URL de sitio web
        public string? SitioWeb { get; set; }

        [StringLength(500)]  // Limitar la longitud de la dirección física
        public string? Direccion { get; set; }

        // NOT NULL: País es necesario
        [StringLength(100)]  // Limitar el nombre del país
        public required string Pais { get; set; }

        [Range(0, double.MaxValue)]  // Facturación anual debe ser un número positivo
        public decimal? FacturacionAnual { get; set; }

        public DateTime? FechaUltimaEdicion { get; set; }  // Fecha de última edición, opcional

        // Nuevos atributos para listas de alto riesgo:
        public bool? EnListaRiesgo { get; set; }  // Si el proveedor está en alguna lista de alto riesgo

        [StringLength(500)]  // Para almacenar las fuentes de alto riesgo en un texto
        public string? FuentesRiesgo { get; set; }  // Contendrá el nombre de la fuente o fuentes (separadas por coma)
    }
}
