using System;
using System.Collections.Generic;

namespace CLINICA_CRUD.Models;

public partial class RegistroMedico
{
    public int Id { get; set; }

    public int? IdPaciente { get; set; }

    public int? IdDiscapacidad { get; set; }

    public int? IdAlergia { get; set; }

    public int? IdEnfermedad { get; set; }

    public int? IdTratamiento { get; set; }

    public int? IdAlergiaNavigationId { get; set; }

    public int? IdDiscapacidadNavigationId { get; set; }

    public int? IdEnfermedadNavigationId { get; set; }

    public int? IdPacienteNavigationId { get; set; }

    public int? IdTratamientoNavigationId { get; set; }

    public int? CitasId { get; set; }

    public virtual Cita? Citas { get; set; }

    public virtual Alergium? IdAlergiaNavigation { get; set; }

    public virtual Discapacidad? IdDiscapacidadNavigation { get; set; }

    public virtual Enfermedad? IdEnfermedadNavigation { get; set; }

    public virtual Paciente? IdPacienteNavigation { get; set; }

    public virtual Tratamiento? IdTratamientoNavigation { get; set; }
}
