using System;


namespace DatabaseMigration.Framework
{
    public class Pluralizer
    {
        public static string Pluralize<TEntity>()
        {
            return Inflector.Inflector.Pluralize(typeof(TEntity).Name);
        }

        public static string Singularize<TEntity>()
        {
            return Inflector.Inflector.Singularize(typeof(TEntity).Name);

        }
    }
}
