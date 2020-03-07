using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Registro_Persona.Entidad;
using Registro_Persona.BLL;

namespace Registro_Persona.UI.RegistrarPersona
{
    /// <summary>
    /// Interaction logic for rPersona.xaml
    /// </summary>
    public partial class rPersona : Window
    {
        Personas persona = new Personas();
        public rPersona()
        {
            InitializeComponent();
            this.DataContext = persona;

            PersonaIdTextBox.Text = "0";
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = false;

            if (!validar())
                return;

            if(persona.PersonaId== 0)
            {
                paso = PersonasBLL.Guardar(persona);
            }
            else
            {
                if(existeEnLaBaseDeDatos())
                {
                    paso = PersonasBLL.Modificar(persona);
                }
                else
                {
                    MessageBox.Show("No se puede modificar una persona que no existe");
                    return;
                }
            }

            if(paso)
            {
                limpiar();
                MessageBox.Show("Guardado");
            }
            else
            {
                MessageBox.Show("No se pudo guardar");
            }
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            int id = 0;
            int.TryParse(PersonaIdTextBox.Text, out id);

            Personas personaAnterior = PersonasBLL.Buscar(id);

            if(personaAnterior!=null)
            {
                persona = personaAnterior;
                reCargar();
            }
            else
            {
                MessageBox.Show("Persona no encontrada");
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            int id = 0;
            int.TryParse(PersonaIdTextBox.Text, out id);

            if(PersonasBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado");
                limpiar();
            }
            else
            {
                MessageBox.Show("No se pudo eliminar una persona que no existe");
            }
        }

        private void limpiar()
        {
            PersonaIdTextBox.Text = "0";
            NombresTextBox.Text = string.Empty;
        }

        private bool existeEnLaBaseDeDatos()
        {
            Personas personaAnterior = PersonasBLL.Buscar(persona.PersonaId);

            return persona != null;
        }

        private void reCargar()
        {
            this.DataContext = null;
            this.DataContext = persona;
        }

        private bool validar()
        {
            bool paso = true;

            if (string.IsNullOrWhiteSpace(PersonaIdTextBox.Text))
                paso = false;
            else
            {
                try
                {
                    int i = Convert.ToInt32(PersonaIdTextBox.Text);
                }
                catch(FormatException)
                {
                    paso = false;
                }
            }

            if (string.IsNullOrWhiteSpace(NombresTextBox.Text))
                paso = false;
            else
            {
                foreach (var caracter in NombresTextBox.Text)
                {
                    if (!char.IsLetter(caracter))
                        paso = false;
                }
            }

            if (paso == false)
                MessageBox.Show("Datos invalidos");

            return paso;
        }
    }
}
