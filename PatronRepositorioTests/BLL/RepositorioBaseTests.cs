using Microsoft.VisualStudio.TestTools.UnitTesting;
using PatronRepositorio.BLL;
using PatronRepositorio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronRepositorio.BLL.Tests
{
    [TestClass()]
    public class RepositorioBaseTests
    {
        [TestMethod()]
        public void RepositorioBaseTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void BuscarTest()
        {
            RepositorioBase<Empleados> Metodos = new RepositorioBase<Empleados>();
            Empleados empleado = new Empleados();
            empleado = Metodos.Buscar(1);
            Assert.AreEqual(empleado != null, true);
        }

        [TestMethod()]
        public void DisposeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void EliminarTest()
        {
            bool paso;
            RepositorioBase<Empleados> Metodos = new RepositorioBase<Empleados>();
            Empleados empleado = new Empleados();
            empleado.EmpleadoId = 2;

            paso = Metodos.Eliminar(empleado.EmpleadoId);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void GetListTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GuardarTest()
        {
            bool paso;
            RepositorioBase<Empleados> Metodos = new RepositorioBase<Empleados>();
            Empleados empleado = new Empleados();
            empleado.EmpleadoId = 0;
            empleado.Fecha = DateTime.Now;
            empleado.Nombres = "Jose Armando";
            empleado.Apellidos = "Flores";
            empleado.Direccion = "Bomba de Cenovi";
            empleado.Telefono = "809-290-8910";
            empleado.Celular = "829-690-2801";
            empleado.Cedula = "402-1296518-6";
            empleado.Sueldo = 45000;
            empleado.Incentivo = 3000;

            paso = Metodos.Guardar(empleado);
            Assert.AreEqual(paso, true);
        }

        [TestMethod()]
        public void ModificarTest()
        {
            bool paso;
            RepositorioBase<Empleados> Metodos = new RepositorioBase<Empleados>();
            Empleados empleado = new Empleados();
            empleado.EmpleadoId = 2;
            empleado.Fecha = DateTime.Now;
            empleado.Nombres = "Jose Armando";
            empleado.Apellidos = "Flores Baldera";
            empleado.Direccion = "Bomba de Cenovi, SFM";
            empleado.Telefono = "809-290-8910";
            empleado.Celular = "829-690-2801";
            empleado.Cedula = "402-1296518-6";
            empleado.Sueldo = 35000;
            empleado.Incentivo = 2000;

            paso = Metodos.Modificar(empleado);
            Assert.AreEqual(paso, true);
        }
    }
}