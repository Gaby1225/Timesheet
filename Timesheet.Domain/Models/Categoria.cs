using Swashbuckle.AspNetCore.Annotations;
using System.ComponentModel.DataAnnotations;

namespace Timesheet.Domain.Models
{
    public class Categoria
    {
        [SwaggerSchema(ReadOnly = true)]
        [Key]
        public int Id { get; set; }
        public string Titulo { get; set; }
    }
}