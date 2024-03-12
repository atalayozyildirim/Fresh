using Entity.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccsess;
/*
 * Hatanız, EfRepositoryBase<TEntity, TContext> genel sınıfının TContext parametresi için genel bir parametresiz oluşturucu içeren,
 * soyut olmayan bir tür gerektirdiğini belirtiyor.
 * Bu, Context sınıfınızın bir parametresiz oluşturucuya ihtiyaç duyduğu anlamına gelir.
 * Bu durumu çözmek için, Context sınıfınıza parametresiz bir oluşturucu ekleyebiliriz.
 * Ancak, bu oluşturucunun DbContextOptions'ı nasıl alacağı konusunda bir sorun var.
 * Bu genellikle bir yapılandırma dosyasından veya bir hizmet enjeksiyonundan alınır.
 * Bir çözüm, DbContextOptions'ı statik bir özellik olarak saklamak ve parametreli oluşturucunun bu özelliği ayarlamasını sağlamaktır.
 * Parametresiz oluşturucu daha sonra bu özelliği kullanabilir.
 * Aşağıda, bu değişiklikleri uyguladığımız Context sınıfınızın bir versiyonunu bulabilirsiniz:
 * Bu çözüm, DbContextOptions'ın her zaman parametreli oluşturucu tarafından ilk olarak ayarlandığını varsayar. Bu genellikle doğru olmalıdır,
 * çünkü EF Core migrations ve diğer DbContext kullanımları genellikle parametreli oluşturucuyu kullanır.
 * Ancak, bu çözümün her durumda çalışacağının garantisi yoktur ve daha karmaşık bir uygulamada farklı bir yaklaşım gerekebilir.
 */
public class Context: IdentityDbContext<Users>
{
    private static DbContextOptions<Context> _options;
    public Context(DbContextOptions<Context> options): base(options)
    {
        _options = options;
    }
    public Context() : base(_options)
    {
    }
    public DbSet<Users> Users { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Likes> Likes { get; set; }
}