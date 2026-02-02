using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    /// <summary>
    /// 产品信息实体类
    /// </summary>
    [Table("产品信息")]
    public class ProductInfoEntity /*存入SQL Server数据库，使用EF框架(EF6) Entity Framework
                                    */
    {

        [Key]
        public int Id { get; set; }

        [Column("产品名称")] 
        public string Name { get; set; }

        [Column("起始时间")]
        [Required()]  //不能为null
        public string StartMakeTime { get; set; }

        [Column("耗时")]
        public double TakeTime { get; set; }

    }

}
