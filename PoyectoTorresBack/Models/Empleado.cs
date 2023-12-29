using System;
using System.Collections.Generic;

namespace PoyectoTorresBack.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string? Usuario { get; set; }

    public string? PrimerNombre { get; set; }

    public string? SegundoNombre { get; set; }

    public string? PrimerApellido { get; set; }

    public string? SegundoApellido { get; set; }

    public int? IdDepartamento { get; set; }

    public int? IdCargo { get; set; }

    public string? Email { get; set; }

    public virtual Cargo? IdCargoNavigation { get; set; }

    public virtual Departamento? IdDepartamentoNavigation { get; set; }
}
