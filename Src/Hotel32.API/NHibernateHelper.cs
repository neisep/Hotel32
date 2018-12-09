using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Hotel32.API.Mapping;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System.IO;

namespace Hotel32.API
{
    public class NHibernateHelper
    {
        private static string _connectionString { get; set; }
        public static ISession OpenSession(bool create = false, bool update = false)
        {
            var _connectionString = File.ReadAllText("connection.json");

            ISessionFactory sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                  .ConnectionString(_connectionString)
                              .ShowSql()
                )
               .Mappings(m => m.FluentMappings
                              .AddFromAssemblyOf<CustomerMap>())
                .ExposeConfiguration(cfg => BuildSchema(cfg, create, update))
                .BuildSessionFactory();
            return sessionFactory.OpenSession();
        }

        private static void BuildSchema(Configuration config, bool create = false, bool update = false)
        {
            if (create)
            {
                new SchemaExport(config).Create(false, true);
            }
            else
            {
                new SchemaUpdate(config).Execute(false, update);
            }
        }
    }
}
