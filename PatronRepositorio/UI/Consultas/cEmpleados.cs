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

namespace PatronRepositorio.UI.Consultas
{
    public partial class cEmpleados : Form
    {
        public cEmpleados()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, EventArgs e)
        {
            RepositorioBase<Empleados> Metodos = new RepositorioBase<Empleados>();
            var listado = new List<Empleados>();
            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0://Todo
                        listado = Metodos.GetList(p => true);
                        break;
                    case 1://ID
                        int id = Convert.ToInt32(CriterioTextBox.Text);
                        listado = Metodos.GetList(p => p.EmpleadoId == id);
                        break;
                    case 2://Nombre
                        listado = Metodos.GetList(p => p.Nombres.Contains(CriterioTextBox.Text));
                        break;
                    case 3://Perdido
                        decimal sueldo = Convert.ToDecimal(CriterioTextBox.Text);
                        listado = Metodos.GetList(p => p.Sueldo == sueldo);
                        break;
                    case 4://Pronostico
                        decimal incentivo = Convert.ToDecimal(CriterioTextBox.Text);
                        listado = Metodos.GetList(p => p.Incentivo == incentivo);
                        break;
                }
                listado = listado.Where(x => x.Fecha.Date >= DesdeDateTimePicker.Value.Date && x.Fecha.Date <= HastaDateTimePicker.Value.Date).ToList();
            }
            else
            {
                listado = Metodos.GetList(p => true);
            }
            ConsultaDataGridView.DataSource = null;
            ConsultaDataGridView.DataSource = listado;
        }
    }
}
