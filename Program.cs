using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Drawing.Imaging;

namespace 分析
{

    using wordcloud = WordCloud.WordCloud;


    class Program
    {

       static Dictionary<string, int> hotnum = new Dictionary<string, int>();


        public static string Read(string filename,string c)
        {
            
            // 读取文件的源路径及其读取流
            string strReadFilePath = filename;
            StreamReader srReadFile = new StreamReader(strReadFilePath);
            ArrayList arrylist_2 = new ArrayList();
            // 读取流直至文件末尾结束
            while (!srReadFile.EndOfStream)
            {
       
               
                string strReadLine =  srReadFile.ReadLine(); //读取每行数据
                c = strReadLine + c;
                //Console.WriteLine(strReadLine); //屏幕打印每行数据
            }
           // Console.WriteLine(c);

            // 关闭读取流文件
            srReadFile.Close();
            return c;
          
        }


        /*
 			功能：
			C#统计文章中单词的重复次数，并且按照次数从高到低排序返回（无法处理中文）
			例子：
			i am a big boy,how a bout boy?   返回boy(2),i(1),....等。
 			命名空间为：
			using System.Collections.Generic;
 			using System.Linq;
		*/
     


        /*
 			功能：
			C#统计文章中单词的重复次数，并且按照次数从高到低排序返回（无法处理中文）
			例子：
			i am a big boy,how a bout boy?   返回boy(2),i(1),....等。
 			命名空间为：
			using System.Collections.Generic;
 			using System.Linq;
		*/
         static Dictionary<string, int> gethotstring(string content)
        {
            Dictionary<string, int> HOT = new Dictionary<string, int>();
            string[] s = content.Split(new char[] { ' ' });
            for (int i = 0; i < s.Length; i++)
            {
                if (HOT.ContainsKey(s[i]))
                {
                    HOT[s[i]]++; ;
                }
                else
                {
                    HOT[s[i]] = 1;
                }
            }

            return HOT.OrderByDescending(r => r.Value).ToDictionary(r => r.Key, r => r.Value);

        }





        /// <summary>
        /// 截取字符串中开始和结束字符串中间的字符串
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <param name="startStr">开始字符串</param>
        /// <param name="endStr">结束字符串</param>
        /// <returns>中间字符串</returns>
        public static string SubstringSingle(string source, string startStr, string endStr)
        {
            Regex rg = new Regex("(?<=(" + startStr + "))[.\\s\\S]*?(?=(" + endStr + "))", RegexOptions.Multiline | RegexOptions.Singleline);
            return rg.Match(source).Value;
        }

        /// <summary>
        /// （批量）截取字符串中开始和结束字符串中间的字符串
        /// </summary>
        /// <param name="source">源字符串</param>
        /// <param name="startStr">开始字符串</param>
        /// <param name="endStr">结束字符串</param>
        /// <returns>中间字符串</returns>
        public static List<string> SubstringMultiple(string source, string startStr, string endStr)
        {
            Regex rg = new Regex("(?<=(" + startStr + "))[.\\s\\S]*?(?=(" + endStr + "))", RegexOptions.Multiline | RegexOptions.Singleline);

            MatchCollection matches = rg.Matches(source);

            List<string> resList = new List<string>();

            foreach (Match item in matches)
                resList.Add(item.Value);

            return resList;
        }


        static public void WordCLD(List<string> wordc, List<int> fre,string filename)
        {
            wordcloud wc = new wordcloud(1000, 720);
            var ima = wc.Draw(wordc, fre);
            var newFilename = filename;
            ima.Save(newFilename, ImageFormat.Jpeg);
        }

        static void Ciyun(string filename,string c,string mubiaoname)
        {
            string a;
            a=Read(filename,c);
            List<string> wordc = new List<string>();
            List<int> fre = new List<int>();
            Dictionary<string, int> MEWHOT = gethotstring(a);

            string output = null;
            //遍历字典
            int size = 0;
            int i = 0;
            foreach (KeyValuePair<string, int> kvp in MEWHOT)
            {
                size++;

                if (size > 120)
                {
                    wordc.Add(kvp.Key);
                    fre.Add(i);

                    output += kvp.Key + "(" + kvp.Value.ToString() + ")";
                    output += "\r\n";
                }
               
                i++;
                if (size > 150) break;
            }
            //Console.WriteLine(output);

            WordCLD(wordc, fre,mubiaoname);


        }


        static void Ciyun_jidu(string filename, string c,string mubiaoname)
        {
            string a;
            a = Read(filename, c);
            List<string> wordc = new List<string>();
            List<int> fre = new List<int>();
            Dictionary<string, int> MEWHOT = gethotstring(a);

            string output = null;
            //遍历字典
            int size = 0;
            int i = 0;
            foreach (KeyValuePair<string, int> kvp in MEWHOT)
            {
                size++;

                if (size > 120)
                {
                    wordc.Add(kvp.Key);
                    fre.Add(i);

                    output += kvp.Key + "(" + kvp.Value.ToString() + ")";
                    output += "\r\n";
                }

                i++;
                if (size > 150) break;
            }
            Console.WriteLine(output);

            WordCLD(wordc, fre,mubiaoname);


        }

        static void Ciyun_year(string filename, string c,string mubiaoname)
        {
            string a;
            a = Read(filename, c);
            List<string> wordc = new List<string>();
            List<int> fre = new List<int>();
            Dictionary<string, int> MEWHOT = gethotstring(a);

            string output = null;
            //遍历字典
            int size = 0;
            int i = 0;
            foreach (KeyValuePair<string, int> kvp in MEWHOT)
            {
                size++;

                if (size > 120)
                {
                    wordc.Add(kvp.Key);
                    fre.Add(i);

                    output += kvp.Key + "(" + kvp.Value.ToString() + ")";
                    output += "\r\n";
                }

                i++;
                if (size > 150) break;
            }
            Console.WriteLine(output);

            WordCLD(wordc, fre,mubiaoname);


        }

        static void month()
        {
            DirectoryInfo folder = new DirectoryInfo(@"./[2020-12-25 07-47-19]StatPearls [Internet]");
            string mubiaoname;
            int i = 0;
            foreach (FileInfo file in folder.GetFiles("*.txt"))
            {
                string c = null;
                i++;
                mubiaoname = i + ".jpg";
                Ciyun(file.FullName, c, mubiaoname);
                Console.WriteLine("月度词云完成");
                //Console.WriteLine(file.FullName);
            }
        }

        static void jidu()
        {
            DirectoryInfo folder = new DirectoryInfo(@"./[2020-12-25 07-47-19]StatPearls [Internet]");
            string mubiaoname;
            int i = 1;
            string c = null;
            foreach (FileInfo file in folder.GetFiles("*.txt"))
            {
                if (i % 4 == 0)
                {
                    c = null;
                    mubiaoname = i / 4 + "_jidu" + ".jpg";
                    Ciyun(file.FullName, c, mubiaoname);
                }
                c = Read(file.FullName, c);
                i++;
                Console.WriteLine("季度词云完成");
                //Console.WriteLine(file.FullName);
            }
        }

        static void year()
        {
            DirectoryInfo folder = new DirectoryInfo(@"./[2020-12-25 07-47-19]StatPearls [Internet]");
            string mubiaoname;
            int i = 1;
            string c = null;
            foreach (FileInfo file in folder.GetFiles("*.txt"))
            {
                if (i % 12 == 0)
                {
                    c = null;
                    mubiaoname = i / 12 + "_niandu" + ".jpg";
                    Ciyun(file.FullName, c, mubiaoname);
                }
                c = Read(file.FullName, c);
                i++;
                Console.WriteLine("年度词云完成");
                //Console.WriteLine(file.FullName);
            }
        }


        public static void WriteByLine(string path, string DataLine)
        {
            FileStream fs = new FileStream(path, FileMode.Append);//创建文件流
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(DataLine);
            sw.Close();//关闭写入器
            fs.Close();//关闭文件流
        }




        static void guanzhudu(string path)
        {
            Random random = new Random();
            int[] array = new int[120];
            for (int i = 0; i < array.Length; i++)
            {
               
                array[i] = random.Next(60,150);
            }
            int t=0;
            for(int i=0;i<array.Length;i++)
            {
                t = t + array[i];

               // Console.WriteLine("第" + (i+1) + "个月:\r");
                WriteByLine(path, "第" + (i + 1) + "个月:");

               // Console.WriteLine(array[i].ToString());
                     WriteByLine(path, array[i].ToString());
                if ((i+1)%3==0)
                {

                    //Console.WriteLine("第" + (i/3+1) + "季度:\r");
                    WriteByLine(path, "第" + (i / 3 + 1) + "季度:");
                    //Console.WriteLine( t.ToString());
                    WriteByLine(path, t.ToString());
                }

                if((i+1)%12==0)
                {

                    //Console.WriteLine("第" + (i/12+1) + "年度:");
                    WriteByLine(path, "第" + (i / 12 + 1) + "年度:");
                   // Console.WriteLine( t.ToString());
                    WriteByLine(path, t.ToString());
                }
                   

            }
        }

        static void Main(string[] args)
        {
            /*string filename = @"H:/C#/分析/bin/Debug/netcoreapp3.1/[2020-12-24 16-28-44]Breast Cancer.txt";
            string c = null;
            Ciyun(filename, c);*/

            string path = @"./关注度.txt";




            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine("请输入功能序号，并生成词云图片和关注度txt文档\n");
            Console.WriteLine("1.生成月度词云和关注度文档\n");
            Console.WriteLine("2.生成季度词云和关注度文档\n");
            Console.WriteLine("3.生成年度词云和关注度文档\n");
            Console.WriteLine("其他数字键退出\n");
            Console.WriteLine("------------------------------------------------------------------");


            guanzhudu(path);



             int i = Convert.ToInt32(Console.ReadLine());
             switch (i)
             {
                 case 1:
                     month();
                     break;
                 case 2:
                     jidu();
                     break;
                 case 3:
                     year();
                     break;
                 default:
                     break;



             }













            /* foreach (string f in arrylist_3)
             {
                 /*keyValuePairs = gethotstring(f);
                 string output = null;
                 //遍历字典
                 int size = 0;
                 foreach (KeyValuePair<string, int> kvp in keyValuePairs)
                 {
                     size++;
                     if (size > 10) break;
                     output += kvp.Key + "(" + kvp.Value.ToString() + ")";
                     output += "\r\n";
                 }
                 Console.WriteLine(output);
                 Console.WriteLine(f);
             }
             Console.ReadKey();
             */







        }
    }
}
