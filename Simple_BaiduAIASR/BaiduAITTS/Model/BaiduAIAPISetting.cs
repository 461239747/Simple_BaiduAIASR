namespace BaiduAITTS
{
    /// <summary>
    /// 百度AI接口设置
    /// 郑伟 2023-05-05
    /// </summary>
    public struct BaiduAIAPISetting
    {
        /// <summary>
        /// 语音二进制数据
        /// </summary>
        public byte[] data;
        /// <summary>
        /// 语音文件的格式
        /// </summary>
        public AudioFormatType format;
        /// <summary>
        /// 音频采样率
        /// </summary>
        public APIAudioRate rate;
        /// <summary>
        /// 用户唯一标识，用来区分用户，填写机器 MAC 地址或 IMEI 码，长度为60以内
        /// </summary>
        public string cuid;
        /// <summary>
        /// dev_pid 必须为整数类型
        /// </summary>
        public APILanguageType dev_pid;
        /// <summary>
        /// 声道数量
        /// </summary>
        public int channels;
        /// <summary>
        /// [已废弃] 历史兼容参数，请使用dev_pid
        /// 如果dev_pid填写，该参数会被覆盖
        /// 语种选择,输入法模型，默认中文（zh）
        /// 中文=zh、粤语=ct、英文=en，不区分大小写
        /// </summary>
        private string lan;

        /// <summary>
        /// API网络调用使用参数 APP_ID
        /// </summary>
        public string APP_ID;
        /// <summary>
        /// API网络调用使用参数 API_KEY
        /// </summary>
        public string API_KEY;
        /// <summary>
        /// API网络调用使用参数 SECRET_KEY
        /// </summary>
        public string SECRET_KEY;
    }
}
