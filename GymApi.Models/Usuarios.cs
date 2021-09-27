using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApi.Models
{
    public class Usuarios
    {
        [Key]
        public int Id { get; set; }
        public string Email { get; set; }
        //El Password lo suyo es en un hash md5 o Sha1
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        //lo he puesto en mayusculas el DNI por convención 
        public string NIF { get; set; }
        /* Esta sera la cadena donde esta almacenada la imagen dentro de nuestra propia aplicación, esto conlleva que si 
         * borro la imagen, tengo que dejar la cadena esta vacia
         */
        public string Imagen1 { get; set; }
        public string Imagen2 { get; set; }
        public string Imagen3 { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime LastUpdateDateTime { get; set; }
        public Ejercicios ejercicios { get; set; }
    }
}
