namespace RestApiLibrary.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using RestApiLibrary.Models.Objects;

    public class DbLibrary : DbContext
    {
        // El contexto se ha configurado para usar una cadena de conexión 'DbLibrary' del archivo 
        // de configuración de la aplicación (App.config o Web.config). De forma predeterminada, 
        // esta cadena de conexión tiene como destino la base de datos 'RestApiLibrary.Models.DbLibrary' de la instancia LocalDb. 
        // 
        // Si desea tener como destino una base de datos y/o un proveedor de base de datos diferente, 
        // modifique la cadena de conexión 'DbLibrary'  en el archivo de configuración de la aplicación.
        public DbLibrary()
            : base("name=DbLibrary")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        // Agregue un DbSet para cada tipo de entidad que desee incluir en el modelo. Para obtener más información 
        // sobre cómo configurar y usar un modelo Code First, vea http://go.microsoft.com/fwlink/?LinkId=390109.
        
        public virtual DbSet<SystemUser> tc_SystemUser { get; set; }
        public virtual DbSet<SystemRol> tc_SystemRol { get; set; }
        public virtual DbSet<SystemUserRol> tc_SystemUserRol { get; set; }
        public virtual DbSet<SystemPermissions> tc_SystemPermissions { get; set; }
        public virtual DbSet<SystemRolePermission> tc_SystemRolePermission { get; set; }
        public virtual DbSet<Language> tc_Language { get; set; }
        public virtual DbSet<Category> tc_Category { get; set; }
        public virtual DbSet<Country> tc_Country { get; set; }
        public virtual DbSet<Editorial> tc_Editorial { get; set; }
        public virtual DbSet<Author> tc_Author { get; set; }
        public virtual DbSet<Document> tc_Document { get; set; }
        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}