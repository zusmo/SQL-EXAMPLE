using Ejemplo_sql2.CLASE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejemplo_sql2.Mantenimiento
{
    public partial class Con_Emp : Form
    {
        public Con_Emp()
        {
            InitializeComponent();
        }
        Conector conector = new Conector();
        #region SQL
        string SQL_SEL = @" SELECT e.Codigo, e.Nombre, a.Nombre as Departamentos, Sueldo 
                        FROM Empleados e INNER JOIN Departamentos a ON e.ID_Departamento = a.ID WHERE e.Nombre LIKE '{0}%'";

        #endregion



        private void Con_Emp_Load(object sender, EventArgs e)
        {
            conector.Abrir();
            this.dataGridView1.DataSource = conector.select(string.Format(SQL_SEL, "")).Tables[0];
            conector.cerrar();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            conector.Abrir();
            this.dataGridView1.DataSource = conector.select(string.Format(SQL_SEL, this.textBox1.Text)).Tables[0];
            conector.cerrar();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mantenimiento.NuevoEmpleado forma = new NuevoEmpleado();
            forma.MdiParent = this.MdiParent;
            forma.Show();
        }
    }
}
