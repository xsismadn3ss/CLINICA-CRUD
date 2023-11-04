using System;
using System.Collections.Generic;

namespace CLINICA_CRUD.Models;

public partial class Alergium
{
    public int Id { get; set; }

    public string? Alergia { get; set; }

    public virtual ICollection<RegistroMedico> RegistroMedicos { get; set; } = new List<RegistroMedico>();
}
