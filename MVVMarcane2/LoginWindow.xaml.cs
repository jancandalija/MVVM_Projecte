using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MVVMarcane2.model;
using MVVMarcane2.viewmodel;

namespace MVVMarcane2
{
    /// <summary>
    /// Lógica de interacción para LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        MediaPlayer playerMusica = new MediaPlayer();
        bool musicaPausada;

        public LoginWindow()
        {
            InitializeComponent();

            musicaPausada = false;
            playerMusica.Open(new Uri(@"audio\mop_the_golden_lotus.wav", UriKind.Relative));
            playerMusica.Volume = 0.05;  // Ajuste de volumen
            playerMusica.Play();
        }

        private void TancarApp_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        
        private void MinimitzarApp_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BotoLogin_Click(object sender, RoutedEventArgs e)
        {
            string usuariNom = userEntry.Text.ToString().ToLower();
            string usuariPwd = pwdEntry.Password.ToString();
            UsuariVM usuari = new UsuariVM(usuariNom, usuariPwd);

            DoubleAnimation fadeInOut = new DoubleAnimation
            {
                From = 0,
                To = 1,
                Duration = new Duration(TimeSpan.FromSeconds(0.5)),
                AutoReverse = true,
            };

            DoubleAnimation fadeOutIn = new DoubleAnimation
            {
                From = 1,
                To = 0,
                Duration = new Duration(TimeSpan.FromSeconds(0.5)),
                AutoReverse = true,
            };

            if (usuari != null && usuari.UsuariNom != null && usuari.UsuariNom != "" && usuari.UsuariPwd != null && usuari.UsuariPwd != "" && usuari.UsuariId > 0)
            {
                glowIniciarVermell.Opacity = 0;
                glowIniciarVerd.BeginAnimation(OpacityProperty, fadeOutIn);
                glowIniciarBlau.BeginAnimation(OpacityProperty, fadeInOut);
            }
            else
            {
                glowIniciarBlau.Opacity = 0;
                glowIniciarVerd.BeginAnimation(OpacityProperty, fadeOutIn);
                glowIniciarVermell.BeginAnimation(OpacityProperty, fadeInOut);
            }
            
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Resume o Stop
            if (musicaPausada)
            {
                musicaPausada = false;
                playerMusica.Play();
            } 
            else
            {
                musicaPausada = true;
                playerMusica.Pause();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Reiniciar
            playerMusica.Position = TimeSpan.Zero;
        }
    }
}
