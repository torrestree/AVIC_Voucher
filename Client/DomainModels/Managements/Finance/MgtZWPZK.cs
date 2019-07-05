using Client.DomainModels.Managements.Base.Abstracts;
using Client.Helpers;
using Client.Models.EF.Context;
using Client.Models.EF.Finance;
using Client.Models.Statics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.DomainModels.Managements.Finance
{
    /// <summary>
    /// 凭证管理器
    /// </summary>
    public class MgtZWPZK : MgtEFList<CtxRuntime, ZWPZK>
    {
        /// <summary>
        /// 导入数据缓存
        /// </summary>
        public DataTable ImportBuffer { get; set; }

        /// <summary>
        /// 设置字段名称
        /// </summary>
        protected override void SetPropertyNames()
        {
            PropertyKey = "ZWPZK_PZNM";
        }
        /// <summary>
        /// 设置读取实例集合规则
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        protected override bool SetReadContentsRule(ZWPZK entity, string value)
        {
            Msg = MsgNullMethod;
            return false;
        }
        /// <summary>
        /// 设置搜索规则
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        protected override bool SetSearchRule(ZWPZK obj)
        {
            return obj.ZWPZK_PZBH.NoCaseContains(SearchValue) || obj.ZWPZK_ZDR.NoCaseContains(SearchValue);
        }

        /// <summary>
        /// 保存单个实例
        /// </summary>
        /// <returns></returns>
        public override bool SaveEntity()
        {
            if (!SetEntityID()) return false;
            return SaveEntityFrame();
        }
        /// <summary>
        /// 设置主键信息
        /// </summary>
        /// <returns></returns>
        private bool SetEntityID()
        {
            Entity.ZWPZK_PZNM = MgtLSNBBM.GetNBBM("ZWPZNM", false);
            Entity.ZWPZK_PZBH = MgtLSNBBM.GetZWPZBH(Entity.ZWPZLX);
            if (string.IsNullOrEmpty(Entity.ZWPZK_PZBH))
            {
                Msg = ("没有可用的会计期间或数据库连接异常");
                return false;
            }

            int num = 1;
            int num2 = 1;
            foreach (ZWPZFL fl in Entity.ListZWPZFL)
            {
                fl.ZWPZFL_FLNM = MgtLSNBBM.GetNBBM("ZWFLNM", false);
                fl.ZWPZFL_FLBH = num.ToString("0000");
                num++;
                foreach (ZWFZYS ys in fl.ListZWFZYS)
                {
                    ys.ZWFZYS_YSBH = num2.ToString("0000");
                    ys.ZWFZYS_YT = fl.ZWPZFL_ZY;

                    num2++;
                }
            }

            return true;
        }
        /// <summary>
        /// 保存验证单个实例
        /// </summary>
        /// <returns></returns>
        protected override bool SaveValidation()
        {
            foreach (ZWPZFL item in Entity.ListZWPZFL)
            {
                if (string.IsNullOrEmpty(item.ZWPZFL_ZY))
                {
                    Msg = ("请补全摘要");
                    return false;
                }
            }

            double num = Math.Round((from t in Entity.ListZWPZFL
                                     where t.ZWPZFL_JZFX == "1"
                                     select t).Sum((ZWPZFL t) => t.ZWPZFL_JE), 2);
            double num2 = Math.Round((from t in Entity.ListZWPZFL
                                      where t.ZWPZFL_JZFX == "2"
                                      select t).Sum((ZWPZFL t) => t.ZWPZFL_JE), 2);
            if (num != num2)
            {
                Msg = ("借贷两方金额总计不等");
            }

            return true;
        }

        /// <summary>
        /// 从剪切板读取Excel
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public DataTable ReadFromClipboard(string data)
        {
            return DHelper.ReadFromClipboard(data);
        }
        /// <summary>
        /// 导入
        /// </summary>
        /// <param name="vit"></param>
        /// <returns></returns>
        public bool Import(VIT vit)
        {
            if (vit == null)
            {
                Msg = "没有选择可用的导入模板";
                return false;
            }

            try
            {
                IniPZK(vit);
                foreach (VITDetail vITDetail in vit.VITDetails)
                {
                    ZWPZFL zWPZFL = new ZWPZFL();
                    base.Entity.ListZWPZFL.Add(zWPZFL);
                    IniPZFL(zWPZFL, vITDetail);
                }
                return true;
            }
            catch (Exception ex)
            {
                Msg = "导入失败";
                Ex = ex;
                return false;
            }
        }
        /// <summary>
        /// 表头赋值
        /// </summary>
        /// <param name="vit"></param>
        private void IniPZK(VIT vit)
        {
            base.Entity.ZWPZK_KJND = LoginInfo.LoginDate.Year.ToString();
            base.Entity.ZWPZK_KJQJ = LoginInfo.LoginDate.Month.ToString("00");
            base.Entity.ZWPZK_PZRQ = DHelper.ConverToDateString(LoginInfo.LoginDate);
            base.Entity.ZWPZLX = CtxEntity.ZWPZLX.Single((ZWPZLX t) => t.ZWPZLX_LXBH == vit.VoucherType);
            base.Entity.ZWPZK_ZDR = LoginInfo.LoginName;
            base.Entity.ZWPZK_KJZG = vit.Supervisor;
            base.Entity.ZWPZK_FJZS = 0;
            base.Entity.ZWPZK_FHF = "0";
            base.Entity.ZWPZK_JZF = "0";
            base.Entity.ZWPZK_WZF = "1";
            base.Entity.ZWPZK_ZFF = "0";
            base.Entity.ZWPZK_XJDQ = "0";
            base.Entity.ZWPZK_WBBM = string.Empty;
            base.Entity.ZWPZK_WBZJ = string.Empty;
            base.Entity.ZWPZK_WBPZ = string.Empty;
            base.Entity.ZWPZK_CWBZ = "0";
            base.Entity.ZWPZK_CWXX = " ";
        }
        /// <summary>
        /// 分录赋值
        /// </summary>
        /// <param name="pzfl"></param>
        /// <param name="detail"></param>
        private void IniPZFL(ZWPZFL pzfl, VITDetail detail)
        {
            pzfl.ZWKMZD = base.CtxEntity.ZWKMZD.Single((ZWKMZD t) => t.ZWKMZD_KMBH == detail.AccountID);
            pzfl.ZWPZFL_JE = Math.Round(ImportBuffer.AsEnumerable().Sum((DataRow t) => ConvertValue(t.Field<string>($"Column{detail.Total}"))), 2);
            if (detail.IsDebit)
            {
                pzfl.ZWPZFL_JZFX = "1";
            }
            else
            {
                pzfl.ZWPZFL_JZFX = "2";
            }
            pzfl.ZWPZFL_YWRQ = Entity.ZWPZK_PZRQ;
            if (detail.IsAD || detail.IsAP)
            {
                DataRow[] array = ImportBuffer.Select($"Column{detail.Total} is not null and Column{detail.Total} <> ''");
                foreach (DataRow row in array)
                {
                    ZWFZYS ys = new ZWFZYS();
                    pzfl.ListZWFZYS.Add(ys);
                    IniFZYS(ys, detail, row);
                    ys.ZWFZYS_YWRQ = pzfl.ZWPZFL_YWRQ;
                }
            }
            pzfl.ZWPZFL_SL = pzfl.ListZWFZYS.Sum((ZWFZYS t) => t.ZWFZYS_SL);
            if (pzfl.ZWPZFL_SL != 0.0)
            {
                pzfl.ZWPZFL_DJ = Math.Round(pzfl.ZWPZFL_JE / pzfl.ZWPZFL_SL, 2);
            }
            pzfl.ZWPZFL_TZXM = string.Empty;
            pzfl.ZWPZFL_JSFS = string.Empty;
            pzfl.ZWPZFL_ZY = string.Empty;
            pzfl.ZWPZFL_WB = 0.0;
            pzfl.ZWPZFL_HL = 0.0;
            pzfl.ZWPZFL_JSH = string.Empty;
            pzfl.ZWPZFL_WBBH = string.Empty;
            pzfl.ZWPZFL_YHDZ = "0";
        }
        /// <summary>
        /// 辅助赋值
        /// </summary>
        /// <param name="fzys"></param>
        /// <param name="detail"></param>
        /// <param name="row"></param>
        private void IniFZYS(ZWFZYS fzys, VITDetail detail, DataRow row)
        {
            fzys.ZWKMZD = CtxEntity.ZWKMZD.Single((ZWKMZD t) => t.ZWKMZD_KMBH == detail.AccountID);
            if (detail.IsAD)
            {
                string bmbh = row[detail.ADIndex.Value - 1].ToString();
                fzys.LSBMZD = CtxEntity.LSBMZD.Single((LSBMZD t) => t.LSBMZD_BMBH == bmbh);
            }
            if (detail.IsAP)
            {
                string xmbh = row[detail.APIndex.Value - 1].ToString();
                string lbbh = row[detail.APCatIndex.Value - 1].ToString();
                if (string.IsNullOrEmpty(lbbh))
                    fzys.XM01 = CtxEntity.ZWHSXM.Single((ZWHSXM t) => t.ZWHSXM_XMBH == xmbh);
                else
                    fzys.XM01 = CtxEntity.ZWHSXM.Single((ZWHSXM t) => t.ZWHSXM_XMBH == xmbh && t.ZWHSXM_LBBH == lbbh);
            }
            if (detail.IsDebit)
            {
                fzys.ZWFZYS_JZFX = "1";
            }
            else
            {
                fzys.ZWFZYS_JZFX = "2";
            }
            if (detail.Quantity.HasValue)
            {
                try
                {
                    fzys.ZWFZYS_SL = Math.Round(double.Parse(row[detail.Quantity.Value - 1].ToString()), 4);
                }
                catch
                {
                    fzys.ZWFZYS_SL = 0.0;
                }
            }
            else
            {
                fzys.ZWFZYS_SL = 0.0;
            }
            if (detail.Price.HasValue)
            {
                try
                {
                    fzys.ZWFZYS_DJ = Math.Round(double.Parse(row[detail.Price.Value - 1].ToString()), 2);
                }
                catch
                {
                    fzys.ZWFZYS_DJ = 0.0;
                }
            }
            else
            {
                fzys.ZWFZYS_DJ = 0.0;
            }
            try
            {
                fzys.ZWFZYS_JE = Math.Round(double.Parse(row[detail.Total - 1].ToString()), 2);
            }
            catch
            {
                fzys.ZWFZYS_JE = 0.0;
            }
            fzys.ZWFZYS_DWBH = string.Empty;
            fzys.ZWFZYS_ZGBH = string.Empty;
            fzys.ZWFZYS_XM02 = string.Empty;
            fzys.ZWFZYS_XM03 = string.Empty;
            fzys.ZWFZYS_XM04 = string.Empty;
            fzys.ZWFZYS_XM05 = string.Empty;
            fzys.ZWFZYS_WBBH = string.Empty;
            fzys.ZWFZYS_WB = 0.0;
            fzys.ZWFZYS_HL = 0.0;
            fzys.ZWFZYS_YWH = string.Empty;
            fzys.ZWFZYS_ZRR = string.Empty;
            fzys.ZWFZYS_PJH = string.Empty;
            fzys.ZWFZYS_DWDZ = "0";
            fzys.ZWFZYS_SJ01 = 0.0;
            fzys.ZWFZYS_SJ02 = 0.0;
            fzys.ZWFZYS_SJ03 = 0.0;
            fzys.ZWFZYS_SJ04 = 0.0;
            fzys.ZWFZYS_SJ05 = 0.0;
            fzys.ZWFZYS_SJ06 = 0.0;
            fzys.ZWFZYS_SJ07 = 0.0;
            fzys.ZWFZYS_SJ08 = 0.0;
            fzys.ZWFZYS_SJ09 = 0.0;
            fzys.ZWFZYS_SJ10 = 0.0;
            fzys.ZWFZYS_SJ11 = 0.0;
            fzys.ZWFZYS_SJ12 = 0.0;
            fzys.ZWFZYS_SJ13 = 0.0;
            fzys.ZWFZYS_SJ14 = 0.0;
            fzys.ZWFZYS_SJ15 = 0.0;
            fzys.ZWFZYS_SJ16 = 0.0;
            fzys.ZWFZYS_SJ17 = 0.0;
            fzys.ZWFZYS_SJ18 = 0.0;
            fzys.ZWFZYS_SJ19 = 0.0;
            fzys.ZWFZYS_SJ20 = 0.0;
            fzys.ZWFZYS_SM01 = string.Empty;
            fzys.ZWFZYS_SM02 = string.Empty;
            fzys.ZWFZYS_SM03 = string.Empty;
            fzys.ZWFZYS_SM04 = string.Empty;
            fzys.ZWFZYS_SM05 = string.Empty;
            fzys.ZWFZYS_SM06 = string.Empty;
            fzys.ZWFZYS_SM07 = string.Empty;
            fzys.ZWFZYS_SM08 = string.Empty;
            fzys.ZWFZYS_SM09 = string.Empty;
            fzys.ZWFZYS_SM10 = string.Empty;
            fzys.ZWFZYS_SM11 = string.Empty;
            fzys.ZWFZYS_SM12 = string.Empty;
            fzys.ZWFZYS_SM13 = string.Empty;
            fzys.ZWFZYS_SM14 = string.Empty;
            fzys.ZWFZYS_SM15 = string.Empty;
            fzys.ZWFZYS_SM16 = string.Empty;
            fzys.ZWFZYS_SM17 = string.Empty;
            fzys.ZWFZYS_SM18 = string.Empty;
            fzys.ZWFZYS_SM19 = string.Empty;
            fzys.ZWFZYS_SM20 = string.Empty;
            fzys.ZWFZYS_SM21 = string.Empty;
            fzys.ZWFZYS_SM22 = string.Empty;
            fzys.ZWFZYS_SM23 = string.Empty;
            fzys.ZWFZYS_SM24 = string.Empty;
            fzys.ZWFZYS_SM25 = string.Empty;
            fzys.ZWFZYS_SM26 = string.Empty;
            fzys.ZWFZYS_SM27 = string.Empty;
            fzys.ZWFZYS_SM28 = string.Empty;
            fzys.ZWFZYS_SM29 = string.Empty;
            fzys.ZWFZYS_SM30 = string.Empty;
            fzys.ZWFZYS_JSFS = string.Empty;
            fzys.ZWFZYS_JSH = string.Empty;
            fzys.ZWFZYS_YT = "1";
            fzys.ZWFZYS_ZGDZ = "0";
            fzys.ZWFZYS_YHDZ = "0";
        }
        /// <summary>
        /// 值转换
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private double ConvertValue(string value)
        {
            double.TryParse(value, out double result);
            return result;
        }

        /// <summary>
        /// 重新合计
        /// </summary>
        /// <param name="pzfl"></param>
        public void ReCalculate(ZWPZFL pzfl)
        {
            if (pzfl != null)
            {
                pzfl.ZWPZFL_JE = pzfl.ListZWFZYS.Sum((ZWFZYS t) => t.ZWFZYS_JE);
            }
        }
    }
}
