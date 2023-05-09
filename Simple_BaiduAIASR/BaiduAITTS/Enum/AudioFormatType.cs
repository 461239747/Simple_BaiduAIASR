namespace BaiduAITTS
{
    /// <summary>
    /// 音频格式化信息
    /// 不区分大小写 推荐pcm文件
    /// 郑伟 2023-05-05
    /// </summary>
    public enum AudioFormatType
    {
        /// <summary>
        /// PCM格式文件
        /// </summary>
        Pcm = 0,
        /// <summary>
        /// Wav格式文件
        /// </summary>
        Wav = 1,
        /// <summary>
        /// Amr格式文件
        /// </summary>
        Amr = 2
    }
}
