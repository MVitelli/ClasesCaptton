using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TF_Base.Models
{
    public class Registro
    {
        [Display(Name = "Nombre de usuario")]
        [Required(ErrorMessage="Se requiere nombre de usuario")]
        public string UserName { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Se requiere un nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "Se requiere el apellido")]
        public string Apellido { get; set; }

        [Display(Name = "Dni")]
        [Required(ErrorMessage = "Necesitás documento")]
        [Range(200000,50000000, ErrorMessage="El DNI debe estar entre 200000 y 50000000")]
        public int Dni { get; set; }

        [EmailAddress(ErrorMessage="Ingrese un email válido")]
        [Display(Name = "Email")]
        [Required(ErrorMessage="Se requiere un email")]
        public string UserEmail { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        [StringLength(25, ErrorMessage = "La contraseña es muy corta o muy larga", MinimumLength = 6)]
        [Required(ErrorMessage = "Se requiere un password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Repita su contraseña")]
        [Required(ErrorMessage = "Repita su contraseña")]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
        public string PasswordConfirmation { get; set; }
    }

    public class Login
    {
        [Display(Name = "Nombre de usuario")]
        [Required (ErrorMessage= "Se requiere un usuario")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        [Required(ErrorMessage="Se requiere una contraseña")]
        public string Password { get; set; }

        [Display(Name = "Mantener sesion iniciada")]
        public bool RememberMe { get; set; }
    }
}