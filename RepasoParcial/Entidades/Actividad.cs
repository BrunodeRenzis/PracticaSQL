using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace Entidades
{
    public delegate void DelegadoTemporizador(); 
    public class Actividad
    {
        int tiempoActivo;
        int tiempoInicial;
        public event DelegadoTemporizador TimeOut;
        public Thread hiloResta;

        /// <summary>
        /// El objeto lanza un evento timeOut cada vez que se termina el tiempo activo.
        /// </summary>
        /// <param name="tiempoActivo">El tiempo de parámetro debe ir en segundos</param>
        public Actividad(int tiempoActivo)
        {
            this.tiempoActivo = tiempoActivo;
            this.tiempoInicial = tiempoActivo;
            this.hiloResta = new Thread(Descontar);
            this.hiloResta.Start();
        }

        public void Reactivar()
        {
            this.tiempoActivo = this.tiempoInicial;
        }

        public void Descontar()
        {
            this.tiempoActivo--;
            if(this.tiempoActivo <= 0)
            {
                if(!(TimeOut is null)) //Denota que haya algún manejador asignado al evento con un new
                {
                    TimeOut.Invoke();
                }
            }

            else
            {
                Thread.Sleep(1000);
                this.Descontar();
            }
        }
    }
}
