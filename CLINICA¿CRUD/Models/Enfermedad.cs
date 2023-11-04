using System;
using System.Collections.Generic;

namespace CLINICA_CRUD.Models;

public partial class Enfermedad
{
    public int Id { get; set; }

    public string? Enfermedad1 { get; set; }

    public virtual ICollection<RegistroMedico> RegistroMedicos { get; set; } = new List<RegistroMedico>();
}
