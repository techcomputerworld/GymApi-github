using System;
using System.Collections.Generic;
//using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GymApi.Data;
using GymApi.Data.CustomIdentity;

namespace GymApi.Models
{
    //probaremos a hacerlo con DataAnnotations si vemos problemas pues lo probaré con otros métodos que habia
    /// <summary>
    /// Class Ejercicios == Training en inglés
    /// Es de la base de datos de nuestra REST API.
    /// It's from our REST API database. 
    /// Anotaremos los ejercicios en la base de datos con foto incluso con enlace de un vídeo de como se hace.
    /// 
    /// </summary>
    public class Ejercicios
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
        [Column(TypeName = "text")]
        public string explicacion { get; set; }
        public string foto1 { get; set; }
        public string foto2 { get; set; }
        public string foto3 { get; set; }
        public string video1 { get; set; }
        public string video2 { get; set; }
        public ICollection<Usuarios> usuarios { get; set; }
    }
}
