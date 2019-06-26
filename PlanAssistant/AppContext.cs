namespace PlanAssistant
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class AppContext : DbContext
    {
        // Контекст настроен для использования строки подключения "Database" из файла конфигурации  
        // приложения (App.config или Web.config). По умолчанию эта строка подключения указывает на базу данных 
        // "PlanAssistant.Database" в экземпляре LocalDb. 
        // 
        // Если требуется выбрать другую базу данных или поставщик базы данных, измените строку подключения "Database" 
        // в файле конфигурации приложения.
        public AppContext()
            : base("name=Database")
        {
        }

        public virtual DbSet<Task> Tasks { get; set; }
        //public virtual DbSet<Frequency> Frequencies { get; set; }
        //public virtual DbSet<Email> Emails { get; set; }
        //public virtual DbSet<FileDownloader> FileDownloaders { get; set; }
        //public virtual DbSet<CatalogMoving> CatalogMovings { get; set; }

        // Добавьте DbSet для каждого типа сущности, который требуется включить в модель. Дополнительные сведения 
        // о настройке и использовании модели Code First см. в статье http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}