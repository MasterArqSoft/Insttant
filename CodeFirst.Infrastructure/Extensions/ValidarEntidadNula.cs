using CodeFirst.Infrastructure.Exceptions;
using System.Linq;

namespace CodeFirst.Infrastructure.Extensions
{
    public static class ValidarEntidadNula<T>
    {
        public static void IsNullEntity(T entity)
        {
            if (entity == null) { throw new InfraestructuraException("{0} no puede ser nulo.", nameof(entity)); }
        }

        public static void IsNullListEntity(IQueryable<T> entity)
        {
            if (entity?.Any() != true) { throw new InfraestructuraException("La lista de {0} no puede ser nulo.", nameof(entity)); }
        }
    }
}
