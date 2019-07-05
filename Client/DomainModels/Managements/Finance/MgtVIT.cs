using Client.DomainModels.Managements.Base.Abstracts;
using Client.Helpers;
using Client.Models.EF.BasicInfo;
using Client.Models.EF.Context;
using Client.Models.EF.Finance;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.DomainModels.Managements.Finance
{
    /// <summary>
    /// MgtVIT
    /// </summary>
    public class MgtVIT : MgtEFList<CtxRuntime, VIT>
    {
        /// <summary>
        /// 设置字段名称
        /// </summary>
        protected override void SetPropertyNames()
        {
            PropertyKey = "ID";
        }
        /// <summary>
        /// 设置读取实例集合规则
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected override bool SetReadContentsRule(VIT entity, string value)
        {
            return entity.ID.ToString().NoCaseContains(value) || entity.Name.NoCaseContains(value);
        }
        /// <summary>
        /// 设置搜索规则
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected override bool SetSearchRule(VIT obj)
        {
            return SetReadContentsRule(obj, SearchValue);
        }

        /// <summary>
        /// 表体集合的默认列表视图
        /// </summary>
        public ICollectionView Entries { get; set; }

        /// <summary>
        /// 创建单个实例视图
        /// </summary>
        protected override void BuildEntityView()
        {
            base.BuildEntityView();
            Entries = Entity.VITDetails.AsICV();
        }

        /// <summary>
        /// 新建单个实例
        /// </summary>
        /// <returns></returns>
        public override bool AddEntity()
        {
            return AddEntityFrame(() =>
            {
                Entity.Designator = "财务部";
                Entity.DesignedDate = DateTime.Now;
            });
        }

        /// <summary>
        /// 新增分录
        /// </summary>
        /// <param name="km"></param>
        /// <returns></returns>
        public bool AddEntry(ZWKMZD km)
        {
            if (Entity == null) return false;
            try
            {
                VITDetail detail = new VITDetail();
                Entity.VITDetails.Add(detail);
                IniDetail(detail, CtxEntity.ZWKMZD.Single(t => t.ZWKMZD_KMBH == km.ZWKMZD_KMBH));
                Entries.Refresh();
                return true;
            }
            catch (Exception ex) { return AddFailed(ex); }
        }
        /// <summary>
        /// 初始化分录
        /// </summary>
        /// <param name="detail"></param>
        /// <param name="km"></param>
        private void IniDetail(VITDetail detail, ZWKMZD km)
        {
            detail.ZWKMZD = km;
            if (km.ZWKMZD_ZXHS == "1")
            {
                detail.IsAP = true;
            }
            if (km.ZWKMZD_BMHS == "1")
            {
                detail.IsAD = true;
            }
            detail.IsDebit = true;
        }
        /// <summary>
        /// 删除分录
        /// </summary>
        /// <param name="detail"></param>
        /// <returns></returns>
        public bool DeleteEntry(VITDetail detail)
        {
            if (detail == null || Entity == null) return false;
            try
            {
                CtxEntity.VITDetail.Remove(detail);
                Entries.Refresh();
                return true;
            }
            catch(Exception ex) { return DeleteFailed(ex); }
        }

        /// <summary>
        /// 保存验证单个实例
        /// </summary>
        /// <returns></returns>
        protected override bool SaveValidation()
        {
            if (string.IsNullOrEmpty(Entity.Name))
            {
                Msg = "模板名称不能为空";
                return false;
            }

            if(Entity.ZWPZLX==null)
            {
                Msg = "凭证类型不能为空";
                return false;
            }

            if(Entity.ZWZGZD==null)
            {
                Msg = "会计主管不能为空";
                return false;
            }

            if(Entity.VITDetails.Count==0)
            {
                Msg = "没有添加科目";
                return false;
            }

            return base.SaveValidation();
        }

        /// <summary>
        /// 设置凭证类型
        /// </summary>
        /// <param name="lx"></param>
        /// <returns></returns>
        public bool SetVoucherType(ZWPZLX lx)
        {
            if (lx == null || Entity == null) return false;
            try
            {
                Entity.ZWPZLX = CtxEntity.ZWPZLX.Single(t => t.ZWPZLX_LXBH == lx.ZWPZLX_LXBH);
                return true;
            }
            catch(Exception ex)
            {
                Msg = "凭证类型设置失败";
                Ex = ex;
                return false;
            }
        }
        /// <summary>
        /// 设置财务主管
        /// </summary>
        /// <param name="zg"></param>
        /// <returns></returns>
        public bool SetSupervisor(ZWZGZD zg)
        {
            if (zg == null || Entity == null) return false;
            try
            {
                Entity.ZWZGZD = CtxEntity.ZWZGZD.Single(t => t.ZWZGZD_ZGBH == zg.ZWZGZD_ZGBH);
                return true;
            }
            catch(Exception ex)
            {
                Msg = "财务主管设置失败";
                Ex = ex;
                return false;
            }
        }

        /// <summary>
        /// 更改借贷方向
        /// </summary>
        /// <param name="detail"></param>
        public void ChangeIsDebit(VITDetail detail)
        {
            detail.IsDebit = !detail.IsDebit;
            Entries.Refresh();
        }
    }
}
