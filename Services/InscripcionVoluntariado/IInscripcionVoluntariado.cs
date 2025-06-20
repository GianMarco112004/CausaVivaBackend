using CausaViva.DTOs.InscripcionVoluntariado;
using CausaViva.DTOs.Organizacion;

namespace CausaViva.Services.InscripcionVoluntariado
{
    public interface IInscripcionVoluntariado
    {
        Task InscripcionVol(InscripcionVoluntariadoDTO inscripcion);
        Task<IEnumerable<InscripcionVolDatosPanelUsuarioDTO>> GetInsVolPanelUsuario(String IdUsuario);
        Task<IEnumerable<InscripcionVolDatosPanelOrganizacionDTO>> GetInsVolPanelOrganizacion(Int32 IdVoluntariado);
        Task ActualizarEstadoInscripcion(InscripcionVolActualizarDTO inscripcion);
    }

}
