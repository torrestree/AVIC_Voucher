using Client.Helpers;
using Client.Models.EF.BasicInfo;
using Client.Models.EF.Context;
using Client.Models.EF.Finance;
using Client.Models.Statics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.DomainModels.Managements.Finance
{
    /// <summary>
    /// 主键编码管理器
    /// </summary>
    public static class MgtLSNBBM
    {
        /// <summary>
        /// 获得主键编码
        /// </summary>
        /// <param name="nmbh"></param>
        /// <param name="current"></param>
        /// <returns></returns>
        public static string GetNBBM(string nmbh, bool current)
        {
            string text2;
            using (CtxRuntime ctxBase = new CtxRuntime())
            {
                LSNBBM bm = ctxBase.LSNBBM.Single((LSNBBM t) => t.LSNBBM_NMBH == nmbh);
                if (!current)
                {
                    text2 = (bm.LSNBBM_DQNM = (int.Parse(bm.LSNBBM_DQNM) + 1).ToString());
                }
                else
                {
                    text2 = bm.LSNBBM_DQNM;
                    bm.LSNBBM_DQNM = (int.Parse(text2) + 1).ToString();
                }
                ctxBase.SaveChanges();
            }
            return text2;
        }

        /// <summary>
        /// 获得凭证编号
        /// </summary>
        /// <param name="pzlx"></param>
        /// <returns></returns>
        public static string GetZWPZBH(ZWPZLX pzlx)
        {
            using (CtxRuntime ctxBase = new CtxRuntime())
            {
                string year = LoginInfo.LoginDate.Year.ToString();
                string month = LoginInfo.LoginDate.Month.ToString("00");
                ZWPZBH zWPZBH = (from t in ctxBase.ZWPZBH
                                 where t.ZWPZBH_KJND == year
                                 where t.ZWPZBH_KJQJ == month
                                 where t.ZWPZBH_PZZ == pzlx.ZWPZLX_PZZ
                                 select t).SingleOrDefault();
                if (zWPZBH != null)
                {
                    string result = $"{pzlx.ZWPZLX_PZZ}{zWPZBH.ZWPZBH_PZBH}";
                    zWPZBH.ZWPZBH_PZBH = (int.Parse(zWPZBH.ZWPZBH_PZBH) + 1).ToString("0000");
                    zWPZBH.ZWPZBH_PZRQ = DHelper.ConverToDateString(LoginInfo.LoginDate);
                    try
                    {
                        ctxBase.SaveChanges();
                        return result;
                    }
                    catch
                    {
                        return null;
                    }
                }
                return null;
            }
        }
    }
}
