using PatronRepositorio.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PatronRepositorio.BLL
{
    public class RepositorioBase<T> : IDisposable, IRepository<T> where T : class
    {
        internal Contexto db;

        public RepositorioBase()
        {
            db = new Contexto();
        }

        public virtual T Buscar(int id)
        {
            T entidad;

            try
            {
                entidad = db.Set<T>().Find(id);
            }
            catch (Exception)
            {
                throw;
            }
            return entidad;
        }

        public void Dispose()
        {
            db.Dispose();
        }

        public virtual bool Eliminar(int id)
        {
            bool paso = false;

            try
            {
                T entidad = db.Set<T>().Find(id);
                db.Set<T>().Remove(entidad);
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;
        }

        public virtual List<T> GetList(Expression<Func<T, bool>> expression)
        {
            List<T> Lista = new List<T>();

            try
            {
                Lista = db.Set<T>().Where(expression).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            return Lista;
        }


        public virtual bool Guardar(T entidad)
        {
            bool paso = false;

            try
            {
                if (db.Set<T>().Add(entidad) != null)
                    paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return paso;

        }

        public virtual bool Modificar(T entidad)
        {
            bool paso = false;

            try
            {
                db.Entry(entidad).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }            
            return paso;
        }
    }
}
