using System;

namespace BaiduAITTS
{
    /// <summary>
    /// 识别结果
    /// 郑伟 2023-05-05
    /// </summary>
    public struct RecognitionResult
    {
        /// <summary>
        /// 错误码 
        /// 成功失败均返回
        /// 识别成功 0
        /// 其他 识别有误
        /// </summary>
        public Error_Code err_no;
        /// <summary>
        /// 异常消息
        /// 成功失败均返回
        /// </summary>
        public string err_msg;
        /// <summary>
        /// 识别集合号码
        /// </summary>
        public string corpus_no;
        /// <summary>
        /// 语音数据唯一标识，系统内部产生，用于 debug
        /// 成功返回值 失败返回NULL
        /// </summary>
        public string sn;
        /// <summary>
        /// 识别结果数组，提供多个候选结果，无论返回多少个请取第一个
        /// </summary>
        public string[] result;
        /// <summary>
        /// 产生结果的时间
        /// </summary>
        public DateTime ResultTime;
    }
}
