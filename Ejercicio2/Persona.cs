using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ejercicio2
{
    public class Persona
    {
        private string Nombre { get; set;}
        private int Edad { get; set; }
        private string Dni { get; set; }
        private char Sexo { get; set; }
        private double Peso { get; set; }
        private double Altura { get; set; }

        //Constante por defecto para el sexo.
        private const char SexoPorDefecto = 'H';

        //Constructor  Simple por defecto
        public void SetNombre(string nombre)
        {
            this.Nombre = nombre;
        }

        public void SetEdad(int edad)
        {
            this.Edad = edad;
        }

        public void SetSexo(char sexo)
        {
            this.Sexo = sexo;
        }
        public void SetAltura(double altura)
        {
            this.Altura = altura;
        }
        public void SetPeso(double peso)
        {
            this.Peso = peso;
        }
        public Persona()
        {
            Nombre = "";
            Edad = 0;
            Dni = null;
            Sexo = SexoPorDefecto;
            Peso = 0;
            Altura = 0;
        }
        public Persona(string nombre,int edad,char sexo)
        {
            Nombre = nombre;
            Edad= edad;
            Dni = null;
            Sexo = ComprobarSexo(sexo);
            Peso = 76;
            Altura = 1.73;
        }

        public Persona(string nombre,int edad,char sexo,double peso,double altura,string dni)
        {
            Nombre= nombre;
            Edad = edad;
            Dni = dni;
            Sexo = ComprobarSexo(sexo);
            Peso = peso;
            Altura = altura;
        }

        private const int peso_inferior = -1;
        private const int peso_normal = 0;
        private const int peso_superior = 1;

        public int CalcularIMC()
        {
            double altura =Altura;
            double peso = Peso;

            double IMC = peso / (altura * altura);


            if (IMC < 20)
            {
                return peso_inferior; 
            }
            else if (IMC>=20 && IMC<=25)
            {
                return peso_normal;
            }
            else
            {
                return peso_superior;
            }
        }
        public bool EsMayorDeEdad()
        {
           int edad = Edad;
            return edad >= 18;
        }

        private char ComprobarSexo(char sexo)
        {
            if (sexo=='H' || sexo == 'h' ||sexo == 'M'|| sexo == 'm')
            {
                
                return char.ToUpper(sexo); //Es correcto y lo convierte a mayuscula tmb.
            }
            else
            {
                MessageBox.Show("Sexo fue incorreto, se establecera por defecto el sexo en H.");
                return SexoPorDefecto;
            }
        }

        public string ValorObjeto()
        {
           
            
            string information = $"Nombre:{Nombre}\n" +
                                 $"Edad:{Edad}\n" +
                                 $"DNI:{Dni=GeneraDNI()}\n" +
                                 $"Sexo:{Sexo}\n" +
                                 $"Peso:{Peso}\n" +
                                 $"Altura{Altura}\n";
            return information;
        }

        private int GenerarNumeroAleatorio()
        {
            Random rnd = new Random();
            return rnd.Next(10000000, 99999999);
        }

        private char CalcularLetraDNI(int numero)
        {
            //busque en googl y  este es el codigo que se utiliza para los dni y que tengan un numero asociado.

            string letrasDNI = "TRWAGMYFPDXBNJZSQVHLCKE";

            //calcular el indice de la letra correspondiente al numero de DNI

            int indice = numero % 23;

            //DEVUELVE la letra correspondiente.
            return letrasDNI[indice];
        }

        private string GeneraDNI()
        {
            //PASO 1: GENERAR numero aleatorio de 8 cifras
            int numeroAleatorio = GenerarNumeroAleatorio();
            //paso 2: Con el dni ya creado, buscamos la letra correspondiente.
            char letraDNI=CalcularLetraDNI(numeroAleatorio);

            string dniCompleto = $"{numeroAleatorio}-{letraDNI}";

            return dniCompleto;
        }

    }
}
