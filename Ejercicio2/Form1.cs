using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
          if (VerificarLetras(txtNombre.Text) && VerificarNumeroDecimal(txtAltura.Text))
            {
                string nombre= txtNombre.Text;
                int edad = (int)numEdad.Value;
                char sexo = Convert.ToChar(cbSexo.SelectedItem);
                double peso=(double)numPeso.Value;
                double altura=Convert.ToDouble(txtAltura.Text);
                

                Persona persona1 = new Persona(nombre, edad, sexo, peso,altura,""); //este va al tercer constructor
                Persona persona2 = new Persona(nombre,edad,sexo); // este al 2do
                Persona persona3 = new Persona(); // y esta al 1, que es el simple.

                persona3.SetNombre("Roberto");
                persona3.SetEdad(12);
                persona3.SetSexo('M');
                persona3.SetPeso(150.0);
                persona3.SetAltura(1.85);

                //Obtengo los pesos
                MessageBox.Show($"La persona 1:{ObtenerEstadoPeso(persona1)}", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show($"La persona 2:{ObtenerEstadoPeso(persona2)}", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show($"La persona 3:{ObtenerEstadoPeso(persona3)}", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Si es mayor de edad
                MessageBox.Show($"La persona 1:{(persona1.EsMayorDeEdad())}","Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show($"La persona 2:{(persona2.EsMayorDeEdad())}","Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show($"La persona 3:{(persona3.EsMayorDeEdad())}", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);


                MessageBox.Show($"Informacion Persona 1:\n{persona1.ValorObjeto()}", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MessageBox.Show($"Informacion Persona 2:\n{persona2.ValorObjeto()}", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MessageBox.Show($"Informacion Persona 3:\n{persona3.ValorObjeto()}", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
          else
            {
                MessageBox.Show("Error en la entrada de datos del nombre!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private string ObtenerEstadoPeso(Persona persona)
        {
            int estadoPeso=persona.CalcularIMC();
            switch(estadoPeso)
            {
                case -1:
                    return "Por debajo del peso ideal";

                case 0:
                    return "En su peso ideal";

                 case 1:
                     return "Con sobrepeso";

                default:
                    return "Estado de peso desconocido";
            }
        }

        public static bool VerificarLetras(string linea)
        {
            return Regex.IsMatch(linea, @"^[a-zA-Z]+$");
        }

      
        public static bool VerificarNumeroDecimal(string linea)
        {
            return Regex.IsMatch(linea, @"^\d+\,\d+$");
        }

        //public static bool VerficarNumero(string linea)
        //{
        //    return Regex.IsMatch(linea, @"^[0,0-9,9]+$");
        //}

    }
}
