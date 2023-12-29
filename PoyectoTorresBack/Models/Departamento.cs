using System;
using System.Collections.Generic;

namespace PoyectoTorresBack.Models;

public partial class Departamento
{
    public int IdDepartamento { get; set; }

    public string? Departamento1 { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
