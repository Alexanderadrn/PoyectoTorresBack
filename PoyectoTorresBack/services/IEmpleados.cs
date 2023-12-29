using PoyectoTorresBack.viewmodels;

namespace PoyectoTorresBack.services
{
    public interface IEmpleados
    {
        public List<CatalogoVM> GetAllCargos();
        public List<CatalogoVM> GetAllDepartamentos();
        public List<EmpleadoVM> ObtenerEmpleado();
        public bool setEmpleados(EmpleadoVM empleados);
        public bool putEmpleados(EmpleadoVM empleados);
        public bool deleteEmpleados(int id);
    }
}
