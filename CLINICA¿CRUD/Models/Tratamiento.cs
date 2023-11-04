using System;
using System.Collections.Generic;

namespace CLINICA_CRUD.Models;

public partial class Tratamiento
{
    public int Id { get; set; }

    public string? Tratamiento1 { get; set; }

    public virtual ICollection<RegistroMedico> RegistroMedicos { get; set; } = new List<RegistroMedico>();
}
