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
using System.Linq;
using Registro_Persona.Entidad;
using Registro_Persona.BLL;

namespace Registro_Persona.UI.ConsultarPersona
{
    /// <summary>
    /// Interaction logic for cPersona.xaml
    /// </summary>
    public partial class cPersona : Window
    {
        public cPersona()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Personas>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                listado = PersonasBLL.GetList(p => p.Nombres.Contains(CriterioTextBox.Text));
            }
            else
            {
                listado = PersonasBLL.GetList(p => true);
            }

            ConsultaDataGrid.ItemsSource = listado;
        }
    }
}
