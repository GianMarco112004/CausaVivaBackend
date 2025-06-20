using System.Text.Json.Serialization;

namespace CausaViva.DTOs.InscripcionVoluntariado
{
    public class InscripcionVoluntariadoDTO
    {
        public String IdUsuario { get; set; }
        public Int32 IdVoluntariado { get; set; }
    }

    public class InscripcionVolDatosPanelUsuarioDTO
    {
        public Int32 IdVoluntariado { get; set; }
        public Int32 IdInscripcion { get; set; }
        public String TituloPropuesta { get; set; }
        public String EstadoInscripcion { get; set; }
        public DateTime FechaInscripcion { get; set; }

    }

    public class InscripcionVolDatosPanelOrganizacionDTO
    {
        public Int32 IdVoluntariado { get; set; }
        public Int32 IdInscripcion { get; set; }
        public String Nombres {  get; set; }
        public String EstadoInscripcion { get; set; }
        public DateTime FechaInscripcion { get; set; }
        public String TituloPropuesta { get; set; }
        public String Descripcion { get; set; }

    }

    public class InscripcionVolActualizarDTO
    {
        public Int32 IdInscripcion { get; set; }
        public Int32 IdEstadoP {  get; set; }
    }

}
