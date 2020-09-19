using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

public class Persona{  
    [Key]
    public int PersonaId{ set; get;}

    public string Nombre{set; get;}

    public string Telefono{set; get;}

    public string Direccion{set; get;}

    public string cedula{set; get;}

    public DateTime FechaNacimiento{set; get;}


   

} 