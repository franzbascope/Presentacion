﻿using DAL.Pagos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Pagos.PagosDSTableAdapters;
using System.Configuration;
using CapaAcceso.App_Code.Model.Pagos;
using VentasNur.Model;

namespace CapaAcceso.App_Code.BLL.PagosBLL
{
    public class PagosBLL
    {
        public PagosBLL()
        {

        }
        private static Pagos getPagoFromRow(PagosDS.PagosRow row)
        {
            return new Pagos()
            {
                pagoId = row.pagoId,
                fechaPago = row.fechaPago,
                conceptoId = row.conceptoId,
                conceptoDescripcion = row.concepto,
                numeroLinea = row.numeroLinea,
                esIngreso = row.esIngreso
            };
        }

        private static PagoUsuario getPagosFromRow(PagosDS.PagoUsuarioRow row)
        {
            return new PagoUsuario()
            {
                correo = row.correo,
                userRecargo = row.usuarioRecargo,
                monto = row.monto
            };
        }

        public static List<Pagos> getPagosByUsuarioId(int usuarioId, DateTime fechaDesde, DateTime fechaHasta)
        {
            if (usuarioId <= 0)
                throw new Exception("El usuarioId no puede ser <=0");

            PagosTableAdapter localAdapter = new PagosTableAdapter();
            PagosDS.PagosDataTable table = localAdapter.getPagosByUsuarioId(usuarioId, fechaDesde, fechaHasta);

            List<Pagos> list = new List<Pagos>();
            foreach (var row in table)
            {
                Pagos obj = getPagoFromRow(row);
                list.Add(obj);
            }
            return list;
        }

        public static List<PagoUsuario> getPagosMontoByUsuarioId(int usuarioId)
        {
            if (usuarioId <= 0)
                throw new Exception("El usuarioId no puede ser <=0");

            PagoUsuarioTableAdapter localAdapter = new PagoUsuarioTableAdapter();
            PagosDS.PagoUsuarioDataTable table = localAdapter.getAllPagosMonto(usuarioId);

            List<PagoUsuario> list = new List<PagoUsuario>();
            foreach (var row in table)
            {
                PagoUsuario obj = getPagosFromRow(row);
                list.Add(obj);
            }
            return list;
        }

        public static int insertPago(String userorcorreo, int monto, int usuarioId)
        {
            if (usuarioId <= 0)
                throw new Exception("El usuarioId no puede ser <=0");
            if (String.IsNullOrEmpty(userorcorreo))
                throw new Exception("La placa no puede ser vacia ni nula");
            if (monto <= 0)
                throw new Exception("El monto no puede ser <=0");

            int? id = null;
            PagosTableAdapter localAdapter = new PagosTableAdapter();
            localAdapter.insertpagoApp(userorcorreo, monto, usuarioId, ref id);

            if (id == null || id.Value <= 0)
                throw new Exception("La llave primaria no se generó correctamente");

            return id.Value;
        }
        public static void insertPagoUsuario(int usuarioId, int vehiculoId, int lineaId)
        {
            Usuario objUsuario;
            if (usuarioId <= 0)
                throw new Exception("El usuarioId no puede ser <=0");
            try
            {
                objUsuario = UsuarioBLL.getUsuarioById(usuarioId);
            }
            catch (Exception ex)
            {
                Console.WriteLine("error al insertar pago" + ex);
                return;
            }
            int conceptoId = string.IsNullOrEmpty(ConfigurationSettings.AppSettings["conceptoIdMayores"]) ?
                    -1 : Convert.ToInt32(ConfigurationSettings.AppSettings["conceptoIdMayores"]);
            conceptoId = 2;
            if (objUsuario.esEstudiante)
            {
                conceptoId = string.IsNullOrEmpty(ConfigurationSettings.AppSettings["conceptoIdEstudiantes"]) ?
                 -1 : Convert.ToInt32(ConfigurationSettings.AppSettings["conceptoIdEstudiantes"]);
                conceptoId = 1;
            }

            try
            {
                PagosTableAdapter localAdapter = new PagosTableAdapter();
                localAdapter.insertPago(usuarioId, vehiculoId, conceptoId, lineaId);

            }
            catch (Exception ex)
            {
                Console.WriteLine("error al insertar pago" + ex);
            }


        }
    }
}
