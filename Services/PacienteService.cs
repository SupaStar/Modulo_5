using Microsoft.Extensions.Configuration;
using Modulo_5.Controllers;
using Modulo_5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Modulo_5.Services
{
    public class PacienteService
    {
        readonly Encriptador enc = new Encriptador();
        MensajeModel mensaje = new MensajeModel();
        public PacienteService()
        {
        }
        public PacienteModel addPaciente(int id_urgencia)
        {
            PacienteModel paciente = new PacienteModel();
            paciente.id_urgencia = id_urgencia;
            paciente.fecha_entrada = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            using (var context = new DbEntityContext())
            {
                context.pacientes.Add(paciente);
                context.SaveChanges();
            }
            return paciente;
        }
        public PacienteModel findPaciente(int id_paciente)
        {
            PacienteModel paciente;
            using (var context = new DbEntityContext())
            {
                paciente = context.pacientes.Where(paciente => paciente.id == id_paciente).Single();
                paciente.urgencia = context.urgencias.Find(paciente.id_urgencia);
            }
            return paciente;
        }
        public PacienteModel updatePaciente(PacienteModel pacienteE)
        {
            PacienteModel paciente;
            using (var context = new DbEntityContext())
            {
                paciente = context.pacientes.Where(paciente => paciente.id == pacienteE.id).Single();
                paciente.fecha_entrada = pacienteE.fecha_entrada;
                paciente.fecha_salida = pacienteE.fecha_salida;
                context.SaveChanges();
            }
            return paciente;
        }
        public List<PacienteModel> allPaciente()
        {
            List<PacienteModel> pacientes;
            using (var context = new DbEntityContext())
            {
                pacientes = context.pacientes.ToList();
                foreach(PacienteModel paciente in pacientes)
                {
                    paciente.urgencia = context.urgencias.Find(paciente.id_urgencia);
                }
            }
            return pacientes;
        }
    }
}
