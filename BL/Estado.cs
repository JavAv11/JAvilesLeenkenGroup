using Microsoft.EntityFrameworkCore;

namespace BL
{
    public class Estado
    {
        public static ML.Result EstadoGetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.JavilesLeenkenGroupContext context = new DL.JavilesLeenkenGroupContext())
                {
                    var query = context.Estados.FromSqlRaw("EstadoGetAll").ToList();
                    result.Objects = new List<object>();

                    if(query !=null)
                    {
                        result.Objects = new List<object>();
                        foreach(var obj in query)
                        {
                            ML.Estado estado = new ML.Estado();
                            estado.IdEstado = obj.IdEstado;
                            estado.Nombre= obj.Nombre;
                            result.Objects.Add(estado);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        Console.WriteLine("Se ha producido un error");
                        Console.ReadKey();
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct=false;
                result.ErrorMessage=ex.Message; 
                result.Ex=ex;
            }
            return result;
        }
    }
}