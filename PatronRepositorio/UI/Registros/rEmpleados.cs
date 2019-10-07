using PatronRepositorio.BLL;
using PatronRepositorio.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatronRepositorio.UI.Registros
{
    public partial class rEmpleados : Form
    {
        public rEmpleados()
        {
            InitializeComponent();
        }

        private void REmpleados_Load(object sender, EventArgs e)
        {

        }

        private void Limpiar()
        {
            MyErrorProvider.Clear();
            IDNumericUpDown.Value = 0;
            FechaDateTimePicker.Text = string.Empty;
            NombresTextBox.Text = string.Empty;
            ApellidosTextBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;
            TelefonoMaskedTextBox.Text = string.Empty;
            CelularMaskedTextBox.Text = string.Empty;
            CedulaMaskedTextBox.Text = string.Empty;
            SueldoTextBox.Text = string.Empty;
            IncentivoTextBox.Text = string.Empty;
        }

        private Empleados LlenaClase()
        {
            Empleados empleado = new Empleados();
            empleado.EmpleadoId = Convert.ToInt32(IDNumericUpDown.Value);
            empleado.Fecha = FechaDateTimePicker.Value;
            empleado.Nombres = NombresTextBox.Text;
            empleado.Apellidos = ApellidosTextBox.Text;
            empleado.Direccion = DireccionTextBox.Text;
            empleado.Telefono = TelefonoMaskedTextBox.Text;
            empleado.Celular = CelularMaskedTextBox.Text;
            empleado.Cedula = CedulaMaskedTextBox.Text;
            empleado.Sueldo = Convert.ToDecimal(SueldoTextBox.Text);
            empleado.Incentivo = Convert.ToDecimal(IncentivoTextBox.Text);
           
            return empleado;
        }

        private void LlenaCampo(Empleados empleado)
        {
            IDNumericUpDown.Value = empleado.EmpleadoId;
            FechaDateTimePicker.Value = empleado.Fecha;
            NombresTextBox.Text = empleado.Nombres;
            ApellidosTextBox.Text = empleado.Apellidos;
            DireccionTextBox.Text = empleado.Direccion;
            TelefonoMaskedTextBox.Text = empleado.Telefono;
            CelularMaskedTextBox.Text = empleado.Celular;
            CedulaMaskedTextBox.Text = empleado.Cedula;           
            SueldoTextBox.Text = Convert.ToString(empleado.Sueldo);
            IncentivoTextBox.Text = Convert.ToString(empleado.Incentivo);
            
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            RepositorioBase<Empleados> Metodos = new RepositorioBase<Empleados>();
            Empleados empleado = Metodos.Buscar((int)IDNumericUpDown.Value);
            return (empleado != null);
        }

        private bool Validar()
        {
            bool paso = true;
            if (string.IsNullOrWhiteSpace(NombresTextBox.Text))
            {
                MyErrorProvider.SetError(NombresTextBox, "Campo Invalido.");
                NombresTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(ApellidosTextBox.Text))
            {
                MyErrorProvider.SetError(ApellidosTextBox, "Campo Invalido.");
                ApellidosTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(DireccionTextBox.Text))
            {
                MyErrorProvider.SetError(DireccionTextBox, "Campo Invalido.");
                DireccionTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(TelefonoMaskedTextBox.Text.Replace("-","")))
            {
                MyErrorProvider.SetError(TelefonoMaskedTextBox, "Campo Invalido.");
                TelefonoMaskedTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(CelularMaskedTextBox.Text.Replace("-", "")))
            {
                MyErrorProvider.SetError(CelularMaskedTextBox, "Campo Invalido.");
                CelularMaskedTextBox.Focus();
                paso = false;
            }

            if (string.IsNullOrWhiteSpace(CedulaMaskedTextBox.Text.Replace("-", "")))
            {
                MyErrorProvider.SetError(CedulaMaskedTextBox, "Campo Invalido.");
                CedulaMaskedTextBox.Focus();
                paso = false;
            }

            if (Convert.ToDecimal(SueldoTextBox.Text) < 0 || string.IsNullOrWhiteSpace(SueldoTextBox.Text))
            {
                MyErrorProvider.SetError(SueldoTextBox, "Campo Invalido.");
                SueldoTextBox.Focus();
                paso = false;
            }

            if (Convert.ToDecimal(IncentivoTextBox.Text) < 0 || string.IsNullOrWhiteSpace(IncentivoTextBox.Text))
            {
                MyErrorProvider.SetError(IncentivoTextBox, "Campo Invalido.");
                IncentivoTextBox.Focus();
                paso = false;
            }

            return paso;
        }
        private void NuevoButton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Empleados> Metodos = new RepositorioBase<Empleados>();
            bool paso = false;
            Empleados empleado;

            if (!Validar())
                return;
            empleado = LlenaClase();

            if (IDNumericUpDown.Value == 0)
                paso = Metodos.Guardar(empleado);
            else
            {
                if (!ExisteEnLaBaseDeDatos())
                {
                    MessageBox.Show("No se puede modificar un empleado que no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                paso = Metodos.Modificar(empleado);
            }

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Guardado!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("No se pudo guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Empleados> Metodos = new RepositorioBase<Empleados>();
            int id;
            int.TryParse(IDNumericUpDown.Text, out id);

            Limpiar();
            if (Metodos.Buscar(id) != null)
            {
                if (Metodos.Eliminar(id))
                {
                    MessageBox.Show("Eliminado!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else
            {
                MessageBox.Show("No se puede eliminar un empleado que no existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Empleados> Metodos = new RepositorioBase<Empleados>();
            Empleados empleado = new Empleados();
            int id;
            int.TryParse(IDNumericUpDown.Text, out id);

            Limpiar();

            empleado = Metodos.Buscar(id);
            if (empleado != null)
            {
                LlenaCampo(empleado);
            }
            else
            {
                MessageBox.Show("Empleado no encontrado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
