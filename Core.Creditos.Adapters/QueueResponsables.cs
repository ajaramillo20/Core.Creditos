using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Core.Creditos.Adapters
{
    public static class QueueResponsables
    {
        private static Queue QueueAnalistas { get; set; }
        private static Queue QueueEjecutivos { get; set; }
        public static void StartQueueService()
        {
            QueueAnalistas = new Queue();
            QueueEjecutivos = new Queue();
            SetQueueDataAnalista();
            SetQueueDataEjecutivos();
        }

        public static void SetQueueDataAnalista()
        {

            QueueAnalistas.Enqueue("ajaramillo");
            QueueAnalistas.Enqueue("gmoncayo");
            QueueAnalistas.Enqueue("csilva");
            //QueueAnalistas.Enqueue("pmejia");            
        }

        public static void SetQueueDataEjecutivos()
        {
            QueueEjecutivos.Enqueue("fmontenegro");
            QueueEjecutivos.Enqueue("dcorrea");
        }

        public static string GetAnalistaEnCola()
        {
            if (QueueAnalistas.Count == 0)
            {
                SetQueueDataAnalista();
            }            
            return QueueAnalistas.Dequeue().ToString();
        }

        public static string GetEjecutivoEnCola()
        {
            if (QueueEjecutivos.Count == 0)
            {
                SetQueueDataEjecutivos();
            }            
            return QueueEjecutivos.Dequeue().ToString();
        }

    }
}
