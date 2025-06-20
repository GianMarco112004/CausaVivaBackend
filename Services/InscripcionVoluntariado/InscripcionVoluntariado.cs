using System.Data;
using CausaViva.DTOs.InscripcionVoluntariado;
using CausaViva.DTOs.Organizacion;
using CausaViva.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace CausaViva.Services.InscripcionVoluntariado
{
    public class InscripcionVoluntariado : IInscripcionVoluntariado
    {
        private readonly string _connectionString;

        public InscripcionVoluntariado(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection"); 
        }

        public async Task InscripcionVol(InscripcionVoluntariadoDTO inscripcion)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("dbo.sp_inscripcionvoluntariado", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@pIdUsuario", inscripcion.IdUsuario);
                    command.Parameters.AddWithValue("@pIdVoluntariado", inscripcion.IdVoluntariado);


                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<IEnumerable<InscripcionVolDatosPanelUsuarioDTO>> GetInsVolPanelUsuario(String IdUsuario)
        {
            var inscripcion = new List<InscripcionVolDatosPanelUsuarioDTO>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("dbo.sp_obtenerinscripcionusuario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@pIdUsuario", IdUsuario);

                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            inscripcion.Add(new InscripcionVolDatosPanelUsuarioDTO
                            {
                                IdVoluntariado = reader.GetInt32(reader.GetOrdinal("IdVoluntariado")),
                                IdInscripcion = reader.GetInt32(reader.GetOrdinal("IdInscripcion")),
                                TituloPropuesta = reader.GetString(reader.GetOrdinal("TituloPropuesta")),
                                EstadoInscripcion = reader.GetString(reader.GetOrdinal("EstadoInscripcion")),
                                FechaInscripcion = reader.GetDateTime(reader.GetOrdinal("FechaInscripcion"))
                            });


                        }
                    }

                }
            }
            return inscripcion;
        }
        public async Task<IEnumerable<InscripcionVolDatosPanelOrganizacionDTO>> GetInsVolPanelOrganizacion(Int32 IdVoluntariado)
        {
            var inscripcion = new List<InscripcionVolDatosPanelOrganizacionDTO>();

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("dbo.sp_obtenerinscripcionorganizacion", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@pIdVoluntariado", IdVoluntariado);

                    await connection.OpenAsync();

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            inscripcion.Add(new InscripcionVolDatosPanelOrganizacionDTO
                            {
                                IdVoluntariado = reader.GetInt32(reader.GetOrdinal("IdVoluntariado")),
                                Nombres = reader.GetString(reader.GetOrdinal("Nombres")),
                                EstadoInscripcion = reader.GetString(reader.GetOrdinal("EstadoInscripcion")),
                                FechaInscripcion = reader.GetDateTime(reader.GetOrdinal("FechaInscripcion")),
                                TituloPropuesta = reader.GetString(reader.GetOrdinal("TituloPropuesta")),
                                Descripcion = reader.GetString(reader.GetOrdinal("Descripcion"))
                            });


                        }
                    }

                }
            }
            return inscripcion;
        }
        public async Task ActualizarEstadoInscripcion(InscripcionVolActualizarDTO inscripcion)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("dbo.sp_actualizarestadoinscripcion", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@pIdInscripcion", inscripcion.IdInscripcion);
                    command.Parameters.AddWithValue("@pIdEstadoP", inscripcion.IdEstadoP);


                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
