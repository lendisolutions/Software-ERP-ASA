using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using ERP.BusinessEntity;
using ERP.BusinessLogic;

namespace ERP.Presentacion
{
    public class Parametros
    {
        public static List<LoginAccessBE> pListaPermisoAcceso = new List<LoginAccessBE>();

        public static string Key = "YUXTAPUESTO/ARIN";
        public static string IV = "kabosilva0123456";

        public static DateTime dtFechaHoraServidor = DateTime.Today;

        public static string sIdDepartamento = "15"; //LIMA
        public static string sIdProvincia = "01"; //LIMA
        public static string sIdDistrito = "01"; //LIMA

        public static int intPerfilId = 0;
        public static int intMenuId = 23;
        public static string strNomPerfil = "";
        public static int intUsuarioId = 0;
        public static int intPeriodo = 2019;
        public static int intMes = DateTime.Today.Month;
        public static string strUsuarioLogin = "";
        public static string strUsuarioNombres = "";
        public static string strUsuarioApellidos = "";
        public static int intEmpresaId = 1;
        public static int intAreaId = 1;
        public static int intPersonaId = 1;
        public static string strEmpresaNombre = "";
        public static string strRutaLogo = "";

        //Tabla
        public static int intTblGender = 1;
        public static int intTblCivilStatus = 2;
        public static int intTblEmployeeSituation = 3;
        public static int intTblDevelopmentSituation = 5;
        public static int intTblTypeShipping = 6;
        public static int intTblInspectionCertificateSituation = 7;
        public static int intTblInvoiceSituation = 7;

        //SEXO
        public static int intSEXMasculino = 1;
        public static int intSEXFemenino = 2;

        //ESTADO CIVIL

        public static int intECSoltero = 3;
        public static int intECCasado = 4;
        public static int intECConcubino = 5;

        //SITUACION PERSONA
        public static int intSPActivo = 6;
        public static int intSPCesado = 7;

        //SITUACION PO DEVELOPMENT
        public static int intDOPending = 9;
        public static int intPOClosed = 10;

        //SITUATION INSPECTION CERTIFICATE
        public static int intICActive = 14;
        public static int intICFinished = 15;
        public static int intICDeleted = 16;

        //SITUATION INVOICE
        public static int intIVNActive = 17;
        public static int intIVNFinished = 18;
        public static int intIVNDeleted = 19;
    }
}
