using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.UsuarioEntities context = new DL.UsuarioEntities())
                {
                    var query = (from usuarioBD in context.Usuarios
                                 select usuarioBD).ToList();
                    if (query != null)
                    {
                        result.Objects = new List<object>();
                        foreach (var usuarioBD in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = usuarioBD.IdUsuario;
                            usuario.Nombre = usuarioBD.Nombre;
                            usuario.ApellidoPaterno = usuarioBD.ApellidoPaterno;
                            usuario.ApellidoMaterno = usuarioBD.ApellidoMaterno;
                            usuario.Edad = (int)usuarioBD.Edad;
                            usuario.Sexo = usuarioBD.Sexo;
                            usuario.Telefono = usuarioBD.Telefono;
                            result.Objects.Add(usuario);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros.";
                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Exception = ex;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result GetById(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.UsuarioEntities context = new DL.UsuarioEntities())
                {
                    var query = context.UsuarioGetById(IdUsuario).FirstOrDefault();
                    if (query != null)
                    {

                        ML.Usuario usuario = new ML.Usuario();
                        usuario.IdUsuario = query.IdUsuario;
                        usuario.Nombre = query.Nombre;
                        usuario.ApellidoPaterno = query.ApellidoPaterno;
                        usuario.ApellidoMaterno = query.ApellidoMaterno;
                        usuario.Edad = (int)query.Edad;
                        usuario.Sexo = query.Sexo;
                        usuario.Telefono = query.Telefono;
                        result.Object = usuario;

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encotro el registro.";
                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Exception = ex;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.UsuarioEntities context = new DL.UsuarioEntities())
                {
                    var query = context.UsuarioAdd(usuario.Nombre, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Edad, usuario.Sexo, usuario.Telefono);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se agrego el registro.";
                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Exception = ex;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static ML.Result Update(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.UsuarioEntities context = new DL.UsuarioEntities())
                {
                    var query = (from usuarioBD in context.Usuarios
                                 where usuarioBD.IdUsuario == usuario.IdUsuario
                                 select usuarioBD).FirstOrDefault();
                    query.Nombre = usuario.Nombre;
                    query.ApellidoPaterno = usuario.ApellidoPaterno;
                    query.ApellidoMaterno = usuario.ApellidoMaterno;
                    query.Edad = (int)usuario.Edad;
                    query.Sexo = usuario.Sexo;
                    query.Telefono = usuario.Telefono;


                    if (query != null)
                    {
                        context.SaveChanges();
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se actualizo el registro.";
                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Exception = ex;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Delete(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.UsuarioEntities context = new DL.UsuarioEntities())
                {
                    var query = (from usuarioBD in context.Usuarios
                                 where usuarioBD.IdUsuario == IdUsuario
                                 select usuarioBD).FirstOrDefault();

                    if (query != null)
                    {
                        context.Usuarios.Remove(query);
                    }
                    int querySave = context.SaveChanges();
                    if (querySave > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se elimino el registro.";
                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Exception = ex;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

    }
}
