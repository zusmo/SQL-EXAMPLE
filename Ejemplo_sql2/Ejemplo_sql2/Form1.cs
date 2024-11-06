namespace Ejemplo_sql2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void empleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mantenimiento.Con_Emp forma = new Mantenimiento.Con_Emp();
            forma.MdiParent = this;
            forma.Show();
        }
    }
}
