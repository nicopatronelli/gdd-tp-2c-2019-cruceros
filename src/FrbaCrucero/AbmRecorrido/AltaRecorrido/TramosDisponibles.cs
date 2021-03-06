﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FrbaCrucero.Utils;
using FrbaCrucero.AbmRecorrido.Dominio;

namespace FrbaCrucero.AbmRecorrido.AltaRecorrido
{
    public class TramosDisponibles
    {
        DataGridView dgvTramosDisponibles;

        public TramosDisponibles(DataGridView dgvTramosDisponibles)
        {
            this.dgvTramosDisponibles = dgvTramosDisponibles;
        }

        public DataGridView getDgvTramosDisponibles()
        {
            return this.dgvTramosDisponibles;
        }

        // Cargamos el dgvTramosDisponibles con TODOS los tramos disponibles en la tabla Tramo
        public void popularTramos()
        {
            ConexionBD conexion = new ConexionBD();
            conexion.abrir();

            string miConsulta = "SELECT t.id_tramo tramo, puerto_inicio.puerto_nombre puerto_inicio, puerto_fin.puerto_nombre puerto_fin, t.tramo_precio precio  "
                              + "FROM LOS_BARONES_DE_LA_CERVEZA.Tramo t "
                                + "JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto puerto_inicio "
                                    + "ON t.tramo_puerto_inicio = puerto_inicio.id_puerto "
                                + "JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto puerto_fin "
                                    + "ON t.tramo_puerto_destino = puerto_fin.id_puerto";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(miConsulta, conexion.obtenerConexion());
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            this.dgvTramosDisponibles.DataSource = dt;
            conexion.cerrar();
        }

        // Cargamos el dgvTramosDisponibles sólo con los posibles tramos que según el puerto final del último tramo agregado
        public void popularTramosPosibles(string puertoInicio)
        {
            ConexionBD conexion = new ConexionBD();
            conexion.abrir();

            string miConsulta = "SELECT t.id_tramo tramo, puerto_inicio.puerto_nombre puerto_inicio, puerto_fin.puerto_nombre puerto_fin, t.tramo_precio precio "
                              + "FROM LOS_BARONES_DE_LA_CERVEZA.Tramo t "
                                + "JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto puerto_inicio "
                                    + "ON t.tramo_puerto_inicio = puerto_inicio.id_puerto "
                                + "JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto puerto_fin "
                                    + "ON t.tramo_puerto_destino = puerto_fin.id_puerto "
                              + "WHERE puerto_inicio.puerto_nombre = @puerto_inicio";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(miConsulta, conexion.obtenerConexion());
            Parametro paramPuertoInicio = new Parametro("@puerto_inicio", SqlDbType.NVarChar, puertoInicio, 255);
            dataAdapter.SelectCommand.Parameters.Add(paramPuertoInicio.obtenerSqlParameter());
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            this.dgvTramosDisponibles.DataSource = dt;
            conexion.cerrar();
        }

        public Tramo getTramoSeleccionado(int rowIndex)
        {
            int idTramoSeleccionado = Convert.ToInt32(this.dgvTramosDisponibles.Rows[rowIndex].Cells["tramo"].Value);
            string puertoInicioTramoSeleccionado = Convert.ToString(this.dgvTramosDisponibles.Rows[rowIndex].Cells["puerto_inicio"].Value);
            string puertoFinTramoSeleccionado = Convert.ToString(this.dgvTramosDisponibles.Rows[rowIndex].Cells["puerto_fin"].Value);
            double precioTramoSeleccionado = Convert.ToDouble(dgvTramosDisponibles.Rows[rowIndex].Cells["precio"].Value);
            return new Tramo(idTramoSeleccionado, puertoInicioTramoSeleccionado, puertoFinTramoSeleccionado, precioTramoSeleccionado);
        }

        // Cargamos el dgvTramosDisponibles con TODOS los tramos disponibles en la tabla Tramo
        public void popularTramosConBusqueda(string puertoInicio, string puertoFin)
        {   
            ConexionBD conexion = new ConexionBD();
            conexion.abrir();

            // Armamos la query en forma dinámica según el puerto de inicio y fin ingresados 
            string miConsulta = "SELECT t.id_tramo tramo, puerto_inicio.puerto_nombre puerto_inicio, puerto_fin.puerto_nombre puerto_fin, t.tramo_precio precio  "
                              + "FROM LOS_BARONES_DE_LA_CERVEZA.Tramo t "
                                + "JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto puerto_inicio "
                                    + "ON t.tramo_puerto_inicio = puerto_inicio.id_puerto "
                                + "JOIN LOS_BARONES_DE_LA_CERVEZA.Puerto puerto_fin "
                                    + "ON t.tramo_puerto_destino = puerto_fin.id_puerto "
                                + "WHERE puerto_inicio.puerto_nombre LIKE '%'+@puerto_inicio+'%' "
                                    + "AND puerto_fin.puerto_nombre LIKE '%'+@puerto_fin+'%'";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(miConsulta, conexion.obtenerConexion());

            // Añadimos el parámetro puerto_inicio
            Parametro paramPuertoInicio = new Parametro("@puerto_inicio", SqlDbType.NVarChar, puertoInicio, 255);
            if (puertoInicio.Equals("")) // Si no se introdujo el puerto de inicio
                paramPuertoInicio.esCadenaVaciaYNoNull();
            dataAdapter.SelectCommand.Parameters.Add(paramPuertoInicio.obtenerSqlParameter());

            // Añadimos el parámetro puerto_fin
            Parametro paramPuertoFin= new Parametro("@puerto_fin", SqlDbType.NVarChar, puertoFin, 255);
            if (puertoFin.Equals("")) // Si no se introdujo el puerto de fin
                paramPuertoFin.esCadenaVaciaYNoNull();
            dataAdapter.SelectCommand.Parameters.Add(paramPuertoFin.obtenerSqlParameter());
            
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(dataAdapter);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            this.dgvTramosDisponibles.DataSource = dt;
            conexion.cerrar();
        }

        public void recargarTramosConBusqueda()
        {
            this.popularTramosConBusqueda("", "");
        }

    }
}
