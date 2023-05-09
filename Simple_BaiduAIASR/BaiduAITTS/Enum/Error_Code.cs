namespace BaiduAITTS
{
    /// <summary>
    /// 语音识别错误码
    /// </summary>
    public enum Error_Code
    {
        /// <summary>
        /// 识别成功
        /// </summary>
        Success = 0,

        #region 自定义代码段 5000-5999
        /// <summary>
        /// 识别失败
        /// 数据为空
        /// </summary>
        DataEmpty = 5000,
        /// <summary>
        /// 识别失败
        /// 文件不存在
        /// </summary>
        FileNotExist = 5001,
        /// <summary>
        /// 识别失败
        /// 声道数设置异常
        /// </summary>
        ChannelsEmpty = 5002,
        #endregion

        /// <summary>
        /// 用户输入错误
        /// 输入参数不正确
        /// 请仔细核对文档及参照demo，核对输入参数
        /// </summary>
        InputParameterError = 3300,
        /// <summary>
        /// 用户输入错误
        /// 音频质量过差
        /// 请上传清晰的音频
        /// </summary>
        PoorAudioQuality = 3001,
        /// <summary>
        /// 用户输入错误
        /// 鉴权失败
        /// token字段校验失败。请使用正确的API_KEY 和 SECRET_KEY生成。或QPS、调用量超出限额。或音频采样率不正确（可尝试更换为16k采样率）
        /// </summary>
        AuthenticationFailed = 3302,
        /// <summary>
        /// 服务端问题
        /// 语音服务器后端问题
        /// 请将api返回结果反馈至论坛或者QQ群
        /// </summary>
        VoiceServerBackendIssues = 3303,
        /// <summary>
        /// 用户请求超限
        /// 用户的请求QPS超限
        /// 请降低识别api请求频率 （qps以appId计算，移动端如果共用则累计）
        /// </summary>
        UsersRequestQPSExceededLimit = 3304,
        /// <summary>
        /// 用户请求超限
        /// 用户的日pv（日请求量）超限
        /// 请“申请提高配额”，如果暂未通过，请降低日请求量
        /// </summary>
        UsersDailyPVExceedsTheLimit = 3305,
        /// <summary>
        /// 服务端问题
        /// 语音服务器后端识别出错问题
        /// 目前请确保16000的采样率音频时长低于30s。如果仍有问题，请将api返回结果反馈至论坛或者QQ群
        /// </summary>
        VoiceServerBackendRecognitionErrorIssue = 3307,
        /// <summary>
        /// 用户输入错误
        /// 音频过长
        /// 音频时长不超过60s，请将音频时长截取为60s以下
        /// </summary>
        AudioTooLong = 3308,
        /// <summary>
        /// 用户输入错误
        /// 音频数据问题
        /// 服务端无法将音频转为pcm格式，可能是长度问题，音频格式问题等。 请将输入的音频时长截取为60s以下，并核对下音频的编码，是否是16K， 16bits，单声道。
        /// </summary>
        AudioDataIssues = 3309,
        /// <summary>
        /// 用户输入错误
        /// 输入的音频文件过大
        /// 语音文件共有3种输入方式： json 里的speech 参数（base64后）； 直接post 二进制数据，及callback参数里url。 分别对应三种情况：json超过10M；直接post的语音文件超过10M；callback里回调url的音频文件超过10M
        /// </summary>
        TheInputAudioFileIsTooLarge = 3310,
        /// <summary>
        /// 用户输入错误 
        /// 采样率rate参数不在选项里
        /// 目前rate参数仅提供16000，填写4000即会有此错误
        /// </summary>
        TheSamplingRateParameterIsNotInTheOption = 3311,
        /// <summary>
        /// 用户输入错误
        /// 音频格式format参数不在选项里
        /// 目前格式仅仅支持pcm，wav或amr，如填写mp3即会有此错误
        /// </summary>
        TheAudioFormatParameterIsNotInTheOption = 3312,

        /// <summary>
        /// 服务端问题
        /// 语音服务器解析超时
        /// 请将api返回结果反馈至工单、论坛或者QQ群
        /// </summary>
        ParsingTimeout = 3313,

        /// <summary>
        /// 用户输入错误
        /// 音频长度过短
        /// 音频长度的len参数不能小于等于4
        /// </summary>
        AudioLengthTooShort = 3314,
        /// <summary>
        /// 服务端问题
        /// 语音服务器处理超时
        /// 请将api返回结果反馈至工单、论坛或者QQ群
        /// </summary>
        VoiceServerProcessingTimeout = 3315,
        /// <summary>
        /// 用户输入错误
        /// 音频转为pcm失败
        /// 使用pcm格式，或者确认wav和amr的采样率16000，单声道。 wav是否是pcm编码，小端序，16bits
        /// </summary>
        FailedToConvertToPCM = 3316,
    }
}
