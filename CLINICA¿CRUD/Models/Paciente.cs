using System;
using System.Collections.Generic;

namespace CLINICA_CRUD.Models;

public partial class Paciente
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apelido { get; set; }

    public int? Edad { get; set; }

    public string? Sexo { get; set; }

    public string? NombreResponsable { get; set; }

    public string? ApellidoResponsable { get; set; }

    public int? Telefono { get; set; }

    public int? TelefonoResponsable { get; set; }

    public virtual ICollection<RegistroMedico> RegistroMedicos { get; set; } = new List<RegistroMedico>();
}
