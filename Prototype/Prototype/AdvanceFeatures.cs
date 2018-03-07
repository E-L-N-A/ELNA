using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using VideoLibrary;
using MediaToolkit.Model;
using MediaToolkit;
using NAudio.Wave;
using System.Speech.Recognition;


namespace Prototype
{
    class AdvanceFeatures
    {
        // 用于单词列表的翻译
        public static void FileToFileTranslation(string SourceFilePath,string TargetFilePath,string from,string to)
        {
            string[] s = File.ReadAllLines(SourceFilePath);
            List<string> Words = new List<string>();
            string Filename = @"\NewVocabFile.txt";
            for (int i = 0; i < s.Length; i++)
            {
                string passvalue = Regex.Replace(s[i], @"[^a-zA-Z]+", " ").Trim(' ');
                foreach (string n in passvalue.Split(' '))
                {
                    Words.Add(n);
                }
            }
            string newstr = "";
            foreach(string w in Words)
            {
                 newstr = newstr += Translations.Google_Translate(w, from, to);
            }

            using (StreamWriter sw= File.CreateText(TargetFilePath + Filename))
            {
                sw.Write(newstr);
            }
        }
        // 用于句子的翻译
        public static void FileToFileTranslationVer2(string SourceFilePath, string TargetFilePath, string from, string to)
        {
            string s = File.ReadAllText(SourceFilePath);
            string Result = Translations.Google_Translate(s, from, to);
            using (StreamWriter sw = File.CreateText(TargetFilePath + @"\NewFile.txt"))
            {
                sw.Write(Result);
            }
            
        }
        // PDF文本提取
        public static void FileToFileTranslationPDF(string Sourcefile,string TargetfilePath,string from,string to)
        {
            
                string fp = Sourcefile;
                string empty = "";
                PdfReader pdr = new PdfReader(fp);
                for (int i = 1; i <= pdr.NumberOfPages; i++)
                {
                    ITextExtractionStrategy it = new LocationTextExtractionStrategy();
                    string s = PdfTextExtractor.GetTextFromPage(pdr, i, it);
                    s = Encoding.UTF8.GetString(ASCIIEncoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.Default.GetBytes(s)));
                    empty = empty + s;
                }
                pdr.Close();
                string translationResult = Translations.Google_Translate(empty, from, to);
                using (StreamWriter sw= File.CreateText(TargetfilePath+@"\NewPDF.txt"))
                {
                        sw.Write(translationResult);
                }

        }//mp3和wav文件格式的转换
        public static void MP3ToWAV(string input, string output)
        {
            using (Mp3FileReader m3r = new Mp3FileReader(input))
            {
                using (WaveStream wvs = WaveFormatConversionStream.CreatePcmStream(m3r))
                {
                    WaveFileWriter.CreateWaveFile(output, wvs);
                }
            }
        }

        //提取Youtube的视频和音频
        public static void YoutubeExtraction(string input, string output, byte[] Video)
        {


            File.WriteAllBytes(input, Video);
            MediaFile in_md = new MediaFile(input);
            MediaFile out_md = new MediaFile(output);
            using (Engine e = new Engine())
            {
                e.GetMetadata(in_md);
                e.Convert(in_md, out_md);
            }


        }

        //使用System.speech进行语音识别
        public static string Voice_Recognition(string path)
        {

            SpeechRecognitionEngine sre = new SpeechRecognitionEngine();
            Grammar gr = new DictationGrammar();
            sre.LoadGrammar(gr);
            sre.SetInputToWaveFile(path);
            sre.BabbleTimeout = new TimeSpan(Int32.MaxValue);
            sre.InitialSilenceTimeout = new TimeSpan(Int32.MaxValue);
            sre.EndSilenceTimeout = new TimeSpan(100000000);
            sre.EndSilenceTimeoutAmbiguous = new TimeSpan(100000000);

            StringBuilder sb = new StringBuilder();
            while (true)
            {
                try
                {
                    var recText = sre.Recognize();
                    if (recText == null)
                    {
                        break;
                    }

                    sb.Append(recText.Text);
                }
                catch (Exception)
                {

                    break;
                }
            }
            return sb.ToString();
        }
    }
}
