using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class NormalEnum
    {
        /// <summary>
        /// 版本定义类
        /// </summary>
        public class VersionInfo
        {
            /// <summary>
            /// 当前版本号，只有版本升级才会变更
            /// </summary>
            public static readonly decimal Ver = 1.0M;

            /// <summary>
            /// 是否有二次开发
            /// </summary>
            public static readonly bool HasReDev = false;
        }
        /// <summary>
        /// 表的状态
        /// </summary>
        public enum EnumStatus
        {

            /// <summary>
            /// 正常
            /// </summary>
            Availabilit=1,
            /// <summary>
            /// 已删除
            /// </summary>
            HaveDeleted=2,
        }
        /// <summary>
        /// 审核状态
        /// </summary>
        public enum EnumAuitStatus
        {

            /// <summary>
            /// 未审核
            /// </summary>
            NotAuit = 0,
            /// <summary>
            /// 已审核审核
            /// </summary>
            AlreadyAuit = 1,
            /// <summary>
            /// 审核通过
            /// </summary>
            ThroughAuit = 2,
            /// <summary>
            /// 审核未通过
            /// </summary>
            FailedAudit = 4,


        }
        /// <summary>
        /// 出库状态
        /// </summary>
        public enum EnumOutIoStatus
        {

            /// <summary>
            /// 未出库
            /// </summary>
            Notout = 0,
            /// <summary>
            /// 部分出库
            /// </summary>
            PartOutIo = 1,
            /// <summary>
            /// 货全出
            /// </summary>
            AllOutIo = 2,
           


        }
    }
}
