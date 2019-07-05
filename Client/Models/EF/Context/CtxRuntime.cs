using Client.Models.EF.BasicInfo;
using Client.Models.EF.Finance;
using Client.Models.Statics;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Models.EF.Context
{
    /// <summary>
    /// CtxRuntime
    /// </summary>
    public class CtxRuntime : DbContext
    {
        /// <summary>
        /// 构造
        /// </summary>
        public CtxRuntime() : base(LoginInfo.SqlConn.ToString())
        { }

        /// <summary>
        /// 单据部门
        /// </summary>
        public virtual DbSet<KCBMZD> KCBMZD { get; set; }
        /// <summary>
        /// 主键编码
        /// </summary>
        public virtual DbSet<LSNBBM> LSNBBM { get; set; }
        /// <summary>
        /// 审批表体
        /// </summary>
        public virtual DbSet<PPSPMXSJ> PPSPMXSJ { get; set; }
        /// <summary>
        /// 审批表头
        /// </summary>
        public virtual DbSet<PPSPZSJ> PPSPZSJ { get; set; }
        /// <summary>
        /// 职工字典
        /// </summary>
        public virtual DbSet<ZWZGZD> ZWZGZD { get; set; }

        /// <summary>
        /// 核算部门
        /// </summary>
        public virtual DbSet<LSBMZD> LSBMZD { get; set; }
        /// <summary>
        /// 凭证辅助
        /// </summary>
        public virtual DbSet<ZWFZYS> ZWFZYS { get; set; }
        /// <summary>
        /// 核算项目
        /// </summary>
        public virtual DbSet<ZWHSXM> ZWHSXM { get; set; }
        /// <summary>
        /// 核算科目
        /// </summary>
        public virtual DbSet<ZWKMZD> ZWKMZD { get; set; }
        /// <summary>
        /// 凭证编号
        /// </summary>
        public virtual DbSet<ZWPZBH> ZWPZBH { get; set; }
        /// <summary>
        /// 凭证分录
        /// </summary>
        public virtual DbSet<ZWPZFL> ZWPZFL { get; set; }
        /// <summary>
        /// 凭证表头
        /// </summary>
        public virtual DbSet<ZWPZK> ZWPZK { get; set; }
        /// <summary>
        /// 凭证类型
        /// </summary>
        public virtual DbSet<ZWPZLX> ZWPZLX { get; set; }
        /// <summary>
        /// 核算项目类别
        /// </summary>
        public virtual DbSet<ZWXMLB> ZWXMLB { get; set; }

        /// <summary>
        /// 凭证模板表头
        /// </summary>
        public virtual DbSet<VIT> VIT { get; set; }
        /// <summary>
        /// 凭证模板表体
        /// </summary>
        public virtual DbSet<VITDetail> VITDetail { get; set; }

        /// <summary>
        /// 配置模型映射
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            string schema = $"lc{LoginInfo.SqlConn.ID.PadLeft(3, '0')}9999";

            modelBuilder.Entity<KCBMZD>().ToTable("KCBMZD", schema);
            modelBuilder.Entity<LSNBBM>().ToTable("LSNBBM", schema);
            modelBuilder.Entity<PPSPMXSJ>().ToTable("PPSPMXSJ", schema);
            modelBuilder.Entity<PPSPZSJ>().ToTable("PPSPZSJ", schema);
            modelBuilder.Entity<ZWZGZD>().ToTable("ZWZGZD", schema);

            modelBuilder.Entity<LSBMZD>().ToTable("LSBMZD", schema);
            modelBuilder.Entity<ZWFZYS>().ToTable("ZWFZYS", schema);
            modelBuilder.Entity<ZWHSXM>().ToTable("ZWHSXM", schema);
            modelBuilder.Entity<ZWKMZD>().ToTable("ZWKMZD", schema);
            modelBuilder.Entity<ZWPZBH>().ToTable("ZWPZBH", schema);
            modelBuilder.Entity<ZWPZFL>().ToTable("ZWPZFL", schema);
            modelBuilder.Entity<ZWPZK>().ToTable("ZWPZK", schema);
            modelBuilder.Entity<ZWPZLX>().ToTable("ZWPZLX", schema);
            modelBuilder.Entity<ZWXMLB>().ToTable("ZWXMLB", schema);

            modelBuilder.Entity<VIT>().ToTable("VIT", schema);
            modelBuilder.Entity<VITDetail>().ToTable("VITDetail", schema);
        }
    }
}
