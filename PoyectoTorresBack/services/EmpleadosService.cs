using PoyectoTorresBack.Models;
using PoyectoTorresBack.viewmodels;

namespace PoyectoTorresBack.services
{
    public class EmpleadosService : IEmpleados
    {
        private UsuariosContext _context;
        public List<CatalogoVM> GetAllCargos()
        {
            List<CatalogoVM> Lista = new List<CatalogoVM>();

            var consulta = _context.Cargos.ToList();
            foreach (var item in consulta)
            {
                CatalogoVM cargo = new CatalogoVM
                {
                    descripcion = item.Cargo1,
                    id = item.IdCargo
                };
                Lista.Add(cargo);
            }

            return Lista;
        }
        public List<CatalogoVM> GetAllDepartamentos()
        {
            List<CatalogoVM> Lista = new List<CatalogoVM>();

            var consulta = _context.Departamentos.ToList();
            foreach (var item in consulta)
            {
                CatalogoVM cargo = new CatalogoVM
                {
                    descripcion = item.Departamento1,
                    id = item.IdDepartamento
                };
                Lista.Add(cargo);
            }

            return Lista;
        }

        public EmpleadosService(UsuariosContext context)
        {
            this._context = context;
        }
        public List<EmpleadoVM> ObtenerEmpleado()
        {
           List<EmpleadoVM> listEmpleados =new List<EmpleadoVM>();
            var empleados =(from usuarios in _context.Empleados
                            join departamentos in _context.Departamentos
                            on usuarios.IdDepartamento equals departamentos.IdDepartamento
                            join cargos in _context.Cargos
                            on usuarios.IdCargo equals cargos.IdCargo
                            where usuarios.IdEmpleado !=0
                            select new
                            {
                                usuarios.IdEmpleado,
                                usuarios.PrimerNombre,
                                usuarios.SegundoNombre,
                                usuarios.PrimerApellido,
                                usuarios.SegundoApellido,
                                email=usuarios.Email,
                                usuario = usuarios.Usuario,
                                idCargo=cargos.IdCargo,
                                NombrCargo=cargos.Cargo1,
                                idDepartamento=departamentos.IdDepartamento,
                                NombreDepartamento=departamentos.Departamento1


                            }
                            ).ToList();
            foreach(var empleado in empleados)
            {
                EmpleadoVM registro = new EmpleadoVM
                {
                    idEmpleados=empleado.IdEmpleado,
                    primernombre=empleado.PrimerNombre,
                    segundonombre=empleado.SegundoNombre,
                    primerapellido=empleado.PrimerApellido,
                    segundoapellido=empleado.SegundoApellido,
                    email=empleado.email,
                    usuario=empleado.usuario,
                    departamento=empleado.NombreDepartamento,
                    iddepartamento=empleado.idDepartamento,
                    idcargo=empleado.idCargo,
                    cargo=empleado.NombrCargo
                                 
                                     
                };
                listEmpleados.Add(registro);
            }
            return listEmpleados;
        }

        public bool setEmpleados(EmpleadoVM empleados)
        {
            bool registrado = false;

            try
            {
                Empleado empleadoBD = new Empleado();
                empleadoBD.Usuario = empleados.usuario;
                empleadoBD.PrimerNombre = empleados.primernombre;
                empleadoBD.SegundoNombre = empleados.segundonombre;
                empleadoBD.PrimerApellido = empleados.primerapellido;
                empleadoBD.SegundoApellido = empleados.segundoapellido;
                empleadoBD.IdDepartamento = empleados.iddepartamento;
                empleadoBD.IdCargo=empleados.idcargo;
                empleadoBD.Email = empleados.email;

                _context.Empleados.Add(empleadoBD);
                _context.SaveChanges();
                registrado = true;
            }
            catch (Exception)
            {
                registrado = false;
            }
            return registrado;
        }

        public bool putEmpleados(EmpleadoVM empleados)
        {
            bool registrado = false;
            try
            {
                var putEmpleados = _context.Empleados.Where(X => X.IdEmpleado == empleados.idEmpleados).FirstOrDefault();
                putEmpleados.Usuario = empleados.usuario;
                putEmpleados.PrimerNombre = empleados.primernombre;
                putEmpleados.SegundoNombre = empleados.segundonombre;
                putEmpleados.PrimerApellido = empleados.primerapellido;
                putEmpleados.SegundoApellido = empleados.segundoapellido;
                putEmpleados.IdDepartamento = empleados.iddepartamento;
                putEmpleados.IdCargo= empleados.idcargo;
                putEmpleados.Email=empleados.email;
                _context.SaveChanges();
                registrado = true;
            }
            catch
            {
                registrado = false;
            }
            return registrado;
        }

        public bool deleteEmpleados(int id)
        {
            bool registrado = false;
            var deleteEmpleados = _context.Empleados.Where(X => X.IdEmpleado == id).FirstOrDefault();
            try
            {
                _context.Empleados.Remove(deleteEmpleados);
                _context.SaveChanges();
                registrado = true;
            }
            catch
            {
                registrado = false;
            }
            return registrado;
        }
    }
}
