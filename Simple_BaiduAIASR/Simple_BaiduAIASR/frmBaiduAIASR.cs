using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AudioUnit.SoundRecord;

using BaiduAITTS;

namespace Simple_BaiduAIASR
{
    public partial class frmBaiduAIASR : Form
    {
        public frmBaiduAIASR()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 鼠标按下 开始录音
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            string sPath = $"{Application.StartupPath}/audio/{DateTime.Now.ToString("yyyyMMdd")}/";
            if (!Directory.Exists(sPath))
            {
                Directory.CreateDirectory(sPath);
            }
            string fileName = $"{DateTime.Now.ToString("yyyyMMdd-HHmmss")}.wav";

            Recorder.StartRecord(sPath + fileName);
        }

        /// <summary>
        /// 鼠标抬起 结束录音
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            string filePath = Recorder.StopRecord();
            txtfilePath.Text = filePath;

            BaiduAIAPISetting baiduAIAPISetting = BaiduTTS.GetDefaultSetting();
            //请在开通服务后将对应的参数填在这里
            baiduAIAPISetting.APP_ID = "";
            baiduAIAPISetting.API_KEY = "";
            baiduAIAPISetting.SECRET_KEY = "";
            baiduAIAPISetting.cuid = "";//识别记录名

            RecognitionResult recognitionResult = BaiduTTS.TTSIdentifyCustomAPP_ID(baiduAIAPISetting, filePath);
            txtResult.Text = "时间:" + recognitionResult.ResultTime + Environment.NewLine + "错误码:" + recognitionResult.err_no + Environment.NewLine +
            "错误描述:" + recognitionResult.err_msg + Environment.NewLine + "集合码:" + (recognitionResult.corpus_no ?? "") + Environment.NewLine + "语音标识:" + recognitionResult.sn + Environment.NewLine;
            if (recognitionResult.result != null)
            {
                for (int i = 0; i < recognitionResult.result.Length; i++)
                {
                    txtResult.Text += "识别结果" + (i + 1).ToString() + ":" + (recognitionResult.result == null ? string.Empty : recognitionResult.result[i]) + Environment.NewLine;
                }
            }
        }
    }
}
