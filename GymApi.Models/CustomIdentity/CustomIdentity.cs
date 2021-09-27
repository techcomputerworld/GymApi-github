using GymApi.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymApi.Models.CustomIdentity
{
    //tabla AspNetRoles
    public class ApplicationRole : IdentityRole<int>
    {
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
        public virtual ICollection<ApplicationRoleClaim> RoleClaims { get; set; }
    }
    //tabla AspNetUserRoles
    public class ApplicationRoleClaim : IdentityRoleClaim<int>
    {
        public virtual ApplicationRole Role { get; set; }
    }
    //esta tabla esta mal
    public class Usuarios : IdentityUser<int>
    {
        //public override int Id { get; set; }
        public virtual ICollection<ApplicationUserClaim> Claims { get; set; }
        public virtual ICollection<ApplicationUserLogin> Logins { get; set; }
        public virtual ICollection<ApplicationUserToken> Tokens { get; set; }
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
        //campo que se verá en la tabla Usuarios como UsuariosID o algo asi
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
        public Ejercicios ejercicios { get; set; }
    }

    //tabla AspNetUsersRole
    public class ApplicationUserRole : IdentityUserRole<int>
    {
        public virtual Usuarios User { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }
    //AspNetUserClaims para decirme que el id estan 
    public class ApplicationUserClaim : IdentityUserClaim<int>
    {
        public virtual Usuarios User { get; set; }
    }

    public class ApplicationUserLogin : IdentityUserLogin<int>
    {
        public virtual Usuarios User { get; set; }
    }

    public class ApplicationUserToken : IdentityUserToken<int>
    {
        public virtual Usuarios User { get; set; }
    }


}
