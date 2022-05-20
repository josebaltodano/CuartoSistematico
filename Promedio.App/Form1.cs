using Promedio.Aplications.Iservices;
using Promedio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Promedio.App
{
    public partial class Form1 : Form
    {
        public IEstudianteservice estudianteservice;
        private int select = -1;
        public Form1(IEstudianteservice estudianteservice)
        {
            this.estudianteservice = estudianteservice;
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            mostrarpromedio();
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            Estudiante estudiante = new Estudiante
            {
                Nombres = tXTNOMBRE.Text,
                Apellidos = txtapellido.Text,
                Carnet = txtcarnetg.Text,
                Phone = txttelefono.Text,
                Direccion = ricdirrecion.Text,
                Correo = txtemail.Text,
                Matematica = (int)Math.Round(double.Parse(txtmagte.Text)),
                Programacion = (int)Math.Round(double.Parse(txtprogra.Text)),
                Contabilidad = (int)Math.Round(double.Parse(txtconta.Text)),
                Estadistica = (int)Math.Round(double.Parse(xtxtesta.Text))


            };
            estudianteservice.Create(estudiante);
            Clean();
            mostrarpromedio();
        
        }
        private void Clean()
        {
            ricdirrecion.Clear();
            txtapellido.Clear();
            txtcarnetg.Clear();
            txttelefono.Clear();
            txtconta.Clear();
            txtemail.Clear();
            xtxtesta.Clear();
            txtmagte.Clear();
            tXTNOMBRE.Clear();
            txtprogra.Clear();
        }
        private void mostrarpromedio()
        {
            DtRegistro.Rows.Clear();
            foreach(Estudiante estudiante in estudianteservice.GetAll())
            {
                DtRegistro.Rows.Add(estudiante.Id, estudiante.Nombres, estudiante.Apellidos, estudiante.Carnet, estudiante.Phone, estudiante.Direccion, estudiante.Carnet, estudianteservice.calculopromedio(estudiante),
                    estudiante.Matematica, estudiante.Programacion, estudiante.Contabilidad, estudiante.Estadistica);
            }

        }

        private void DtRegistro_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                int id = (int)DtRegistro.Rows[e.RowIndex].Cells[0].Value;
                Estudiante estudiante = estudianteservice.FinById(id);
                select = e.RowIndex;
                mostrarpromedio();

            }
            MessageBox.Show(select.ToString());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(select >= 0)
            {
                int id = (int)DtRegistro.Rows[select].Cells[0].Value;
                Estudiante estudiante = estudianteservice.FinById(id);
                estudianteservice.Delete(estudiante);
                select = -1;
                mostrarpromedio();
                Clean();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrEmpty(txtapellido.Text) && string.IsNullOrEmpty(txtcarnetg.Text) && string.IsNullOrEmpty(txttelefono.Text)
                 && string.IsNullOrEmpty(txtconta.Text) && string.IsNullOrEmpty(txtemail.Text) &&
                string.IsNullOrEmpty(xtxtesta.Text) && string.IsNullOrEmpty(txtmagte.Text) && string.IsNullOrEmpty(tXTNOMBRE.Text) &&
                string.IsNullOrEmpty(txtprogra.Text) && string.IsNullOrEmpty(ricdirrecion.Text))
            {
                MessageBox.Show("Tienes que rellenar todos los formularios.");
                return;
            }
            if (double.Parse(txtmagte.Text) > 100
           || double.Parse(txtconta.Text) > 100
           || double.Parse(xtxtesta.Text) > 100
           || double.Parse(txtprogra.Text) > 100)
            {
                MessageBox.Show("Nota del 1 al 100");
                return;
            }
            Estudiante estudiante = new Estudiante
            {
                Id = (int)DtRegistro.Rows[select].Cells[0].Value,
                Nombres = tXTNOMBRE.Text,
                Apellidos = txtapellido.Text,
                Carnet = txtcarnetg.Text,
                Phone = txttelefono.Text,
                Direccion = ricdirrecion.Text,
                Correo = txtemail.Text,
                Matematica = (int)Math.Round(double.Parse(txtmagte.Text)),
                Programacion = (int)Math.Round(double.Parse(txtprogra.Text)),
                Contabilidad = (int)Math.Round(double.Parse(txtconta.Text)),
                Estadistica = (int)Math.Round(double.Parse(xtxtesta.Text))
            };
            this.estudianteservice.Update(estudiante);
            mostrarpromedio();
            Clean();
        }

        private void DtRegistro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id = (int)DtRegistro.Rows[e.RowIndex].Cells[0].Value;
                Estudiante estudiante = estudianteservice.FinById(id);
                select = e.RowIndex;
                mostrarpromedio();

            }
            
        }
    }
}
