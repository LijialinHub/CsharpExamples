using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    /// <summary>
    /// SQLServer数据库上下文类
    /// </summary>
    public class SQLServerDbContext : DbContext
    {

        public SQLServerDbContext()
            : base("name=SQLServerDbContext")
        {
        }

        /// <summary>
        /// ProductInfoEntity 属性 会自动映射到数据库的表
        /// </summary>
        public DbSet<ProductInfoEntity> productInfoEntities { get; set; }

    }
}
