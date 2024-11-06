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
    public partial class NuevoEmpleado : Form
    {
        public NuevoEmpleado()
        {
            InitializeComponent();
        }

        Conector con_new = new Conector();
        #region SQL
        string SQL_INS = @"INSERT INTO Empleados ( Nombre, ID_Departamento, Sueldo)
                            VALUES( '{0}', {1},{2}) ";
        string SQL_SEL = @"SELECT ID, Nombre FROM Departamentos";
        #endregion

        private void NuevoEmpleado_Load(object sender, EventArgs e)
        {
            //Esto permite que se asigne el id en vez del nombre en la base de datos para que haga match
            this.comboBox1.DisplayMember = "Nombre";
            this.comboBox1.ValueMember = "ID";

            //clasico select 
            con_new.Abrir();
            this.comboBox1.DataSource = con_new.select(SQL_SEL).Tables[0];
            con_new.cerrar();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con_new.Abrir();
            con_new.insert(string.Format(SQL_INS, this.txtNombre.Text, this.comboBox1.SelectedValue.ToString(), this.numericUpDown1.Value));
            con_new.cerrar();

            MessageBox.Show("Empleado Agregado");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
