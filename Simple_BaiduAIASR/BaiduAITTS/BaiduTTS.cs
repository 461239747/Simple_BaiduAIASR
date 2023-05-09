using System;
using System.Collections.Generic;
using System.IO;

using Baidu.Aip.Speech;

using Newtonsoft.Json.Linq;

namespace BaiduAITTS
{
    /// <summary>
    /// 百度TTS语音识别
    /// 开通网站:https://console.bce.baidu.com/ai/?fromai=1#/ai/speech/overview/index 
    /// </summary>
    public static class BaiduTTS
    {
        #region 设置
        /// <summary>
        /// 语音识别超时时间 (单位:毫秒)
        /// </summary>
        public static int TimeoutMillisecond = 12000;
        #endregion

        /// <summary>
        /// 自定义语音识别 
        /// </summary>
        /// <param name="baiduAIAPISetting">音频识别设置</param>
        /// <returns></returns>
        public static RecognitionResult TTSIdentify(BaiduAIAPISetting baiduAIAPISetting)
        {
            RecognitionResult recognitionResult = new RecognitionResult();
            if (baiduAIAPISetting.channels == 0)
            {
                recognitionResult.err_no = Error_Code.ChannelsEmpty;
                recognitionResult.err_msg = "声道数量设置错误";
                recognitionResult.ResultTime = DateTime.Now;
            }
            else if (baiduAIAPISetting.data == null || baiduAIAPISetting.data.Length == 0)
            {
                recognitionResult.err_no = Error_Code.DataEmpty;
                recognitionResult.err_msg = "识别数据不可为空";
                recognitionResult.ResultTime = DateTime.Now;
            }
            else
            {
                Asr TTSClient = new Asr(baiduAIAPISetting.APP_ID, baiduAIAPISetting.API_KEY, baiduAIAPISetting.SECRET_KEY);
                TTSClient.Timeout = TimeoutMillisecond;  // 修改超时时间
                JObject result = TTSRecognize(TTSClient, baiduAIAPISetting.data, baiduAIAPISetting.format.ToString(), (int)baiduAIAPISetting.rate, (int)baiduAIAPISetting.dev_pid);
                recognitionResult = result.ToObject<RecognitionResult>();
                recognitionResult.ResultTime = DateTime.Now;
            }
            return recognitionResult;
        }

        /// <summary>
        /// 语音路径语音识别 (默认账号:孟凯)
        /// </summary>
        /// <param name="audioFilePath">音频文件路径</param>
        /// <returns></returns>
        public static RecognitionResult TTSIdentify(string audioFilePath)
        {
            RecognitionResult recognitionResult = new RecognitionResult();

            byte[] data = File.ReadAllBytes(audioFilePath);
            if (!File.Exists(audioFilePath))
            {
                recognitionResult.err_no = Error_Code.FileNotExist;
                recognitionResult.err_msg = "文件不存在";
                recognitionResult.ResultTime = DateTime.Now;
            }
            else
            {
                BaiduAIAPISetting baiduAIAPISetting = GetDefaultSetting();
                baiduAIAPISetting.data = data;

                Asr TTSClient = new Asr(baiduAIAPISetting.APP_ID, baiduAIAPISetting.API_KEY, baiduAIAPISetting.SECRET_KEY);
                TTSClient.Timeout = TimeoutMillisecond;  // 修改超时时间
                JObject result = TTSRecognize(TTSClient, baiduAIAPISetting.data, baiduAIAPISetting.format.ToString(), (int)baiduAIAPISetting.rate, (int)baiduAIAPISetting.dev_pid);
                recognitionResult = result.ToObject<RecognitionResult>();
                recognitionResult.ResultTime = DateTime.Now;
            }
            return recognitionResult;
        }

        /// <summary>
        /// 自定义语音识别 
        /// </summary>
        /// <param name="baiduAIAPISetting">音频识别设置</param>
        /// <param name="audioFilePath">音频文件路径</param>
        /// <returns></returns>
        public static RecognitionResult TTSIdentifyCustomAPP_ID(BaiduAIAPISetting baiduAIAPISetting, string audioFilePath)
        {
            RecognitionResult recognitionResult = new RecognitionResult();

            if (baiduAIAPISetting.channels == 0)
            {
                recognitionResult.err_no = Error_Code.ChannelsEmpty;
                recognitionResult.err_msg = "声道数量设置错误";
                recognitionResult.ResultTime = DateTime.Now;
            }
            else if (!File.Exists(audioFilePath))
            {
                recognitionResult.err_no = Error_Code.FileNotExist;
                recognitionResult.err_msg = "文件不存在";
                recognitionResult.ResultTime = DateTime.Now;
            }
            else
            {
                byte[] data = File.ReadAllBytes(audioFilePath);
                if (data.Length == 0)
                {
                    recognitionResult.err_no = Error_Code.DataEmpty;
                    recognitionResult.err_msg = "识别数据不可为空";
                    recognitionResult.ResultTime = DateTime.Now;
                }
                else
                {
                    baiduAIAPISetting.data = data;
                    Asr TTSClient = new Asr(baiduAIAPISetting.APP_ID, baiduAIAPISetting.API_KEY, baiduAIAPISetting.SECRET_KEY);
                    TTSClient.Timeout = TimeoutMillisecond;  // 修改超时时间
                    JObject result = TTSRecognize(TTSClient, baiduAIAPISetting.data, baiduAIAPISetting.format.ToString(), (int)baiduAIAPISetting.rate, (int)baiduAIAPISetting.dev_pid);
                    recognitionResult = result.ToObject<RecognitionResult>();
                    recognitionResult.ResultTime = DateTime.Now;
                }
            }
            return recognitionResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="TTSClient"></param>
        /// <param name="data"></param>
        /// <param name="format"></param>
        /// <param name="rate"></param>
        /// <param name="dev_pid"></param>
        /// <returns></returns>
        private static JObject TTSRecognize(Asr TTSClient, byte[] data, string format, int rate, int dev_pid)
        {
            Dictionary<string, object> options = new Dictionary<string, object>
             {
                {"dev_pid", 1537}
             };
            return TTSClient.Recognize(data, format, rate, options);
        }

        /// <summary>
        /// 获得默认设置
        /// </summary>
        /// <returns></returns>
        public static BaiduAIAPISetting GetDefaultSetting()
        {
            BaiduAIAPISetting baiduAIAPISetting = new BaiduAIAPISetting();
            baiduAIAPISetting.format = AudioFormatType.Pcm;
            baiduAIAPISetting.rate = APIAudioRate.Rate_16000;
            baiduAIAPISetting.dev_pid = APILanguageType.Mandarin;
            baiduAIAPISetting.channels = 1;
            baiduAIAPISetting.cuid = "默认";

            //baiduAIAPISetting.APP_ID = "";
            //baiduAIAPISetting.API_KEY = "";
            //baiduAIAPISetting.SECRET_KEY = "";
            return baiduAIAPISetting;
        }
    }
}