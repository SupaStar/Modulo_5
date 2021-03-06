﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Modulo_5.Models
{
    public class DbEntityContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=127.0.0.1;user=root;password=;database=hospital");
            //optionsBuilder.UseMySQL("Server=127.0.0.1;Port=50980;Database=localdb;Uid=azure;Pwd=6#vWHD_$;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AreaModel>().ToTable("area");
            modelBuilder.Entity<EmpleadoModel>().ToTable("empleado");
            modelBuilder.Entity<PacienteModel>().ToTable("paciente");
            modelBuilder.Entity<QuejaModelE>().ToTable("queja");
            modelBuilder.Entity<SugerenciaModel>().ToTable("sugerencia");
            modelBuilder.Entity<TipoQueja>().ToTable("tipo_queja");
            modelBuilder.Entity<UrgenciaModelE>().ToTable("urgencia");
            modelBuilder.Entity<UsuarioModel>().ToTable("login");
            modelBuilder.Entity<EstanciaModel>().ToTable("estancia");
            modelBuilder.Entity<SolucionQuejaModel>().ToTable("solucion_queja");
            modelBuilder.Entity<OperacionModel>().ToTable("operacion");
            modelBuilder.Entity<UsuariosPacienteModel>().ToTable("usuarios_paciente");
            modelBuilder.Entity<ObservacionModel>().ToTable("observaciones");
        }
        public DbSet<AreaModel> areas { get; set; }
        public DbSet<EmpleadoModel> empleados { get; set; }
        public DbSet<PacienteModel> pacientes { get; set; }
        public DbSet<OperacionModel> operaciones { get; set; }
        public DbSet<ObservacionModel> observaciones { get; set; }
        public DbSet<UsuariosPacienteModel> usuarios_paciente { get; set; }
        public DbSet<SolucionQuejaModel> soluciones { get; set; }
        public DbSet<EstanciaModel> estancias { get; set; }
        public DbSet<QuejaModelE> quejas { get; set; }
        public DbSet<SugerenciaModel> sugerencias { get; set; }
        public DbSet<TipoQueja> tipos_quejas { get; set; }
        public DbSet<UrgenciaModelE> urgencias { get; set; }
        public DbSet<UsuarioModel> usuarios { get; set; }
    }
}
