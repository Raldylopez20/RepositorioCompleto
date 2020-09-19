using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RepositorioCompleto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Persona persona = new Persona();
        public MainWindow()
        {
            InitializeComponent(); 
            DataContext = persona; 
        }

      private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var Personita = PersonaBLL.Buscar(Utilidades.ToInt(PersonaIdTextBox.Text) ); // todo 

            if(Personita != null)
            {
                persona = Personita;
            }
            else
            {
               this.persona =new Persona(); 
            }
           this.DataContext= this.persona;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Refrescar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            Contexto context = new Contexto();
            if (!Validar()) { return; }
                var proceso = PersonaBLL.Guardar(persona);

                if (proceso == true)
                {
                    Refrescar();
                  MessageBox.Show("Guardado Correctamente.", "Complete", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                  MessageBox.Show("Guardado Fallido", "Incompleto", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                Refrescar();
            
        } 

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (PersonaBLL.Eliminar(Utilidades.ToInt(PersonaIdTextBox.Text)))
            {
                Refrescar();
                MessageBox.Show("Datos Eliminados", "Completo", MessageBoxButton.OK, MessageBoxImage.Information);
            } 
            else
            {
               MessageBox.Show("No se pudo Eliminar los datos", "Incompleto", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            Refrescar(); 
        }

        private void Refrescar()
        {
            persona = new Persona(); 
            DataContext = persona; 
        }

        private bool Validar()
        {
            bool esOkay = true;
           /*if(NombreTextBox.Text.length == 0){ 

            esOkay = false;
            MessageBox.Show("Nombre esta vacio.", "Llenar campo", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            } */
           
            return esOkay; 
        }

    }

}
