using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empleado
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JavilesLeenkenGroupContext context = new DL.JavilesLeenkenGroupContext())
                {
                    var query = context.Empleados.FromSqlRaw($"GetAllEmpleado").ToList();

                    result.Objects = new List<object>();

                    if (query != null)
                    {
                        foreach (var objEmpleado in query)
                        {
                            ML.Empleado empleado = new ML.Empleado();

                            empleado.IdEmpleado = objEmpleado.IdEmpleado;
                            empleado.Nombre = objEmpleado.Nombre;
                            empleado.ApellidoPaterno = objEmpleado.ApellidoPaterno;
                            empleado.ApellidoMaterno = objEmpleado.ApellidoMaterno;
                            empleado.NumeroNomina = objEmpleado.NumeroNomina;

                            empleado.Estado = new ML.Estado();
                            empleado.Estado.IdEstado = objEmpleado.IdEstado.Value;
                            empleado.Estado.Nombre = objEmpleado.Estados;

                            result.Objects.Add(empleado);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result GetById(int IdEmpleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JavilesLeenkenGroupContext context = new DL.JavilesLeenkenGroupContext())
                {
                    var query = context.Empleados.FromSqlRaw($"GetByIdEmpleado {IdEmpleado}").AsEnumerable().FirstOrDefault();
                    result.Objects = new List<object>();
                    if(query != null)
                    {
                        ML.Empleado objEmpleado = new ML.Empleado();
                        objEmpleado.IdEmpleado = query.IdEmpleado;
                        objEmpleado.Nombre = query.Nombre;
                        objEmpleado.ApellidoPaterno =   query.ApellidoPaterno;
                        objEmpleado.ApellidoMaterno = query.ApellidoMaterno;
                        objEmpleado.NumeroNomina = query.NumeroNomina;

                        objEmpleado.Estado = new ML.Estado();
                        objEmpleado.Estado.IdEstado = query.IdEstado.Value;
                        objEmpleado.Estado.Nombre = query.Estados;

                        result.Object = objEmpleado;

                        result.Correct=true;
                    }
                    else
                    {
                        result.Correct=false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Add(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using(DL.JavilesLeenkenGroupContext context = new DL.JavilesLeenkenGroupContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"AddEmpleado '{empleado.Nombre}','{empleado.ApellidoPaterno}','{empleado.ApellidoMaterno}',{empleado.Estado.IdEstado}");
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct  =   false;
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result Update(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.JavilesLeenkenGroupContext context = new DL.JavilesLeenkenGroupContext())
                {
                    var query = context.Database.ExecuteSqlRaw($"UpdateEmpleado {empleado.IdEmpleado},'{empleado.Nombre}','{empleado.ApellidoPaterno}','{empleado.ApellidoMaterno}',{empleado.Estado.IdEstado}");
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Delete(int IdEmpleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.JavilesLeenkenGroupContext context = new DL.JavilesLeenkenGroupContext())
                {
                    var query = context.Empleados.FromSql($"DeleteEmpleado {IdEmpleado}").AsEnumerable().FirstOrDefault();
                    if (query != null)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
